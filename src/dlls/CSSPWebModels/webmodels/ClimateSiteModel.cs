/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class ClimateSiteModel
    {
        #region Properties
        public TVItemMapModel TVItemMapModel { get; set; }
        public ClimateSite ClimateSite { get; set; }
        public List<ClimateDataValue> ClimateDataValueList { get; set; }
        #endregion Properties

        #region Constructors
        public ClimateSiteModel()
        {
            TVItemMapModel = new TVItemMapModel();
            ClimateSite = new ClimateSite();
            ClimateDataValueList = new List<ClimateDataValue>();
        }
        #endregion Constructors
    }
}
