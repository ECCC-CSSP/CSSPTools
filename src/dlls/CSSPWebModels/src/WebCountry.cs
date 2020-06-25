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
    public partial class WebCountry : WebBase
    {
        #region Properties
        public TVItem TVItemCountry { get; set; }
        public List<TVItemLanguage> TVItemLanguageCountryList { get; set; }
        public List<TVItem> TVItemProvinceList { get; set; }
        public List<TVItemLanguage> TVItemLanguageProvinceList { get; set; }
        public List<TVItemStat> TVItemStatProvinceList { get; set; }
        public List<MapInfo> MapInfoProvinceList { get; set; }
        public List<MapInfoPoint> MapInfoPointProvinceList { get; set; }
        #endregion Properties

        #region Constructors
        public WebCountry()
        {
            TVItemCountry = new TVItem();
            TVItemLanguageCountryList = new List<TVItemLanguage>();
            TVItemProvinceList = new List<TVItem>();
            TVItemLanguageProvinceList = new List<TVItemLanguage>();
            TVItemStatProvinceList = new List<TVItemStat>();
            MapInfoProvinceList = new List<MapInfo>();
            MapInfoPointProvinceList = new List<MapInfoPoint>();
        }
        #endregion Constructors
    }
}
