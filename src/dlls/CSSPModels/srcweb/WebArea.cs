/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebArea : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<WebBase> TVItemSectorList { get; set; }
        #endregion Properties

        #region Constructors
        public WebArea()
        {
            TVItemParentList = new List<WebBase>();
            TVItemSectorList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
