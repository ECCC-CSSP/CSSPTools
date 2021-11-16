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
    public partial class WebMWQMSamples
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public List<TVItemModel> TVItemModelParentList { get; set; }
        public List<MWQMSampleModel> MWQMSampleModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMWQMSamples()
        {
            TVItemModel = new TVItemModel();
            TVItemModelParentList = new List<TVItemModel>();
            MWQMSampleModelList = new List<MWQMSampleModel>();
        }
        #endregion Constructors
    }
}
