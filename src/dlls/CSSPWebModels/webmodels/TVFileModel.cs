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
    public partial class TVFileModel
    {
        public int ParentTVItemID { get; set; }
        public TVFile TVFile { get; set; }
        public List<TVFileLanguage> TVFileLanguageList { get; set; }

        public TVFileModel()
        {
            ParentTVItemID = 0;
            TVFile = new TVFile();
            TVFileLanguageList = new List<TVFileLanguage>();
        }
    }
}
