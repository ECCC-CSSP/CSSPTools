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
        public TVItemStatMapModel TVItemStatMapModel { get; set; }
        public List<TVItemStatModel> TVItemStatModelParentList { get; set; }
        public List<MWQMSampleModel> MWQMSampleModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebMWQMSamples()
        {
            TVItemStatMapModel = new TVItemStatMapModel();
            TVItemStatModelParentList = new List<TVItemStatModel>();
            MWQMSampleModelList = new List<MWQMSampleModel>();
        }
        #endregion Constructors
    }
}
