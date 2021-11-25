namespace CSSPWebModels;

[NotMapped]
public partial class WebAllMWQMAnalysisReportParameters
{
    public List<MWQMAnalysisReportParameter> MWQMAnalysisReportParameterList { get; set; }

    public WebAllMWQMAnalysisReportParameters()
    {
        MWQMAnalysisReportParameterList = new List<MWQMAnalysisReportParameter>();
    }
}

