using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class MapInfoPoints
    {
        public int MapInfoPointID { get; set; }
        public int MapInfoID { get; set; }
        public int Ordinal { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual MapInfos MapInfo { get; set; }
    }
}
