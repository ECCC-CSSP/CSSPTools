/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebHydrometricSite
    {
        #region Properties
        public List<HydrometricSite> HydrometricSiteList { get; set; }
        public List<WebBase> TVItemHydrometricSiteList { get; set; }

        public List<RatingCurve> RatingCurveList { get; set; }
        public List<RatingCurveValue> RatingCurveValueList { get; set; }
        #endregion Properties

        #region Constructors
        public WebHydrometricSite()
        {
            HydrometricSiteList = new List<HydrometricSite>();
            TVItemHydrometricSiteList = new List<WebBase>();

            RatingCurveList = new List<RatingCurve>();
            RatingCurveValueList = new List<RatingCurveValue>();
        }
        #endregion Constructors
    }
}
