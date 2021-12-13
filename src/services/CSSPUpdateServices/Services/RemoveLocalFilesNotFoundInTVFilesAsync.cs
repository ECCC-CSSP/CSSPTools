﻿namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> RemoveLocalFilesNotFoundInTVFilesAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        DirectoryInfo diLocal = new DirectoryInfo(Configuration["LocalAppDataPath"]);
        if (!diLocal.Exists)
        {
            CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.LocalAppDataPathDoesNotExist_, diLocal.FullName) }");

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
        }

        List<TVItem> TVItemList = (from c in db.TVItems
                                   where c.TVType == TVTypeEnum.File
                                   orderby c.TVLevel
                                   select c).AsNoTracking().ToList();

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
            if (tvItem == null)
            {
                CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.CouldNotFindTVItemForTVFile_TVFileTVItemIDEqual_, tvFile.TVFileTVItemID) }");

                CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
            }


            ParentAndFileNameList.Add(new ParentAndFileName() { ParentID = (int)tvItem.ParentID, ServerFileName = tvFile.ServerFileName, TVFileID = tvFile.TVFileID, TVItemID = tvFile.TVFileTVItemID });
        }

        List<int> ParentIDList = (from c in ParentAndFileNameList
                                      //where c.ParentID == 1
                                  orderby c.ParentID
                                  select c.ParentID).Distinct().ToList();


        count = 0;
        total = ParentIDList.Count;
        foreach (int ParentID in ParentIDList)
        {
            count += 1;
            if (count % 1 == 0)
            {
                Console.WriteLine($"Count -> {count}/{total} doing ParentID {ParentID}");
            }

            DirectoryInfo diParentLocal = new DirectoryInfo($@"{diLocal.FullName}{ParentID}\");
            List<FileInfo> FileInfoLocalList = new List<FileInfo>();
            if (diParentLocal.Exists)
            {
                FileInfoLocalList = diParentLocal.GetFiles().ToList();
            }

            List<ParentAndFileName> parentAndFileNameList = (from c in ParentAndFileNameList
                                                             where c.ParentID == ParentID
                                                             orderby c.ServerFileName
                                                             select c).ToList();

            foreach (FileInfo fileInfoNat in FileInfoLocalList)
            {
                if (!parentAndFileNameList.Where(c => c.ServerFileName == fileInfoNat.Name).Any())
                {
                    string DirNat = $@"{ParentID}\{fileInfoNat.Name}";

                    CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.DeletingLocalFile_, DirNat) }");

                    try
                    {
                        fileInfoNat.Delete();
                    }
                    catch (Exception ex)
                    {
                        CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.ErrorDeletingLocalFile_Error_, DirNat, ex.Message) }");

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
