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
    public partial class WebAllEmails
    {
        #region Properties
        public List<EmailModel> EmailModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllEmails()
        {
            EmailModelList = new List<EmailModel>();
        }
        #endregion Constructors
    }
}
