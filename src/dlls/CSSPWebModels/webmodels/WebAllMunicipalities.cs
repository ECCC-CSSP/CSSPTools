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
        public List<AllMunicipalityModel> AllMunicipalityModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllMunicipalities()
        {
            AllMunicipalityModelList = new List<AllMunicipalityModel>();
        }
        #endregion Constructors
    }
}
