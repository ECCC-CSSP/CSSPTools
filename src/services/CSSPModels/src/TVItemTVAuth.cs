namespace CSSPModels;

[NotMapped]
public partial class TVItemTVAuth
{
    [CSSPRange(1, -1)]
    public int TVItemUserAuthID { get; set; }
    [CSSPMaxLength(255)]
    [CSSPMinLength(1)]
    public string TVText { get; set; }
    [CSSPRange(1, -1)]
    public int TVItemID1 { get; set; }
    [CSSPMaxLength(255)]
    [CSSPMinLength(1)]
    public string TVTypeStr { get; set; }
    [CSSPEnumType]
    public TVAuthEnum TVAuth { get; set; }
    [CSSPMaxLength(100)]
    [CSSPEnumTypeText(EnumTypeName = "TVAuthEnum", EnumType = "TVAuth")]
    [CSSPAllowNull]
    public string TVAuthText { get; set; }

    public TVItemTVAuth() : base()
    {
    }
}

