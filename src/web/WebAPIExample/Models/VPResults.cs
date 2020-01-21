using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class VPResults
    {
        [Key]
        public int VPResultID { get; set; }
        public int VPScenarioID { get; set; }
        public int Ordinal { get; set; }
        public int Concentration_MPN_100ml { get; set; }
        public double Dilution { get; set; }
        public double FarFieldWidth_m { get; set; }
        public double DispersionDistance_m { get; set; }
        public double TravelTime_hour { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(VPScenarioID))]
        [InverseProperty(nameof(VPScenarios.VPResults))]
        public virtual VPScenarios VPScenario { get; set; }
    }
}
