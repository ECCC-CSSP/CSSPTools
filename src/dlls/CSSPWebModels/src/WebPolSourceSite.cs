/*
 * Manually edited
 * 
 */
using CSSPModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSSPWebModels
{
    public partial class WebPolSourceSite
    {
        #region Properties
        public List<PolSourceSite> PolSourceSiteList { get; set; }
        public List<PolSourceObservation> PolSourceObservationList { get; set; }
        public List<PolSourceObservationIssue> PolSourceObservationIssueList { get; set; }
        public List<PolSourceSiteEffect> PolSourceSiteEffectList { get; set; }
        public List<PolSourceSiteEffectTerm> PolSourceSiteEffectTermList { get; set; }
        public List<Address> PolSourceSiteCivicAddressList { get; set; }
        #endregion Properties

        #region Constructors
        public WebPolSourceSite()
        {
            PolSourceSiteList = new List<PolSourceSite>();
            PolSourceObservationList = new List<PolSourceObservation>();
            PolSourceObservationIssueList = new List<PolSourceObservationIssue>();
            PolSourceSiteEffectList = new List<PolSourceSiteEffect>();
            PolSourceSiteEffectTermList = new List<PolSourceSiteEffectTerm>();
            PolSourceSiteCivicAddressList = new List<Address>();
        }
        #endregion Constructors
    }
}
