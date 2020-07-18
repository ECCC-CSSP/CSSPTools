/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebRoot : WebBase
    {
        #region Properties
        public List<TVItem> TVItemCountryList { get; set; }
        public List<TVItemLanguage> TVItemLanguageCountryList { get; set; }
        public List<TVItemStat> TVItemStatCountryList { get; set; }
        public List<MapInfo> MapInfoCountryList { get; set; }
        public List<MapInfoPoint> MapInfoPointCountryList { get; set; }
        #endregion Properties

        #region Constructors
        public WebRoot() : base()
        {
            TVItemCountryList = new List<TVItem>();
            TVItemLanguageCountryList = new List<TVItemLanguage>();
            TVItemStatCountryList = new List<TVItemStat>();
            MapInfoCountryList = new List<MapInfo>();
            MapInfoPointCountryList = new List<MapInfoPoint>();
        }
        #endregion Constructors
    }
}
