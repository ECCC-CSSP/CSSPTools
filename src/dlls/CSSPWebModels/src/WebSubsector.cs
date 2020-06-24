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
    public partial class WebSubsector : WebBase
    {
        #region Properties
        public List<TVItem> TVItemMWQMSiteList { get; set; }
        public List<TVItemLanguage> TVItemLanguageMWQMSiteList { get; set; }
        public List<TVItemStat> TVItemStatMWQMSiteList { get; set; }
        public List<MapInfo> MapInfoMWQMSiteList { get; set; }
        public List<MapInfoPoint> MapInfoPointMWQMSiteList { get; set; }

        public List<TVItem> TVItemMWQMRunList { get; set; }
        public List<TVItemLanguage> TVItemLanguageMWQMRunList { get; set; }
        public List<TVItemStat> TVItemStatMWQMRunList { get; set; }

        public List<TVItem> TVItemPolSourceSiteList { get; set; }
        public List<TVItemLanguage> TVItemLanguagePolSourceSiteList { get; set; }
        public List<TVItemStat> TVItemStatPolSourceSiteList { get; set; }
        public List<MapInfo> MapInfoPolSourceSiteList { get; set; }
        public List<MapInfoPoint> MapInfoPointPolSourceSiteList { get; set; }
        #endregion Properties

        #region Constructors
        public WebSubsector()
        {
            TVItemMWQMSiteList = new List<TVItem>();
            TVItemLanguageMWQMSiteList = new List<TVItemLanguage>();
            TVItemStatMWQMSiteList = new List<TVItemStat>();
            MapInfoMWQMSiteList = new List<MapInfo>();
            MapInfoPointMWQMSiteList = new List<MapInfoPoint>();

            TVItemMWQMRunList = new List<TVItem>();
            TVItemLanguageMWQMRunList = new List<TVItemLanguage>();
            TVItemStatMWQMRunList = new List<TVItemStat>();

            TVItemPolSourceSiteList = new List<TVItem>();
            TVItemLanguagePolSourceSiteList = new List<TVItemLanguage>();
            TVItemStatPolSourceSiteList = new List<TVItemStat>();
            MapInfoPolSourceSiteList = new List<MapInfo>();
            MapInfoPointPolSourceSiteList = new List<MapInfoPoint>();
        }
        #endregion Constructors
    }
}
