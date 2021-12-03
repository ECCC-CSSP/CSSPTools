namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private async Task<bool> MergeJsonWebAllReportTypesAsync(WebAllReportTypes webAllReportTypes, WebAllReportTypes webAllReportTypesLocal)
    {
        string FunctionName = $"{ this.GetType().Name }.{ CSSPLogService.GetFunctionName(MethodBase.GetCurrentMethod().DeclaringType.Name) }(WebAllReportTypes WebAllReportTypes, WebAllReportTypes WebAllReportTypesLocal)";
        CSSPLogService.FunctionLog(FunctionName);

        MergeJsonWebAllReportsTypesReportTypeModelList(webAllReportTypes, webAllReportTypesLocal);

        CSSPLogService.EndFunctionLog(FunctionName);

        return await Task.FromResult(true);
    }

    private void MergeJsonWebAllReportsTypesReportTypeModelList(WebAllReportTypes webAllReportTypes, WebAllReportTypes webAllReportTypesLocal)
    {
        List<ReportTypeModel> reportTypeModelLocalList = (from c in webAllReportTypesLocal.ReportTypeModelList
                                                          where c.ReportType.DBCommand != DBCommandEnum.Original
                                                          || (from r in c.ReportSectionList
                                                              where r.DBCommand != DBCommandEnum.Original
                                                              select r).Any()
                                                          select c).ToList();

        foreach (ReportTypeModel reportTypeModelLocal in reportTypeModelLocalList)
        {
            ReportTypeModel reportTypeModelOriginal = webAllReportTypes.ReportTypeModelList.Where(c => c.ReportType.ReportTypeID == reportTypeModelLocal.ReportType.ReportTypeID).FirstOrDefault();
            if (reportTypeModelOriginal == null)
            {
                webAllReportTypes.ReportTypeModelList.Add(reportTypeModelLocal);
            }
            else
            {
                SyncReportTypeModel(reportTypeModelOriginal, reportTypeModelLocal);
            }
        }
    }
}

