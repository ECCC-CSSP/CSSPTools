/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class MonitoringStatsModel
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<MonitoringStatByYear> MonitoringStatByYearList { get; set; }
        public List<MonitoringStatByMonth> MonitoringStatByMonthList { get; set; }
        public List<MonitoringStatBySeason> MonitoringStatBySeasonList { get; set; }
        #endregion Properties

        #region Constructors
        public MonitoringStatsModel()
        {
            TVItemModel = new TVItemModel();
            MonitoringStatByYearList = new List<MonitoringStatByYear>();
            MonitoringStatByMonthList = new List<MonitoringStatByMonth>();
            MonitoringStatBySeasonList = new List<MonitoringStatBySeason>();
        }
        #endregion Constructors
    }
}
