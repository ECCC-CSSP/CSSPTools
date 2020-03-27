using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class PolSourceSiteEffects
    {
        public int PolSourceSiteEffectID { get; set; }
        public int PolSourceSiteOrInfrastructureTVItemID { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        public string PolSourceSiteEffectTermIDs { get; set; }
        public string Comments { get; set; }
        public int? AnalysisDocumentTVItemID { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems AnalysisDocumentTVItem { get; set; }
        public virtual TVItems MWQMSiteTVItem { get; set; }
        public virtual TVItems PolSourceSiteOrInfrastructureTVItem { get; set; }
    }
}
