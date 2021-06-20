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
    public partial class InfrastructureItemValue
    {
        #region Properties
        public string Item { get; set; }
        public string Value { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureItemValue()
        {
        }
        #endregion Constructors
    }
}
