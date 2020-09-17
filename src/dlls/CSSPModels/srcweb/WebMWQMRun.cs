/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebMWQMRun
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
