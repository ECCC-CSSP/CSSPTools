namespace CSSPDBModels;

public partial class TVFileLanguage : LastUpdate
{
    [Key]
    public int TVFileLanguageID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVFile", ExistPlurial = "s", ExistFieldID = "TVFileID")]
    [CSSPForeignKey(TableName = "TVFiles", FieldName = "TVFileID")]
    public int TVFileID { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    [CSSPAllowNull]
    public string FileDescription { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatus { get; set; }

    public TVFileLanguage() : base()
    {
    }
}

