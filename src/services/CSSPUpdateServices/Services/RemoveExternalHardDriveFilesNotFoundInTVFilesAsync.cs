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

        List<TVFile> TVFileList = (from c in db.TVFiles
                                   select c).AsNoTracking().ToList();

        // --------------------------------------------------------------
        // Cleaning External hard drive files not found in TVItems table
        //---------------------------------------------------------------

        List<DirectoryInfo> diLocalList = diExternalHardDrive.GetDirectories().ToList();

        foreach (DirectoryInfo diLocal in diLocalList)
        {
            int? ParentIDExist = (from c in TVItemList
                                  where c.ParentID.ToString() == diLocal.Name
                                  select c.ParentID).FirstOrDefault();

            if (ParentIDExist != null)
            {
                if (diLocal.Name == "WebTide")
                {
                    continue;
                }

                CSSPLogService.AppendLog($"{String.Format(CSSPCultureServicesRes.DoingExternalHardDriveDirectory_, diLocal.Name)}");

                foreach (FileInfo fi in diLocal.GetFiles().ToList())
                {
                    List<TVItem> tvItemList2 = (from c in TVItemList
                                                where c.ParentID == ParentIDExist
                                                select c).ToList();

                    List<TVFile> tvFileList2 = (from c in TVFileList
                                                where c.ServerFileName == fi.Name
                                                select c).ToList();

                    TVFile tvFile = (from c in tvFileList2
                                     from t in tvItemList2
                                     where t.TVItemID == c.TVFileTVItemID
                                     && t.ParentID == ParentIDExist
                                     && c.ServerFileName == fi.Name
                                     select c).FirstOrDefault();

                    if (tvFile == null)
                    {
                        CSSPLogService.AppendLog($"{String.Format(CSSPCultureServicesRes.DeletingExternalHardDriveFile_, fi.FullName)}");

                        try
                        {
                            fi.Delete();
                        }
                        catch (Exception ex)
                        {
                            CSSPLogService.AppendError($"{String.Format(CSSPCultureServicesRes.ErrorDeletingExternalHardDriveFile_Error_, fi.FullName, ex.Message)}");

                            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

                            return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                        }
                    }
                }
            }
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(true));
    }
}

