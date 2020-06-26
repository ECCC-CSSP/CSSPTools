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
