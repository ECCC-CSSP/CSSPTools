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
    public partial class VPResult : LastUpdate
    {
        #region Properties in DB
        [Key]
        public int VPResultID { get; set; }
        [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID")]
        public int VPScenarioID { get; set; }
        [CSSPRange(0, 1000)]
        public int Ordinal { get; set; }
        [CSSPRange(0, 10000000)]
        public int Concentration_MPN_100ml { get; set; }
        [CSSPRange(0.0D, 1000000.0D)]
        public double Dilution { get; set; }
        [CSSPRange(0.0D, 10000.0D)]
        public double FarFieldWidth_m { get; set; }
        [CSSPRange(0.0D, 100000.0D)]
        public double DispersionDistance_m { get; set; }
        [CSSPRange(0.0D, 100.0D)]
        public double TravelTime_hour { get; set; }
        #endregion Properties in DB

        #region Constructors
        public VPResult() : base()
        {
        }
        #endregion Constructors
    }
}
