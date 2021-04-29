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
    public partial class WebProvince
    {
        #region Properties
        public TVItemStatMapModel TVItemStatMapModel { get; set; }
        public List<TVItemStatModel> TVItemStatModelParentList { get; set; }
        public List<TVItemStatMapModel> TVItemStatMapAreaList { get; set; }
        public List<TVItemStatMapModel> TVItemStatMapMunicipalityList { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        public List<SamplingPlanModel> SamplingPlanModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebProvince()
        {
            TVItemStatMapModel = new TVItemStatMapModel();
            TVItemStatModelParentList = new List<TVItemStatModel>();
            TVItemStatMapAreaList = new List<TVItemStatMapModel>();
            TVItemStatMapMunicipalityList = new List<TVItemStatMapModel>();
            TVFileModelList = new List<TVFileModel>();
            SamplingPlanModelList = new List<SamplingPlanModel>();
        }
        #endregion Constructors
    }
}
