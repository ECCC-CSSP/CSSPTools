namespace CSSPDBModels;

public partial class EmailDistributionListLanguage : LastUpdate
{
    [Key]
    public int EmailDistributionListLanguageID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "EmailDistributionList", ExistPlurial = "s", ExistFieldID = "EmailDistributionListID")]
    [CSSPForeignKey(TableName = "EmailDistributionLists", FieldName = "EmailDistributionListID")]
    public int EmailDistributionListID { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    [CSSPMaxLength(100)]
    [CSSPMinLength(1)]
    public string EmailListName { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatus { get; set; }

    public EmailDistributionListLanguage() : base()
    {
    }
}

