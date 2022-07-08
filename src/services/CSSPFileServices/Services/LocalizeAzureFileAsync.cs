namespace CSSPFileServices;

public partial class CSSPFileService : ControllerBase, ICSSPFileService
{
    public async Task<ActionResult<bool>> LocalizeAzureFileAsync(int ParentTVItemID, string FileName)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(int ParentTVItemID, string FileName) - ParentTVItemID: { ParentTVItemID }  FileName: { FileName }";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        ShareFileClient shareFileClient;
        ShareFileProperties shareFileProperties;
        try
        {
            ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPFilesPath"]);
            ShareDirectoryClient shareDirectoryClient = shareClient.GetDirectoryClient($"{ParentTVItemID}");
            shareFileClient = shareDirectoryClient.GetFileClient(FileName);
            shareFileProperties = shareFileClient.GetProperties();
        }
        catch (Exception ex)
        {
            string ErrorText = ex.Message + (ex.InnerException == null ? "" : " InnerException: " + ex.InnerException.Message);

            return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.ErrorWhileTryingToGetAzureFileInfoFor_Error_, $"{ParentTVItemID}\\{FileName}", ErrorText));
        }

        FileInfo fiDownload = new FileInfo($"{ Configuration["CSSPFilesPath"] }{ParentTVItemID}\\{FileName}");
        bool ShouldDownload = false;

        if (fiDownload.Exists)
        {
            var manageFileExist = await ManageFileService.GetWithAzureStorageAndAzureFileNameAsync(Configuration["AzureStoreCSSPFilesPath"], $"{ ParentTVItemID}\\{FileName}");
            ManageFile manageFile = (ManageFile)((OkObjectResult)manageFileExist.Result).Value;
            if (manageFile != null)
            {
                if (!manageFile.LoadedOnce)
                {
                    manageFile.LoadedOnce = true;

                    var actionCSSPFileAdded = await ManageFileService.ModifyAsync(manageFile);
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

                string eTag = shareFileProperties.ETag.ToString().Replace("\"", "");

                if (manageFile.AzureETag != eTag)
                {
                    ShouldDownload = true;

                    try
                    {
                        fiDownload.Delete();
                    }
                    catch (Exception ex)
                    {
                        string ErrorText = ex.Message + (ex.InnerException == null ? "" : " InnerException: " + ex.InnerException.Message);

                        return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.CouldNotDeleteFile_Error_, fiDownload.FullName, ErrorText));
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

                    return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.CouldNoCreateDirectory_, di.FullName, ErrorText));
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

                return await CSSPLogService.EndFunctionReturnBadRequest(FunctionName, string.Format(CSSPCultureServicesRes.CouldNotLocalizeAzureFile_Error_, $"{ParentTVItemID}\\{FileName}", ErrorText));
            }

            var actionCSSPFile = await ManageFileService.GetWithAzureStorageAndAzureFileNameAsync(Configuration["AzureStoreCSSPFilesPath"], $"{ ParentTVItemID}\\{FileName}");
            ManageFile manageFile = (ManageFile)((OkObjectResult)actionCSSPFile.Result).Value;

            string eTag = shareFileProperties.ETag.ToString().Replace("\"", "");

            if (manageFile == null)
            {
                manageFile = new ManageFile()
                {
                    ManageFileID = 0,
                    AzureStorage = Configuration["AzureStoreCSSPFilesPath"],
                    AzureFileName = $"{ParentTVItemID}\\{FileName}",
                    AzureETag = eTag,
                    AzureCreationTimeUTC = DateTime.Parse(shareFileProperties.LastModified.ToString()),
                    LoadedOnce = true,
                };

                var actionCSSPFileAdded = await ManageFileService.AddAsync(manageFile);
                if (((ObjectResult)actionCSSPFileAdded.Result).StatusCode == 200)
                {
                    // information got uploaded to CSSPDBManage.db Table ManageFiles properly
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
                manageFile.AzureETag = eTag;
                manageFile.AzureCreationTimeUTC = DateTime.Parse(shareFileProperties.LastModified.ToString());
                manageFile.LoadedOnce = true;

                var actionCSSPFilePut = await ManageFileService.AddAsync(manageFile);
                if (((ObjectResult)actionCSSPFilePut.Result).StatusCode == 200)
                {
                    // information got uploaded to CSSPDBManage.db Table ManageFiles properly
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

        }

        return await CSSPLogService.EndFunctionReturnOkTrue(FunctionName);
    }
}

