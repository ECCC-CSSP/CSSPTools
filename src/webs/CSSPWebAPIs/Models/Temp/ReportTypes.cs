using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class ReportTypes
    {
        public ReportTypes()
        {
            ReportSections = new HashSet<ReportSections>();
        }

        public int ReportTypeID { get; set; }
        public int TVType { get; set; }
        public int FileType { get; set; }
        public string UniqueCode { get; set; }
        public int? Language { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StartOfFileName { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual ICollection<ReportSections> ReportSections { get; set; }
    }
}
