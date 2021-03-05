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
    public partial class WebBase
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        #endregion Properties

        #region Constructors
        public WebBase()
        {
            TVItemModel = new TVItemModel();
        }
        #endregion Constructors
    }
}
