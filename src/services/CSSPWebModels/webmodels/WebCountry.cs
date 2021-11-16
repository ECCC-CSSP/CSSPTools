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
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<TVItemModel> TVItemModelProvinceList { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        public List<RainExceedanceModel> RainExceedanceModelList { get; set; }
        public List<EmailDistributionListModel> EmailDistributionListModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebCountry()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            TVItemModelProvinceList = new List<TVItemModel>();
            TVFileModelList = new List<TVFileModel>();
            RainExceedanceModelList = new List<RainExceedanceModel>();
            EmailDistributionListModelList = new List<EmailDistributionListModel>();
        }
        #endregion Constructors
    }
}
