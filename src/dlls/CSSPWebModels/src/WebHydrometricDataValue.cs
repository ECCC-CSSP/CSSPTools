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
    public partial class WebHydrometricDataValue : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<HydrometricDataValue> HydrometricDataValueList { get; set; }
        #endregion Properties

        #region Constructors
        public WebHydrometricDataValue()
        {
            TVItemParentList = new List<WebBase>();
            HydrometricDataValueList = new List<HydrometricDataValue>();
        }
        #endregion Constructors
    }
}
