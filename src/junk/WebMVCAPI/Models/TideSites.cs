using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class TideSites
    {
        public int TideSiteID { get; set; }
        public int TideSiteTVItemID { get; set; }
        public string TideSiteName { get; set; }
        public string Province { get; set; }
        public int sid { get; set; }
        public int Zone { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems TideSiteTVItem { get; set; }
    }
}
