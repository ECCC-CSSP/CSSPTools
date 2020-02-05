using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class RainExceedanceClimateSites
    {
        public int RainExceedanceClimateSiteID { get; set; }
        public int RainExceedanceTVItemID { get; set; }
        public int ClimateSiteTVItemID { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems ClimateSiteTVItem { get; set; }
        public virtual TVItems RainExceedanceTVItem { get; set; }
    }
}
