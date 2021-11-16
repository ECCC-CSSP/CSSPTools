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
    public partial class MWQMRunModel
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public MWQMRun MWQMRun { get; set; }
        public List<MWQMRunLanguage> MWQMRunLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunModel()
        {
            TVItemModel = new TVItemModel();
            MWQMRun = new MWQMRun();
            MWQMRunLanguageList = new List<MWQMRunLanguage>();
        }
        #endregion Constructors
    }
}
