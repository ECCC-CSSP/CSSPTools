namespace CSSPUpdateServices;

public partial class CSSPUpdateService : ControllerBase, ICSSPUpdateService
{
    public async Task<ActionResult<bool>> RemoveTVItemsNoAssociatedWithTVFilesAsync()
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }()";
        CSSPLogService.FunctionLog(FunctionName);

        if (!await CSSPLogService.CheckLogin(FunctionName)) return await Task.FromResult(Unauthorized(CSSPLogService.ErrRes));

        List<TVItem> TVItemList = (from c in db.TVItems
                                   where c.TVType == TVTypeEnum.File
                                   orderby c.TVLevel
                                   select c).ToList();

        List<TVFile> TVFileList = (from c in db.TVFiles
                                   select c).ToList();

        int count = 0;
        int total = TVItemList.Count;
        foreach (TVItem tvItem in TVItemList)
        {
            count += 1;

            if (count % 1000 == 0)
            {
                Console.WriteLine($"Count -> {count}/{total}");
            }

            if (!(TVFileList.Where(c => c.TVFileTVItemID == tvItem.TVItemID).Any()))
            {
                string dupText = $@"{tvItem.TVItemID} --- {tvItem.ParentID}";

                CSSPLogService.AppendLog($"{ dupText }");

                db.TVItems.Remove(tvItem);
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

