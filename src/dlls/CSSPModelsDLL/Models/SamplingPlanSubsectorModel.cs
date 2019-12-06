using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class SamplingPlanSubsectorModel : LastUpdateAndContactModel
    {
        public SamplingPlanSubsectorModel()
        {
            SamplingPlanSubsectorSiteModelList = new List<SamplingPlanSubsectorSiteModel>();
        }

        public int SamplingPlanSubsectorID { get; set; }
        public int SamplingPlanID { get; set; }
        public int SubsectorTVItemID { get; set; }
        public string SubsectorTVText { get; set; }
        public List<SamplingPlanSubsectorSiteModel> SamplingPlanSubsectorSiteModelList { get; set; }
        public int SiteCount { get; set; }
    }
}
