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
        public TVItemStatMapModel TVItemStatMapModel { get; set; }
        public List<TVItemStatModel> TVItemStatModelParentList { get; set; }
        public List<MikeScenarioModel> MikeScenarioModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMikeScenarios()
        {
            TVItemStatMapModel = new TVItemStatMapModel();
            TVItemStatModelParentList = new List<TVItemStatModel>();
            MikeScenarioModelList = new List<MikeScenarioModel>();
        }
        #endregion Constructors
    }
}
