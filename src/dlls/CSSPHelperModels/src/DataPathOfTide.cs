/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPEnums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class DataPathOfTide
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(200)]
        [CSSPMinLength(1)]
        public string Text { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        public WebTideDataSetEnum? WebTideDataSet { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "WebTideDataSetEnum", EnumType = "WebTideDataSet")]
        [CSSPAllowNull]
        public string WebTideDataSetText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public DataPathOfTide() : base()
        {
            Text = "";
            WebTideDataSet = null;
        }
        #endregion Constructors
    }
}
