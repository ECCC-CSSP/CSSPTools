using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsDLL.Models
{
    public class LabSheetDetailModel : LastUpdateAndContactModel
    {
        public LabSheetDetailModel()
        {
        }

        public int LabSheetDetailID { get; set; }
        public int LabSheetID { get; set; }
        public int SamplingPlanID { get; set; }
        public int SubsectorTVItemID { get; set; }
        public string SubsectorTVText { get; set; }
        public int Version { get; set; }
        public System.DateTime RunDate { get; set; }
        public string Tides { get; set; }
        public string SampleCrewInitials { get; set; }
        public Nullable<int> WaterBathCount { get; set; }
        public Nullable<System.DateTime> IncubationBath1StartTime { get; set; }
        public Nullable<System.DateTime> IncubationBath2StartTime { get; set; }
        public Nullable<System.DateTime> IncubationBath3StartTime { get; set; }
        public Nullable<System.DateTime> IncubationBath1EndTime { get; set; }
        public Nullable<System.DateTime> IncubationBath2EndTime { get; set; }
        public Nullable<System.DateTime> IncubationBath3EndTime { get; set; }
        public Nullable<int> IncubationBath1TimeCalculated_minutes { get; set; }
        public Nullable<int> IncubationBath2TimeCalculated_minutes { get; set; }
        public Nullable<int> IncubationBath3TimeCalculated_minutes { get; set; }
        public string WaterBath1 { get; set; }
        public string WaterBath2 { get; set; }
        public string WaterBath3 { get; set; }
        public Nullable<float> TCField1 { get; set; }
        public Nullable<float> TCLab1 { get; set; }
        public Nullable<float> TCField2 { get; set; }
        public Nullable<float> TCLab2 { get; set; }
        public Nullable<float> TCFirst { get; set; }
        public Nullable<float> TCAverage { get; set; }
        public string ControlLot { get; set; }
        public string Positive35 { get; set; }
        public string NonTarget35 { get; set; }
        public string Negative35 { get; set; }
        public string Bath1Positive44_5 { get; set; }
        public string Bath2Positive44_5 { get; set; }
        public string Bath3Positive44_5 { get; set; }
        public string Bath1NonTarget44_5 { get; set; }
        public string Bath2NonTarget44_5 { get; set; }
        public string Bath3NonTarget44_5 { get; set; }
        public string Bath1Negative44_5 { get; set; }
        public string Bath2Negative44_5 { get; set; }
        public string Bath3Negative44_5 { get; set; }
        public string Blank35 { get; set; }
        public string Bath1Blank44_5 { get; set; }
        public string Bath2Blank44_5 { get; set; }
        public string Bath3Blank44_5 { get; set; }
        public string Lot35 { get; set; }
        public string Lot44_5 { get; set; }
        public string RunComment { get; set; }
        public string RunWeatherComment { get; set; }
        public string SampleBottleLotNumber { get; set; }
        public string SalinitiesReadBy { get; set; }
        public Nullable<System.DateTime> SalinitiesReadDate { get; set; }
        public string ResultsReadBy { get; set; }
        public Nullable<System.DateTime> ResultsReadDate { get; set; }
        public string ResultsRecordedBy { get; set; }
        public Nullable<System.DateTime> ResultsRecordedDate { get; set; }
        public Nullable<double> DailyDuplicateRLog { get; set; }
        public Nullable<double> DailyDuplicatePrecisionCriteria { get; set; }
        public Nullable<bool> DailyDuplicateAcceptable { get; set; }
        public Nullable<double> IntertechDuplicateRLog { get; set; }
        public Nullable<double> IntertechDuplicatePrecisionCriteria { get; set; }
        public Nullable<bool> IntertechDuplicateAcceptable { get; set; }
        public Nullable<bool> IntertechReadAcceptable { get; set; }
        public bool IncludeLaboratoryQAQC { get; set; }
    }

}
