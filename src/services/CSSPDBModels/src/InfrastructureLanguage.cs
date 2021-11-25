namespace CSSPDBModels;

public partial class InfrastructureLanguage : LastUpdate
{
    [Key]
    public int InfrastructureLanguageID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "Infrastructure", ExistPlurial = "s", ExistFieldID = "InfrastructureID")]
    [CSSPForeignKey(TableName = "Infrastructures", FieldName = "InfrastructureID")]
    public int InfrastructureID { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    public string Comment { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatus { get; set; }

    public InfrastructureLanguage() : base()
    {
    }
}

