/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class ElementLayer
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(1, 1000)]
        public int Layer { get; set; }
        [CSSPRange(-1.0D, -1.0D)]
        public double ZMin { get; set; }
        [CSSPRange(-1.0D, -1.0D)]
        public double ZMax { get; set; }
        public Element Element { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public ElementLayer() : base()
        {
        }
        #endregion Constructors
    }
}
