using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class BoxModelResults
    {
        public int BoxModelResultID { get; set; }
        public int BoxModelID { get; set; }
        public int BoxModelResultType { get; set; }
        public double Volume_m3 { get; set; }
        public double Surface_m2 { get; set; }
        public double Radius_m { get; set; }
        public double? LeftSideDiameterLineAngle_deg { get; set; }
        public double? CircleCenterLatitude { get; set; }
        public double? CircleCenterLongitude { get; set; }
        public bool FixLength { get; set; }
        public bool FixWidth { get; set; }
        public double RectLength_m { get; set; }
        public double RectWidth_m { get; set; }
        public double? LeftSideLineAngle_deg { get; set; }
        public double? LeftSideLineStartLatitude { get; set; }
        public double? LeftSideLineStartLongitude { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual BoxModels BoxModel { get; set; }
    }
}
