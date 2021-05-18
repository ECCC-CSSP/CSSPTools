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
    public partial class ChartXYNumbersModel
    {
        #region Properties
        public double x { get; set; }
        public double y { get; set; }
        #endregion Properties

        #region Constructors
        public ChartXYNumbersModel()
        {
        }
        #endregion Constructors
    }
}
