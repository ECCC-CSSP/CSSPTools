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
    public partial class CSSPWQInputApp
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [StringLength(100, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Access code")]
        [CSSPDisplayFR(DisplayFR = "Code d'accès")]
        [CSSPDescriptionEN(DescriptionEN = @"Access code")]
        [CSSPDescriptionFR(DescriptionFR = @"Code d'accès")]
        public string AccessCode { get; set; }
        [StringLength(4, MinimumLength = 4)]
        [CSSPDisplayEN(DisplayEN = "Active year")]
        [CSSPDisplayFR(DisplayFR = "Année active")]
        [CSSPDescriptionEN(DescriptionEN = @"Active year")]
        [CSSPDescriptionFR(DescriptionFR = @"Année active")]
        public string ActiveYear { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Daily duplicate precision criteria")]
        [CSSPDisplayFR(DisplayFR = "Critère de précision du duplicata du la tournée")]
        [CSSPDescriptionEN(DescriptionEN = @"Daily duplicate precision criteria")]
        [CSSPDescriptionFR(DescriptionFR = @"Critère de précision du duplicata du la tournée")]
        public double DailyDuplicatePrecisionCriteria { get; set; }
        [Range(0.0D, 100.0D)]
        [CSSPDisplayEN(DisplayEN = "Intertech duplicate precision criteria")]
        [CSSPDisplayFR(DisplayFR = "Critère de précision du duplicata intertech")]
        [CSSPDescriptionEN(DescriptionEN = @"Intertech duplicate precision criteria")]
        [CSSPDescriptionFR(DescriptionFR = @"Critère de précision du duplicata intertech")]
        public double IntertechDuplicatePrecisionCriteria { get; set; }
        [CSSPDisplayEN(DisplayEN = "Include lab QA/QC")]
        [CSSPDisplayFR(DisplayFR = "Inclure QC/QC du lab")]
        [CSSPDescriptionEN(DescriptionEN = @"Include laboratory quality assurance / quality control")]
        [CSSPDescriptionFR(DescriptionFR = @"Inclure l'assurance quality / contrôle de qualité du laboratoire")]
        public bool IncludeLaboratoryQAQC { get; set; }
        [StringLength(100, MinimumLength = 1)]
        [CSSPDisplayEN(DisplayEN = "Approval code")]
        [CSSPDisplayFR(DisplayFR = "Code d'approbation")]
        [CSSPDescriptionEN(DescriptionEN = @"Approval code")]
        [CSSPDescriptionFR(DescriptionFR = @"Code d'approbation")]
        public string ApprovalCode { get; set; }
        [CSSPAfter(Year = 1980)]
        [CSSPDisplayEN(DisplayEN = "Approval date")]
        [CSSPDisplayFR(DisplayFR = "Date d'approbation")]
        [CSSPDescriptionEN(DescriptionEN = @"Approval date")]
        [CSSPDescriptionFR(DescriptionFR = @"Date d'approbation")]
        public DateTime ApprovalDate { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public CSSPWQInputApp() : base()
        {
        }
        #endregion Constructors
    }
}
