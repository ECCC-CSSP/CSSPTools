using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class VPScenarios
    {
        public VPScenarios()
        {
            VPAmbients = new HashSet<VPAmbients>();
            VPResults = new HashSet<VPResults>();
            VPScenarioLanguages = new HashSet<VPScenarioLanguages>();
        }

        public int VPScenarioID { get; set; }
        public int InfrastructureTVItemID { get; set; }
        public int VPScenarioStatus { get; set; }
        public bool UseAsBestEstimate { get; set; }
        public double? EffluentFlow_m3_s { get; set; }
        public int? EffluentConcentration_MPN_100ml { get; set; }
        public double? FroudeNumber { get; set; }
        public double? PortDiameter_m { get; set; }
        public double? PortDepth_m { get; set; }
        public double? PortElevation_m { get; set; }
        public double? VerticalAngle_deg { get; set; }
        public double? HorizontalAngle_deg { get; set; }
        public int? NumberOfPorts { get; set; }
        public double? PortSpacing_m { get; set; }
        public double? AcuteMixZone_m { get; set; }
        public double? ChronicMixZone_m { get; set; }
        public double? EffluentSalinity_PSU { get; set; }
        public double? EffluentTemperature_C { get; set; }
        public double? EffluentVelocity_m_s { get; set; }
        public string RawResults { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems InfrastructureTVItem { get; set; }
        public virtual ICollection<VPAmbients> VPAmbients { get; set; }
        public virtual ICollection<VPResults> VPResults { get; set; }
        public virtual ICollection<VPScenarioLanguages> VPScenarioLanguages { get; set; }
    }
}
