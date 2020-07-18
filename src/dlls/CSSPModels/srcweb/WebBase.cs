/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebBase
    {
        #region Properties
        public TVItem TVItem { get; set; }
        public List<TVItemLanguage> TVItemLanguageList { get; set; }
        public List<TVItemLink> TVItemLinkList { get; set; }
        public List<TVItemStat> TVItemStatList { get; set; }
        public List<MapInfo> MapInfoList { get; set; }
        public List<MapInfoPoint> MapInfoPointList { get; set; }
        public List<TVFile> TVFileList { get; set; }
        public List<TVFileLanguage> TVFileLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public WebBase()
        {
            TVItem = new TVItem();
            TVItemLinkList = new List<TVItemLink>();
            TVItemLanguageList = new List<TVItemLanguage>();
            TVItemStatList = new List<TVItemStat>();
            MapInfoList = new List<MapInfo>();
            MapInfoPointList = new List<MapInfoPoint>();
            TVFileList = new List<TVFile>();
            TVFileLanguageList = new List<TVFileLanguage>();
        }
        #endregion Constructors
    }
}
