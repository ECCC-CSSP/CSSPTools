namespace CSSPDBModels;

public partial class TVItemLink : LastUpdate
{
    [Key]
    public int TVItemLinkID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int FromTVItemID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int ToTVItemID { get; set; }
    [CSSPEnumType]
    public TVTypeEnum FromTVType { get; set; }
    [CSSPEnumType]
    public TVTypeEnum ToTVType { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? StartDateTime_Local { get; set; }
    [CSSPAfter(Year = 1980)]
    [CSSPBigger(OtherField = "StartDateTime_Local")]
    public DateTime? EndDateTime_Local { get; set; }
    [CSSPRange(0, 100)]
    public int Ordinal { get; set; }
    [CSSPRange(0, 100)]
    public int TVLevel { get; set; }
    [CSSPMaxLength(250)]
    public string TVPath { get; set; }
    [CSSPExist(ExistTypeName = "TVItemLink", ExistPlurial = "s", ExistFieldID = "TVItemLinkID")]
    [CSSPForeignKey(TableName = "TVItemLinks", FieldName = "TVItemLinkID")]
    public int? ParentTVItemLinkID { get; set; }

    public TVItemLink() : base()
    {
    }
}

