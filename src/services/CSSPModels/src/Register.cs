namespace CSSPModels;

[NotMapped]
public partial class Register
{
    [CSSPMaxLength(255)]
    [CSSPMinLength(6)]
    public string LoginEmail { get; set; }
    [CSSPMaxLength(100)]
    [CSSPMinLength(1)]
    public string FirstName { get; set; }
    [CSSPMaxLength(50)]
    [CSSPAllowNull]
    public string Initial { get; set; }
    [CSSPMaxLength(100)]
    [CSSPMinLength(1)]
    public string LastName { get; set; }
    [CSSPMaxLength(100)]
    [CSSPMinLength(1)]
    public string WebName { get; set; }
    [CSSPMaxLength(100)]
    [CSSPMinLength(6)]
    public string Password { get; set; }
    [CSSPMaxLength(100)]
    [CSSPMinLength(6)]
    [CSSPCompare("Password")]
    public string ConfirmPassword { get; set; }

    public Register() : base()
    {
    }
}

