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
    public partial class WebAllContacts
    {
        #region Properties
        public List<ContactModel> ContactModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllContacts()
        {
            ContactModelList = new List<ContactModel>();
        }
        #endregion Constructors
    }
}
