/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebArea
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<TVItemModel> TVItemModelSectorList { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebArea()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            TVItemModelSectorList = new List<TVItemModel>();
            TVFileModelList = new List<TVFileModel>();
        }
        #endregion Constructors
    }
}
