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
    public partial class WebAllMWQMSubsectors
    {
        #region Properties
        public List<MWQMSubsectorModel> MWQMSubsectorModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllMWQMSubsectors()
        {
            MWQMSubsectorModelList = new List<MWQMSubsectorModel>();
        }
        #endregion Constructors
    }
}
