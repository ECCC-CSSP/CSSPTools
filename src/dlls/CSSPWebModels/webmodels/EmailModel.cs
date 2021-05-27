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
    public partial class EmailModel
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public Email Email { get; set; }
        #endregion Properties

        #region Constructors
        public EmailModel()
        {
            TVItemModel = new TVItemModel();
            Email = new Email();
        }
        #endregion Constructors
    }
}
