namespace CSSPDBModels;

public partial class AppTask : LastUpdate
{
    [Key]
    public int AppTaskID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,6,8,9,11,12,14,15,16,17,18,19,20,22,24,25,26,29,30,41,42")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int TVItemID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,6,8,9,11,12,14,15,16,17,18,19,20,22,24,25,26,29,30,41,42")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int TVItemID2 { get; set; }
    [CSSPEnumType]
    public AppTaskCommandEnum AppTaskCommand { get; set; }
    [CSSPEnumType]
    public AppTaskStatusEnum AppTaskStatus { get; set; }
    [CSSPRange(0, 100)]
    public int PercentCompleted { get; set; }
    public string Parameters { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime StartDateTime_UTC { get; set; }
    [CSSPAfter(Year = 1980)]
    [CSSPBigger(OtherField = "StartDateTime_UTC")]
    public DateTime? EndDateTime_UTC { get; set; }
    [CSSPRange(0, 1000000)]
    public int? EstimatedLength_second { get; set; }
    [CSSPRange(0, 1000000)]
    public int? RemainingTime_second { get; set; }

    public AppTask() : base()
    {
    }
}
