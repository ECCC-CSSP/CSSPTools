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
    public partial class WebCountry : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<WebBase> TVItemProvinceList { get; set; }
        public List<WebBase> TVItemRainExceedanceList { get; set; }
        public List<EmailDistributionList> EmailDistributionListList { get; set; }
        public List<EmailDistributionListLanguage> EmailDistributionListLanguageList { get; set; }
        public List<EmailDistributionListContact> EmailDistributionListContactList { get; set; }
        public List<EmailDistributionListContactLanguage> EmailDistributionListContactLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public WebCountry()
        {
            TVItemParentList = new List<WebBase>();
            TVItemProvinceList = new List<WebBase>();
            TVItemRainExceedanceList = new List<WebBase>();
            EmailDistributionListList = new List<EmailDistributionList>();
            EmailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
            EmailDistributionListContactList = new List<EmailDistributionListContact>();
            EmailDistributionListContactLanguageList = new List<EmailDistributionListContactLanguage>();
        }
        #endregion Constructors
    }
}
