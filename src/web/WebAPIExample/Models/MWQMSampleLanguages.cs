using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MWQMSampleLanguages
    {
        [Key]
        public int MWQMSampleLanguageID { get; set; }
        public int MWQMSampleID { get; set; }
        public int Language { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string MWQMSampleNote { get; set; }
        public int TranslationStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(MWQMSampleID))]
        [InverseProperty(nameof(MWQMSamples.MWQMSampleLanguages))]
        public virtual MWQMSamples MWQMSample { get; set; }
    }
}
