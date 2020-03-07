using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class TVItemStats
    {
        public int TVItemStatID { get; set; }
        public int TVItemID { get; set; }
        public int TVType { get; set; }
        public int ChildCount { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems TVItem { get; set; }
    }
}
