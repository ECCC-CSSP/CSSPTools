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
    public partial class TableConvertToCSVModel
    {
        #region Properties
        public string CSVString { get; set; }
        public string TableFileName { get; set; }
        #endregion Properties

        #region Constructors
        public TableConvertToCSVModel()
        {
            
        }
        #endregion Constructors
    }
}
