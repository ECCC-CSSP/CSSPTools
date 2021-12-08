namespace CSSPModels;

[NotMapped]
public partial class WebMonitoringRoutineStatsProvince
{
    public List<MonitoringStatsModel> MonitoringStatsModelList { get; set; }

    public WebMonitoringRoutineStatsProvince()
    {
        MonitoringStatsModelList = new List<MonitoringStatsModel>();
    }
}

