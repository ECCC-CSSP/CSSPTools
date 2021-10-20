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
    public partial class ContactModel
    {
        #region Properties
        public Contact Contact { get; set; }
        public List<int> ContactEmailTVItemIDList { get; set; }
        public List<int> ContactTelTVItemIDList { get; set; }
        public List<int> ContactAddressTVItemIDList { get; set; }
        #endregion Properties

        #region Constructors
        public ContactModel()
        {
            Contact = new Contact();
            ContactEmailTVItemIDList = new List<int>();
            ContactTelTVItemIDList = new List<int>();
            ContactAddressTVItemIDList = new List<int>();
        }
        #endregion Constructors
    }
}
