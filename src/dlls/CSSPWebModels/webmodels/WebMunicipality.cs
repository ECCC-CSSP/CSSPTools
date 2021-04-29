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
    public partial class WebMunicipality
    {
        #region Properties
        public TVItemStatMapModel TVItemStatMapModel { get; set; }
        public List<TVItemStatModel> TVItemStatModelParentList { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        public List<ContactModel> MunicipalityContactModelList { get; set; }
        public List<TVItemLink> MunicipalityTVItemLinkList { get; set; }
        public List<InfrastructureModel> InfrastructureModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMunicipality()
        {
            TVItemStatMapModel = new TVItemStatMapModel();
            TVItemStatModelParentList = new List<TVItemStatModel>();
            TVFileModelList = new List<TVFileModel>();
            MunicipalityContactModelList = new List<ContactModel>();
            MunicipalityTVItemLinkList = new List<TVItemLink>();
            InfrastructureModelList = new List<InfrastructureModel>();
        }
        #endregion Constructors
    }
}
