using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MWQMRunLanguages
    {
        [Key]
        public int MWQMRunLanguageID { get; set; }
        public int MWQMRunID { get; set; }
        public int Language { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string RunComment { get; set; }
        public int TranslationStatusRunComment { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string RunWeatherComment { get; set; }
        public int TranslationStatusRunWeatherComment { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(MWQMRunID))]
        [InverseProperty(nameof(MWQMRuns.MWQMRunLanguages))]
        public virtual MWQMRuns MWQMRun { get; set; }
    }
}
