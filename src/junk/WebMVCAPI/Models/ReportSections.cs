using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class ReportSections
    {
        public ReportSections()
        {
            InverseParentReportSection = new HashSet<ReportSections>();
            InverseTemplateReportSection = new HashSet<ReportSections>();
            ReportSectionLanguages = new HashSet<ReportSectionLanguages>();
        }

        public int ReportSectionID { get; set; }
        public int ReportTypeID { get; set; }
        public int? TVItemID { get; set; }
        public int Ordinal { get; set; }
        public bool IsStatic { get; set; }
        public int? ParentReportSectionID { get; set; }
        public int? Year { get; set; }
        public bool Locked { get; set; }
        public int? TemplateReportSectionID { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual ReportSections ParentReportSection { get; set; }
        public virtual ReportTypes ReportType { get; set; }
        public virtual TVItems TVItem { get; set; }
        public virtual ReportSections TemplateReportSection { get; set; }
        public virtual ICollection<ReportSections> InverseParentReportSection { get; set; }
        public virtual ICollection<ReportSections> InverseTemplateReportSection { get; set; }
        public virtual ICollection<ReportSectionLanguages> ReportSectionLanguages { get; set; }
    }
}
