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

        List<int> ParentIDList = (from c in TVItemList
                                  orderby c.ParentID
                                  select (int)c.ParentID).Distinct().ToList();


        List<TVFile> TVFileList = (from c in db.TVFiles
                                   select c).AsNoTracking().ToList();

        List<ParentAndFileName> ParentAndFileNameList = new List<ParentAndFileName>();

        int count = 0;
        int total = TVFileList.Count;
        foreach (TVFile tvFile in TVFileList)
        {
            count += 1;
            if (count % 1000 == 0)
            {
                Console.WriteLine($"Count -> {count}/{total}");
            }

            TVItem tvItem = TVItemList.Where(c => c.TVItemID == tvFile.TVFileTVItemID).FirstOrDefault();
            if (tvItem != null)
            {
                ParentAndFileNameList.Add(new ParentAndFileName() { ParentID = (int)tvItem.ParentID, ServerFileName = tvFile.ServerFileName, TVFileID = tvFile.TVFileID, TVItemID = tvFile.TVFileTVItemID });
            }
        }

        // ---------------------------------------------
        // Cleaning Azure drive (files)
        //----------------------------------------------

        ShareClient shareClient = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPFilesPath"]);
        ShareDirectoryClient directory = shareClient.GetRootDirectoryClient();

        Pageable<ShareFileItem> shareFileItemList = directory.GetFilesAndDirectories();

        foreach (ShareFileItem shareFileItem in shareFileItemList)
        {
            int? ParentIDExist = (from c in ParentIDList
                                  where c.ToString() == shareFileItem.Name
                                  select c).FirstOrDefault();

            if (ParentIDExist != null)
            {
                if (shareFileItem.Name == "WebTide")
                {
                    continue;
                }

                CSSPLogService.AppendLog($"{String.Format(CSSPCultureServicesRes.DoingAzureDirectory_, shareFileItem.Name)}");

                if (shareFileItem.IsDirectory)
                {
                    ShareClient shareClientSub = new ShareClient(CSSPScrambleService.Descramble(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.AzureStoreHash), Configuration["AzureStoreCSSPFilesPath"]);
                    ShareDirectoryClient directorySub = shareClientSub.GetDirectoryClient(shareFileItem.Name);

                    if (directorySub.Exists())
                    {
                        foreach (ShareFileItem shareFileItemSub in directorySub.GetFilesAndDirectories())
                        {
                            ParentAndFileName parentAndFileName = (from c in ParentAndFileNameList
                                                                   where c.ServerFileName == shareFileItemSub.Name
                                                                   select c).FirstOrDefault();

                            if (parentAndFileName == null)
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
                    }
                }
            }
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(true));
    }
}
