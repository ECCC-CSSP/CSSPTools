using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class MikeScenarioResults
    {
        public int MikeScenarioResultID { get; set; }
        public int MikeScenarioTVItemID { get; set; }
        public string MikeResultsJSON { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems MikeScenarioTVItem { get; set; }
    }
}
