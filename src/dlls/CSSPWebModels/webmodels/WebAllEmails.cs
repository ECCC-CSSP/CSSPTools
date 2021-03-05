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
        public List<WebBase> TVItemAllEmailList { get; set; }

        public List<Email> EmailList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllEmails()
        {
            TVItemAllEmailList = new List<WebBase>();
            EmailList = new List<Email>();
        }
        #endregion Constructors
    }
}
