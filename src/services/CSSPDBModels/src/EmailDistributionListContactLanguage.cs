namespace CSSPDBModels;

public partial class EmailDistributionListContactLanguage : LastUpdate
{
    [Key]
    public int EmailDistributionListContactLanguageID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "EmailDistributionListContact", ExistPlurial = "s", ExistFieldID = "EmailDistributionListContactID")]
    [CSSPForeignKey(TableName = "EmailDistributionListContacts", FieldName = "EmailDistributionListContactID")]
    public int EmailDistributionListContactID { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    [CSSPMaxLength(100)]
    [CSSPMinLength(1)]
    public string Agency { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatus { get; set; }

    public EmailDistributionListContactLanguage() : base()
    {
    }
}

