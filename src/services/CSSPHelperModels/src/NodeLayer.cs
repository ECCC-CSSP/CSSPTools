/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class NodeLayer
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(1, 100)]
        public int Layer { get; set; }
        [CSSPRange(-10000.0D, 10000.0D)]
        public double Z { get; set; }
        public Node Node { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public NodeLayer() : base()
        {
        }
        #endregion Constructors
    }
}
