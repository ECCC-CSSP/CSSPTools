namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillDrogueRunModelAsync(List<DrogueRunModel> DrogueRunModelList, TVItem TVItemProvince)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<DrogueRunModel> DrogueRunModelList, TVItem TVItemProvince) -- TVItem.TVItemID: { TVItemProvince.TVItemID }   TVItem.TVPath: { TVItemProvince.TVPath })";
        CSSPLogService.FunctionLog(FunctionName);

        List<DrogueRun> drogueRunList = await GetDrogueRunListUnderProvinceAsync(TVItemProvince);
        List<DrogueRunPosition> drogueRunPositionList = await GetDrogueRunPositionListUnderProvinceAsync(TVItemProvince);

        foreach (DrogueRun drogueRun in drogueRunList)
        {
            DrogueRunModel drogueRunModel = new DrogueRunModel()
            {
                DrogueRun = drogueRun,
                DrogueRunPositionList = (from c in drogueRunPositionList
                                         where c.DrogueRunID == drogueRun.DrogueRunID
                                         orderby c.Ordinal
                                         select c).ToList(),
            };

            DrogueRunModelList.Add(drogueRunModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
