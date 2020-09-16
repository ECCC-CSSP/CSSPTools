/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebMunicipalities
    {
        #region Properties
        public List<WebBase> TVItemMunicipalityList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMunicipalities()
        {
            TVItemMunicipalityList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
