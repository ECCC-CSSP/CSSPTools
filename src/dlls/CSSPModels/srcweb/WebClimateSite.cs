/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebClimateSite
    {
        #region Properties
        public List<ClimateSite> ClimateSiteList { get; set; }
        public List<TVItem> TVItemList { get; set; }
        public List<TVItemLanguage> TVItemLanguageList { get; set; }
        public List<MapInfo> MapInfoList { get; set; }
        public List<MapInfoPoint> MapInfoPointList { get; set; }
        #endregion Properties

        #region Constructors
        public WebClimateSite()
        {
            ClimateSiteList = new List<ClimateSite>();
            TVItemList = new List<TVItem>();
            TVItemLanguageList = new List<TVItemLanguage>();
            MapInfoList = new List<MapInfo>();
            MapInfoPointList = new List<MapInfoPoint>();
        }
        #endregion Constructors
    }
}
