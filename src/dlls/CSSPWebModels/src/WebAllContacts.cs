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
        public List<Contact> ContactList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllContacts()
        {
            ContactList = new List<Contact>();
        }
        #endregion Constructors
    }
}
