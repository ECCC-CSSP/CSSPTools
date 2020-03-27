using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class DrogueRuns
    {
        public DrogueRuns()
        {
            DrogueRunPositions = new HashSet<DrogueRunPositions>();
        }

        public int DrogueRunID { get; set; }
        public int SubsectorTVItemID { get; set; }
        public int DrogueNumber { get; set; }
        public int DrogueType { get; set; }
        public DateTime RunStartDateTime { get; set; }
        public bool IsRisingTide { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems SubsectorTVItem { get; set; }
        public virtual ICollection<DrogueRunPositions> DrogueRunPositions { get; set; }
    }
}
