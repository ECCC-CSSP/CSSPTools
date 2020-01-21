using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class ReportSections
    {
        public ReportSections()
        {
            InverseParentReportSection = new HashSet<ReportSections>();
            InverseTemplateReportSection = new HashSet<ReportSections>();
            ReportSectionLanguages = new HashSet<ReportSectionLanguages>();
        }

        [Key]
        public int ReportSectionID { get; set; }
        public int ReportTypeID { get; set; }
        public int? TVItemID { get; set; }
        public int Ordinal { get; set; }
        public bool IsStatic { get; set; }
        public int? ParentReportSectionID { get; set; }
        public int? Year { get; set; }
        public bool Locked { get; set; }
        public int? TemplateReportSectionID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ParentReportSectionID))]
        [InverseProperty(nameof(ReportSections.InverseParentReportSection))]
        public virtual ReportSections ParentReportSection { get; set; }
        [ForeignKey(nameof(ReportTypeID))]
        [InverseProperty(nameof(ReportTypes.ReportSections))]
        public virtual ReportTypes ReportType { get; set; }
        [ForeignKey(nameof(TVItemID))]
        [InverseProperty(nameof(TVItems.ReportSections))]
        public virtual TVItems TVItem { get; set; }
        [ForeignKey(nameof(TemplateReportSectionID))]
        [InverseProperty(nameof(ReportSections.InverseTemplateReportSection))]
        public virtual ReportSections TemplateReportSection { get; set; }
        [InverseProperty(nameof(ReportSections.ParentReportSection))]
        public virtual ICollection<ReportSections> InverseParentReportSection { get; set; }
        [InverseProperty(nameof(ReportSections.TemplateReportSection))]
        public virtual ICollection<ReportSections> InverseTemplateReportSection { get; set; }
        [InverseProperty("ReportSection")]
        public virtual ICollection<ReportSectionLanguages> ReportSectionLanguages { get; set; }
    }
}
