namespace CSSPCreateGzFileServices;

public partial class CSSPCreateGzFileService : ControllerBase, ICSSPCreateGzFileService
{
    private async Task<bool> FillLabSheetModelListAsync(List<LabSheetModel> LabSheetModelList, TVItem TVItem)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(List<LabSheetModel> LabSheetModelList, TVItem TVItem) -- TVItem.TVItemID: { TVItem.TVItemID }   TVItem.TVPath: { TVItem.TVPath })";
        CSSPLogService.FunctionLog(FunctionName);

        List<LabSheet> LabSheetList = await GetLabSheetListUnderSubsectorAsync(TVItem.TVItemID);
        List<LabSheetDetail> LabSheetDetailList = await GetLabSheetDetailListUnderSubsectorAsync(TVItem.TVItemID);
        List<LabSheetTubeMPNDetail> LabSheetTubeMPNDetailList = await GetLabSheetTubeMPNDetailListUnderSubsectorAsync(TVItem.TVItemID);

        foreach (LabSheet LabSheet in LabSheetList)
        {
            LabSheetModel LabSheetModel = new LabSheetModel();
            LabSheetModel.LabSheet = LabSheet;
            LabSheetModel.LabSheetDetail = LabSheetDetailList.Where(c => c.LabSheetID == LabSheet.LabSheetID).FirstOrDefault();
            if (LabSheetModel.LabSheetDetail != null)
            {
                LabSheetModel.LabSheetTubeMPNDetailList = LabSheetTubeMPNDetailList.Where(c => c.LabSheetDetailID == LabSheetModel.LabSheetDetail.LabSheetDetailID).ToList();
            }

            LabSheetModelList.Add(LabSheetModel);
        }

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }
}
