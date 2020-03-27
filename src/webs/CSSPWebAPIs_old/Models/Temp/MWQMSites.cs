using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class MWQMSites
    {
        public int MWQMSiteID { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        public string MWQMSiteNumber { get; set; }
        public string MWQMSiteDescription { get; set; }
        public int MWQMSiteLatestClassification { get; set; }
        public int Ordinal { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems MWQMSiteTVItem { get; set; }
    }
}
