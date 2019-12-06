using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class MWQMAnalysisReportParameterModel : LastUpdateAndContactModel
    {
        public MWQMAnalysisReportParameterModel()
        {
        }
        public int MWQMAnalysisReportParameterID { get; set; }
        public int SubsectorTVItemID { get; set; }
        public string AnalysisName { get; set; }
        public int? AnalysisReportYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AnalysisCalculationTypeEnum AnalysisCalculationType { get; set; }
        public int NumberOfRuns { get; set; }
        public bool FullYear { get; set; }
        public float SalinityHighlightDeviationFromAverage { get; set; }
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
        public string ExcelTVFileTVText { get; set; }
        public AnalysisReportExportCommandEnum Command { get; set; }

    }
}
