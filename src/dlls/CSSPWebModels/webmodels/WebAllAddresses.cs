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
        public List<WebBase> TVItemAllAddressList { get; set; }

        public List<Address> AddressList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllAddresses()
        {
            TVItemAllAddressList = new List<WebBase>();
            AddressList = new List<Address>();
        }
        #endregion Constructors
    }
}
