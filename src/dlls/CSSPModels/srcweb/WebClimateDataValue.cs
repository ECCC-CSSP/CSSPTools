/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebClimateDataValue
    {
        #region Properties
        public List<ClimateDataValue> ClimateDataValueList { get; set; }
        #endregion Properties

        #region Constructors
        public WebClimateDataValue()
        {
            ClimateDataValueList = new List<ClimateDataValue>();
        }
        #endregion Constructors
    }
}
