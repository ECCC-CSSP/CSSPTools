namespace CSSPDBModels;

public partial class ContactShortcut : LastUpdate
{
    [Key]
    public int ContactShortcutID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "Contact", ExistPlurial = "s", ExistFieldID = "ContactID")]
    [CSSPForeignKey(TableName = "Contacts", FieldName = "ContactID")]
    public int ContactID { get; set; }
    [CSSPMaxLength(100)]
    public string ShortCutText { get; set; }
    [CSSPMaxLength(200)]
    public string ShortCutAddress { get; set; }

    public ContactShortcut() : base()
    {
    }
}

