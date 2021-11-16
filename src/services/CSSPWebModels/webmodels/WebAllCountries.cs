/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebAllCountries
    {
        #region Properties
        public List<TVItemModel> TVItemModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllCountries()
        {
            TVItemModelList = new List<TVItemModel>();
        }
        #endregion Constructors
    }
}
