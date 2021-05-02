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
    public partial class MWQMSiteModel
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public MWQMSite MWQMSite { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        public List<MWQMSiteStartEndDate> MWQMSiteStartEndDateList { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteModel()
        {
            TVItemModel = new TVItemModel();
            MWQMSite = new MWQMSite();
            TVFileModelList = new List<TVFileModel>();
            MWQMSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
        }
        #endregion Constructors
    }
}
