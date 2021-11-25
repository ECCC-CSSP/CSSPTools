namespace CSSPDBModels;

public partial class MWQMRunLanguage : LastUpdate
{
    [Key]
    public int MWQMRunLanguageID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "MWQMRun", ExistPlurial = "s", ExistFieldID = "MWQMRunID")]
    [CSSPForeignKey(TableName = "MWQMRuns", FieldName = "MWQMRunID")]
    public int MWQMRunID { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    public string RunComment { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatusRunComment { get; set; }
    public string RunWeatherComment { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatusRunWeatherComment { get; set; }

    public MWQMRunLanguage() : base()
    {
    }
}

