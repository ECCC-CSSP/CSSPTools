namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> RemoveAzureDirectoriesNotFoundInTVFilesAsync()
    {
        string FunctionName = $"{this.GetType().Name}.{CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name)}()";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        List<int> ParentIDList = (from c in db.TVItems
                                  where c.TVType == TVTypeEnum.File
                                  orderby c.TVLevel
                                  select (int)c.ParentID).Distinct().ToList();


        // -----------------------------------------------------
        // Cleaning Azure directory not found in TVItems table
        //------------------------------------------------------

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPFilesPath"]);
        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();

        Pageable<ShareFileItem> shareFileItemList = directory.GetFilesAndDirectories();

        foreach (ShareFileItem shareFileItem in shareFileItemList)
        {
            int ParentIDExist = (from c in ParentIDList
                                 where c.ToString() == shareFileItem.Name
                                 select c).FirstOrDefault();

            if (ParentIDExist == 0)
            {
                if (shareFileItem.Name == "WebTide")
                {
                    continue;
                }

                CSSPLogService.AppendLog($"{String.Format(CSSPCultureServicesRes.DeletingAzureDirectory_, shareFileItem.Name)}");

                if (shareFileItem.IsDirectory)
                {
                    ShareDirectoryClient directorySub = shareClient.GetDirectoryClient(shareFileItem.Name);

                    if (directorySub.Exists())
                    {
                        foreach (ShareFileItem shareFileItemSub in directorySub.GetFilesAndDirectories())
                        {
                            ShareFileClient file = directorySub.GetFileClient(shareFileItemSub.Name);

                            string dirFile = $@"{shareFileItem.Name}\{shareFileItemSub.Name}";
                            CSSPLogService.AppendLog($"{String.Format(CSSPCultureServicesRes.DeletingAzureFile_, dirFile)}");

                            Response<bool> responseFile = file.DeleteIfExists();

                            if (responseFile.Value)
                            {
                                CSSPLogService.AppendLog($"{String.Format(CSSPCultureServicesRes.DeletedAzureFile_, dirFile)}");
                            }
                            else
                            {
                                CSSPLogService.AppendError($"{String.Format(CSSPCultureServicesRes.ErrorDeletingAzureFile_, dirFile)}");
                            }
                        }
                    }

                    Response<bool> responseDir = directorySub.DeleteIfExists();

                    if (responseDir.Value)
                    {
                        CSSPLogService.AppendLog($"{String.Format(CSSPCultureServicesRes.DeletedAzureDirectory_, shareFileItem.Name)}");
                    }
                    else
                    {
                        CSSPLogService.AppendError($"{String.Format(CSSPCultureServicesRes.ErrorDeletingAzureDirectory_, shareFileItem.Name)}");
                    }
                }
            }
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(true));
    }
}

