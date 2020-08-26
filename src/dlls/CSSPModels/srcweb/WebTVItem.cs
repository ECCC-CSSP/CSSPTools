/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebTVItem
    {
        #region Properties
        public List<TVItem> TVItemList { get; set; }
        public List<TVItemLanguage> TVItemLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public WebTVItem()
        {
            TVItemList = new List<TVItem>();
            TVItemLanguageList = new List<TVItemLanguage>();
        }
        #endregion Constructors
    }
}
