using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class TideDataValues
    {
        public int TideDataValueID { get; set; }
        public int TideSiteTVItemID { get; set; }
        public DateTime DateTime_Local { get; set; }
        public bool Keep { get; set; }
        public int TideDataType { get; set; }
        public int StorageDataType { get; set; }
        public double Depth_m { get; set; }
        public double UVelocity_m_s { get; set; }
        public double VVelocity_m_s { get; set; }
        public int? TideStart { get; set; }
        public int? TideEnd { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems TideSiteTVItem { get; set; }
    }
}
