/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using CSSPWebModels;
using System.Linq;
using Microsoft.AspNetCore.Http;
using LoggedInServices;
using ManageServices;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using Azure.Storage.Blobs;
using Azure;

namespace FileServices
{
    public partial class FileService : ControllerBase, IFileService
    {
        public async Task<ActionResult<bool>> DownloadGzFile(WebTypeEnum webType, int TVItemID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTypeEnum webType, int TVItemID) - webtype: { webType } TVItemID: { TVItemID }";
            await CSSPLogService.FunctionLog(FunctionName);

            if (!await CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ValidationResultList));

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            try
            {
                BlobClient blobClient = new BlobClient(config.AzureStore, config.AzureStoreCSSPJSONPath, FileName);

                Response response = blobClient.DownloadTo($"{ config.CSSPJSONPath }{ FileName }");
                if (response.Status == 206)
                {
                    ManageFile manageFile = null;

                    var actionCSSPFile = await ManageFileService.ManageFileGetWithAzureStorageAndAzureFileName(config.AzureStoreCSSPJSONPath, FileName);
                    if (((ObjectResult)actionCSSPFile.Result).StatusCode == 400)
                    {
                        manageFile = new ManageFile()
                        {
                            ManageFileID = 0,
                            AzureStorage = config.AzureStoreCSSPJSONPath,
                            AzureFileName = FileName,
                            AzureETag = response.Headers.ETag.ToString(),
                            AzureCreationTimeUTC = DateTime.Parse(response.Headers.Date.ToString()),
                            LoadedOnce = true,
                        };

                        var actionCSSPFileAdded = await ManageFileService.ManageFileAddOrModify(manageFile);
                        if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 200)
                        {
                            manageFile = (ManageFile)((OkObjectResult)actionCSSPFileAdded.Result).Value;
                        }
                        else if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 401)
                        {
                            return await EndFunctionReturnUnauthorized(FunctionName, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                        }
                        else
                        {
                            return await EndFunctionReturnBadRequest(FunctionName, ((BadRequestObjectResult)actionCSSPFileAdded.Result).Value.ToString());
                        }
                    }
                    else
                    {
                        if (((OkObjectResult)actionCSSPFile.Result).StatusCode == 200)
                        {
                            manageFile = (ManageFile)((OkObjectResult)actionCSSPFile.Result).Value;

                            manageFile.AzureETag = response.Headers.ETag.ToString();
                            manageFile.AzureCreationTimeUTC = DateTime.Parse(response.Headers.Date.ToString());
                            manageFile.LoadedOnce = true;

                            var actionCSSPFilePut = await ManageFileService.ManageFileAddOrModify(manageFile);
                            if (((ObjectResult)actionCSSPFilePut.Result).StatusCode == 200)
                            {
                                manageFile = (ManageFile)((OkObjectResult)actionCSSPFilePut.Result).Value;
                            }
                            else if (((ObjectResult)actionCSSPFilePut.Result).StatusCode == 401)
                            {
                                return await EndFunctionReturnUnauthorized(FunctionName, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                            }
                            else
                            {
                                return await EndFunctionReturnBadRequest(FunctionName, ((BadRequestObjectResult)actionCSSPFilePut.Result).Value.ToString());
                            }
                        }
                        else
                        {
                            return await EndFunctionReturnBadRequest(FunctionName, ((BadRequestObjectResult)actionCSSPFile.Result).Value.ToString());
                        }
                    }

                    return await EndFunctionReturnOkTrue(FunctionName);
                }
                else
                {
                    return await EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDownload_FromAzure, FileName));
                }
            }
            catch (Exception ex)
            {
                return await EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDownload_FromAzureException_, FileName, ex.Message));
            }
        }
    }
}
