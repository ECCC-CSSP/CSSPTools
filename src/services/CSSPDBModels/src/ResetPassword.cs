namespace CSSPDBModels;

public partial class ResetPassword : LastUpdate
{
    [Key]
    public int ResetPasswordID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPMaxLength(256)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime ExpireDate_Local { get; set; }
    [CSSPMaxLength(8)]
    public string Code { get; set; }

    public ResetPassword() : base()
    {
    }
}

