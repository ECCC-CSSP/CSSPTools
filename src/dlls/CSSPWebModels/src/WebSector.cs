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
    public partial class WebSector
    {
        #region Properties
        public List<TVItem> TVItemList { get; set; }
        public List<TVItemLanguage> TVItemLanguageList { get; set; }
        public List<TVItemStat> TVItemStatList { get; set; }
        public List<MapInfo> MapInfoList { get; set; }
        public List<MapInfoPoint> MapInfoPointList { get; set; }
        #endregion Properties

        #region Constructors
        public WebSector()
        {
            TVItemList = new List<TVItem>();
            TVItemStatList = new List<TVItemStat>();
            TVItemStatList = new List<TVItemStat>();
            MapInfoList = new List<MapInfo>();
            MapInfoPointList = new List<MapInfoPoint>();
        }
        #endregion Constructors
    }
}
