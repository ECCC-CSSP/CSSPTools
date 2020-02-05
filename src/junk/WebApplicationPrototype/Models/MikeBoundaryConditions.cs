using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class MikeBoundaryConditions
    {
        public int MikeBoundaryConditionID { get; set; }
        public int MikeBoundaryConditionTVItemID { get; set; }
        public string MikeBoundaryConditionCode { get; set; }
        public string MikeBoundaryConditionName { get; set; }
        public double MikeBoundaryConditionLength_m { get; set; }
        public string MikeBoundaryConditionFormat { get; set; }
        public int MikeBoundaryConditionLevelOrVelocity { get; set; }
        public int WebTideDataSet { get; set; }
        public int NumberOfWebTideNodes { get; set; }
        public string WebTideDataFromStartToEndDate { get; set; }
        public int TVType { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems MikeBoundaryConditionTVItem { get; set; }
    }
}
