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
        private async Task<ActionResult<bool>> DoDownloadGzFile(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            string FileName = await GetFileName(webType, TVItemID, webTypeYear);

            var LoggedInContactInfo = await LoggedInService.GetLoggedInContactInfo();
            if (LoggedInContactInfo == null || LoggedInContactInfo.LoggedInContact == null)
            {
                return await Task.FromResult(Unauthorized());
            }

            try
            {
                BlobClient blobClient = new BlobClient(AzureCSSPStorageConnectionString, AzureCSSPStorageCSSPJSON, FileName);

                Response response = blobClient.DownloadTo($"{ LocalJSONPath }{ FileName }");
                if (response.Status == 206)
                {
                    CSSPFile csspFile = null;

                    var actionCSSPFile = await CSSPFileService.GetWithAzureStorageAndAzureFileName(AzureCSSPStorageCSSPJSON, FileName);
                    if (((ObjectResult)actionCSSPFile.Result).StatusCode == 400)
                    {
                        int NextIndex = -1;
                        var actionInt = await CSSPFileService.GetCSSPFileNextIndexToUse();
                        if (((ObjectResult)actionInt.Result).StatusCode == 200)
                        {
                            NextIndex = (int)((OkObjectResult)actionInt.Result).Value;
                        }

                        csspFile = new CSSPFile()
                        {
                            CSSPFileID = NextIndex,
                            AzureStorage = AzureCSSPStorageCSSPJSON,
                            AzureFileName = FileName,
                            AzureETag = response.Headers.ETag.ToString(),
                            AzureCreationTime = DateTime.Now,
                        };

                        var actionCSSPFileAdded = await CSSPFileService.Post(csspFile);
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

                            var actionCSSPFilePut = await CSSPFileService.Put(csspFile);
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
