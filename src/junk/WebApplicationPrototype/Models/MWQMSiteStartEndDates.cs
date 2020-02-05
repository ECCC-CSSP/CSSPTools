using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class MWQMSiteStartEndDates
    {
        public int MWQMSiteStartEndDateID { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems MWQMSiteTVItem { get; set; }
    }
}
