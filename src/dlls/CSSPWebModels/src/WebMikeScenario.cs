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
    public partial class WebMikeScenario : WebBase
    {
        #region Properties
        public MikeScenario MikeScenario { get; set; }

        public List<MikeBoundaryCondition> MikeBoundaryConditionList { get; set; }
        public List<TVItem> TVItemMikeBoundaryConditionList { get; set; }
        public List<TVItemLanguage> TVItemLanguageMikeBoundaryConditionList { get; set; }
        public List<TVItemStat> TVItemStatMikeBoundaryConditionList { get; set; }
        public List<MapInfo> MapInfoMikeBoundaryConditionList { get; set; }
        public List<MapInfoPoint> MapInfoPointMikeBoundaryConditionList { get; set; }

        public List<MikeSource> MikeSourceList { get; set; }
        public List<TVItem> TVItemMikeSourceList { get; set; }
        public List<TVItemLanguage> TVItemLanguageMikeSourceList { get; set; }
        public List<TVItemStat> TVItemStatMikeSourceList { get; set; }
        public List<MapInfo> MapInfoMikeSourceList { get; set; }
        public List<MapInfoPoint> MapInfoPointMikeSourceList { get; set; }

        public List<MikeSourceStartEnd> MikeSourceStartEndList { get; set; }

        #endregion Properties

        #region Constructors
        public WebMikeScenario()
        {
            MikeScenario = new MikeScenario();
            MikeBoundaryConditionList = new List<MikeBoundaryCondition>();
            TVItemMikeBoundaryConditionList = new List<TVItem>();
            TVItemLanguageMikeBoundaryConditionList = new List<TVItemLanguage>();
            TVItemStatMikeBoundaryConditionList = new List<TVItemStat>();
            MapInfoMikeBoundaryConditionList = new List<MapInfo>();
            MapInfoPointMikeBoundaryConditionList = new List<MapInfoPoint>();
            MikeSourceList = new List<MikeSource>();
            TVItemMikeSourceList = new List<TVItem>();
            TVItemLanguageMikeSourceList = new List<TVItemLanguage>();
            TVItemStatMikeSourceList = new List<TVItemStat>();
            MapInfoMikeSourceList = new List<MapInfo>();
            MapInfoPointMikeSourceList = new List<MapInfoPoint>();
            MikeSourceStartEndList = new List<MikeSourceStartEnd>();
        }
        #endregion Constructors
    }
}
