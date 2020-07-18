/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebHelpDoc : WebBase
    {
        #region Properties
        public List<HelpDoc> HelpDocList { get; set; }
        #endregion Properties

        #region Constructors
        public WebHelpDoc()
        {
            HelpDocList = new List<HelpDoc>();
        }
        #endregion Constructors
    }
}
