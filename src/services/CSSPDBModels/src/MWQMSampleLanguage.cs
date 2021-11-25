namespace CSSPDBModels;

public partial class MWQMSampleLanguage : LastUpdate
{
    [Key]
    public int MWQMSampleLanguageID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "MWQMSample", ExistPlurial = "s", ExistFieldID = "MWQMSampleID")]
    [CSSPForeignKey(TableName = "MWQMSamples", FieldName = "MWQMSampleID")]
    public int MWQMSampleID { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    public string MWQMSampleNote { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatus { get; set; }

    public MWQMSampleLanguage() : base()
    {
    }
}

