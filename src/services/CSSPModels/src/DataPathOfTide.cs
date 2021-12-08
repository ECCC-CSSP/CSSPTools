namespace CSSPModels;

[NotMapped]
public partial class DataPathOfTide
{
    [CSSPMaxLength(200)]
    [CSSPMinLength(1)]
    public string Text { get; set; }
    [CSSPEnumType]
    [CSSPAllowNull]
    public WebTideDataSetEnum? WebTideDataSet { get; set; }
    [CSSPMaxLength(100)]
    [CSSPEnumTypeText(EnumTypeName = "WebTideDataSetEnum", EnumType = "WebTideDataSet")]
    [CSSPAllowNull]
    public string WebTideDataSetText { get; set; }

    public DataPathOfTide() : base()
    {
        Text = "";
        WebTideDataSet = null;
    }
}

