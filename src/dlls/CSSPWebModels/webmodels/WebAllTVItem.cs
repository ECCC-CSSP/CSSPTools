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
    public partial class WebAllTVItems
    {
        #region Properties
        public List<TVItem> TVItemList { get; set; }
        #endregion Properties

        #region Constructors
        public WebAllTVItems()
        {
            TVItemList = new List<TVItem>();
        }
        #endregion Constructors
    }
}
