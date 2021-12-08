namespace CSSPModels;

[NotMapped]
public partial class BoxModelCalNumb
{
    [CSSPEnumType]
    public BoxModelResultTypeEnum BoxModelResultType { get; set; }
    [CSSPRange(0.0D, -1.0D)]
    public double CalLength_m { get; set; }
    [CSSPRange(0.0D, -1.0D)]
    public double CalRadius_m { get; set; }
    [CSSPRange(0.0D, -1.0D)]
    public double CalSurface_m2 { get; set; }
    [CSSPRange(0.0D, -1.0D)]
    public double CalVolume_m3 { get; set; }
    [CSSPRange(0.0D, -1.0D)]
    public double CalWidth_m { get; set; }
    public bool FixLength { get; set; }
    public bool FixWidth { get; set; }
    [CSSPMaxLength(100)]
    [CSSPEnumTypeText(EnumTypeName = "BoxModelResultTypeEnum", EnumType = "BoxModelResultType")]
    [CSSPAllowNull]
    public string BoxModelResultTypeText { get; set; }

    public BoxModelCalNumb() : base()
    {
    }
}

