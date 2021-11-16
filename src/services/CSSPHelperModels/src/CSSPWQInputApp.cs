/*
 * Manually edited
 * 
 */
using CSSPCustomAttributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPHelperModels
{
    [NotMapped]
    public partial class CSSPWQInputApp
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPMaxLength(100)]
        [CSSPMinLength(1)]
        public string AccessCode { get; set; }
        [CSSPMaxLength(4)]
        [CSSPMinLength(4)]
        public string ActiveYear { get; set; }
        [CSSPRange(0.0D, 100.0D)]
        public double DailyDuplicatePrecisionCriteria { get; set; }
        [CSSPRange(0.0D, 100.0D)]
        public double IntertechDuplicatePrecisionCriteria { get; set; }
        public bool IncludeLaboratoryQAQC { get; set; }
        [CSSPMaxLength(100)]
        [CSSPMinLength(1)]
        public string ApprovalCode { get; set; }
        [CSSPAfter(Year = 1980)]
        public DateTime ApprovalDate { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public CSSPWQInputApp() : base()
        {
        }
        #endregion Constructors
    }
}
