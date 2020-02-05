using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class BoxModelLanguages
    {
        public int BoxModelLanguageID { get; set; }
        public int BoxModelID { get; set; }
        public int Language { get; set; }
        public string ScenarioName { get; set; }
        public int TranslationStatus { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual BoxModels BoxModel { get; set; }
    }
}
