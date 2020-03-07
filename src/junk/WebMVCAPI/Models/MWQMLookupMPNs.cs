using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class MWQMLookupMPNs
    {
        public int MWQMLookupMPNID { get; set; }
        public int Tubes10 { get; set; }
        public int Tubes1 { get; set; }
        public int Tubes01 { get; set; }
        public int MPN_100ml { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    }
}
