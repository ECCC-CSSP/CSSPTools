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
        public List<TVItemModel> TVItemModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllProvinces()
        {
            TVItemModelList = new List<TVItemModel>();
        }
        #endregion Constructors
    }
}
