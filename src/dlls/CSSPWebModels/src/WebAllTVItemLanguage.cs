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
