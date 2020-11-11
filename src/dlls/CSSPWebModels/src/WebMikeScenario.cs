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

    [NotMapped]
    public partial class MikeSourceModel : WebBase
    {
        public MikeSource MikeSource { get; set; }
        #region Properties
        public List<MikeSourceStartEnd> MikeSourceStartEndList { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceModel()
        {
            MikeSource = new MikeSource();
            MikeSourceStartEndList = new List<MikeSourceStartEnd>();
        }
        #endregion Constructors
    }

    [NotMapped]
    public partial class MikeBoundaryConditionModel : WebBase
    {
        #region Properties
        public List<MikeBoundaryCondition> MikeBoundaryConditionList { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionModel()
        {
            MikeBoundaryConditionList = new List<MikeBoundaryCondition>();
        }
        #endregion Constructors

    }
}
