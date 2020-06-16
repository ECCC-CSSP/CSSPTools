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

namespace CSSPModels
{
    [NotMapped]
    public partial class LabSheetA1Measurement
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public string Site { get; set; }
        [CSSPRange(1, -1)]
        public int TVItemID { get; set; }
        [CSSPAllowNull]
        public DateTime? Time { get; set; }
        [CSSPAllowNull]
        public int? MPN { get; set; }
        [CSSPAllowNull]
        public int? Tube10 { get; set; }
        [CSSPAllowNull]
        public int? Tube1_0 { get; set; }
        [CSSPAllowNull]
        public int? Tube0_1 { get; set; }
        [CSSPAllowNull]
        public double? Salinity { get; set; }
        public double Temperature { get; set; }
        [CSSPAllowNull]
        public string ProcessedBy { get; set; }
        [CSSPEnumType]
        [CSSPAllowNull]
        public SampleTypeEnum? SampleType { get; set; }
        public string SiteComment { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "SampleTypeEnum", EnumType = "SampleType")]
        [CSSPAllowNull]
        public string SampleTypeText { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public LabSheetA1Measurement() : base()
        {
        }
        #endregion Constructors
    }
}
