using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class MWQMSamples
    {
        public MWQMSamples()
        {
            MWQMSampleLanguages = new HashSet<MWQMSampleLanguages>();
        }

        public int MWQMSampleID { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        public int MWQMRunTVItemID { get; set; }
        public DateTime SampleDateTime_Local { get; set; }
        public string TimeText { get; set; }
        public double? Depth_m { get; set; }
        public int FecCol_MPN_100ml { get; set; }
        public double? Salinity_PPT { get; set; }
        public double? WaterTemp_C { get; set; }
        public double? PH { get; set; }
        public string SampleTypesText { get; set; }
        public int? SampleType_old { get; set; }
        public int? Tube_10 { get; set; }
        public int? Tube_1_0 { get; set; }
        public int? Tube_0_1 { get; set; }
        public string ProcessedBy { get; set; }
        public bool UseForOpenData { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems MWQMRunTVItem { get; set; }
        public virtual TVItems MWQMSiteTVItem { get; set; }
        public virtual ICollection<MWQMSampleLanguages> MWQMSampleLanguages { get; set; }
    }
}
