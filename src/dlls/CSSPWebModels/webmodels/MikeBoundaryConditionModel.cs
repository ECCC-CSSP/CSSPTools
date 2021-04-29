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
        public TVItemMapModel TVItemMapModel { get; set; }
        public MikeBoundaryCondition MikeBoundaryCondition { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionModel()
        {
            TVItemMapModel = new TVItemMapModel();
            MikeBoundaryCondition = new MikeBoundaryCondition();
        }
        #endregion Constructors
    }
}
