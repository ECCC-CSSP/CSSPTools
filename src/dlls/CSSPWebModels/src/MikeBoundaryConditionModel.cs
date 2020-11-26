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
    public partial class MikeBoundaryConditionModel : WebBase
    {
        #region Properties
        public List<MikeBoundaryCondition> MikeBoundaryConditionList { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionModel()
        {
            MikeBoundaryConditionList = new List<MikeBoundaryCondition>();
        }
        #endregion Constructors

    }
}
