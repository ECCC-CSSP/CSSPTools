/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebArea : WebBase
    {
        #region Properties
        public List<TVItem> TVItemSectorList { get; set; }
        public List<TVItemLanguage> TVItemLanguageSectorList { get; set; }
        public List<TVItemStat> TVItemStatSectorList { get; set; }
        public List<MapInfo> MapInfoSectorList { get; set; }
        public List<MapInfoPoint> MapInfoPointSectorList { get; set; }
        #endregion Properties

        #region Constructors
        public WebArea()
        {
            TVItemSectorList = new List<TVItem>();
            TVItemLanguageSectorList = new List<TVItemLanguage>();
            TVItemStatSectorList = new List<TVItemStat>();
            MapInfoSectorList = new List<MapInfo>();
            MapInfoPointSectorList = new List<MapInfoPoint>();
        }
        #endregion Constructors
    }
}
