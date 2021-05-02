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
    public partial class MikeScenarioModel
    {
        #region Properties
        public MikeScenario MikeScenario { get; set; }
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        public List<MikeBoundaryConditionModel> MikeBoundaryConditionModelList { get; set; }
        public List<MikeSourceModel> MikeSourceModelList { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioModel()
        {
            MikeScenario = new MikeScenario();
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            TVFileModelList = new List<TVFileModel>();
            MikeBoundaryConditionModelList = new List<MikeBoundaryConditionModel>();
            MikeSourceModelList = new List<MikeSourceModel>();
        }
        #endregion Constructors

    }
}
