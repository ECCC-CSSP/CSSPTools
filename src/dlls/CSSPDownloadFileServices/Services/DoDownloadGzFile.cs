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
using CSSPDBFilesManagementModels;
using CSSPWebModels;

namespace DownloadFileServices
{
    public partial class DownloadFileService : ControllerBase, IDownloadFileService
    {
        private async Task<ActionResult<bool>> DoDownloadGzFile(WebTypeEnum webType, int TVItemID, WebTypeYearEnum webTypeYear)
        {
            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID, webTypeYear);

            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
            }

            try
            {
                BlobClient blobClient = new BlobClient(AzureStore, AzureStoreCSSPJSONPath, FileName);

                Response response = blobClient.DownloadTo($"{ CSSPJSONPath }{ FileName }");
                if (response.Status == 206)
                {
                    FilesManagement filesManagement = null;

                    var actionCSSPFile = await FilesManagementService.GetWithAzureStorageAndAzureFileName(AzureStoreCSSPJSONPath, FileName);
                    if (((ObjectResult)actionCSSPFile.Result).StatusCode == 400)
                    {
                        filesManagement = new FilesManagement()
                        {
                            FilesManagementID = 0,
                            AzureStorage = AzureStoreCSSPJSONPath,
                            AzureFileName = FileName,
                            AzureETag = response.Headers.ETag.ToString(),
                            AzureCreationTimeUTC = DateTime.Parse(response.Headers.Date.ToString()),
                        };

                        var actionCSSPFileAdded = await FilesManagementService.AddOrModify(filesManagement);
                        if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 200)
                        {
                            filesManagement = (FilesManagement)((OkObjectResult)actionCSSPFileAdded.Result).Value;
                        }
                        else if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 401)
                        {
                            return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
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
                            filesManagement = (FilesManagement)((OkObjectResult)actionCSSPFile.Result).Value;

                            filesManagement.AzureETag = response.Headers.ETag.ToString();
                            filesManagement.AzureCreationTimeUTC = DateTime.Parse(response.Headers.Date.ToString());

                            var actionCSSPFilePut = await FilesManagementService.AddOrModify(filesManagement);
                            if (((ObjectResult)actionCSSPFilePut.Result).StatusCode == 200)
                            {
                                filesManagement = (FilesManagement)((OkObjectResult)actionCSSPFilePut.Result).Value;
                            }
                            else if (((ObjectResult)actionCSSPFilePut.Result).StatusCode == 401)
                            {
                                return await Task.FromResult(Unauthorized(string.Format(CSSPCultureServicesRes.YouDoNotHaveAuthorization)));
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
