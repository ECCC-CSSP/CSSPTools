using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class InfrastructureLanguages
    {
        public int InfrastructureLanguageID { get; set; }
        public int InfrastructureID { get; set; }
        public int Language { get; set; }
        public string Comment { get; set; }
        public int TranslationStatus { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual Infrastructures Infrastructure { get; set; }
    }
}
