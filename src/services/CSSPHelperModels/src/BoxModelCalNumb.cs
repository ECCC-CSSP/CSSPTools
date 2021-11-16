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
    public partial class BoxModelCalNumb
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPEnumType]
        public BoxModelResultTypeEnum BoxModelResultType { get; set; }
        [CSSPRange(0.0D, -1.0D)]
        public double CalLength_m { get; set; }
        [CSSPRange(0.0D, -1.0D)]
        public double CalRadius_m { get; set; }
        [CSSPRange(0.0D, -1.0D)]
        public double CalSurface_m2 { get; set; }
        [CSSPRange(0.0D, -1.0D)]
        public double CalVolume_m3 { get; set; }
        [CSSPRange(0.0D, -1.0D)]
        public double CalWidth_m { get; set; }
        public bool FixLength { get; set; }
        public bool FixWidth { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "BoxModelResultTypeEnum", EnumType = "BoxModelResultType")]
        [CSSPAllowNull]
        public string BoxModelResultTypeText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public BoxModelCalNumb() : base()
        {
        }
        #endregion Constructors
    }
}
