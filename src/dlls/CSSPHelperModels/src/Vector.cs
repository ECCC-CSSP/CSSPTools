/*
 * Manually edited
 * 
 */
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class Vector
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public Vector() : base()
        {
        }
        #endregion Constructors
    }
}
