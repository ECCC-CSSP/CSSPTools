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
    public partial class WebMunicipalities
    {
        #region Properties
        public List<TVItem> TVItemList { get; set; }
        public List<TVItemLanguage> TVItemLanguageList { get; set; }
        public List<TVItemStat> TVItemStatList { get; set; }
        public List<MapInfo> MapInfoList { get; set; }
        public List<MapInfoPoint> MapInfoPointList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMunicipalities()
        {
            TVItemList = new List<TVItem>();
            TVItemLanguageList = new List<TVItemLanguage>();
            TVItemStatList = new List<TVItemStat>();
            MapInfoList = new List<MapInfo>();
            MapInfoPointList = new List<MapInfoPoint>();
        }
        #endregion Constructors
    }
}
