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
    public partial class ClassificationModel
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public Classification Classification { get; set; }
        #endregion Properties

        #region Constructors
        public ClassificationModel()
        {
            TVItemModel = new TVItemModel();
            Classification = new Classification();
        }
        #endregion Constructors
    }
}
