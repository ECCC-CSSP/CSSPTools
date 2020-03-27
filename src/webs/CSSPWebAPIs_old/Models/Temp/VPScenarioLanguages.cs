using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class VPScenarioLanguages
    {
        public int VPScenarioLanguageID { get; set; }
        public int VPScenarioID { get; set; }
        public int Language { get; set; }
        public string VPScenarioName { get; set; }
        public int TranslationStatus { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual VPScenarios VPScenario { get; set; }
    }
}
