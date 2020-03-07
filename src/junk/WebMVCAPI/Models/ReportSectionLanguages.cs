using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class ReportSectionLanguages
    {
        public int ReportSectionLanguageID { get; set; }
        public int ReportSectionID { get; set; }
        public int Language { get; set; }
        public string ReportSectionName { get; set; }
        public int TranslationStatusReportSectionName { get; set; }
        public string ReportSectionText { get; set; }
        public int TranslationStatusReportSectionText { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual ReportSections ReportSection { get; set; }
    }
}
