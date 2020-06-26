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
