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
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace FileServices
{
    public partial class FileService : ControllerBase, IFileService
    {
        public async Task<ActionResult<bool>> LocalizeAzureFile(int ParentTVItemID, string FileName)
        {
            string FunctionName = $"{ this.GetType().Name }.{ await CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int ParentTVItemID, string FileName) - ParentTVItemID: { ParentTVItemID }  FileName: { FileName }";
            await CSSPLogService.FunctionLog(FunctionName);

            if (!await CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ValidationResultList));

            ShareFileClient shareFileClient;
            ShareFileProperties shareFileProperties;
            try
            {
                ShareClient shareClient = new ShareClient(config.AzureStore, config.AzureStoreCSSPFilesPath);
                ShareDirectoryClient shareDirectoryClient = shareClient.GetDirectoryClient($"{ParentTVItemID}");
                shareFileClient = shareDirectoryClient.GetFileClient(FileName);
                shareFileProperties = shareFileClient.GetProperties();
            }
            catch (Exception ex)
            {
                string ErrorText = ex.Message + (ex.InnerException == null ? "" : " InnerException: " + ex.InnerException.Message);

                return await EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.ErrorWhileTryingToGetAzureFileInfoFor_Error_, $"{ParentTVItemID}\\{FileName}", ErrorText));
            }

            FileInfo fiDownload = new FileInfo($"{config.CSSPFilesPath}{ParentTVItemID}\\{FileName}");
            bool ShouldDownload = false;

            if (fiDownload.Exists)
            {
                var manageFileExist = await ManageFileService.ManageFileGetWithAzureStorageAndAzureFileName(config.AzureStoreCSSPFilesPath, $"{ParentTVItemID}\\{FileName}");
                if (((ObjectResult)manageFileExist.Result).StatusCode == 200)
                {
                    ManageFile manageFile = (ManageFile)((OkObjectResult)manageFileExist.Result).Value;

                    if (!manageFile.LoadedOnce)
                    {
                        manageFile.LoadedOnce = true;

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

                    if (manageFile.AzureETag != shareFileProperties.ETag.ToString().Replace("\"", ""))
                    {
                        ShouldDownload = true;

                        try
                        {
                            fiDownload.Delete();
                        }
                        catch (Exception ex)
                        {
                            string ErrorText = ex.Message + (ex.InnerException == null ? "" : " InnerException: " + ex.InnerException.Message);

                            return await EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.CouldNotDeleteFile_Error_, fiDownload.FullName, ErrorText));
                        }
                    }
                }
                else
                {
                    ShouldDownload = true;
                }
            }
            else
            {
                ShouldDownload = true;
            }

            if (ShouldDownload)
            {
                DirectoryInfo di = new DirectoryInfo(fiDownload.Directory.FullName);
                if (!di.Exists)
                {
                    try
                    {
                        di.Create();
                    }
                    catch (Exception ex)
                    {
                        string ErrorText = ex.Message + (ex.InnerException == null ? "" : " InnerException: " + ex.InnerException.Message);

                        return await EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.CouldNoCreateDirectory_, di.FullName, ErrorText));
                    }
                }

                try
                {
                    ShareFileDownloadInfo download = shareFileClient.Download();
                    using (FileStream stream = System.IO.File.OpenWrite(fiDownload.FullName))
                    {
                        download.Content.CopyTo(stream);
                    }
                }
                catch (Exception ex)
                {
                    string ErrorText = ex.Message + (ex.InnerException == null ? "" : " InnerException: " + ex.InnerException.Message);

                    return await EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.CouldNotLocalizeAzureFile_Error_, $"{ParentTVItemID}\\{FileName}", ErrorText));
                }

                var actionCSSPFile = await ManageFileService.ManageFileGetWithAzureStorageAndAzureFileName(config.AzureStoreCSSPFilesPath, $"{ParentTVItemID}\\{FileName}");
                if (((ObjectResult)actionCSSPFile.Result).StatusCode == 400)
                {
                    ManageFile manageFile = new ManageFile()
                    {
                        ManageFileID = 0,
                        AzureStorage = config.AzureStoreCSSPFilesPath,
                        AzureFileName = $"{ParentTVItemID}\\{FileName}",
                        AzureETag = shareFileProperties.ETag.ToString().Replace("\"", ""),
                        AzureCreationTimeUTC = DateTime.Parse(shareFileProperties.LastModified.ToString()),
                        LoadedOnce = true,
                    };

                    var actionCSSPFileAdded = await ManageFileService.ManageFileAddOrModify(manageFile);
                    if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 200)
                    {
                        // information got uploaded to CSSPDBManage.db Table ManageFiles properly
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
                        ManageFile manageFile = (ManageFile)((OkObjectResult)actionCSSPFile.Result).Value;

                        manageFile.AzureETag = shareFileProperties.ETag.ToString().Replace("\"", "");
                        manageFile.AzureCreationTimeUTC = DateTime.Parse(shareFileProperties.LastModified.ToString());
                        manageFile.LoadedOnce = true;

                        var actionCSSPFilePut = await ManageFileService.ManageFileAddOrModify(manageFile);
                        if (((ObjectResult)actionCSSPFilePut.Result).StatusCode == 200)
                        {
                            // information got uploaded to CSSPDBManage.db Table ManageFiles properly
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

            }

            return await EndFunctionReturnOkTrue(FunctionName);
        }
    }
}
