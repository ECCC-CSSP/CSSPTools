namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> RemoveLocalDirectoriesNotFoundInTVFilesAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        DirectoryInfo diLocalHardDrive = new DirectoryInfo(Configuration["LocalAppDataPath"]);
        if (!diLocalHardDrive.Exists)
        {
            CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.LocalAppDataPathDoesNotExist_, diLocalHardDrive.FullName) }");

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
        }

        List<int> ParentIDList = (from c in db.TVItems
                                  where c.TVType == TVTypeEnum.File
                                  orderby c.TVLevel
                                  select (int)c.ParentID).Distinct().ToList();

        // -------------------------------------------------------------------
        // Cleaning Local hard drive directory not found in TVItems table
        //--------------------------------------------------------------------

        List<DirectoryInfo> diLocalSubList = diLocalHardDrive.GetDirectories().OrderBy(c => c.Name).ToList();

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

                CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.DeletingLocalHardDriveDirectory_, diSub.FullName) }");

                try
                {
                    diSub.Delete(true);
                }
                catch (Exception ex)
                {
                    CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.ErrorDeletingLocalHardDriveDirectory_Error_, diSub.FullName, ex.Message) }");

                    CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);


                    return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
                }
            }
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(true));
    }
}

