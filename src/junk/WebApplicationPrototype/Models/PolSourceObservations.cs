using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class PolSourceObservations
    {
        public PolSourceObservations()
        {
            PolSourceObservationIssues = new HashSet<PolSourceObservationIssues>();
        }

        public int PolSourceObservationID { get; set; }
        public int PolSourceSiteID { get; set; }
        public DateTime ObservationDate_Local { get; set; }
        public int ContactTVItemID { get; set; }
        public bool DesktopReviewed { get; set; }
        public string Observation_ToBeDeleted { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems ContactTVItem { get; set; }
        public virtual PolSourceSites PolSourceSite { get; set; }
        public virtual ICollection<PolSourceObservationIssues> PolSourceObservationIssues { get; set; }
    }
}
