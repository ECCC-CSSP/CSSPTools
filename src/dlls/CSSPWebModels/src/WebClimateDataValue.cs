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
    public partial class WebClimateDataValue : WebBase
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
