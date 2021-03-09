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
    public partial class WebTideDataValue : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<TideDataValue> TideDataValueList { get; set; }
        #endregion Properties

        #region Constructors
        public WebTideDataValue()
        {
            TVItemParentList = new List<WebBase>();
            TideDataValueList = new List<TideDataValue>();
        }
        #endregion Constructors
    }
}
