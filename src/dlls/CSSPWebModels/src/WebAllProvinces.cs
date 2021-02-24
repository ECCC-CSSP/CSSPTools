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
        public List<WebBase> TVItemAllProvinceList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllProvinces()
        {
            TVItemAllProvinceList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
