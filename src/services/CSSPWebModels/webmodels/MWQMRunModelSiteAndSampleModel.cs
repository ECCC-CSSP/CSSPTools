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
    public partial class MWQMRunModelSiteAndSampleModel
    {
        #region Properties
        public MWQMRunModel MWQMRunModel { get; set; }
        public List<MWQMSiteModelAndSampleModel> MWQMSiteModelAndSampleModelList { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunModelSiteAndSampleModel()
        {
            MWQMRunModel = new MWQMRunModel();
            MWQMSiteModelAndSampleModelList = new List<MWQMSiteModelAndSampleModel>();
        }
        #endregion Constructors
    }
}
