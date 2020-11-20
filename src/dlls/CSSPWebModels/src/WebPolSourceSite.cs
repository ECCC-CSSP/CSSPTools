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
    public partial class WebPolSourceSite : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<PolSourceSiteModel> PolSourceSiteModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebPolSourceSite()
        {
            TVItemParentList = new List<WebBase>();
            PolSourceSiteModelList = new List<PolSourceSiteModel>();
        }
        #endregion Constructors
    }

    [NotMapped]
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

    [NotMapped]
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
