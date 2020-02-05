using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class TVFileLanguages
    {
        public int TVFileLanguageID { get; set; }
        public int TVFileID { get; set; }
        public int Language { get; set; }
        public string FileDescription { get; set; }
        public int TranslationStatus { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVFiles TVFile { get; set; }
    }
}
