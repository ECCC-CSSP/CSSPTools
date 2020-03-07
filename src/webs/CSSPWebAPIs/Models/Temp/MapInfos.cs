using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class MapInfos
    {
        public MapInfos()
        {
            MapInfoPoints = new HashSet<MapInfoPoints>();
        }

        public int MapInfoID { get; set; }
        public int TVItemID { get; set; }
        public int TVType { get; set; }
        public double LatMin { get; set; }
        public double LatMax { get; set; }
        public double LngMin { get; set; }
        public double LngMax { get; set; }
        public int MapInfoDrawType { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems TVItem { get; set; }
        public virtual ICollection<MapInfoPoints> MapInfoPoints { get; set; }
    }
}
