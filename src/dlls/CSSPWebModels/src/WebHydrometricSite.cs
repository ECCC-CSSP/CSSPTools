/*
 * Manually edited
 * 
 */
using CSSPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPWebModels
{
    public partial class WebHydrometricSite
    {
        #region Properties
        public List<HydrometricSite> HydrometricSiteList { get; set; }
        public List<RatingCurve> RatingCurveList { get; set; }
        public List<RatingCurveValue> RatingCurveValueList { get; set; }
        #endregion Properties

        #region Constructors
        public WebHydrometricSite()
        {
            HydrometricSiteList = new List<HydrometricSite>();
            RatingCurveList = new List<RatingCurve>();
            RatingCurveValueList = new List<RatingCurveValue>();
        }
        #endregion Constructors
    }
}
