namespace CSSPDBModels;

public partial class TVTypeUserAuthorization : LastUpdate
{
    [Key]
    public int TVTypeUserAuthorizationID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int ContactTVItemID { get; set; }
    [CSSPEnumType]
    public TVTypeEnum TVType { get; set; }
    [CSSPEnumType]
    public TVAuthEnum TVAuth { get; set; }

    public TVTypeUserAuthorization() : base()
    {
    }
}

