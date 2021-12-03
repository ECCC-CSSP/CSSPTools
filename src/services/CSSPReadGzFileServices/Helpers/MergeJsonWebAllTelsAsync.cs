namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebAllTelsAsync(WebAllTels webAllTels, WebAllTels webAllTelsLocal)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllTels WebAllTels, WebAllTels WebAllTelsLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebAllTelsTelModelList(webAllTels, webAllTelsLocal);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }

    private void MergeJsonWebAllTelsTelModelList(WebAllTels webAllTels, WebAllTels webAllTelsLocal)
    {
        List<Tel> telLocalList = (from c in webAllTelsLocal.TelList
                                  where c.DBCommand != DBCommandEnum.Original
                                  select c).ToList();

        foreach (Tel telLocal in telLocalList)
        {
            Tel telOriginal = webAllTels.TelList.Where(c => c.TelID == telLocal.TelID).FirstOrDefault();
            if (telOriginal == null)
            {
                webAllTels.TelList.Add(telLocal);
            }
            else
            {
                telOriginal = telLocal;
            }
        }
    }
}

