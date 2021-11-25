namespace CSSPDBModels;

public partial class LabSheet : LastUpdate
{
    [Key]
    public int LabSheetID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPRange(1, -1)]
    public int OtherServerLabSheetID { get; set; }
    [CSSPExist(ExistTypeName = "SamplingPlan", ExistPlurial = "s", ExistFieldID = "SamplingPlanID")]
    [CSSPForeignKey(TableName = "SamplingPlans", FieldName = "SamplingPlanID")]
    public int SamplingPlanID { get; set; }
    [CSSPMaxLength(250)]
    [CSSPMinLength(1)]
    public string SamplingPlanName { get; set; }
    [CSSPRange(1980, -1)]
    public int Year { get; set; }
    [CSSPRange(1, 12)]
    public int Month { get; set; }
    [CSSPRange(1, 31)]
    public int Day { get; set; }
    [CSSPRange(1, 100)]
    public int RunNumber { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "20")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int SubsectorTVItemID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "31")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? MWQMRunTVItemID { get; set; }
    [CSSPEnumType]
    public SamplingPlanTypeEnum SamplingPlanType { get; set; }
    [CSSPEnumType]
    public SampleTypeEnum SampleType { get; set; }
    [CSSPEnumType]
    public LabSheetTypeEnum LabSheetType { get; set; }
    [CSSPEnumType]
    public LabSheetStatusEnum LabSheetStatus { get; set; }
    [CSSPMaxLength(250)]
    [CSSPMinLength(1)]
    public string FileName { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime FileLastModifiedDate_Local { get; set; }
    public string FileContent { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? AcceptedOrRejectedByContactTVItemID { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? AcceptedOrRejectedDateTime { get; set; }
    [CSSPMaxLength(250)]
    [CSSPAllowNull]
    public string RejectReason { get; set; }

    public LabSheet() : base()
    {
    }
}

