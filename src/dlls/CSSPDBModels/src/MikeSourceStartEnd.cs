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

namespace CSSPDBModels
{
    public partial class MikeSourceStartEnd : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int MikeSourceStartEndID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "MikeSource", ExistPlurial = "s", ExistFieldID = "MikeSourceID")]
        [CSSPForeignKey(TableName = "MikeSources", FieldName = "MikeSourceID")]
        public int MikeSourceID { get; set; }
        [CSSPAfter(Year = 1980)]
        public DateTime StartDateAndTime_Local { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPBigger(OtherField = "StartDateAndTime_Local")]
        public DateTime EndDateAndTime_Local { get; set; }
        [CSSPRange(0.0D, 1000000.0D)]
        public double SourceFlowStart_m3_day { get; set; }
        [CSSPRange(0.0D, 1000000.0D)]
        public double SourceFlowEnd_m3_day { get; set; }
        [CSSPRange(0, 10000000)]
        public int SourcePollutionStart_MPN_100ml { get; set; }
        [CSSPRange(0, 10000000)]
        public int SourcePollutionEnd_MPN_100ml { get; set; }
        [CSSPRange(-10.0D, 40.0D)]
        public double SourceTemperatureStart_C { get; set; }
        [CSSPRange(-10.0D, 40.0D)]
        public double SourceTemperatureEnd_C { get; set; }
        [CSSPRange(0.0D, 40.0D)]
        public double SourceSalinityStart_PSU { get; set; }
        [CSSPRange(0.0D, 40.0D)]
        public double SourceSalinityEnd_PSU { get; set; }
        #endregion Properties in DB

        #region Constructors
        public MikeSourceStartEnd() : base()
        {
        }
        #endregion Constructors
    }
}
