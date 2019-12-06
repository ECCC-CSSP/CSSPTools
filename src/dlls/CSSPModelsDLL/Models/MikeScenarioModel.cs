using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class MikeScenarioModel : LastUpdateAndContactModel
    {
        public MikeScenarioModel()
        {
        }
        public int MikeScenarioID { get; set; }
        public int MikeScenarioTVItemID { get; set; }
        public string MikeScenarioTVText { get; set; }
        public int? ParentMikeScenarioID { get; set; }
        public ScenarioStatusEnum ScenarioStatus { get; set; }
        public string ErrorInfo { get; set; }
        public System.DateTime MikeScenarioStartDateTime_Local { get; set; }
        public System.DateTime MikeScenarioEndDateTime_Local { get; set; }
        public Nullable<System.DateTime> MikeScenarioStartExecutionDateTime_Local { get; set; }
        public Nullable<double> MikeScenarioExecutionTime_min { get; set; }
        public double WindSpeed_km_h { get; set; }
        public double WindDirection_deg { get; set; }
        public double DecayFactor_per_day { get; set; }
        public bool DecayIsConstant { get; set; }
        public double DecayFactorAmplitude { get; set; }
        public int ResultFrequency_min { get; set; }
        public double AmbientTemperature_C { get; set; }
        public double AmbientSalinity_PSU { get; set; }
        public bool? GenerateDecouplingFiles { get; set; }
        public bool? UseDecouplingFiles { get; set; }
        public int? UseSalinityAndTemperatureInitialConditionFromTVFileTVItemID { get; set; }
        public int? ForSimulatingMWQMRunTVItemID { get; set; }
        public double ManningNumber { get; set; }
        public Nullable<int> NumberOfElements { get; set; }
        public Nullable<int> NumberOfTimeSteps { get; set; }
        public Nullable<int> NumberOfSigmaLayers { get; set; }
        public Nullable<int> NumberOfZLayers { get; set; }
        public Nullable<int> NumberOfHydroOutputParameters { get; set; }
        public Nullable<int> NumberOfTransOutputParameters { get; set; }
        public Nullable<long> EstimatedHydroFileSize { get; set; }
        public Nullable<long> EstimatedTransFileSize { get; set; }
    }
}
