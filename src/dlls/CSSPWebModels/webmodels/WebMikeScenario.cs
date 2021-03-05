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
        public List<WebBase> TVItemMikeSourceList { get; set; }
        public List<WebBase> TVItemMikeBoundaryConditionMeshList { get; set; }
        public List<WebBase> TVItemMikeBoundaryConditionWebTideList { get; set; }
        public List<MikeSourceModel> MikeSourceModelList { get; set; }
        public List<MikeBoundaryConditionModel> MikeBoundaryConditionModelMeshList { get; set; }
        public List<MikeBoundaryConditionModel> MikeBoundaryConditionModelWebTideList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMikeScenario()
        {
            TVItemParentList = new List<WebBase>();
            MikeScenario = new MikeScenario();
            TVItemMikeSourceList = new List<WebBase>();
            TVItemMikeBoundaryConditionMeshList = new List<WebBase>();
            TVItemMikeBoundaryConditionWebTideList = new List<WebBase>();
            MikeSourceModelList = new List<MikeSourceModel>();
            MikeBoundaryConditionModelMeshList = new List<MikeBoundaryConditionModel>();
            MikeBoundaryConditionModelWebTideList = new List<MikeBoundaryConditionModel>();
        }
        #endregion Constructors
    }
}
