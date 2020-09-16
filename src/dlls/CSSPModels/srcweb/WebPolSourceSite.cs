/*
 * Manually edited
 * 
 */
using System.Collections.Generic;

namespace CSSPModels
{
    public partial class WebPolSourceSite
    {
        #region Properties
        public List<PolSourceSiteModel> PolSourceSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebPolSourceSite()
        {
            PolSourceSiteModelList = new List<PolSourceSiteModel>();
        }
        #endregion Constructors
    }

    public partial class PolSourceSiteModel : WebBase
    {
        #region Properties
        public PolSourceSite PolSourceSite { get; set; }
        public Address PolSourceSiteCivicAddress { get; set; }
        public List<PolSourceObservationModel> PolSourceObservationModelList { get; set; }
        public List<PolSourceSiteEffect> PolSourceSiteEffectList { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteModel()
        {
            PolSourceSite = new PolSourceSite();
            PolSourceSiteCivicAddress = new Address();
            PolSourceObservationModelList = new List<PolSourceObservationModel>();
            PolSourceSiteEffectList = new List<PolSourceSiteEffect>();
        }
        #endregion Constructors
    }

    public partial class PolSourceObservationModel
    {
        #region Properties
        public PolSourceObservation PolSourceObservation { get; set; }
        public List<PolSourceObservationIssue> PolSourceObservationIssueList { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationModel()
        {
            PolSourceObservation = new PolSourceObservation();
            PolSourceObservationIssueList = new List<PolSourceObservationIssue>();
        }
        #endregion Constructors
    }
}
