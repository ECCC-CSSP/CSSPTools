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
    public partial class EmailDistributionListContactModel
    {
        #region Properties
        public EmailDistributionListContact EmailDistributionListContact { get; set; }
        public List<EmailDistributionListContactLanguage> EmailDistributionListContactLanguageList { get; set; }

        #endregion Properties

        #region Constructors
        public EmailDistributionListContactModel()
        {
            EmailDistributionListContact = EmailDistributionListContact;
            EmailDistributionListContactLanguageList = new List<EmailDistributionListContactLanguage>();
        }
        #endregion Constructors
    }
}
