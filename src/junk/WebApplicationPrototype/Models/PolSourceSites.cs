using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class PolSourceSites
    {
        public PolSourceSites()
        {
            PolSourceObservations = new HashSet<PolSourceObservations>();
        }

        public int PolSourceSiteID { get; set; }
        public int PolSourceSiteTVItemID { get; set; }
        public string Temp_Locator_CanDelete { get; set; }
        public int? Oldsiteid { get; set; }
        public int? Site { get; set; }
        public int? SiteID { get; set; }
        public bool IsPointSource { get; set; }
        public int? InactiveReason { get; set; }
        public int? CivicAddressTVItemID { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems CivicAddressTVItem { get; set; }
        public virtual TVItems PolSourceSiteTVItem { get; set; }
        public virtual ICollection<PolSourceObservations> PolSourceObservations { get; set; }
    }
}
