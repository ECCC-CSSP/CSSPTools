using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class SpillLanguages
    {
        public int SpillLanguageID { get; set; }
        public int SpillID { get; set; }
        public int Language { get; set; }
        public string SpillComment { get; set; }
        public int TranslationStatus { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual Spills Spill { get; set; }
    }
}
