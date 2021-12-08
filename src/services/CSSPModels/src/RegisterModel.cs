namespace CSSPModels;

[NotMapped]
public partial class RegisterModel
{
    [CSSPMaxLength(100)]
    [CSSPMinLength(1)]
    public string FirstName { get; set; }
    [CSSPMaxLength(100)]
    [CSSPAllowNull]
    public string Initial { get; set; }
    [CSSPMaxLength(100)]
    [CSSPMinLength(1)]
    public string LastName { get; set; }
    [CSSPMaxLength(100)]
    [CSSPMinLength(5)]
    public string LoginEmail { get; set; }
    [CSSPMaxLength(50)]
    [CSSPMinLength(5)]
    public string Password { get; set; }
    [CSSPMaxLength(50)]
    [CSSPMinLength(5)]
    public string ConfirmPassword { get; set; }
    [CSSPAllowNull]
    [CSSPEnumType]
    public ContactTitleEnum? ContactTitle { get; set; }

    public RegisterModel() : base()
    {
    }
}

