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
        public List<WebBase> TVItemAllCountryList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllCountries()
        {
            TVItemAllCountryList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
