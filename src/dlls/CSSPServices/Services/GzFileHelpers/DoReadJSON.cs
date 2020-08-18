/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class GzFileService : ControllerBase, IGzFileService
    {
        private async Task<ActionResult<T>> DoReadJSON<T>(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            bool gzExistLocaly = false;
            bool gzExist = false;
            bool gzLocalIsUpToDate = false;

            if ((await LoggedInService.GetLoggedInContactInfo()).LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            string fileName = await GetFileName(webType, TVItemID, webTypeYear);

            FileInfo fiGZ = new FileInfo(LocalJSONPath + string.Format(fileName, TVItemID));

            if (fiGZ.Exists)
            {
                gzExistLocaly = true;
            }

            if (LoggedInService.HasInternetConnection)
            {
                BlobClient blobClient = new BlobClient(AzureCSSPStorageConnectionString, AzureCSSPStorageCSSPJSON, fileName);
                BlobProperties blobProperties = null;

                try
                {
                    blobProperties = blobClient.GetProperties();

                }
                catch (RequestFailedException ex)
                {
                    if (ex.Status == 404)
                    {
                        var actionRes = await CreateGzFile(webType, TVItemID, webTypeYear);

                        if (((ObjectResult)actionRes.Result).StatusCode != 200)
                        {
                            return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.CouldNotCreateFile_OnAzure, fiGZ.Name)));
                        }

                        if ((bool)((OkObjectResult)actionRes.Result).Value)
                        {
                            gzExist = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.UnmanagedServerError_, ex.Message)));
                }

                if (blobProperties == null)
                {
                    try
                    {
                        blobProperties = blobClient.GetProperties();
                    }
                    catch (Exception ex)
                    {
                        return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.UnmanagedServerError_, ex.Message)));
                    }
                }

                if (gzExistLocaly)
                {
                    CSSPFile csspFile = null;

                    var actionCSSPFile = await CSSPFileService.GetWithAzureStorageAndAzureFileName(AzureCSSPStorageCSSPJSON, fiGZ.Name);
                    if (((ObjectResult)actionCSSPFile.Result).StatusCode == 200)
                    {
                        csspFile = (CSSPFile)((OkObjectResult)actionCSSPFile.Result).Value;
                    }

                    if (csspFile == null || blobProperties.ETag.Equals(csspFile.AzureETag))
                    {
                        gzLocalIsUpToDate = true;
                    }
                }

                if (!gzLocalIsUpToDate)
                {
                    var actionRes = await DownloadGzFile(webType, TVItemID, webTypeYear);

                    if (((ObjectResult)actionRes.Result).StatusCode != 200)
                    {
                        return await Task.FromResult(actionRes.Result);
                    }
                }
            }

            using (FileStream gzipFileStream = fiGZ.OpenRead())
            {
                using (GZipStream gzStream = new GZipStream(gzipFileStream, CompressionMode.Decompress))
                {
                    using (StreamReader sr = new StreamReader(gzStream))
                    {
                        return await Task.FromResult(Ok(JsonSerializer.Deserialize<T>(sr.ReadToEnd())));
                    }
                }
            }
        }
    }
}
