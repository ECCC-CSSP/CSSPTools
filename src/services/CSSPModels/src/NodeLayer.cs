namespace CSSPModels;

[NotMapped]
public partial class NodeLayer
{
    [CSSPRange(1, 100)]
    public int Layer { get; set; }
    [CSSPRange(-10000.0D, 10000.0D)]
    public double Z { get; set; }
    public Node Node { get; set; }

    public NodeLayer() : base()
    {
    }
}

