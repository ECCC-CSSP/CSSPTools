using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class TideLocations
    {
        public int TideLocationID { get; set; }
        public int Zone { get; set; }
        public string Name { get; set; }
        public string Prov { get; set; }
        public int sid { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    }
}
