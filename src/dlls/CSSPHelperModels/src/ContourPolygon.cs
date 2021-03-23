/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class ContourPolygon
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(0.0D, -1.0D)]
        public double ContourValue { get; set; }
        [CSSPRange(1, 100)]
        public int Layer { get; set; }
        [CSSPRange(1.0D, 10000.0D)]
        public double Depth_m { get; set; }
        public List<Node> ContourNodeList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public ContourPolygon() : base()
        {
            ContourNodeList = new List<Node>();
        }
        #endregion Constructors
    }
}
