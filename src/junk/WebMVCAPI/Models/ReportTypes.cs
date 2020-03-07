using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class ReportTypes
    {
        public ReportTypes()
        {
            ReportSections = new HashSet<ReportSections>();
            ReportTypeLanguages = new HashSet<ReportTypeLanguages>();
        }

        public int ReportTypeID { get; set; }
        public int TVType { get; set; }
        public int FileType { get; set; }
        public string UniqueCode { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual ICollection<ReportSections> ReportSections { get; set; }
        public virtual ICollection<ReportTypeLanguages> ReportTypeLanguages { get; set; }
    }
}
