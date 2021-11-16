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
    public partial class ChartXYTextNumberModel
    {
        #region Properties
        public string x { get; set; }
        public double y { get; set; }
        #endregion Properties

        #region Constructors
        public ChartXYTextNumberModel()
        {
        }
        #endregion Constructors
    }

}
