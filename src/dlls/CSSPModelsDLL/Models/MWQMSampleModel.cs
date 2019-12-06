using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class MWQMSampleModel : LastUpdateAndContactModel
    {
        public MWQMSampleModel()
        {
        }
        public int MWQMSampleID { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        public string MWQMSiteTVText { get; set; }
        public int MWQMRunTVItemID { get; set; }
        public string MWQMRunTVText { get; set; }
        public System.DateTime SampleDateTime_Local { get; set; }
        public string TimeText { get; set; }
        public Nullable<double> Depth_m { get; set; }
        public int FecCol_MPN_100ml { get; set; }
        public Nullable<double> Salinity_PPT { get; set; }
        public Nullable<double> WaterTemp_C { get; set; }
        public Nullable<double> PH { get; set; }
        public string SampleTypesText { get; set; }
        public List<SampleTypeEnum> SampleTypeList { get; set; }
        public Nullable<int> Tube_10 { get; set; }
        public Nullable<int> Tube_1_0 { get; set; }
        public Nullable<int> Tube_0_1 { get; set; }
        public string ProcessedBy { get; set;}
        public bool UseForOpenData { get; set; }
        public string MWQMSampleNote { get; set; }
    }
}
