namespace CSSPDBModels;

public partial class TVItemUserAuthorization : LastUpdate
{
    [Key]
    public int TVItemUserAuthorizationID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int ContactTVItemID { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int TVItemID1 { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? TVItemID2 { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? TVItemID3 { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,8,9,10,13,14,15,16,17,18,19,20,21,22,24,25,26,27,28,30,31,38,39,40,41,42,52,53")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int? TVItemID4 { get; set; }
    [CSSPEnumType]
    public TVAuthEnum TVAuth { get; set; }

    public TVItemUserAuthorization() : base()
    {
    }
}

