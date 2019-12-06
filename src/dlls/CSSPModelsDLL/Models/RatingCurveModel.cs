using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class RatingCurveModel : LastUpdateAndContactModel
    {
        public RatingCurveModel()
        {
        }
        public int RatingCurveID { get; set; }
        public int HydrometricSiteID { get; set; }
        public string HydrometricSiteTVText { get; set; }
        public string RatingCurveNumber { get; set; }
    }
}
