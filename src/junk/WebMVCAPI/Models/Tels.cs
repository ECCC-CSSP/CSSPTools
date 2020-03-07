using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class Tels
    {
        public int TelID { get; set; }
        public int TelTVItemID { get; set; }
        public string TelNumber { get; set; }
        public int TelType { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems TelTVItem { get; set; }
    }
}
