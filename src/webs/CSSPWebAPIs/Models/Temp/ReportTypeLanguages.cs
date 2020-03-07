using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class ReportTypeLanguages
    {
        public int ReportTypeLanguageID { get; set; }
        public int ReportTypeID { get; set; }
        public int Language { get; set; }
        public string Name { get; set; }
        public int TranslationStatusName { get; set; }
        public string Description { get; set; }
        public int TranslationStatusDescription { get; set; }
        public string StartOfFileName { get; set; }
        public int TranslationStatusStartOfFileName { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual ReportTypes ReportType { get; set; }
    }
}
