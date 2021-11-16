/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPDBModels
{
    public partial class CoCoRaHSValue : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int CoCoRaHSValueID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "CoCoRaHSSite", ExistPlurial = "s", ExistFieldID = "CoCoRaHSSiteID")]
        [CSSPForeignKey(TableName = "CoCoRaHSSites", FieldName = "CoCoRaHSSiteID")]
        public int CoCoRaHSSiteID { get; set; }
        [CSSPAfter(Year = 1980)]
        public DateTime ObservationDateAndTime { get; set; }
        [CSSPRange(0.0D, 10000.0D)]
        [CSSPAllowNull]
        public Nullable<double> TotalPrecipAmt { get; set; }
        [CSSPRange(0.0D, 10000.0D)]
        [CSSPAllowNull]
        public Nullable<double> NewSnowDepth { get; set; }
        [CSSPRange(0.0D, 10000.0D)]
        [CSSPAllowNull]
        public Nullable<double> NewSnowSWE { get; set; }
        [CSSPRange(0.0D, 10000.0D)]
        [CSSPAllowNull]
        public Nullable<double> TotalSnowDepth { get; set; }
        [CSSPRange(0.0D, 10000.0D)]
        [CSSPAllowNull]
        public Nullable<double> TotalSnowSWE { get; set; }
        #endregion Properties in DB

        #region Constructors
        public CoCoRaHSValue() : base()
        {
        }
        #endregion Constructors
    }

    
}
