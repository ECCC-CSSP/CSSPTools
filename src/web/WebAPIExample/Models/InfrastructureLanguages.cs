using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class InfrastructureLanguages
    {
        [Key]
        public int InfrastructureLanguageID { get; set; }
        public int InfrastructureID { get; set; }
        public int Language { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Comment { get; set; }
        public int TranslationStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(InfrastructureID))]
        [InverseProperty(nameof(Infrastructures.InfrastructureLanguages))]
        public virtual Infrastructures Infrastructure { get; set; }
    }
}
