namespace CSSPModels;

[NotMapped]
public partial class MonitoringStatByYear
{
    public int Year { get; set; }
    public int MWQMSiteCount { get; set; }
    public int MWQMRunCount { get; set; }
    public int MWQMSampleCount { get; set; }

    public MonitoringStatByYear()
    {

    }
}

