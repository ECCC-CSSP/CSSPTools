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
    public partial class TVItemID_TVText_Sort
    {
        #region Properties
        public int TVItemID { get; set; }
        public string TVText { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemID_TVText_Sort()
        {
        }
        #endregion Constructors
    }
}
