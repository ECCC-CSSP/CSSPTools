/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
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

    [NotMapped]
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

    [NotMapped]
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

    [NotMapped]
    public partial class TVFileModel
    {
        public int ParentTVItemID { get; set; }
        public TVFile TVFile { get; set; }
        public TVFileLanguage TVFileLanguageEN { get; set; }
        public TVFileLanguage TVFileLanguageFR { get; set; }

        public TVFileModel()
        {
            ParentTVItemID = 0;
            TVFile = new TVFile();
            TVFileLanguageEN = new TVFileLanguage();
            TVFileLanguageFR = new TVFileLanguage();
        }
    }
}
