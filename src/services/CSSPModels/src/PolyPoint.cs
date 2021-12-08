namespace CSSPModels;

[NotMapped]
public partial class PolyPoint
{
    [CSSPRange(-180.0D, 180.0D)]
    public double XCoord { get; set; }
    [CSSPRange(-90.0D, 90.0D)]
    public double YCoord { get; set; }
    [CSSPRange(-10000.0D, 10000.0D)]
    public double Z { get; set; }

    public PolyPoint() : base()
    {
    }
}

