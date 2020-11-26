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
    public partial class VPScenarioModel
    {
        #region Properties
        public VPScenario VPScenario { get; set; }
        public List<VPScenarioLanguage> VPScenarioLanguageList { get; set; }
        public List<VPAmbient> VPAmbientList { get; set; }
        public List<VPResult> VPResultList { get; set; }

        #endregion Properties

        #region Constructors
        public VPScenarioModel()
        {
            VPScenario = new VPScenario();
            VPScenarioLanguageList = new List<VPScenarioLanguage>();
            VPAmbientList = new List<VPAmbient>();
            VPResultList = new List<VPResult>();
        }
        #endregion Constructors

    }

}
