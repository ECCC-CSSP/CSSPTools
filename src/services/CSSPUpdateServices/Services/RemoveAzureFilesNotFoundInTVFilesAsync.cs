namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> RemoveAzureFilesNotFoundInTVFilesAsync()
    {
        string FunctionName = $"{this.GetType().Name}.{CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name)}()";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        List<TVItem> TVItemList = (from c in db.TVItems
                                   where c.TVType == TVTypeEnum.File
                                   orderby c.TVLevel
                                   select c).AsNoTracking().ToList();

        List<TVFile> TVFileList = (from c in db.TVFiles
                                   select c).AsNoTracking().ToList();

        // --------------------------------------------------
        // Cleaning Azure files not found in TVItems table
        //---------------------------------------------------

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPFilesPath"]);
        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();

        Pageable<ShareFileItem> shareFileItemDirList = directory.GetFilesAndDirectories();

        foreach (ShareFileItem shareFileItemDir in shareFileItemDirList)
        {
            int? ParentIDExist = (from c in TVItemList
                                  where c.ParentID.ToString() == shareFileItemDir.Name
                                  select c.ParentID).FirstOrDefault();

            if (ParentIDExist != null)
            {
                if (shareFileItemDir.Name == "WebTide")
                {
                    continue;
                }

                CSSPLogService.AppendLog($"{String.Format(CSSPCultureServicesRes.DoingAzureDirectory_, shareFileItemDir.Name)}");

                if (shareFileItemDir.IsDirectory)
                {
                    //ShareClient shareClientSub = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPFilesPath"]);
                    ShareDirectoryClient directorySub = shareClient.GetDirectoryClient(shareFileItemDir.Name);

                    if (directorySub.Exists())
                    {
                        foreach (ShareFileItem shareFileItemSub in directorySub.GetFilesAndDirectories())
                        {
                            List<TVItem> tvItemList2 = (from c in TVItemList
                                                        where c.ParentID == ParentIDExist
                                                        select c).ToList();

                            List<TVFile> tvFileList2 = (from c in TVFileList
                                                        where c.ServerFileName == shareFileItemSub.Name
                                                        select c).ToList();

                            TVFile tvFile = (from c in tvFileList2
                                             from t in tvItemList2
                                             where t.TVItemID == c.TVFileTVItemID
                                             && t.ParentID == ParentIDExist
                                             && c.ServerFileName == shareFileItemSub.Name
                                             select c).FirstOrDefault();

                            if (tvFile == null)
                            {
                                ShareFileClient file = directorySub.GetFileClient(shareFileItemSub.Name);

                                string dirFile = $@"{shareFileItemDir.Name}\{shareFileItemSub.Name}";
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
                    }
                }
            }
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(true));
    }
}
