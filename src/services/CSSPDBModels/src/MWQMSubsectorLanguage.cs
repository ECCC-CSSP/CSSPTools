namespace CSSPDBModels;

public partial class MWQMSubsectorLanguage : LastUpdate
{
    [Key]
    public int MWQMSubsectorLanguageID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "MWQMSubsector", ExistPlurial = "s", ExistFieldID = "MWQMSubsectorID")]
    [CSSPForeignKey(TableName = "MWQMSubsectors", FieldName = "MWQMSubsectorID")]
    public int MWQMSubsectorID { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    [CSSPMaxLength(250)]
    public string SubsectorDesc { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatusSubsectorDesc { get; set; }
    [CSSPAllowNull]
    public string LogBook { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public TranslationStatusEnum? TranslationStatusLogBook { get; set; }

    public MWQMSubsectorLanguage() : base()
    {
    }
}

