namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> RemoveExternalHardDriveFilesNotFoundInTVFilesAsync()
    {
        string FunctionName = $"{this.GetType().Name}.{CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name)}()";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        DirectoryInfo diExternalHardDrive = new DirectoryInfo(Configuration["ExternalHardDriveBackkupAppDataPath"]);
        if (!diExternalHardDrive.Exists)
        {
            CSSPLogService.AppendError($"{String.Format(CSSPCultureServicesRes.ExternalHardDriveAppDataPathDoesNotExist_, diExternalHardDrive.FullName)}");

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
        }

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

        List<DirectoryInfo> diLocalList = diExternalHardDrive.GetDirectories().ToList();
        count = 0;
        total = diLocalList.Count;
        foreach (DirectoryInfo diLocalChild in diLocalList)
        {
            count += 1;
            if (count % 1 == 0)
            {
                Console.WriteLine($"Count -> {count}/{total} doing local directory {diLocalChild.Name}");
            }

            DirectoryInfo diParentLocal = new DirectoryInfo($@"{diExternalHardDrive.FullName}{diLocalChild.Name}\");
            List<FileInfo> FileInfoLocalList = new List<FileInfo>();
            if (diParentLocal.Exists)
            {
                FileInfoLocalList = diParentLocal.GetFiles().ToList();
            }

            int ParentID = int.Parse(diLocalChild.Name);

            List<ParentAndFileName> parentAndFileNameList = (from c in ParentAndFileNameList
                                                             where c.ParentID == ParentID
                                                             orderby c.ServerFileName
                                                             select c).ToList();

            foreach (FileInfo fileInfoNat in FileInfoLocalList)
            {
                if (!parentAndFileNameList.Where(c => c.ServerFileName == fileInfoNat.Name).Any())
                {
                    string DirNat = $@"{diLocalChild.Name}\{fileInfoNat.Name}";

                    CSSPLogService.AppendLog($"{String.Format(CSSPCultureServicesRes.DeletingExternalHardDriveFile_, DirNat)}");

                    try
                    {
                        fileInfoNat.Delete();
                    }
                    catch (Exception ex)
                    {
                        CSSPLogService.AppendError($"{String.Format(CSSPCultureServicesRes.ErrorDeletingExternalHardDriveFile_Error_, DirNat, ex.Message)}");

                        CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                        return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                    }
                }
            }
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(true));
    }
}

