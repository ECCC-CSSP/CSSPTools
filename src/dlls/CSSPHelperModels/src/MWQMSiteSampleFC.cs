/*
 * Manually edited
 * 
 */
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class MWQMSiteSampleFC
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPAfter(Year = 1980)]
        public DateTime SampleDate { get; set; }
        [CSSPRange(1, 100000000)]
        [CSSPAllowNull]
        public int? FC { get; set; }
        [CSSPAllowNull]
        public double? Sal { get; set; }
        [CSSPAllowNull]
        public double? Temp { get; set; }
        [CSSPAllowNull]
        public double? PH { get; set; }
        [CSSPAllowNull]
        public double? DO { get; set; }
        [CSSPAllowNull]
        public double? Depth { get; set; }
        [CSSPAllowNull]
        public int? SampCount { get; set; }
        [CSSPAllowNull]
        public int? MinFC { get; set; }
        [CSSPAllowNull]
        public int? MaxFC { get; set; }
        [CSSPAllowNull]
        public double? GeoMean { get; set; }
        [CSSPAllowNull]
        public double? Median { get; set; }
        [CSSPAllowNull]
        public double? P90 { get; set; }
        [CSSPAllowNull]
        public double? PercOver43 { get; set; }
        [CSSPAllowNull]
        public double? PercOver260 { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public MWQMSiteSampleFC() : base()
        {
        }
        #endregion Constructors
    }
}
