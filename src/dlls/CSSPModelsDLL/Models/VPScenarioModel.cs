using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class VPScenarioModel : LastUpdateAndContactModel
    {
        public VPScenarioModel()
        {
        }
        public int VPScenarioID { get; set; }
        public string VPScenarioName { get; set; }
        public int InfrastructureTVItemID { get; set; }
        public string InfrastructureTVText { get; set; }
        public ScenarioStatusEnum VPScenarioStatus { get; set; }
        public Nullable<bool> UseAsBestEstimate { get; set; }
        public Nullable<double> EffluentFlow_m3_s { get; set; }
        public Nullable<int> EffluentConcentration_MPN_100ml { get; set; }
        public Nullable<double> FroudeNumber { get; set; }
        public Nullable<double> PortDiameter_m { get; set; }
        public Nullable<double> PortDepth_m { get; set; }
        public Nullable<double> PortElevation_m { get; set; }
        public Nullable<double> VerticalAngle_deg { get; set; }
        public Nullable<double> HorizontalAngle_deg { get; set; }
        public Nullable<int> NumberOfPorts { get; set; }
        public Nullable<double> PortSpacing_m { get; set; }
        public Nullable<double> AcuteMixZone_m { get; set; }
        public Nullable<double> ChronicMixZone_m { get; set; }
        public Nullable<double> EffluentSalinity_PSU { get; set; }
        public Nullable<double> EffluentTemperature_C { get; set; }
        public Nullable<double> EffluentVelocity_m_s { get; set; }
        //public string RawResults { get; set; }
    }
}
