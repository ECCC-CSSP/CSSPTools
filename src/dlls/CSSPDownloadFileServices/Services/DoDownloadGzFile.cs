/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using CSSPCultureServices.Resources;
using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace DownloadFileServices
{
    public partial class DownloadFileService : ControllerBase, IDownloadFileService
    {
        private async Task<ActionResult<bool>> DoDownloadGzFile(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID, webTypeYear);

            if (LocalService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            try
            {
                BlobClient blobClient = new BlobClient(AzureStoreConnectionString, AzureStoreCSSPJSONPath, FileName);

                Response response = blobClient.DownloadTo($"{ CSSPJSONPath }{ FileName }");
                if (response.Status == 206)
                {
                    CSSPFile csspFile = null;

                    var actionCSSPFile = await CSSPDBFilesManagementService.GetWithAzureStorageAndAzureFileName(AzureStoreCSSPJSONPath, FileName);
                    if (((ObjectResult)actionCSSPFile.Result).StatusCode == 400)
                    {
                        int NextIndex = -1;
                        var actionInt = await CSSPDBFilesManagementService.GetCSSPFileNextIndexToUse();
                        if (((ObjectResult)actionInt.Result).StatusCode == 200)
                        {
                            NextIndex = (int)((OkObjectResult)actionInt.Result).Value;
                        }

                        csspFile = new CSSPFile()
                        {
                            CSSPFileID = NextIndex,
                            AzureStorage = AzureStoreCSSPJSONPath,
                            AzureFileName = FileName,
                            AzureETag = response.Headers.ETag.ToString(),
                            AzureCreationTimeUTC = DateTime.Parse(response.Headers.Date.ToString()),
                        };

                        var actionCSSPFileAdded = await CSSPDBFilesManagementService.Post(csspFile);
                        if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 200)
                        {
                            csspFile = (CSSPFile)((OkObjectResult)actionCSSPFileAdded.Result).Value;
                        }
                        else if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 401)
                        {
                            return await Task.FromResult(Unauthorized());
                        }
                        else
                        {
                            return await Task.FromResult((BadRequestObjectResult)actionCSSPFileAdded.Result);
                        }
                    }
                    else 
                    {
                        if (((OkObjectResult)actionCSSPFile.Result).StatusCode == 200)
                        {
                            csspFile = (CSSPFile)((OkObjectResult)actionCSSPFile.Result).Value;

                            csspFile.AzureETag = response.Headers.ETag.ToString();
                            csspFile.AzureCreationTimeUTC = DateTime.Parse(response.Headers.Date.ToString());

                            var actionCSSPFilePut = await CSSPDBFilesManagementService.Put(csspFile);
                            if (((ObjectResult)actionCSSPFilePut.Result).StatusCode == 200)
                            {
                                csspFile = (CSSPFile)((OkObjectResult)actionCSSPFilePut.Result).Value;
                            }
                            else if (((ObjectResult)actionCSSPFilePut.Result).StatusCode == 401)
                            {
                                return await Task.FromResult(Unauthorized());
                            }
                            else
                            {
                                return await Task.FromResult((BadRequestObjectResult)actionCSSPFilePut.Result);
                            }
                        }
                        else
                        {
                            return await Task.FromResult((BadRequestObjectResult)actionCSSPFile.Result);
                        }
                    }

                    return await Task.FromResult(Ok(true));
                }
                else
                {
                    return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDownload_FromAzure, FileName)));
                }
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDownload_FromAzureException_, FileName, ex.Message)));
            }
        }
    }
}
