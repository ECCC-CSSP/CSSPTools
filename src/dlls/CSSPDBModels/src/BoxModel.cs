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
    public partial class BoxModel : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int BoxModelID { get; set; }
        [CSSPEnumType]
        public DBCommandEnum DBCommand { get; set; }
        [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "10")]
        [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
        public int InfrastructureTVItemID { get; set; }
        [CSSPRange(0.0D, 10000.0D)]
        public double Discharge_m3_day { get; set; }
        [CSSPRange(0.0D, 1000.0D)]
        public double Depth_m { get; set; }
        [CSSPRange(-15.0D, 40.0D)]
        public double Temperature_C { get; set; }
        [CSSPRange(0, 10000000)]
        public int Dilution { get; set; }
        [CSSPRange(0.0D, 100.0D)]
        public double DecayRate_per_day { get; set; }
        [CSSPRange(0, 10000000)]
        public int FCUntreated_MPN_100ml { get; set; }
        [CSSPRange(0, 10000000)]
        public int FCPreDisinfection_MPN_100ml { get; set; }
        [CSSPRange(0, 10000000)]
        public int Concentration_MPN_100ml { get; set; }
        [CSSPRange(0.0D, -1.0D)]
        public double T90_hour { get; set; }
        [CSSPRange(0.0D, 24.0D)]
        public double DischargeDuration_hour { get; set; }
        #endregion Properties in DB

        #region Constructors
        public BoxModel() : base()
        {
        }
        #endregion Constructors
    }
}
