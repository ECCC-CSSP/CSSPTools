namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> RemoveExternalHardDriveDirectoriesNotFoundInTVFilesAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        DirectoryInfo diExternalHardDrive = new DirectoryInfo(Configuration["ExternalHardDriveBackkupAppDataPath"]);
        if (!diExternalHardDrive.Exists)
        {
            CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.ExternalHardDriveAppDataPathDoesNotExist_, diExternalHardDrive.FullName) }");

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

        // ---------------------------------------------
        // Cleaning Local drive
        //----------------------------------------------

        List<DirectoryInfo> diLocalSubList = diExternalHardDrive.GetDirectories().OrderBy(c => c.Name).ToList();

        foreach (DirectoryInfo diSub in diLocalSubList)
        {
            int? ParentIDExist = (from c in ParentIDList
                                  where c.ToString() == diSub.Name
                                  select c).FirstOrDefault();

            if (ParentIDExist == 0)
            {
                if (diSub.Name == "WebTide")
                {
                    continue;
                }

                CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.DeletingExternalHardDriveDirectory_, diSub.FullName) }");

                try
                {
                    diSub.Delete(true);
                }
                catch (Exception ex)
                {
                    CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.ErrorDeletingExternalHardDriveDirectory_Error_, diSub.FullName, ex.Message) }");

                    CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);


                    return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                }
            }
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(true));
    }
}

