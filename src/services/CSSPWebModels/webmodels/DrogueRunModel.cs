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
    public partial class DrogueRunModel
    {
        #region Properties
        public DrogueRun DrogueRun { get; set; }
        public List<DrogueRunPosition> DrogueRunPositionList { get; set; }
        #endregion Properties

        #region Constructors
        public DrogueRunModel()
        {
            DrogueRunPositionList = new List<DrogueRunPosition>();
        }
        #endregion Constructors
    }
}
