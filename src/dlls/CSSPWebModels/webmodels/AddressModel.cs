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
        public TVItemModel TVItemModel { get; set; }
        public Address Address { get; set; }
        #endregion Properties

        #region Constructors
        public AddressModel()
        {
            TVItemModel = new TVItemModel();
            Address = new Address();
        }
        #endregion Constructors
    }
}
