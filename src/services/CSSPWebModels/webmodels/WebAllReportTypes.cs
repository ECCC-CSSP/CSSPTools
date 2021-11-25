namespace CSSPWebModels;

[NotMapped]
public partial class WebAllReportTypes
{
    public List<ReportTypeModel> ReportTypeModelList { get; set; }

    public WebAllReportTypes()
    {
        ReportTypeModelList = new List<ReportTypeModel>();
    }
}
