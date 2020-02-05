using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class MWQMSubsectorLanguages
    {
        public int MWQMSubsectorLanguageID { get; set; }
        public int MWQMSubsectorID { get; set; }
        public int Language { get; set; }
        public string SubsectorDesc { get; set; }
        public int TranslationStatusSubsectorDesc { get; set; }
        public string LogBook { get; set; }
        public int? TranslationStatusLogBook { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual MWQMSubsectors MWQMSubsector { get; set; }
    }
}
