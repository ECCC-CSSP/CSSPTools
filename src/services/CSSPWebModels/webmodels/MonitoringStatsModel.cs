namespace CSSPWebModels;

[NotMapped]
public partial class MonitoringStatsModel
{
    public TVItemModel TVItemModel { get; set; }
    public List<MonitoringStatByYear> MonitoringStatByYearList { get; set; }
    public List<MonitoringStatByMonth> MonitoringStatByMonthList { get; set; }
    public List<MonitoringStatBySeason> MonitoringStatBySeasonList { get; set; }

    public MonitoringStatsModel()
    {
        TVItemModel = new TVItemModel();
        MonitoringStatByYearList = new List<MonitoringStatByYear>();
        MonitoringStatByMonthList = new List<MonitoringStatByMonth>();
        MonitoringStatBySeasonList = new List<MonitoringStatBySeason>();
    }
}

