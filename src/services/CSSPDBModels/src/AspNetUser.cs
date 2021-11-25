namespace CSSPDBModels;

public partial class AspNetUser
{
    [Key]
    [CSSPMaxLength(450)]
    public string Id { get; set; }
    [CSSPMaxLength(256)]
    [CSSPAllowNull]
    public string Email { get; set; }
    public bool EmailConfirmed { get; set; }
    [CSSPAllowNull]
    public string PasswordHash { get; set; }
    [CSSPAllowNull]
    public string SecurityStamp { get; set; }
    [CSSPAllowNull]
    public string PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool TwoFactorEnabled { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? LockoutEndDateUtc { get; set; }
    public bool LockoutEnabled { get; set; }
    [CSSPRange(0, 10000)]
    public int AccessFailedCount { get; set; }
    [CSSPMaxLength(256)]
    public string UserName { get; set; }
    [CSSPMaxLength(256)]
    [CSSPAllowNull]
    public string NormalizedUserName { get; set; }
    [CSSPMaxLength(256)]
    [CSSPAllowNull]
    public string NormalizedEmail { get; set; }
    [CSSPMaxLength(256)]
    [CSSPAllowNull]
    public string ConcurrencyStamp { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime? LockoutEnd { get; set; }

    public AspNetUser()
    {
    }
}

