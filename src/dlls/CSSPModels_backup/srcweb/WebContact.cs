/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPModels
{
    [NotMapped]
    public partial class WebContact
    {
        #region Properties
        public List<Contact> ContactList { get; set; }
        #endregion Properties

        #region Constructors
        public WebContact()
        {
            ContactList = new List<Contact>();
        }
        #endregion Constructors
    }
}
