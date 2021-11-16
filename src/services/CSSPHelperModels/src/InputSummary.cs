/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class InputSummary
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(1000000)]
        public string Summary { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public InputSummary() : base()
        {
        }
        #endregion Constructors
    }
}
