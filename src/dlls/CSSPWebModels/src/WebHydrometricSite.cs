/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebHydrometricSite
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<HydrometricSite> HydrometricSiteList { get; set; }
        public List<WebBase> TVItemHydrometricSiteList { get; set; }
        public List<RatingCurve> RatingCurveList { get; set; }
        public List<RatingCurveValue> RatingCurveValueList { get; set; }
        #endregion Properties

        #region Constructors
        public WebHydrometricSite()
        {
            TVItemParentList = new List<WebBase>();
            HydrometricSiteList = new List<HydrometricSite>();
            TVItemHydrometricSiteList = new List<WebBase>();
            RatingCurveList = new List<RatingCurve>();
            RatingCurveValueList = new List<RatingCurveValue>();
        }
        #endregion Constructors
    }
}
