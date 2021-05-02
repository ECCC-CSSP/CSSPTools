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
    public partial class WebMikeScenarios
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<MikeScenarioModel> MikeScenarioModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMikeScenarios()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            MikeScenarioModelList = new List<MikeScenarioModel>();
        }
        #endregion Constructors
    }
}
