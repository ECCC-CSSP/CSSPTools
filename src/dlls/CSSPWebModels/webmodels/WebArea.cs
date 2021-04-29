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
        public TVItemStatMapModel TVItemStatMapModel { get; set; }
        public List<TVItemStatModel> TVItemStatModelParentList { get; set; }
        public List<TVItemStatMapModel> TVItemStatMapModelSectorList { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebArea()
        {
            TVItemStatMapModel = new TVItemStatMapModel();
            TVItemStatModelParentList = new List<TVItemStatModel>();
            TVItemStatMapModelSectorList = new List<TVItemStatMapModel>();
            TVFileModelList = new List<TVFileModel>();
        }
        #endregion Constructors
    }
}
