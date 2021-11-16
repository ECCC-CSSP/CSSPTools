/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class VPScenarioIDAndRawResults
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(1, -1)]
        public int VPScenarioID { get; set; }
        [CSSPMaxLength(1000000)]
        public string RawResults { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public VPScenarioIDAndRawResults() : base()
        {
        }
        #endregion Constructors
    }
}
