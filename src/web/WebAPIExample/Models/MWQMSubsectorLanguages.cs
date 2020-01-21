using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MWQMSubsectorLanguages
    {
        [Key]
        public int MWQMSubsectorLanguageID { get; set; }
        public int MWQMSubsectorID { get; set; }
        public int Language { get; set; }
        [Required]
        [StringLength(250)]
        public string SubsectorDesc { get; set; }
        public int TranslationStatusSubsectorDesc { get; set; }
        [Column(TypeName = "text")]
        public string LogBook { get; set; }
        public int? TranslationStatusLogBook { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(MWQMSubsectorID))]
        [InverseProperty(nameof(MWQMSubsectors.MWQMSubsectorLanguages))]
        public virtual MWQMSubsectors MWQMSubsector { get; set; }
    }
}
