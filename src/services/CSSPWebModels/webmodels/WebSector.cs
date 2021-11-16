/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebSector
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<TVItemModel> TVItemModelSubsectorList { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebSector()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            TVItemModelSubsectorList = new List<TVItemModel>();
            TVFileModelList = new List<TVFileModel>();
        }
        #endregion Constructors
    }
}
