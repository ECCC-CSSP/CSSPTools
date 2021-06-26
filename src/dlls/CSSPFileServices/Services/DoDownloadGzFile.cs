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
using CSSPWebModels;
using ManageServices;

namespace FileServices
{
    public partial class FileService : ControllerBase, IFileService
    {
        private async Task<ActionResult<bool>> DoDownloadGzFile(WebTypeEnum webType, int TVItemID)
        {
            if (LoggedInService.LoggedInContactInfo == null)
            {
                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
            }

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            try
            {
                BlobClient blobClient = new BlobClient(AzureStore, AzureStoreCSSPJSONPath, FileName);

                Response response = blobClient.DownloadTo($"{ CSSPJSONPath }{ FileName }");
                if (response.Status == 206)
                {
                    ManageFile manageFile = null;

                    var actionCSSPFile = await ManageFileService.ManageFileGetWithAzureStorageAndAzureFileName(AzureStoreCSSPJSONPath, FileName);
                    if (((ObjectResult)actionCSSPFile.Result).StatusCode == 400)
                    {
                        manageFile = new ManageFile()
                        {
                            ManageFileID = 0,
                            AzureStorage = AzureStoreCSSPJSONPath,
                            AzureFileName = FileName,
                            AzureETag = response.Headers.ETag.ToString(),
                            AzureCreationTimeUTC = DateTime.Parse(response.Headers.Date.ToString()),
                        };

                        var actionCSSPFileAdded = await ManageFileService.ManageFileAddOrModify(manageFile);
                        if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 200)
                        {
                            manageFile = (ManageFile)((OkObjectResult)actionCSSPFileAdded.Result).Value;
                        }
                        else if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 401)
                        {
                            return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
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
                            manageFile = (ManageFile)((OkObjectResult)actionCSSPFile.Result).Value;

                            manageFile.AzureETag = response.Headers.ETag.ToString();
                            manageFile.AzureCreationTimeUTC = DateTime.Parse(response.Headers.Date.ToString());

                            var actionCSSPFilePut = await ManageFileService.ManageFileAddOrModify(manageFile);
                            if (((ObjectResult)actionCSSPFilePut.Result).StatusCode == 200)
                            {
                                manageFile = (ManageFile)((OkObjectResult)actionCSSPFilePut.Result).Value;
                            }
                            else if (((ObjectResult)actionCSSPFilePut.Result).StatusCode == 401)
                            {
                                return await Task.FromResult(Unauthorized(CSSPCultureServicesRes.YouDoNotHaveAuthorization));
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
