namespace CSSPReadGzFileServices;

public partial class CSSPReadGzFileService : ICSSPReadGzFileService
{
    private void SyncReportTypeModel(ReportTypeModel reportTypeModelOriginal, ReportTypeModel reportTypeModelLocal)
    {
        if (reportTypeModelLocal != null)
        {
            if (reportTypeModelLocal.ReportType != null)
            {
                reportTypeModelOriginal.ReportType = reportTypeModelLocal.ReportType;
            }
            if (reportTypeModelLocal.ReportSectionList != null)
            {
                reportTypeModelOriginal.ReportSectionList = reportTypeModelLocal.ReportSectionList;
            }
        }
    }
}

