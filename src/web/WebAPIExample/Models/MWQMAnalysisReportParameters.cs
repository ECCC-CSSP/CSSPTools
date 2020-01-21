using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models
{
    public partial class MWQMAnalysisReportParameters
    {
        [Key]
        public int MWQMAnalysisReportParameterID { get; set; }
        public int SubsectorTVItemID { get; set; }
        [Required]
        [StringLength(250)]
        public string AnalysisName { get; set; }
        public int? AnalysisReportYear { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EndDate { get; set; }
        public int AnalysisCalculationType { get; set; }
        public int NumberOfRuns { get; set; }
        public bool FullYear { get; set; }
        public double SalinityHighlightDeviationFromAverage { get; set; }
        public int ShortRangeNumberOfDays { get; set; }
        public int MidRangeNumberOfDays { get; set; }
        public int DryLimit24h { get; set; }
        public int DryLimit48h { get; set; }
        public int DryLimit72h { get; set; }
        public int DryLimit96h { get; set; }
        public int WetLimit24h { get; set; }
        public int WetLimit48h { get; set; }
        public int WetLimit72h { get; set; }
        public int WetLimit96h { get; set; }
        [Required]
        [StringLength(4000)]
        public string RunsToOmit { get; set; }
        [StringLength(20)]
        public string ShowDataTypes { get; set; }
        public int? ExcelTVFileTVItemID { get; set; }
        public int Command { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        [ForeignKey(nameof(ExcelTVFileTVItemID))]
        [InverseProperty(nameof(TVItems.MWQMAnalysisReportParametersExcelTVFileTVItem))]
        public virtual TVItems ExcelTVFileTVItem { get; set; }
        [ForeignKey(nameof(SubsectorTVItemID))]
        [InverseProperty(nameof(TVItems.MWQMAnalysisReportParametersSubsectorTVItem))]
        public virtual TVItems SubsectorTVItem { get; set; }
    }
}
