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
    public partial class AddressModel
    {
        #region Properties
        public TVItem TVItem { get; set; }
        public List<TVItemLanguage> TVItemLanguageList { get; set; }
        public Address Address { get; set; }
        #endregion Properties

        #region Constructors
        public AddressModel()
        {
            TVItem = new TVItem();
            TVItemLanguageList = new List<TVItemLanguage>();
            Address = new Address();
        }
        #endregion Constructors
    }
}
