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
        public List<TVModel> TVModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllCountries()
        {
            TVModelList = new List<TVModel>();
        }
        #endregion Constructors
    }
}
