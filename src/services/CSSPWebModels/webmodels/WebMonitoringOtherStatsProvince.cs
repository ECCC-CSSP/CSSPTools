namespace CSSPWebModels;

[NotMapped]
public partial class WebMonitoringOtherStatsProvince
{
    public List<MonitoringStatsModel> MonitoringStatsModelList { get; set; }

    public WebMonitoringOtherStatsProvince()
    {
        MonitoringStatsModelList = new List<MonitoringStatsModel>();
    }
}

