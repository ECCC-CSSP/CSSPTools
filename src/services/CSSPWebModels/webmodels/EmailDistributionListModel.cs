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
    public partial class EmailDistributionListModel
    {
        #region Properties
        public EmailDistributionList EmailDistributionList { get; set; }
        public List<EmailDistributionListLanguage> EmailDistributionListLanguageList { get; set; }
        public List<EmailDistributionListContactModel> EmailDistributionListContactModelList { get; set; }
        #endregion Properties

        #region Constructors
        public EmailDistributionListModel()
        {
            EmailDistributionList = new EmailDistributionList();
            EmailDistributionListLanguageList = new List<EmailDistributionListLanguage>();
            EmailDistributionListContactModelList = new List<EmailDistributionListContactModel>();
        }
        #endregion Constructors
    }
}
