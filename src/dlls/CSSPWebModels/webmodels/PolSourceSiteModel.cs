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
    public partial class PolSourceSiteModel
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public PolSourceSite PolSourceSite { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        public Address PolSourceSiteCivicAddress { get; set; }
        public List<PolSourceObservationModel> PolSourceObservationModelList { get; set; }
        public List<PolSourceSiteEffect> PolSourceSiteEffectList { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteModel()
        {
            TVItemModel = new TVItemModel();
            PolSourceSite = new PolSourceSite();
            TVFileModelList = new List<TVFileModel>();
            PolSourceSiteCivicAddress = new Address();
            PolSourceObservationModelList = new List<PolSourceObservationModel>();
            PolSourceSiteEffectList = new List<PolSourceSiteEffect>();
        }
        #endregion Constructors
    }
}
