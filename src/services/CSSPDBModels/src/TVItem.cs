namespace CSSPDBModels;

public partial class TVItem : LastUpdate
{
    [Key]
    public int TVItemID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPRange(0, 100)]
    public int TVLevel { get; set; }
    [CSSPMaxLength(250)]
    public string TVPath { get; set; }
    [CSSPEnumType]
    public TVTypeEnum TVType { get; set; }
    [CSSPAllowNull]
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,9,10,11,12,13,14,15,16,17,18,19,20,21,31,75,79")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? ParentID { get; set; }
    public bool IsActive { get; set; }

    public TVItem() : base()
    {
    }
}

