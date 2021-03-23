/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class RTBStringPos
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(0, -1)]
        public int StartPos { get; set; }
        [CSSPRange(0, -1)]
        public int EndPos { get; set; }
        [CSSPMaxLength(100)]
        public string Text { get; set; }
        [CSSPMaxLength(100)]
        public string TagText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public RTBStringPos() : base()
        {
        }
        #endregion Constructors
    }
}
