namespace CSSPModels;

[NotMapped]
public partial class PolSourceObsInfoChild
{
    [CSSPEnumType]
    public PolSourceObsInfoEnum PolSourceObsInfo { get; set; }
    [CSSPEnumType]
    public PolSourceObsInfoEnum PolSourceObsInfoChildStart { get; set; }
    [CSSPMaxLength(100)]
    [CSSPEnumTypeText(EnumTypeName = "PolSourceObsInfoEnum", EnumType = "PolSourceObsInfo")]
    [CSSPAllowNull]
    public string PolSourceObsInfoText { get; set; }
    [CSSPMaxLength(100)]
    [CSSPEnumTypeText(EnumTypeName = "PolSourceObsInfoEnum", EnumType = "PolSourceObsInfoChildStart")]
    [CSSPAllowNull]
    public string PolSourceObsInfoChildStartText { get; set; }

    public PolSourceObsInfoChild() : base()
    {
    }
}

