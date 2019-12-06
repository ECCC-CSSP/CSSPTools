using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSSPEnumsDLL.Enums;

namespace CSSPModelsDLL.Models
{
    public class SamplingPlanEmailModel : LastUpdateAndContactModel
    {
        public SamplingPlanEmailModel()
        {
        }

        public int SamplingPlanEmailID { get; set; }
        public int SamplingPlanID { get; set; }
        public string Email { get; set; }
        public bool IsContractor { get; set; }
        public bool LabSheetHasValueOver500 { get; set; }
        public bool LabSheetReceived { get; set; }
        public bool LabSheetAccepted { get; set; }
        public bool LabSheetRejected { get; set; }
    }


}
