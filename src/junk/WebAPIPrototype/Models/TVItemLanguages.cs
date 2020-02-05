using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class TVItemLanguages
    {
        public int TVItemLanguageID { get; set; }
        public int TVItemID { get; set; }
        public int Language { get; set; }
        public string TVText { get; set; }
        public int TranslationStatus { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems TVItem { get; set; }
    }
}
