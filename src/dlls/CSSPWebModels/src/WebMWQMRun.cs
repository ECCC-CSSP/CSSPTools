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
    public partial class WebMWQMRun : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<MWQMRunModel> MWQMRunModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMWQMRun()
        {
            TVItemParentList = new List<WebBase>();
            MWQMRunModelList = new List<MWQMRunModel>();
        }
        #endregion Constructors
    }

    [NotMapped]
    public partial class MWQMRunModel : WebBase
    {
        #region Properties
        public MWQMRun MWQMRun { get; set; }
        public List<MWQMRunLanguage> MWQMRunLanguageList { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunModel()
        {
            MWQMRun = new MWQMRun();
            MWQMRunLanguageList = new List<MWQMRunLanguage>();
        }
        #endregion Constructors
    }
}
