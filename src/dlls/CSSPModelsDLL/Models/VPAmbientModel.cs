using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class VPAmbientModel : LastUpdateAndContactModel
    {
        public VPAmbientModel()
        {
        }
        public int VPAmbientID { get; set; }
        public int VPScenarioID { get; set; }
        public int Row { get; set; }
        public Nullable<double> MeasurementDepth_m { get; set; }
        public Nullable<double> CurrentSpeed_m_s { get; set; }
        public Nullable<double> CurrentDirection_deg { get; set; }
        public Nullable<double> AmbientSalinity_PSU { get; set; }
        public Nullable<double> AmbientTemperature_C { get; set; }
        public Nullable<int> BackgroundConcentration_MPN_100ml { get; set; }
        public Nullable<double> PollutantDecayRate_per_day { get; set; }
        public Nullable<double> FarFieldCurrentSpeed_m_s { get; set; }
        public Nullable<double> FarFieldCurrentDirection_deg { get; set; }
        public Nullable<double> FarFieldDiffusionCoefficient { get; set; }
    }
}
