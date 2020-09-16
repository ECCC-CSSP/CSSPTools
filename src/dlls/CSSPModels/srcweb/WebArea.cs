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
        public List<WebBase> TVItemSectorList { get; set; }
        #endregion Properties

        #region Constructors
        public WebArea()
        {
            TVItemSectorList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
