using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class LabSheetModel : LastUpdateAndContactModel
    {
        public LabSheetModel()
        {
        }

        public int LabSheetID { get; set; }
        public int OtherServerLabSheetID { get; set; }
        public int SamplingPlanID { get; set; }
        public string SamplingPlanName { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int RunNumber { get; set; }
        public int SubsectorTVItemID { get; set; }
        public string SubsectorTVText { get; set; }
        public Nullable<int> MWQMRunTVItemID { get; set; }
        public string MWQMRunTVText { get; set; }
        public SamplingPlanTypeEnum SamplingPlanType { get; set; }
        public SampleTypeEnum SampleType { get; set; }
        public LabSheetTypeEnum LabSheetType { get; set; }
        public LabSheetStatusEnum LabSheetStatus { get; set; }
        public string FileName { get; set; }
        public DateTime FileLastModifiedDate_Local { get; set; }
        public string FileContent { get; set; }
        public Nullable<int> AcceptedOrRejectedByContactTVItemID {get; set;}
        public string AcceptedOrRejectedByContactTVText { get; set; }
        public Nullable<DateTime> AcceptedOrRejectedDateTime { get; set; }
        public string RejectReason { get; set; }
    }


}
