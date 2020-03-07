using System;
using System.Collections.Generic;

namespace WebMVCAPI.Models
{
    public partial class DrogueRunPositions
    {
        public int DrogueRunPositionID { get; set; }
        public int DrogueRunID { get; set; }
        public int Ordinal { get; set; }
        public double StepLat { get; set; }
        public double StepLng { get; set; }
        public DateTime StepDateTime_Local { get; set; }
        public double CalculatedSpeed_m_s { get; set; }
        public double CalculatedDirection_deg { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual DrogueRuns DrogueRun { get; set; }
    }
}
