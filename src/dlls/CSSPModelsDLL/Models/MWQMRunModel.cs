using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class MWQMRunModel : LastUpdateAndContactModel
    {
        public MWQMRunModel()
        {
        }
        public int MWQMRunID { get; set; }
        public int SubsectorTVItemID { get; set; }
        public string SubsectorTVText { get; set; }
        public int MWQMRunTVItemID { get; set; }
        public string MWQMRunTVText { get; set; }
        public SampleTypeEnum RunSampleType { get; set; }
        public string RunComment { get; set; }
        public string RunWeatherComment { get; set; }
        public System.DateTime DateTime_Local { get; set; }
        public int RunNumber { get; set; }
        public Nullable<System.DateTime> StartDateTime_Local { get; set; }
        public Nullable<System.DateTime> EndDateTime_Local { get; set; }
        public Nullable<System.DateTime> LabReceivedDateTime_Local { get; set; }
        public Nullable<double> TemperatureControl1_C { get; set; }
        public Nullable<double> TemperatureControl2_C { get; set; }
        public Nullable<BeaufortScaleEnum> SeaStateAtStart_BeaufortScale { get; set; }
        public Nullable<BeaufortScaleEnum> SeaStateAtEnd_BeaufortScale { get; set; }
        public Nullable<double> WaterLevelAtBrook_m { get; set; }
        public Nullable<double> WaveHightAtStart_m { get; set; }
        public Nullable<double> WaveHightAtEnd_m { get; set; }
        public string SampleCrewInitials { get; set; }
        public Nullable<AnalyzeMethodEnum> AnalyzeMethod { get; set; }
        public Nullable<SampleMatrixEnum> SampleMatrix { get; set; }
        public Nullable<LaboratoryEnum> Laboratory { get; set; }
        public Nullable<SampleStatusEnum> SampleStatus { get; set; }
        public Nullable<int> LabSampleApprovalContactTVItemID { get; set; }
        public string ValidatorContactTVText { get; set; }
        public Nullable<System.DateTime> LabAnalyzeBath1IncubationStartDateTime_Local { get; set; }
        public Nullable<System.DateTime> LabAnalyzeBath2IncubationStartDateTime_Local { get; set; }
        public Nullable<System.DateTime> LabAnalyzeBath3IncubationStartDateTime_Local { get; set; }
        public Nullable<System.DateTime> LabRunSampleApprovalDateTime_Local { get; set; }
        public Nullable<TideTextEnum> Tide_Start { get; set; }
        public Nullable<TideTextEnum> Tide_End { get; set; }
        public Nullable<double> RainDay0_mm { get; set; }
        public Nullable<double> RainDay1_mm { get; set; }
        public Nullable<double> RainDay2_mm { get; set; }
        public Nullable<double> RainDay3_mm { get; set; }
        public Nullable<double> RainDay4_mm { get; set; }
        public Nullable<double> RainDay5_mm { get; set; }
        public Nullable<double> RainDay6_mm { get; set; }
        public Nullable<double> RainDay7_mm { get; set; }
        public Nullable<double> RainDay8_mm { get; set; }
        public Nullable<double> RainDay9_mm { get; set; }
        public Nullable<double> RainDay10_mm { get; set; }
        public Nullable<bool> RemoveFromStat { get; set; }
    }

    public class RunsToRemoveFromStat
    {
        public int MWQMRunTVItemID { get; set; }
        public bool RemoveFromStat { get; set; }
    }
}
