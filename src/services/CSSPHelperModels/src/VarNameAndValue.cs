/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class VarNameAndValue
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(200)]
        public string VariableName { get; set; }
        [CSSPMaxLength(300)]
        public string VariableValue { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public VarNameAndValue() : base()
        {
        }
        #endregion Constructors
    }
}
