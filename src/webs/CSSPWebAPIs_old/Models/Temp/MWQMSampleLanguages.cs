using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class MWQMSampleLanguages
    {
        public int MWQMSampleLanguageID { get; set; }
        public int MWQMSampleID { get; set; }
        public int Language { get; set; }
        public string MWQMSampleNote { get; set; }
        public int TranslationStatus { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual MWQMSamples MWQMSample { get; set; }
    }
}
