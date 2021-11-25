namespace CSSPWebModels;

[NotMapped]
public partial class WebMonitoringRoutineStatsCountry
{
    public List<MonitoringStatsModel> MonitoringStatsModelList { get; set; }

    public WebMonitoringRoutineStatsCountry()
    {
        MonitoringStatsModelList = new List<MonitoringStatsModel>();
    }
}

