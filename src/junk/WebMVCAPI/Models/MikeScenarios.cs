using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class MikeScenarios
    {
        public MikeScenarios()
        {
            InverseParentMikeScenario = new HashSet<MikeScenarios>();
        }

        public int MikeScenarioID { get; set; }
        public int MikeScenarioTVItemID { get; set; }
        public int? ParentMikeScenarioID { get; set; }
        public int ScenarioStatus { get; set; }
        public string ErrorInfo { get; set; }
        public DateTime MikeScenarioStartDateTime_Local { get; set; }
        public DateTime MikeScenarioEndDateTime_Local { get; set; }
        public DateTime? MikeScenarioStartExecutionDateTime_Local { get; set; }
        public double? MikeScenarioExecutionTime_min { get; set; }
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
        public int? NumberOfElements { get; set; }
        public int? NumberOfTimeSteps { get; set; }
        public int? NumberOfSigmaLayers { get; set; }
        public int? NumberOfZLayers { get; set; }
        public int? NumberOfHydroOutputParameters { get; set; }
        public int? NumberOfTransOutputParameters { get; set; }
        public long? EstimatedHydroFileSize { get; set; }
        public long? EstimatedTransFileSize { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems MikeScenarioTVItem { get; set; }
        public virtual MikeScenarios ParentMikeScenario { get; set; }
        public virtual ICollection<MikeScenarios> InverseParentMikeScenario { get; set; }
    }
}
