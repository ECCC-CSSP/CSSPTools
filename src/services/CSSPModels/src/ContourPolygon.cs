namespace CSSPModels;

[NotMapped]
public partial class ContourPolygon
{
    [CSSPRange(0.0D, -1.0D)]
    public double ContourValue { get; set; }
    [CSSPRange(1, 100)]
    public int Layer { get; set; }
    [CSSPRange(1.0D, 10000.0D)]
    public double Depth_m { get; set; }
    public List<Node> ContourNodeList { get; set; }

    public ContourPolygon() : base()
    {
        ContourNodeList = new List<Node>();
    }
}

