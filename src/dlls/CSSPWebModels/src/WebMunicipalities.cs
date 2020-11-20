/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebMunicipalities : WebBase
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
