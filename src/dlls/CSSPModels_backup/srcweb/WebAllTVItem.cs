/*
 * Manually edited
 * 
 */
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPModels
{
    [NotMapped]
    public partial class WebAllTVItem
    {
        #region Properties
        public List<TVItem> TVItemList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllTVItem()
        {
            TVItemList = new List<TVItem>();
        }
        #endregion Constructors
    }
}
