﻿/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebCountry : WebBase
    {
        #region Properties
        public List<WebBase> TVItemProvinceList { get; set; }

        public List<EmailDistributionList> EmailDistributionListList { get; set; }
        public List<EmailDistributionListLanguage> EmailDistributionListLanguageList { get; set; }
        public List<EmailDistributionListContact> EmailDistributionListContactList { get; set; }
        public List<EmailDistributionListContactLanguage> EmailDistributionListContactLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public WebCountry()
        {
            TVItemProvinceList = new List<WebBase>();

            EmailDistributionListList = new List<EmailDistributionList>();
            EmailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
            EmailDistributionListContactList = new List<EmailDistributionListContact>();
            EmailDistributionListContactLanguageList = new List<EmailDistributionListContactLanguage>();
        }
        #endregion Constructors
    }
}
