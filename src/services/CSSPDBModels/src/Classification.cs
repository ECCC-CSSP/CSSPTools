namespace CSSPDBModels;

public partial class Classification : LastUpdate
{
    [Key]
    public int ClassificationID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "79")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int ClassificationTVItemID { get; set; }
    [CSSPEnumType]
    public ClassificationTypeEnum ClassificationType { get; set; }
    [CSSPRange(0, 10000)]
    public int Ordinal { get; set; }

    public Classification() : base()
    {
    }
}

