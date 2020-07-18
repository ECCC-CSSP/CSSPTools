/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebHydrometricDataValue
    {
        #region Properties
        public List<HydrometricDataValue> HydrometricDataValueList { get; set; }
        #endregion Properties

        #region Constructors
        public WebHydrometricDataValue()
        {
            HydrometricDataValueList = new List<HydrometricDataValue>();
        }
        #endregion Constructors
    }
}
