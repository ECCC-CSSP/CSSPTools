namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillPolSourceGroupingModelListAsync(List<PolSourceGroupingModel> PolSourceGroupingModelList)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<PolSourceGroupingModel> PolSourceGroupingModelList)";
        CSSPLogService.FunctionLog(FunctionName);

        List<PolSourceGrouping> PolSourceGroupingList = await GetPolSourceGroupingListAsync();
        List<PolSourceGroupingLanguage> PolSourceGroupingLanguageList = await GetPolSourceGroupingLanguageListAsync();

        foreach (PolSourceGrouping polSourceGrouping in PolSourceGroupingList)
        {
            PolSourceGroupingModelList.Add(new PolSourceGroupingModel()
            {
                PolSourceGrouping = polSourceGrouping,
                PolSourceGroupingLanguageList = PolSourceGroupingLanguageList.Where(c => c.PolSourceGroupingID == polSourceGrouping.PolSourceGroupingID).ToList(),
            });
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
