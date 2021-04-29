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
    public partial class ProvinceModel
    {
        #region Properties
        public TVItem TVItem { get; set; }
        public List<TVItemLanguage> TVItemLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public ProvinceModel()
        {
            TVItem = new TVItem();
            TVItemLanguageList = new List<TVItemLanguage>();
        }
        #endregion Constructors
    }
}
