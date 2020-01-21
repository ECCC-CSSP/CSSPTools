using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class ReportTypeLanguages
    {
        [Key]
        public int ReportTypeLanguageID { get; set; }
        public int ReportTypeID { get; set; }
        public int Language { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public int TranslationStatusName { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Description { get; set; }
        public int TranslationStatusDescription { get; set; }
        [Required]
        [StringLength(100)]
        public string StartOfFileName { get; set; }
        public int TranslationStatusStartOfFileName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ReportTypeID))]
        [InverseProperty(nameof(ReportTypes.ReportTypeLanguages))]
        public virtual ReportTypes ReportType { get; set; }
    }
}
