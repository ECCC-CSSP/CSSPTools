namespace CSSPModels;

[NotMapped]
public partial class ElementLayer
{
    [CSSPRange(1, 1000)]
    public int Layer { get; set; }
    [CSSPRange(-1.0D, -1.0D)]
    public double ZMin { get; set; }
    [CSSPRange(-1.0D, -1.0D)]
    public double ZMax { get; set; }
    public Element Element { get; set; }

    public ElementLayer() : base()
    {
    }
}

