namespace CSSPDBModels;

public partial class DrogueRun : LastUpdate
{
    [Key]
    public int DrogueRunID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "20")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int SubsectorTVItemID { get; set; }
    [CSSPRange(0, 100)]
    public int DrogueNumber { get; set; }
    [CSSPEnumType]
    public DrogueTypeEnum DrogueType { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime RunStartDateTime { get; set; }
    public bool IsRisingTide { get; set; }

    public DrogueRun() : base()
    {
    }
}

