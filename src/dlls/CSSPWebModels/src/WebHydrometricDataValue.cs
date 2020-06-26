/*
 * Manually edited
 * 
 */
using CSSPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPWebModels
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
