namespace CSSPDBModels;

public partial class PolSourceGroupingLanguage : LastUpdate
{
    [Key]
    public int PolSourceGroupingLanguageID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "PolSourceGrouping", ExistPlurial = "s", ExistFieldID = "PolSourceGroupingID")]
    [CSSPForeignKey(TableName = "PolSourceGroupings", FieldName = "PolSourceGroupingID")]
    public int PolSourceGroupingID { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    [CSSPMaxLength(500)]
    public string SourceName { get; set; }
    [CSSPRange(0, 1000)]
    public int SourceNameOrder { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatusSourceName { get; set; }
    [CSSPMaxLength(50)]
    public string Init { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatusInit { get; set; }
    [CSSPMaxLength(500)]
    public string Description { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatusDescription { get; set; }
    [CSSPMaxLength(500)]
    public string Report { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatusReport { get; set; }
    [CSSPMaxLength(500)]
    public string Text { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatusText { get; set; }

    public PolSourceGroupingLanguage() : base()
    {
    }
}

