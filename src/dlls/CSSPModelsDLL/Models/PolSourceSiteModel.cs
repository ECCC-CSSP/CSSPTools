using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class PolSourceSiteModel : LastUpdateAndContactModel
    {
        public PolSourceSiteModel()
        {
            PolSourceObservationModelList = new List<PolSourceObservationModel>();
        }
        public int PolSourceSiteID { get; set; }
        public int PolSourceSiteTVItemID { get; set; }
        public string PolSourceSiteTVText { get; set; }
        public string Temp_Locator_CanDelete { get; set; }
        public Nullable<int> Oldsiteid { get; set; }
        public Nullable<int> Site { get; set; }
        public Nullable<int> SiteID { get; set; }
        public List<PolSourceObservationModel> PolSourceObservationModelList { get; set; }
        public bool IsPointSource { get; set; }
        public PolSourceInactiveReasonEnum? InactiveReason { get; set; }
        public Nullable<int> CivicAddressTVItemID { get; set; }
    }
}
