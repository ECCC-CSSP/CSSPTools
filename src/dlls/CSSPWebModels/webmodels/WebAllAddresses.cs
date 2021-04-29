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
    public partial class WebAllAddresses
    {
        #region Properties
        public List<AddressModel> AddressModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllAddresses()
        {
            AddressModelList = new List<AddressModel>();
        }
        #endregion Constructors
    }
}
