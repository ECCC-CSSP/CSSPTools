namespace CSSPDBModels;

public partial class TVItemLanguage : LastUpdate
{
    [Key]
    public int TVItemLanguageID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "1,2,3,4,5,6,7,9,10,11,12,13,14,15,16,17,18,19,20,21,31,79")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int TVItemID { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    [CSSPMaxLength(200)]
    public string TVText { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatus { get; set; }

    public TVItemLanguage() : base()
    {
    }
}

