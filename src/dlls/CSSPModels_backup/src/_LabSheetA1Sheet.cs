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
    public partial class LabSheetA1Sheet
    {
        #region Properties in DB
        #endregion Properties in DB

        #region Properties not in DB
        [CSSPRange(1, 100)]
        public int Version { get; set; }
        [CSSPEnumType]
        public SamplingPlanTypeEnum SamplingPlanType { get; set; }
        [CSSPEnumType]
        public SampleTypeEnum SampleType { get; set; }
        [CSSPEnumType]
        public LabSheetTypeEnum LabSheetType { get; set; }
        public string SubsectorName { get; set; }
        public string SubsectorLocation { get; set; }
        public int SubsectorTVItemID { get; set; }
        public string RunYear { get; set; }
        public string RunMonth { get; set; }
        public string RunDay { get; set; }
        public int RunNumber { get; set; }
        public string Tides { get; set; }
        public string SampleCrewInitials { get; set; }
        public string IncubationStartSameDay { get; set; }
        public int WaterBathCount { get; set; }
        public string IncubationBath1StartTime { get; set; }
        public string IncubationBath2StartTime { get; set; }
        public string IncubationBath3StartTime { get; set; }
        public string IncubationBath1EndTime { get; set; }
        public string IncubationBath2EndTime { get; set; }
        public string IncubationBath3EndTime { get; set; }
        public string IncubationBath1TimeCalculated { get; set; }
        public string IncubationBath2TimeCalculated { get; set; }
        public string IncubationBath3TimeCalculated { get; set; }
        public string WaterBath1 { get; set; }
        public string WaterBath2 { get; set; }
        public string WaterBath3 { get; set; }
        public string TCField1 { get; set; }
        public string TCLab1 { get; set; }
        public string TCHas2Coolers { get; set; }
        public string TCField2 { get; set; }
        public string TCLab2 { get; set; }
        public string TCFirst { get; set; }
        public string TCAverage { get; set; }
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
        public string SalinitiesReadYear { get; set; }
        public string SalinitiesReadMonth { get; set; }
        public string SalinitiesReadDay { get; set; }
        public string ResultsReadBy { get; set; }
        public string ResultsReadYear { get; set; }
        public string ResultsReadMonth { get; set; }
        public string ResultsReadDay { get; set; }
        public string ResultsRecordedBy { get; set; }
        public string ResultsRecordedYear { get; set; }
        public string ResultsRecordedMonth { get; set; }
        public string ResultsRecordedDay { get; set; }
        public string DailyDuplicateRLog { get; set; }
        public string DailyDuplicatePrecisionCriteria { get; set; }
        public string DailyDuplicateAcceptableOrUnacceptable { get; set; }
        public string IntertechDuplicateRLog { get; set; }
        public string IntertechDuplicatePrecisionCriteria { get; set; }
        public string IntertechDuplicateAcceptableOrUnacceptable { get; set; }
        public string IntertechReadAcceptableOrUnacceptable { get; set; }
        public string ApprovalYear { get; set; }
        public string ApprovalMonth { get; set; }
        public string ApprovalDay { get; set; }
        public string ApprovedBySupervisorInitials { get; set; }
        public bool IncludeLaboratoryQAQC { get; set; }
        public string BackupDirectory { get; set; }
        public string Log { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "SamplingPlanTypeEnum", EnumType = "SamplingPlanType")]
        [CSSPAllowNull]
        public string SamplingPlanTypeText { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "SampleTypeEnum", EnumType = "SampleType")]
        [CSSPAllowNull]
        public string SampleTypeText { get; set; }
        [CSSPMaxLength(100)]
        [CSSPEnumTypeText(EnumTypeName = "LabSheetTypeEnum", EnumType = "LabSheetType")]
        [CSSPAllowNull]
        public string LabSheetTypeText { get; set; }
        public List<LabSheetA1Measurement> LabSheetA1MeasurementList { get; set; }
        #endregion Properties not in DB

        #region Constructors
        public LabSheetA1Sheet() : base()
        {
            LabSheetA1MeasurementList = new List<LabSheetA1Measurement>();
        }
        #endregion Constructors
    }
}
