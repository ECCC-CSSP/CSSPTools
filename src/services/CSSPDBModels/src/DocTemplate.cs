namespace CSSPDBModels;

public partial class DocTemplate : LastUpdate
{
    [Key]
    public int DocTemplateID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    [CSSPEnumType]
    public TVTypeEnum TVType { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "8")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int TVFileTVItemID { get; set; }
    [CSSPMaxLength(150)]
    public string FileName { get; set; }

    public DocTemplate() : base()
    {
    }
}

