/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class PolyPoint
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(-180.0D, 180.0D)]
        public double XCoord { get; set; }
        [CSSPRange(-90.0D, 90.0D)]
        public double YCoord { get; set; }
        [CSSPRange(-10000.0D, 10000.0D)]
        public double Z { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public PolyPoint() : base()
        {
        }
        #endregion Constructors
    }
}
