/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebMWQMSite
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<MWQMSiteModel> MWQMSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMWQMSite()
        {
            TVItemParentList = new List<WebBase>();
            MWQMSiteModelList = new List<MWQMSiteModel>();
        }
        #endregion Constructors
    }

    public partial class MWQMSiteModel : WebBase
    {
        #region Properties
        public MWQMSite MWQMSite { get; set; }
        public List<MWQMSiteStartEndDate> MWQMSiteStartEndDateList { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteModel()
        {
            MWQMSite = new MWQMSite();
            MWQMSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
        }
        #endregion Constructors
    }
}
