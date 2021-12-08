namespace CSSPModels;

[NotMapped]
public partial class NewContact
{
    [CSSPMaxLength(200)]
    [CSSPMinLength(1)]
    public string LoginEmail { get; set; }
    [CSSPMaxLength(200)]
    [CSSPMinLength(1)]
    public string FirstName { get; set; }
    [CSSPMaxLength(200)]
    [CSSPMinLength(1)]
    public string LastName { get; set; }
    [CSSPMaxLength(50)]
    [CSSPAllowNull]
    public string Initial { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public ContactTitleEnum? ContactTitle { get; set; }
    [CSSPMaxLength(100)]
    [CSSPEnumTypeText(EnumTypeName = "ContactTitleEnum", EnumType = "ContactTitle")]
    [CSSPAllowNull]
    public string ContactTitleText { get; set; }

    public NewContact() : base()
    {
    }
}

