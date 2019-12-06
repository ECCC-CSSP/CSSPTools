using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class LabSheetTubeMPNDetailModel : LastUpdateAndContactModel
    {
        public LabSheetTubeMPNDetailModel()
        {
        }

        public int LabSheetTubeMPNDetailID { get; set; }
        public int LabSheetDetailID { get; set; }
        public int Ordinal { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        public Nullable<System.DateTime> SampleDateTime { get; set; }
        public Nullable<int> MPN { get; set; }
        public Nullable<int> Tube10 { get; set; }
        public Nullable<int> Tube1_0 { get; set; }
        public Nullable<int> Tube0_1 { get; set; }
        public Nullable<float> Salinity { get; set; }
        public Nullable<float> Temperature { get; set; }
        public string ProcessedBy { get; set; }
        public SampleTypeEnum SampleType { get; set; }
        public string SiteComment { get; set; }
    }

}
