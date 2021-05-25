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
    public partial class MonitoringStatsByYearModel
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<MonitoringStatByYear> MonitoringStatByYearList { get; set; }
        #endregion Properties

        #region Constructors
        public MonitoringStatsByYearModel()
        {
            TVItemModel = new TVItemModel();
            MonitoringStatByYearList = new List<MonitoringStatByYear>();
        }
        #endregion Constructors
    }
}
