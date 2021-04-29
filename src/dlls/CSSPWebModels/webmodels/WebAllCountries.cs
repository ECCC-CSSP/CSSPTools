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
        public List<CountryModel> CountryModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllCountries()
        {
            CountryModelList = new List<CountryModel>();
        }
        #endregion Constructors
    }
}
