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
    public partial class MWQMSiteModel : WebBase
    {
        #region Properties
        public MWQMSite MWQMSite { get; set; }
        public List<MWQMSiteStartEndDate> MWQMSiteStartEndDateList { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteModel()
        {
            MWQMSite = new MWQMSite();
            MWQMSiteStartEndDateList = new List<MWQMSiteStartEndDate>();
        }
        #endregion Constructors
    }
}
