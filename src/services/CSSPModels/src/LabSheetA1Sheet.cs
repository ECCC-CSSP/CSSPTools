namespace CSSPModels;

[NotMapped]
public partial class LabSheetA1Sheet
{
    [CSSPRange(1, 100)]
    public int Version { get; set; }
    [CSSPEnumType]
    public SamplingPlanTypeEnum SamplingPlanType { get; set; }
    [CSSPEnumType]
    public SampleTypeEnum SampleType { get; set; }
    [CSSPEnumType]
    public LabSheetTypeEnum LabSheetType { get; set; }
    [CSSPMaxLength(1000)]
    public string SubsectorName { get; set; }
    [CSSPMaxLength(1000)]
    public string SubsectorLocation { get; set; }
    [CSSPRange(1, -1)]
    public int SubsectorTVItemID { get; set; }
    [CSSPMaxLength(4)]
    public string RunYear { get; set; }
    [CSSPMaxLength(2)]
    public string RunMonth { get; set; }
    [CSSPMaxLength(2)]
    public string RunDay { get; set; }
    [CSSPRange(1, 100)]
    public int RunNumber { get; set; }
    [CSSPMaxLength(10)]
    public string Tides { get; set; }
    [CSSPMaxLength(50)]
    public string SampleCrewInitials { get; set; }
    [CSSPMaxLength(8)]
    public string IncubationStartSameDay { get; set; }
    [CSSPRange(1, 5)]
    public int WaterBathCount { get; set; }
    [CSSPMaxLength(8)]
    public string IncubationBath1StartTime { get; set; }
    [CSSPMaxLength(8)]
    public string IncubationBath2StartTime { get; set; }
    [CSSPMaxLength(8)]
    public string IncubationBath3StartTime { get; set; }
    [CSSPMaxLength(8)]
    public string IncubationBath1EndTime { get; set; }
    [CSSPMaxLength(8)]
    public string IncubationBath2EndTime { get; set; }
    [CSSPMaxLength(8)]
    public string IncubationBath3EndTime { get; set; }
    [CSSPMaxLength(8)]
    public string IncubationBath1TimeCalculated { get; set; }
    [CSSPMaxLength(8)]
    public string IncubationBath2TimeCalculated { get; set; }
    [CSSPMaxLength(8)]
    public string IncubationBath3TimeCalculated { get; set; }
    [CSSPMaxLength(5)]
    public string WaterBath1 { get; set; }
    [CSSPMaxLength(5)]
    public string WaterBath2 { get; set; }
    [CSSPMaxLength(5)]
    public string WaterBath3 { get; set; }
    [CSSPMaxLength(5)]
    public string TCField1 { get; set; }
    [CSSPMaxLength(5)]
    public string TCLab1 { get; set; }
    [CSSPMaxLength(5)]
    public string TCHas2Coolers { get; set; }
    [CSSPMaxLength(5)]
    public string TCField2 { get; set; }
    [CSSPMaxLength(5)]
    public string TCLab2 { get; set; }
    [CSSPMaxLength(5)]
    public string TCFirst { get; set; }
    [CSSPMaxLength(5)]
    public string TCAverage { get; set; }
    [CSSPMaxLength(100)]
    public string ControlLot { get; set; }
    [CSSPMaxLength(1)]
    public string Positive35 { get; set; }
    [CSSPMaxLength(1)]
    public string NonTarget35 { get; set; }
    [CSSPMaxLength(1)]
    public string Negative35 { get; set; }
    [CSSPMaxLength(1)]
    public string Bath1Positive44_5 { get; set; }
    [CSSPMaxLength(1)]
    public string Bath2Positive44_5 { get; set; }
    [CSSPMaxLength(1)]
    public string Bath3Positive44_5 { get; set; }
    [CSSPMaxLength(1)]
    public string Bath1NonTarget44_5 { get; set; }
    [CSSPMaxLength(1)]
    public string Bath2NonTarget44_5 { get; set; }
    [CSSPMaxLength(1)]
    public string Bath3NonTarget44_5 { get; set; }
    [CSSPMaxLength(1)]
    public string Bath1Negative44_5 { get; set; }
    [CSSPMaxLength(1)]
    public string Bath2Negative44_5 { get; set; }
    [CSSPMaxLength(1)]
    public string Bath3Negative44_5 { get; set; }
    [CSSPMaxLength(1)]
    public string Blank35 { get; set; }
    [CSSPMaxLength(1)]
    public string Bath1Blank44_5 { get; set; }
    [CSSPMaxLength(1)]
    public string Bath2Blank44_5 { get; set; }
    [CSSPMaxLength(1)]
    public string Bath3Blank44_5 { get; set; }
    [CSSPMaxLength(5)]
    public string Lot35 { get; set; }
    [CSSPMaxLength(5)]
    public string Lot44_5 { get; set; }
    [CSSPMaxLength(10000)]
    public string RunComment { get; set; }
    [CSSPMaxLength(10000)]
    public string RunWeatherComment { get; set; }
    [CSSPMaxLength(10)]
    public string SampleBottleLotNumber { get; set; }
    [CSSPMaxLength(100)]
    public string SalinitiesReadBy { get; set; }
    [CSSPMaxLength(4)]
    public string SalinitiesReadYear { get; set; }
    [CSSPMaxLength(2)]
    public string SalinitiesReadMonth { get; set; }
    [CSSPMaxLength(2)]
    public string SalinitiesReadDay { get; set; }
    [CSSPMaxLength(100)]
    public string ResultsReadBy { get; set; }
    [CSSPMaxLength(4)]
    public string ResultsReadYear { get; set; }
    [CSSPMaxLength(2)]
    public string ResultsReadMonth { get; set; }
    [CSSPMaxLength(2)]
    public string ResultsReadDay { get; set; }
    [CSSPMaxLength(100)]
    public string ResultsRecordedBy { get; set; }
    [CSSPMaxLength(4)]
    public string ResultsRecordedYear { get; set; }
    [CSSPMaxLength(2)]
    public string ResultsRecordedMonth { get; set; }
    [CSSPMaxLength(2)]
    public string ResultsRecordedDay { get; set; }
    [CSSPMaxLength(10)]
    public string DailyDuplicateRLog { get; set; }
    [CSSPMaxLength(10)]
    public string DailyDuplicatePrecisionCriteria { get; set; }
    [CSSPMaxLength(20)]
    public string DailyDuplicateAcceptableOrUnacceptable { get; set; }
    [CSSPMaxLength(10)]
    public string IntertechDuplicateRLog { get; set; }
    [CSSPMaxLength(10)]
    public string IntertechDuplicatePrecisionCriteria { get; set; }
    [CSSPMaxLength(20)]
    public string IntertechDuplicateAcceptableOrUnacceptable { get; set; }
    [CSSPMaxLength(20)]
    public string IntertechReadAcceptableOrUnacceptable { get; set; }
    [CSSPMaxLength(4)]
    public string ApprovalYear { get; set; }
    [CSSPMaxLength(2)]
    public string ApprovalMonth { get; set; }
    [CSSPMaxLength(2)]
    public string ApprovalDay { get; set; }
    [CSSPMaxLength(10)]
    public string ApprovedBySupervisorInitials { get; set; }
    public bool IncludeLaboratoryQAQC { get; set; }
    [CSSPMaxLength(250)]
    public string BackupDirectory { get; set; }
    [CSSPMaxLength(1000000)]
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

    public LabSheetA1Sheet() : base()
    {
        LabSheetA1MeasurementList = new List<LabSheetA1Measurement>();
    }
}

