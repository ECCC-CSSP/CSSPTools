/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class WebAllSearch
    {
        #region Properties
        public List<TVModel> TVModelList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllSearch()
        {
            TVModelList = new List<TVModel>();
        }
        #endregion Constructors
    }
}
