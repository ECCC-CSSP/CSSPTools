using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class VPResults
    {
        public int VPResultID { get; set; }
        public int VPScenarioID { get; set; }
        public int Ordinal { get; set; }
        public int Concentration_MPN_100ml { get; set; }
        public double Dilution { get; set; }
        public double FarFieldWidth_m { get; set; }
        public double DispersionDistance_m { get; set; }
        public double TravelTime_hour { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual VPScenarios VPScenario { get; set; }
    }
}
