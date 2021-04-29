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
    public partial class WebCountry
    {
        #region Properties
        public TVItemStatMapModel TVItemStatMapModel { get; set; }
        public List<TVItemStatModel> TVItemStatModelParentList { get; set; }
        public List<TVItemStatMapModel> TVItemStatMapModelProvinceList { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        public List<RainExceedanceModel> RainExceedanceModelList { get; set; }
        public List<EmailDistributionListModel> EmailDistributionListModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebCountry()
        {
            TVItemStatMapModel = new TVItemStatMapModel();
            TVItemStatModelParentList = new List<TVItemStatModel>();
            TVItemStatMapModelProvinceList = new List<TVItemStatMapModel>();
            TVFileModelList = new List<TVFileModel>();
            RainExceedanceModelList = new List<RainExceedanceModel>();
            EmailDistributionListModelList = new List<EmailDistributionListModel>();
        }
        #endregion Constructors
    }
}
