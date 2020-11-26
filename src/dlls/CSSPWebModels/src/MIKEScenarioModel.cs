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
    public partial class MIKEScenarioModel : WebBase
    {
        #region Properties
        public MikeScenario MikeScenario { get; set; }
        public List<MikeSourceModel> MikeSourceModelList { get; set; }
        #endregion Properties

        #region Constructors
        public MIKEScenarioModel()
        {
            MikeScenario = new MikeScenario();
            MikeSourceModelList = new List<MikeSourceModel>();
        }
        #endregion Constructors

    }
}
