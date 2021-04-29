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
        public TVItem TVItem { get; set; }
        public List<TVItemLanguage> TVItemLanguageList { get; set; }
        public List<EmailModel> ContactEmailModelList { get; set; }
        public List<TelModel> ContactTelModelList { get; set; }
        public List<AddressModel> ContactAddressModelList { get; set; }
        #endregion Properties

        #region Constructors
        public ContactModel()
        {
            Contact = new Contact();
            TVItem = new TVItem();
            TVItemLanguageList = new List<TVItemLanguage>();
            ContactEmailModelList = new List<EmailModel>();
            ContactTelModelList = new List<TelModel>();
            ContactAddressModelList = new List<AddressModel>();
        }
        #endregion Constructors
    }
}
