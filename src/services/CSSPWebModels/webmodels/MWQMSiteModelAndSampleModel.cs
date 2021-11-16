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
    public partial class MWQMSiteModelAndSampleModel
    {
        #region Properties
        public MWQMSiteModel MWQMSiteModel { get; set; }
        public MWQMSampleModel MWQMSampleModel { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteModelAndSampleModel()
        {
            MWQMSiteModel = new MWQMSiteModel();
            MWQMSampleModel = new MWQMSampleModel();
        }
        #endregion Constructors
    }
}
