/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class CalDecay
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(0.0D, -1.0D)]
        public double Decay { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public CalDecay() : base()
        {
        }
        #endregion Constructors
    }
}
