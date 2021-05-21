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
    public partial class WebMonitoringOtherStatsByYearForCountry
    {
        #region Properties
        public List<MonitoringStatsByYearModel> MonitoringStatsByYearModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMonitoringOtherStatsByYearForCountry()
        {
            MonitoringStatsByYearModelList = new List<MonitoringStatsByYearModel>();
        }
        #endregion Constructors
    }
}
