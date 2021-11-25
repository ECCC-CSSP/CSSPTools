namespace CSSPWebModels;

[NotMapped]
public partial class WebMonitoringOtherStatsCountry
{
    public List<MonitoringStatsModel> MonitoringStatsModelList { get; set; }

    public WebMonitoringOtherStatsCountry()
    {
        MonitoringStatsModelList = new List<MonitoringStatsModel>();
    }
}

