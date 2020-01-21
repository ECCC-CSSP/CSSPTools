using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MikeScenarios
    {
        public MikeScenarios()
        {
            InverseParentMikeScenario = new HashSet<MikeScenarios>();
        }

        [Key]
        public int MikeScenarioID { get; set; }
        public int MikeScenarioTVItemID { get; set; }
        public int? ParentMikeScenarioID { get; set; }
        public int ScenarioStatus { get; set; }
        [Column(TypeName = "text")]
        public string ErrorInfo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime MikeScenarioStartDateTime_Local { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime MikeScenarioEndDateTime_Local { get; set; }
        [Column(TypeName = "datetime")]
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
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(MikeScenarioTVItemID))]
        [InverseProperty(nameof(TVItems.MikeScenarios))]
        public virtual TVItems MikeScenarioTVItem { get; set; }
        [ForeignKey(nameof(ParentMikeScenarioID))]
        [InverseProperty(nameof(MikeScenarios.InverseParentMikeScenario))]
        public virtual MikeScenarios ParentMikeScenario { get; set; }
        [InverseProperty(nameof(MikeScenarios.ParentMikeScenario))]
        public virtual ICollection<MikeScenarios> InverseParentMikeScenario { get; set; }
    }
}
