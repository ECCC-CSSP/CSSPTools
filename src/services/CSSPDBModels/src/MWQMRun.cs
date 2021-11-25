namespace CSSPDBModels;

public partial class MWQMRun : LastUpdate
{
    [Key]
    public int MWQMRunID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "20")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int SubsectorTVItemID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "31")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int MWQMRunTVItemID { get; set; }
    [CSSPEnumType]
    public SampleTypeEnum RunSampleType { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime DateTime_Local { get; set; }
    [CSSPRange(1, 1000)]
    public int RunNumber { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? StartDateTime_Local { get; set; }
    [CSSPAfter(Year = 1980)]
    [CSSPBigger(OtherField = "StartDateTime_Local")]
    public DateTime? EndDateTime_Local { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? LabReceivedDateTime_Local { get; set; }
    [CSSPRange(-10.0D, 40.0D)]
    public double? TemperatureControl1_C { get; set; }
    [CSSPRange(-10.0D, 40.0D)]
    public double? TemperatureControl2_C { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public BeaufortScaleEnum? SeaStateAtStart_BeaufortScale { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public BeaufortScaleEnum? SeaStateAtEnd_BeaufortScale { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? WaterLevelAtBrook_m { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? WaveHightAtStart_m { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double? WaveHightAtEnd_m { get; set; }
    [CSSPMaxLength(20)]
    [CSSPAllowNull]
    public string SampleCrewInitials { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public AnalyzeMethodEnum? AnalyzeMethod { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public SampleMatrixEnum? SampleMatrix { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public LaboratoryEnum? Laboratory { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public SampleStatusEnum? SampleStatus { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? LabSampleApprovalContactTVItemID { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? LabAnalyzeBath1IncubationStartDateTime_Local { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? LabAnalyzeBath2IncubationStartDateTime_Local { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? LabAnalyzeBath3IncubationStartDateTime_Local { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? LabRunSampleApprovalDateTime_Local { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public TideTextEnum? Tide_Start { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public TideTextEnum? Tide_End { get; set; }
    [CSSPRange(0.0D, 300.0D)]
    public double? RainDay0_mm { get; set; }
    [CSSPRange(0.0D, 300.0D)]
    public double? RainDay1_mm { get; set; }
    [CSSPRange(0.0D, 300.0D)]
    public double? RainDay2_mm { get; set; }
    [CSSPRange(0.0D, 300.0D)]
    public double? RainDay3_mm { get; set; }
    [CSSPRange(0.0D, 300.0D)]
    public double? RainDay4_mm { get; set; }
    [CSSPRange(0.0D, 300.0D)]
    public double? RainDay5_mm { get; set; }
    [CSSPRange(0.0D, 300.0D)]
    public double? RainDay6_mm { get; set; }
    [CSSPRange(0.0D, 300.0D)]
    public double? RainDay7_mm { get; set; }
    [CSSPRange(0.0D, 300.0D)]
    public double? RainDay8_mm { get; set; }
    [CSSPRange(0.0D, 300.0D)]
    public double? RainDay9_mm { get; set; }
    [CSSPRange(0.0D, 300.0D)]
    public double? RainDay10_mm { get; set; }
    public bool? RemoveFromStat { get; set; }

    public MWQMRun() : base()
    {
    }
}

