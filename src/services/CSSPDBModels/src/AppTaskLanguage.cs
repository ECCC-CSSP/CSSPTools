namespace CSSPDBModels;

public partial class AppTaskLanguage : LastUpdate
{
    [Key]
    public int AppTaskLanguageID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "AppTask", ExistPlurial = "s", ExistFieldID = "AppTaskID")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int AppTaskID { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    [CSSPMaxLength(250)]
    [CSSPAllowNull]
    public string StatusText { get; set; }
    [CSSPMaxLength(250)]
    [CSSPAllowNull]
    public string ErrorText { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatus { get; set; }

    public AppTaskLanguage() : base()
    {
    }
}

