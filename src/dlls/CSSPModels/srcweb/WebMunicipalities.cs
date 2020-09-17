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
        public List<WebBase> TVItemParentList { get; set; }
        public List<WebBase> TVItemMunicipalityList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMunicipalities()
        {
            TVItemParentList = new List<WebBase>();
            TVItemMunicipalityList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
