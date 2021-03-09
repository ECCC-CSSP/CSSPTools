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
    public partial class PolSourceSiteModel : WebBase
    {
        #region Properties
        public PolSourceSite PolSourceSite { get; set; }
        public List<WebBase> TVItemFileList { get; set; }
        public Address PolSourceSiteCivicAddress { get; set; }
        public List<PolSourceObservationModel> PolSourceObservationModelList { get; set; }
        public List<PolSourceSiteEffect> PolSourceSiteEffectList { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteModel()
        {
            PolSourceSite = new PolSourceSite();
            TVItemFileList = new List<WebBase>();
            PolSourceSiteCivicAddress = new Address();
            PolSourceObservationModelList = new List<PolSourceObservationModel>();
            PolSourceSiteEffectList = new List<PolSourceSiteEffect>();
        }
        #endregion Constructors
    }
}
