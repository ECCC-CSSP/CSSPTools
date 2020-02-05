using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class VPAmbients
    {
        public int VPAmbientID { get; set; }
        public int VPScenarioID { get; set; }
        public int Row { get; set; }
        public double? MeasurementDepth_m { get; set; }
        public double? CurrentSpeed_m_s { get; set; }
        public double? CurrentDirection_deg { get; set; }
        public double? AmbientSalinity_PSU { get; set; }
        public double? AmbientTemperature_C { get; set; }
        public int? BackgroundConcentration_MPN_100ml { get; set; }
        public double? PollutantDecayRate_per_day { get; set; }
        public double? FarFieldCurrentSpeed_m_s { get; set; }
        public double? FarFieldCurrentDirection_deg { get; set; }
        public double? FarFieldDiffusionCoefficient { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual VPScenarios VPScenario { get; set; }
    }
}
