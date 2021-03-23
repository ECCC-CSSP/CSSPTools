/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class PolSourceInactiveReasonEnumTextAndID
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(1000)]
        public string Text { get; set; }
        [CSSPRange(1, -1)]
        public int ID { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public PolSourceInactiveReasonEnumTextAndID() : base()
        {
        }
        #endregion Constructors
    }
}
