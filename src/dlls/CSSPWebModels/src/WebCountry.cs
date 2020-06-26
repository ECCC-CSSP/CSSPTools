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
        public List<TVItem> TVItemProvinceList { get; set; }
        public List<TVItemLanguage> TVItemLanguageProvinceList { get; set; }
        public List<TVItemStat> TVItemStatProvinceList { get; set; }
        public List<MapInfo> MapInfoProvinceList { get; set; }
        public List<MapInfoPoint> MapInfoPointProvinceList { get; set; }
        public List<EmailDistributionList> EmailDistributionListList { get; set; }
        public List<EmailDistributionListLanguage> EmailDistributionListLanguageList { get; set; }
        public List<EmailDistributionListContact> EmailDistributionListContactList { get; set; }
        public List<EmailDistributionListContactLanguage> EmailDistributionListContactLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public WebCountry()
        {
            TVItemProvinceList = new List<TVItem>();
            TVItemLanguageProvinceList = new List<TVItemLanguage>();
            TVItemStatProvinceList = new List<TVItemStat>();
            MapInfoProvinceList = new List<MapInfo>();
            MapInfoPointProvinceList = new List<MapInfoPoint>();
            EmailDistributionListList = new List<EmailDistributionList>();
            EmailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
            EmailDistributionListContactList = new List<EmailDistributionListContact>();
            EmailDistributionListContactLanguageList = new List<EmailDistributionListContactLanguage>();
        }
        #endregion Constructors
    }
}
