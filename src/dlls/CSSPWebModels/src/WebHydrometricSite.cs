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
        public List<TVItem> TVItemList { get; set; }
        public List<TVItemLanguage> TVItemLanguageList { get; set; }
        public List<MapInfo> MapInfoList { get; set; }
        public List<MapInfoPoint> MapInfoPointList { get; set; }
        public List<RatingCurve> RatingCurveList { get; set; }
        public List<RatingCurveValue> RatingCurveValueList { get; set; }
        #endregion Properties

        #region Constructors
        public WebHydrometricSite()
        {
            HydrometricSiteList = new List<HydrometricSite>();
            TVItemList = new List<TVItem>();
            TVItemLanguageList = new List<TVItemLanguage>();
            MapInfoList = new List<MapInfo>();
            MapInfoPointList = new List<MapInfoPoint>();
            RatingCurveList = new List<RatingCurve>();
            RatingCurveValueList = new List<RatingCurveValue>();
        }
        #endregion Constructors
    }
}
