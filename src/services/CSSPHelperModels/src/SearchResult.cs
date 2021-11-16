/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class SearchResult
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public TVItem TVItem { get; set; }
        public TVItemLanguage TVItemLanguage { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public SearchResult() : base()
        {
        }
        #endregion Constructors
    }
}
