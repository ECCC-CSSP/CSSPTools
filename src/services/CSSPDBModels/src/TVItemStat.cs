namespace CSSPDBModels;

public partial class TVItemStat : LastUpdate
{
    [Key]
    public int TVItemStatID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int TVItemID { get; set; }
    [CSSPEnumType]
    public TVTypeEnum TVType { get; set; }
    [CSSPRange(0, 10000000)]
    public int ChildCount { get; set; }

    public TVItemStat() : base()
    {
    }
}

