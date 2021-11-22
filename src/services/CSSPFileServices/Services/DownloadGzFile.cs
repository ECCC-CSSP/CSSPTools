///*
// * Manually edited
// * 
// */
//using CSSPEnums;
//using CSSPDBModels;
//using CSSPCultureServices.Resources;
//using CSSPCultureServices.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.IO;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using CSSPWebModels;
//using System.Linq;
//using Microsoft.AspNetCore.Http;
//using CSSPLocalLoggedInServices;
//using ManageServices;
//using System.Reflection;
//using System.ComponentModel.DataAnnotations;
//using Azure.Storage.Blobs;
//using Azure;
//using Azure.Storage.Files.Shares;
//using Azure.Storage.Files.Shares.Models;

//namespace CSSPFileServices
//{
//    public partial class CSSPFileService : ControllerBase, ICSSPFileService
//    {
//        public async Task<ActionResult<bool>> DownloadGzFile(WebTypeEnum webType, int TVItemID)
//        {
//            string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebTypeEnum webType, int TVItemID) - webtype: { webType } TVItemID: { TVItemID }";
//            CSSPLogService.FunctionLog(FunctionName);

//            if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

//            string fileName = await BaseGzFileService.GetFileName(webType, TVItemID);

//            try
//            {
//                ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPJsonPath"]);
//                ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();
//                ShareFileClient shareFileClient = directory.GetFileClient(fileName);

//                Response<bool> response = await shareFileClient.ExistsAsync();
//                if (!response.Value)
//                {
//                    CSSPLogService.AppendError(string.Format(CSSPCultureServicesRes.CouldNotFind_, $"{ Configuration["AzureStoreCSSPJsonPath"] }{ fileName }"));
//                    return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
//                }

//                ShareFileProperties shareFileProperties = null;

//                try
//                {
//                    shareFileProperties = shareFileClient.GetProperties();
//                }
//                catch (RequestFailedException)
//                {
//                    CSSPLogService.AppendError(string.Format(CSSPCultureDesktopRes.CouldNotGetPropertiesFromAzureStore_AndFile_, Configuration["AzureStoreCSSPJsonPath"], fiGZ.Name));
//                    return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
//                }

//                if (response.Status == 206)
//                {
//                    ManageFile manageFile = null;

//                    var actionCSSPFile = await ManageFileService.GetWithAzureStorageAndAzureFileNameAsync(Configuration["AzureStoreCSSPJSONPath"], fileName);
//                    manageFile = (ManageFile)((OkObjectResult)actionCSSPFile.Result).Value;

//                    if (manageFile == null)
//                    {
//                        manageFile = new ManageFile()
//                        {
//                            ManageFileID = 0,
//                            AzureStorage = Configuration["AzureStoreCSSPJSONPath"],
//                            AzureFileName = fileName,
//                            AzureETag = response.Headers.ETag.ToString(),
//                            AzureCreationTimeUTC = DateTime.Parse(response.Headers.Date.ToString()),
//                            LoadedOnce = true,
//                        };

//                        var actionCSSPFileAdded = await ManageFileService.AddAsync(manageFile);
//                        if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 200)
//                        {
//                            manageFile = (ManageFile)((OkObjectResult)actionCSSPFileAdded.Result).Value;
//                        }
//                        else if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 401)
//                        {
//                            return await CSSPLogService.EndFunctionReturnUnauthorized(FunctionName, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
//                        }
//                        else
//                        {
//                            return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, ((BadRequestObjectResult)actionCSSPFileAdded.Result).Value.ToString());
//                        }
//                    }
//                    else
//                    {
//                        manageFile.AzureETag = response.Headers.ETag.ToString();
//                        manageFile.AzureCreationTimeUTC = DateTime.Parse(response.Headers.Date.ToString());
//                        manageFile.LoadedOnce = true;

//                        var actionCSSPFilePut = await ManageFileService.AddAsync(manageFile);
//                        if (((ObjectResult)actionCSSPFilePut.Result).StatusCode == 200)
//                        {
//                            manageFile = (ManageFile)((OkObjectResult)actionCSSPFilePut.Result).Value;
//                        }
//                        else if (((ObjectResult)actionCSSPFilePut.Result).StatusCode == 401)
//                        {
//                            return await CSSPLogService.EndFunctionReturnUnauthorized(FunctionName, CSSPCultureServicesRes.YouDoNotHaveAuthorization);
//                        }
//                        else
//                        {
//                            return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, ((BadRequestObjectResult)actionCSSPFilePut.Result).Value.ToString());
//                        }
//                    }

//                    return await CSSPLogService.EndFunctionReturnOkTrue(FunctionName);
//                }
//                else
//                {
//                    return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDownload_FromAzure, fileName));
//                }
//            }
//            catch (Exception ex)
//            {
//                return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.ErrorWhileTryingToDownload_FromAzureException_, fileName, ex.Message));
//            }
//        }
//    }
//}
