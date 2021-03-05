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
    public partial class InfrastructureModel : WebBase
    {
        #region Properties
        public Infrastructure Infrastructure { get; set; }
        public List<InfrastructureLanguage> InfrastructureLanguageList { get; set; }
        public Address InfrastructureCivicAddress { get; set; }
        public List<BoxModelModel> BoxModelModelList { get; set; }
        public List<VPScenarioModel> VPScenarioModelList { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureModel()
        {
            Infrastructure = new Infrastructure();
            InfrastructureLanguageList = new List<InfrastructureLanguage>();
            InfrastructureCivicAddress = new Address();
            BoxModelModelList = new List<BoxModelModel>();
            VPScenarioModelList = new List<VPScenarioModel>();
        }
        #endregion Constructors

    }
}
