/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPModels
{
    [NotMapped]
    public partial class WebAllTVItemLanguage
    {
        #region Properties
        public List<TVItemLanguage> TVItemLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllTVItemLanguage()
        {
            TVItemLanguageList = new List<TVItemLanguage>();
        }
        #endregion Constructors
    }
}
