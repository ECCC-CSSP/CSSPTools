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
    public partial class AddressModel : WebBase
    {
        #region Properties
        public Address Address { get; set; }
        #endregion Properties

        #region Constructors
        public AddressModel()
        {
            Address = new Address();
        }
        #endregion Constructors
    }
}
