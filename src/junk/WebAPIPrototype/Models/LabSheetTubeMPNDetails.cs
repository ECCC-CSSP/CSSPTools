using System;
using System.Collections.Generic;

namespace WebAPIPrototype.Models
{
    public partial class LabSheetTubeMPNDetails
    {
        public int LabSheetTubeMPNDetailID { get; set; }
        public int LabSheetDetailID { get; set; }
        public int Ordinal { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        public DateTime? SampleDateTime { get; set; }
        public int? MPN { get; set; }
        public int? Tube10 { get; set; }
        public int? Tube1_0 { get; set; }
        public int? Tube0_1 { get; set; }
        public double? Salinity { get; set; }
        public double? Temperature { get; set; }
        public string ProcessedBy { get; set; }
        public int SampleType { get; set; }
        public string SiteComment { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual LabSheetDetails LabSheetDetail { get; set; }
        public virtual TVItems MWQMSiteTVItem { get; set; }
    }
}
