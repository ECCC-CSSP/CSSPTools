namespace CSSPDBModels;

public partial class Email : LastUpdate
{
    [Key]
    public int EmailID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "7")]
    [CSSPForeignKey(TableName = "TVItems", FieldName = "TVItemID")]
    public int EmailTVItemID { get; set; }
    [CSSPMaxLength(255)]
    [DataType(DataType.EmailAddress)]
    public string EmailAddress { get; set; }
    [CSSPEnumType]
    public EmailTypeEnum EmailType { get; set; }

    public Email() : base()
    {
    }
}

