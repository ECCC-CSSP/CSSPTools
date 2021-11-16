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
    public partial class MikeBoundaryConditionModel
    {
        #region Properties
        public TVItemModel TVItemModel { get; set; }
        public MikeBoundaryCondition MikeBoundaryCondition { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionModel()
        {
            TVItemModel = new TVItemModel();
            MikeBoundaryCondition = new MikeBoundaryCondition();
        }
        #endregion Constructors
    }
}
