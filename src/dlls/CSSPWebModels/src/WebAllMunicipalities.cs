/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebAllMunicipalities
    {
        #region Properties
        public List<WebBase> TVItemAllMunicipalityList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllMunicipalities()
        {
            TVItemAllMunicipalityList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
