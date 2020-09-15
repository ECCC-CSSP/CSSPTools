﻿/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebBase
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        #endregion Properties

        #region Constructors
        public WebBase()
        {
            TVItemModel = new TVItemModel();
        }
        #endregion Constructors
    }

    public partial class TVItemModel
    {
        public TVItem TVItem { get; set; }
        public TVItemLanguage TVItemLanguageEN { get; set; }
        public TVItemLanguage TVItemLanguageFR { get; set; }
        public List<TVItemStat> TVItemStatList { get; set; }
        public List<MapInfoModel> MapInfoModelList { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }

        public TVItemModel()
        {
            TVItem = new TVItem();
            TVItemLanguageEN = new TVItemLanguage();
            TVItemLanguageFR = new TVItemLanguage();
            TVItemStatList = new List<TVItemStat>();
            MapInfoModelList = new List<MapInfoModel>();
            TVFileModelList = new List<TVFileModel>();
        }
    }

    public partial class MapInfoModel
    {
        public MapInfo MapInfo { get; set; }
        public List<MapInfoPoint> MapInfoPointList { get; set; }

        public MapInfoModel()
        {
            MapInfo = new MapInfo();
            MapInfoPointList = new List<MapInfoPoint>();
        }
    }

    public partial class TVFileModel
    {
        public TVFile TVFile { get; set; }
        public TVFileLanguage TVFileLanguageEN { get; set; }
        public TVFileLanguage TVFileLanguageFR { get; set; }

        public TVFileModel()
        {
            TVFile = new TVFile();
            TVFileLanguageEN = new TVFileLanguage();
            TVFileLanguageFR = new TVFileLanguage();
        }
    }
}
