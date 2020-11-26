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
    public partial class TelModel : WebBase
    {
        #region Properties
        public Tel Tel { get; set; }
        #endregion Properties

        #region Constructors
        public TelModel()
        {
            Tel = new Tel();
        }
        #endregion Constructors
    }
}
