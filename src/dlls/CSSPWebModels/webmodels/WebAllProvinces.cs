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
        public List<TVModel> TVModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllProvinces()
        {
            TVModelList = new List<TVModel>();
        }
        #endregion Constructors
    }
}
