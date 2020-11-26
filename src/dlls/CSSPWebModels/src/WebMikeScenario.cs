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
    public partial class WebMikeScenario : WebBase
    {
        #region Properties
        public List<WebBase> TVItemParentList { get; set; }
        public MikeScenario MikeScenario { get; set; }
        public List<MikeSourceModel> MikeSourceModelList { get; set; }
        public List<MikeBoundaryConditionModel> MikeBoundaryConditionModelWebTideList { get; set; }
        public List<MikeBoundaryConditionModel> MikeBoundaryConditionModelMeshList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMikeScenario()
        {
            TVItemParentList = new List<WebBase>();
            MikeScenario = new MikeScenario();
            MikeSourceModelList = new List<MikeSourceModel>();
            MikeBoundaryConditionModelWebTideList = new List<MikeBoundaryConditionModel>();
            MikeBoundaryConditionModelMeshList = new List<MikeBoundaryConditionModel>();
        }
        #endregion Constructors
    }
}
