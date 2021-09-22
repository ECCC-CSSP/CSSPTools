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

namespace CSSPFileServices
{
    public partial class CSSPFileService : ControllerBase, ICSSPFileService
    {
        public async Task<ActionResult<bool>> DownloadGzFile(WebTypeEnum webType, int TVItemID)
        {
            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTypeEnum webType, int TVItemID) - webtype: { webType } TVItemID: { TVItemID }";
            CSSPLogService.FunctionLog(FunctionName);

            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

            string FileName = await BaseGzFileService.GetFileName(webType, TVItemID);

            try
            {
                BlobClient blobClient = new BlobClient(LoggedInService.Descramble(Configuration["AzureStore"]), Configuration["AzureStoreCSSPJSONPath"], FileName);

                Response response = blobClient.DownloadTo($"{ Configuration["CSSPJSONPath"] }{ FileName }");
                if (response.Status == 206)
                {
                    ManageFile manageFile = null;

                    var actionCSSPFile = await ManageFileService.ManageFileGetWithAzureStorageAndAzureFileName(Configuration["AzureStoreCSSPJSONPath"], FileName);
                    manageFile = (ManageFile)((OkObjectResult)actionCSSPFile.Result).Value;

                    if (manageFile == null)
                    {
                        manageFile = new ManageFile()
                        {
                            ManageFileID = 0,
                            AzureStorage = Configuration["AzureStoreCSSPJSONPath"],
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
                            return await CSSPLogService.EndFunctionReturnUnauthorized(FunctionName, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                        }
                        else
                        {
                            return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, ((BadRequestObjectResult)actionCSSPFileAdded.Result).Value.ToString());
                        }
                    }
                    else
                    {
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
                            return await CSSPLogService.EndFunctionReturnUnauthorized(FunctionName, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
                        }
                        else
                        {
                            return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, ((BadRequestObjectResult)actionCSSPFilePut.Result).Value.ToString());
                        }
                    }

                    return await CSSPLogService.EndFunctionReturnOkTrue(FunctionName);
                }
                else
                {
                    return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDownload_FromAzure, FileName));
                }
            }
            catch (Exception ex)
            {
                return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDownload_FromAzureException_, FileName, ex.Message));
            }
        }
    }
}
