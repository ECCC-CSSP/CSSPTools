namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> RemoveTVFilesDoubleAssociatedWithTVItemsTypeFileAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        //List<TVItem> TVItemList = (from c in db.TVItems
        //                           where c.TVType == TVTypeEnum.File
        //                           orderby c.TVLevel
        //                           select c).ToList();

        List<TVFile> TVFileList = (from c in db.TVFiles
                                   orderby c.TVFileTVItemID
                                   select c).ToList();

        for (int i = 0, count = TVFileList.Count - 1; i < count; i++)
        {
            if (TVFileList[i].TVFileTVItemID == TVFileList[i + 1].TVFileTVItemID)
            {
                string dupText = $@"{TVFileList[i].TVFileTVItemID} -- {TVFileList[i].ServerFileName} -- {TVFileList[i + 1].ServerFileName}";

                CSSPLogService.AppendLog($"{ String.Format(CSSPCultureServicesRes.DuplicateTVFileTVItemID, dupText) }");

                db.TVFiles.Remove(TVFileList[i + 1]);
            }
        }

        try
        {
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            CSSPLogService.AppendError($"{ String.Format(CSSPCultureServicesRes.CouldNotSaveAllRemovedTVItemsError_, ex.Message) }");

            CSSPLogService.EndFunctionLog(MethodBase.GetCurrentMethod().DeclaringType.Name);

            return await Task.FromResult(BadRequest(CSSPLogService.ErrRes));
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(Ok(true));
    }
}

