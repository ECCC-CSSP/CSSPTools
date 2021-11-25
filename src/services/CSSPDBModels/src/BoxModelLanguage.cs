namespace CSSPDBModels;

public partial class BoxModelLanguage : LastUpdate
{
    [Key]
    public int BoxModelLanguageID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "BoxModel", ExistPlurial = "s", ExistFieldID = "BoxModelID")]
    [CSSPForeignKey(TableName = "BoxModels", FieldName = "BoxModelID")]
    public int BoxModelID { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    [CSSPMaxLength(250)]
    public string ScenarioName { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatus { get; set; }

    public BoxModelLanguage() : base()
    {
    }
}

