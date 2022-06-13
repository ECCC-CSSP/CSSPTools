namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> RemoveNationalBackupDirectoriesNotFoundInTVFilesAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        DirectoryInfo diNat = new DirectoryInfo(Configuration["NationalBackupAppDataPath"]);
        if (!diNat.Exists)
        {
            CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.LocalAppDataPathDoesNotExist_, diNat.FullName) }");

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
        }

        List<int> ParentIDList = (from c in db.TVItems
                                  where c.TVType == TVTypeEnum.File
                                  orderby c.TVLevel
                                  select (int)c.ParentID).Distinct().ToList();

        // -------------------------------------------------------------------
        // Cleaning National Shared drive directory not found in TVItems table
        //--------------------------------------------------------------------

        List<DirectoryInfo> diLocalSubList = diNat.GetDirectories().OrderBy(c => c.Name).ToList();

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

                CSSPLogService.AppendLog($"{String.Format(CSSPCultureServicesRes.DeletingNationalSharedDriveDirectory_, diSub.FullName)}");

                try
                {
                    diSub.Delete(true);
                }
                catch (Exception ex)
                {
                    CSSPLogService.AppendError($"{String.Format(CSSPCultureServicesRes.ErrorDeletingNationalSharedDriveDirectory_Error_, diSub.FullName, ex.Message)}");

                    CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);


                    return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                }
            }
        }
        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(true));
    }
}

