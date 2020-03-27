using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class PolSourceObservationIssues
    {
        public int PolSourceObservationIssueID { get; set; }
        public int PolSourceObservationID { get; set; }
        public string ObservationInfo { get; set; }
        public int Ordinal { get; set; }
        public string ExtraComment { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual PolSourceObservations PolSourceObservation { get; set; }
    }
}
