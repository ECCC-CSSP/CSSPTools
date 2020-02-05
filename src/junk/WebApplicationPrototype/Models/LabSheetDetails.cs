using System;
using System.Collections.Generic;

namespace WebApplicationPrototype.Models
{
    public partial class LabSheetDetails
    {
        public LabSheetDetails()
        {
            LabSheetTubeMPNDetails = new HashSet<LabSheetTubeMPNDetails>();
        }

        public int LabSheetDetailID { get; set; }
        public int LabSheetID { get; set; }
        public int SamplingPlanID { get; set; }
        public int SubsectorTVItemID { get; set; }
        public int Version { get; set; }
        public DateTime RunDate { get; set; }
        public string Tides { get; set; }
        public string SampleCrewInitials { get; set; }
        public int? WaterBathCount { get; set; }
        public DateTime? IncubationBath1StartTime { get; set; }
        public DateTime? IncubationBath2StartTime { get; set; }
        public DateTime? IncubationBath3StartTime { get; set; }
        public DateTime? IncubationBath1EndTime { get; set; }
        public DateTime? IncubationBath2EndTime { get; set; }
        public DateTime? IncubationBath3EndTime { get; set; }
        public int? IncubationBath1TimeCalculated_minutes { get; set; }
        public int? IncubationBath2TimeCalculated_minutes { get; set; }
        public int? IncubationBath3TimeCalculated_minutes { get; set; }
        public string WaterBath1 { get; set; }
        public string WaterBath2 { get; set; }
        public string WaterBath3 { get; set; }
        public double? TCField1 { get; set; }
        public double? TCLab1 { get; set; }
        public double? TCField2 { get; set; }
        public double? TCLab2 { get; set; }
        public double? TCFirst { get; set; }
        public double? TCAverage { get; set; }
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
        public string Weather { get; set; }
        public string RunComment { get; set; }
        public string RunWeatherComment { get; set; }
        public string SampleBottleLotNumber { get; set; }
        public string SalinitiesReadBy { get; set; }
        public DateTime? SalinitiesReadDate { get; set; }
        public string ResultsReadBy { get; set; }
        public DateTime? ResultsReadDate { get; set; }
        public string ResultsRecordedBy { get; set; }
        public DateTime? ResultsRecordedDate { get; set; }
        public double? DailyDuplicateRLog { get; set; }
        public double? DailyDuplicatePrecisionCriteria { get; set; }
        public bool? DailyDuplicateAcceptable { get; set; }
        public double? IntertechDuplicateRLog { get; set; }
        public double? IntertechDuplicatePrecisionCriteria { get; set; }
        public bool? IntertechDuplicateAcceptable { get; set; }
        public bool? IntertechReadAcceptable { get; set; }
        public DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }

        public virtual LabSheets LabSheet { get; set; }
        public virtual SamplingPlans SamplingPlan { get; set; }
        public virtual TVItems SubsectorTVItem { get; set; }
        public virtual ICollection<LabSheetTubeMPNDetails> LabSheetTubeMPNDetails { get; set; }
    }
}
