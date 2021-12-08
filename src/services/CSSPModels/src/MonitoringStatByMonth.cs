namespace CSSPModels;

[NotMapped]
public partial class MonitoringStatByMonth
{
    [CSSPEnumType]
    public MonthEnum Month { get; set; }
    public int MWQMSiteCount { get; set; }
    public int MWQMRunCount { get; set; }
    public int MWQMSampleCount { get; set; }

    public MonitoringStatByMonth()
    {

    }
}


