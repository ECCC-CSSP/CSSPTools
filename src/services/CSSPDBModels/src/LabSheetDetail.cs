namespace CSSPDBModels;

public partial class LabSheetDetail : LastUpdate
{
    [Key]
    public int LabSheetDetailID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "LabSheet", ExistPlurial = "s", ExistFieldID = "LabSheetID")]
    [CSSPForeignKey(TableName = "LabSheets", FieldName = "LabSheetID")]
    public int LabSheetID { get; set; }
    [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID")]
    [CSSPForeignKey(TableName = "SamplingPlans", FieldName = "SamplingPlanID")]
    public int SamplingPlanID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "20")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int SubsectorTVItemID { get; set; }
    [CSSPRange(1, 5)]
    public int Version { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime RunDate { get; set; }
    [CSSPMaxLength(7)]
    [CSSPMinLength(1)]
    public string Tides { get; set; }
    [CSSPMaxLength(20)]
    [CSSPAllowNull]
    public string SampleCrewInitials { get; set; }
    [CSSPRange(1, 3)]
    public int? WaterBathCount { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? IncubationBath1StartTime { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? IncubationBath2StartTime { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? IncubationBath3StartTime { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? IncubationBath1EndTime { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? IncubationBath2EndTime { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? IncubationBath3EndTime { get; set; }
    [CSSPRange(0, 10000)]
    public int? IncubationBath1TimeCalculated_minutes { get; set; }
    [CSSPRange(0, 10000)]
    public int? IncubationBath2TimeCalculated_minutes { get; set; }
    [CSSPRange(0, 10000)]
    public int? IncubationBath3TimeCalculated_minutes { get; set; }
    [CSSPMaxLength(10)]
    [CSSPAllowNull]
    public string WaterBath1 { get; set; }
    [CSSPMaxLength(10)]
    [CSSPAllowNull]
    public string WaterBath2 { get; set; }
    [CSSPMaxLength(10)]
    [CSSPAllowNull]
    public string WaterBath3 { get; set; }
    [CSSPRange(-10.0D, 40.0D)]
    public double? TCField1 { get; set; }
    [CSSPRange(-10.0D, 40.0D)]
    public double? TCLab1 { get; set; }
    [CSSPRange(-10.0D, 40.0D)]
    public double? TCField2 { get; set; }
    [CSSPRange(-10.0D, 40.0D)]
    public double? TCLab2 { get; set; }
    [CSSPRange(-10.0D, 40.0D)]
    public double? TCFirst { get; set; }
    [CSSPRange(-10.0D, 40.0D)]
    public double? TCAverage { get; set; }
    [CSSPMaxLength(100)]
    [CSSPAllowNull]
    public string ControlLot { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Positive35 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string NonTarget35 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Negative35 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Bath1Positive44_5 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Bath2Positive44_5 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Bath3Positive44_5 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Bath1NonTarget44_5 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Bath2NonTarget44_5 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Bath3NonTarget44_5 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Bath1Negative44_5 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Bath2Negative44_5 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Bath3Negative44_5 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Blank35 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Bath1Blank44_5 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Bath2Blank44_5 { get; set; }
    [CSSPMaxLength(1)]
    [CSSPMinLength(1)]
    [CSSPAllowNull]
    public string Bath3Blank44_5 { get; set; }
    [CSSPMaxLength(20)]
    [CSSPAllowNull]
    public string Lot35 { get; set; }
    [CSSPMaxLength(20)]
    [CSSPAllowNull]
    public string Lot44_5 { get; set; }
    [CSSPMaxLength(250)]
    [CSSPAllowNull]
    public string Weather { get; set; }
    [CSSPMaxLength(250)]
    [CSSPAllowNull]
    public string RunComment { get; set; }
    [CSSPMaxLength(250)]
    [CSSPAllowNull]
    public string RunWeatherComment { get; set; }
    [CSSPMaxLength(20)]
    [CSSPAllowNull]
    public string SampleBottleLotNumber { get; set; }
    [CSSPMaxLength(20)]
    [CSSPAllowNull]
    public string SalinitiesReadBy { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? SalinitiesReadDate { get; set; }
    [CSSPMaxLength(20)]
    [CSSPAllowNull]
    public string ResultsReadBy { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? ResultsReadDate { get; set; }
    [CSSPMaxLength(20)]
    [CSSPAllowNull]
    public string ResultsRecordedBy { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? ResultsRecordedDate { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? DailyDuplicateRLog { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? DailyDuplicatePrecisionCriteria { get; set; }
    public bool? DailyDuplicateAcceptable { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? IntertechDuplicateRLog { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? IntertechDuplicatePrecisionCriteria { get; set; }
    public bool? IntertechDuplicateAcceptable { get; set; }
    public bool? IntertechReadAcceptable { get; set; }

    public LabSheetDetail() : base()
    {
    }
}

