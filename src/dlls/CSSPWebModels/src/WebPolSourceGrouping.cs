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
    public partial class WebPolSourceGrouping
    {
        #region Properties
        public List<PolSourceGrouping> PolSourceGroupingList { get; set; }
        public List<PolSourceGroupingLanguage> PolSourceGroupingLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public WebPolSourceGrouping()
        {
            PolSourceGroupingList = new List<PolSourceGrouping>();
            PolSourceGroupingLanguageList = new List<PolSourceGroupingLanguage>();
        }
        #endregion Constructors
    }
}
