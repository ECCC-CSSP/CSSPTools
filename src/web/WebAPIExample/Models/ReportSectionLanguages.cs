using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class ReportSectionLanguages
    {
        [Key]
        public int ReportSectionLanguageID { get; set; }
        public int ReportSectionID { get; set; }
        public int Language { get; set; }
        [Required]
        [StringLength(100)]
        public string ReportSectionName { get; set; }
        public int TranslationStatusReportSectionName { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string ReportSectionText { get; set; }
        public int TranslationStatusReportSectionText { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ReportSectionID))]
        [InverseProperty(nameof(ReportSections.ReportSectionLanguages))]
        public virtual ReportSections ReportSection { get; set; }
    }
}
