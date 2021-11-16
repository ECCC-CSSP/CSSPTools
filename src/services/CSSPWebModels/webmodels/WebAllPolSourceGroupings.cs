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
    public partial class WebAllPolSourceGroupings
    {
        #region Properties
        public List<PolSourceGroupingModel> PolSourceGroupingModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllPolSourceGroupings()
        {
            PolSourceGroupingModelList = new List<PolSourceGroupingModel>();
        }
        #endregion Constructors
    }
}
