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
    public partial class SubsectorMWQMSampleYear
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(1, -1)]
        public int SubsectorTVItemID { get; set; }
        public int Year { get; set; }
        [CSSPAfter(Year = 1980)]
        public DateTime EarliestDate { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPBigger(OtherField = "EarliestDate")]
        public DateTime LatestDate { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public SubsectorMWQMSampleYear() : base()
        {
        }
        #endregion Constructors
    }
}
