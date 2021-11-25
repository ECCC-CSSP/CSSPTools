namespace CSSPDBModels;

public partial class ContactPreference : LastUpdate
{
    [Key]
    public int ContactPreferenceID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID")]
    [CSSPForeignKey(TableName = "Contacts", FieldName = "ContactID")]
    public int ContactID { get; set; }
    [CSSPEnumType]
    public TVTypeEnum TVType { get; set; }
    [CSSPRange(1, 1000)]
    public int MarkerSize { get; set; }

    public ContactPreference() : base()
    {
    }
}

