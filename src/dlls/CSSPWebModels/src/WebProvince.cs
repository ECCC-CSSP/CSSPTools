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
    public partial class WebProvince : WebBase
    {
        #region Properties
        public List<TVItem> TVItemAreaList { get; set; }
        public List<TVItemLanguage> TVItemLanguageAreaList { get; set; }
        public List<TVItemStat> TVItemStatAreaList { get; set; }
        public List<MapInfo> MapInfoAreaList { get; set; }
        public List<MapInfoPoint> MapInfoPointAreaList { get; set; }

        public List<SamplingPlan> SamplingPlanList { get; set; }
        #endregion Properties

        #region Constructors
        public WebProvince()
        {
            TVItemAreaList = new List<TVItem>();
            TVItemLanguageAreaList = new List<TVItemLanguage>();
            TVItemStatAreaList = new List<TVItemStat>();
            MapInfoAreaList = new List<MapInfo>();
            MapInfoPointAreaList = new List<MapInfoPoint>();

            SamplingPlanList = new List<SamplingPlan>();
        }
        #endregion Constructors
    }
}
