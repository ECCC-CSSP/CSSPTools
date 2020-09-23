/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPModels
{
    [NotMapped]
    public partial class WebClimateDataValue
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<ClimateDataValue> ClimateDataValueList { get; set; }
        #endregion Properties

        #region Constructors
        public WebClimateDataValue()
        {
            TVItemParentList = new List<WebBase>();
            ClimateDataValueList = new List<ClimateDataValue>();
        }
        #endregion Constructors
    }
}
