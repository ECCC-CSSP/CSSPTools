/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using CSSPEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CSSPWebModels
{

    [NotMapped]
    public partial class StatMWQMRun
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        public int? RunIndex { get; set; }
        public int? MWQMRunTVItemID { get; set; }
        public bool? IsOKRun { get; set; }
        public bool? RemoveFromStat { get; set; }
        public DateTime? RunDate { get; set; }
        public double? RainDay0 { get; set; }
        public double? RainDay1 { get; set; }
        public double? RainDay2 { get; set; }
        public double? RainDay3 { get; set; }
        public double? RainDay4 { get; set; }
        public double? RainDay5 { get; set; }
        public double? RainDay6 { get; set; }
        public double? RainDay7 { get; set; }
        public double? RainDay8 { get; set; }
        public double? RainDay9 { get; set; }
        public double? RainDay10 { get; set; }
        [CSSPEnumType]
        public TideTextEnum StartTide { get; set; }
        [CSSPEnumType]
        public TideTextEnum EndTide { get; set; }
        public bool? UseInStat { get; set; }
        public int? RunYear { get; set; }
        public int? RunMonth { get; set; }
        public int? RunDay { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public StatMWQMRun()
        {
        }
        #endregion Constructors
    }
}
