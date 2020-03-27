using System;
using System.Collections.Generic;

namespace CSSPWebAPIs.Models.Temp
{
    public partial class MWQMAnalysisReportParameters
    {
        public int MWQMAnalysisReportParameterID { get; set; }
        public int SubsectorTVItemID { get; set; }
        public string AnalysisName { get; set; }
        public int? AnalysisReportYear { get; set; }
        public DateTime StartDate { get; set; }
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
        public string RunsToOmit { get; set; }
        public string ShowDataTypes { get; set; }
        public int? ExcelTVFileTVItemID { get; set; }
        public int Command { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual TVItems ExcelTVFileTVItem { get; set; }
        public virtual TVItems SubsectorTVItem { get; set; }
    }
}
