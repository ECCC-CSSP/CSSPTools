using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class PolSourceObservationIssueModel : LastUpdateAndContactModel
    {
        public PolSourceObservationIssueModel()
        {
            PolSourceObsInfoList = new List<PolSourceObsInfoEnum>();
        }
        public int PolSourceObservationIssueID { get; set; }
        public int PolSourceObservationID { get; set; }
        public string ObservationInfo { get; set; }
        public int Ordinal { get; set; }
        public string ExtraComment { get; set; }
        public List<PolSourceObsInfoEnum> PolSourceObsInfoList { get; set; }
    }
}
