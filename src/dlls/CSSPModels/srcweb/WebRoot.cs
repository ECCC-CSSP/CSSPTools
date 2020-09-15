/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebRoot : WebBase
    {
        #region Properties
        public List<WebBase> TVItemCountryList { get; set; }
        #endregion Properties

        #region Constructors
        public WebRoot() : base()
        {
            TVItemCountryList = new List<WebBase>();
        }
        #endregion Constructors
    }
}
