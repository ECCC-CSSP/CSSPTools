using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class VPScenarioLanguages
    {
        [Key]
        public int VPScenarioLanguageID { get; set; }
        public int VPScenarioID { get; set; }
        public int Language { get; set; }
        [Required]
        [StringLength(100)]
        public string VPScenarioName { get; set; }
        public int TranslationStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(VPScenarioID))]
        [InverseProperty(nameof(VPScenarios.VPScenarioLanguages))]
        public virtual VPScenarios VPScenario { get; set; }
    }
}
