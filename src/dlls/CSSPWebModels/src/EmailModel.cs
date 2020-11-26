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
    public partial class EmailModel : WebBase
    {
        #region Properties
        public Email Email { get; set; }
        #endregion Properties

        #region Constructors
        public EmailModel()
        {
            Email = new Email();
        }
        #endregion Constructors
    }
}
