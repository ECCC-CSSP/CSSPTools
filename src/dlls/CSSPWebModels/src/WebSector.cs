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
    public partial class WebSector : WebBase
    {
        #region Properties
        public List<TVItem> TVItemSubsectorList { get; set; }
        public List<TVItemLanguage> TVItemLanguageSubsectorList { get; set; }
        public List<TVItemStat> TVItemStatSubsectorList { get; set; }
        public List<MapInfo> MapInfoSubsectorList { get; set; }
        public List<MapInfoPoint> MapInfoPointSubsectorList { get; set; }
        
        public List<TVItem> TVItemMikeScenarioList { get; set; }
        public List<TVItemLanguage> TVItemLanguageMikeScenarioList { get; set; }
        public List<TVItemStat> TVItemStatMikeScenarioList { get; set; }
        public List<MapInfo> MapInfoMikeScenarioList { get; set; }
        public List<MapInfoPoint> MapInfoPointMikeScenarioList { get; set; }
        #endregion Properties

        #region Constructors
        public WebSector()
        {
            TVItemSubsectorList = new List<TVItem>();
            TVItemLanguageSubsectorList = new List<TVItemLanguage>();
            TVItemStatSubsectorList = new List<TVItemStat>();
            MapInfoSubsectorList = new List<MapInfo>();
            MapInfoPointSubsectorList = new List<MapInfoPoint>();
            
            TVItemMikeScenarioList = new List<TVItem>();
            TVItemLanguageMikeScenarioList = new List<TVItemLanguage>();
            TVItemStatMikeScenarioList = new List<TVItemStat>();
            MapInfoMikeScenarioList = new List<MapInfo>();
            MapInfoPointMikeScenarioList = new List<MapInfoPoint>();
        }
        #endregion Constructors
    }
}
