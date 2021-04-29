/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebAllProvinces
    {
        #region Properties
        public List<ProvinceModel> ProvinceModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllProvinces()
        {
            ProvinceModelList = new List<ProvinceModel>();
        }
        #endregion Constructors
    }
}
