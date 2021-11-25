namespace CSSPDBModels;

public partial class SpillLanguage : LastUpdate
{
    [Key]
    public int SpillLanguageID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "Spill", ExistPlurial = "s", ExistFieldID = "SpillID")]
    [CSSPForeignKey(TableName = "Spills", FieldName = "SpillID")]
    public int SpillID { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    public string SpillComment { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatus { get; set; }

    public SpillLanguage() : base()
    {
    }
}

