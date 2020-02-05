using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class MWQMRunLanguages
    {
        public int MWQMRunLanguageID { get; set; }
        public int MWQMRunID { get; set; }
        public int Language { get; set; }
        public string RunComment { get; set; }
        public int TranslationStatusRunComment { get; set; }
        public string RunWeatherComment { get; set; }
        public int TranslationStatusRunWeatherComment { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual MWQMRuns MWQMRun { get; set; }
    }
}
