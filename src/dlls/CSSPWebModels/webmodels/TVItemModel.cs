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
    public partial class TVItemModel
    {
        public TVItem TVItem { get; set; }
        public List<TVItemLanguage> TVItemLanguageList { get; set; }

        public TVItemModel()
        {
            TVItem = new TVItem();
            TVItemLanguageList = new List<TVItemLanguage>();
        }
    }
}
