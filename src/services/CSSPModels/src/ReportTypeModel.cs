namespace CSSPModels;

[NotMapped]
public partial class ReportTypeModel
{
    public ReportType ReportType { get; set; }
    public List<ReportSection> ReportSectionList { get; set; }

    public ReportTypeModel()
    {
        ReportType = new ReportType();
        ReportSectionList = new List<ReportSection>();
    }
}
