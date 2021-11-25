namespace CSSPDBModels;

public partial class SamplingPlan : LastUpdate
{
    [Key]
    public int SamplingPlanID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    public bool IsActive { get; set; }
    [CSSPMaxLength(200)]
    public string SamplingPlanName { get; set; }
    [CSSPMaxLength(100)]
    public string ForGroupName { get; set; }
    [CSSPEnumType]
    public SampleTypeEnum SampleType { get; set; }
    [CSSPEnumType]
    public SamplingPlanTypeEnum SamplingPlanType { get; set; }
    [CSSPEnumType]
    public LabSheetTypeEnum LabSheetType { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "18")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int ProvinceTVItemID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int CreatorTVItemID { get; set; }
    [CSSPRange(2000, 2050)]
    public int Year { get; set; }
    [CSSPMaxLength(15)]
    public string AccessCode { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double DailyDuplicatePrecisionCriteria { get; set; }
    [CSSPRange(0.0D, 100.0D)]
    public double IntertechDuplicatePrecisionCriteria { get; set; }
    public bool IncludeLaboratoryQAQC { get; set; }
    [CSSPMaxLength(15)]
    public string ApprovalCode { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "8")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? SamplingPlanFileTVItemID { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public AnalyzeMethodEnum? AnalyzeMethodDefault { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public SampleMatrixEnum? SampleMatrixDefault { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public LaboratoryEnum? LaboratoryDefault { get; set; }
    [CSSPMaxLength(250)]
    public string BackupDirectory { get; set; }

    public SamplingPlan() : base()
    {
    }
}

