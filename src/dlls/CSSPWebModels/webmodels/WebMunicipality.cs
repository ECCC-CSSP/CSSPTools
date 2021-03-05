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
    public partial class WebMunicipality : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public List<WebBase> TVItemMikeScenarioList { get; set; }
        public List<WebBase> TVItemInfrastructureList { get; set; }
        public List<InfrastructureModel> InfrastructureModelList { get; set; }
        public List<MIKEScenarioModel> MIKEScenarioModelList { get; set; }
        public List<ContactModel> MunicipalityContactModelList { get; set; }
        public List<TVItemLink> MunicipalityTVItemLinkList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMunicipality()
        {
            TVItemParentList = new List<WebBase>();
            TVItemMikeScenarioList = new List<WebBase>();
            TVItemInfrastructureList = new List<WebBase>();
            InfrastructureModelList = new List<InfrastructureModel>();
            MIKEScenarioModelList = new List<MIKEScenarioModel>();
            MunicipalityContactModelList = new List<ContactModel>();
            MunicipalityTVItemLinkList = new List<TVItemLink>();
        }
        #endregion Constructors
    }
}
