/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebRoot
    {
        #region Properties
        public TVItemStatMapModel TVItemStatMapModel { get; set; }
        public List<TVItemStatModel> TVItemStatModelParentList { get; set; }
        public List<TVItemStatMapModel> TVItemStatMapModelCountryList { get; set; }
        public List<TVFileModel> TVFileModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebRoot() : base()
        {
            TVItemStatMapModel = new TVItemStatMapModel();
            TVItemStatModelParentList = new List<TVItemStatModel>();
            TVItemStatMapModelCountryList = new List<TVItemStatMapModel>();
            TVFileModelList = new List<TVFileModel>();
        }
        #endregion Constructors
    }
}
