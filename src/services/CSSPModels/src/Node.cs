namespace CSSPModels;

[NotMapped]
public partial class Node
{
    [CSSPRange(1, 1000000)]
    public int ID { get; set; }
    [CSSPRange(-180.0D, 180.0D)]
    public double X { get; set; }
    [CSSPRange(-90.0D, 90.0D)]
    public double Y { get; set; }
    [CSSPRange(-100000.0D, 100000.0D)]
    public double Z { get; set; }
    [CSSPRange(0, 20)]
    public int Code { get; set; }
    [CSSPRange(-1.0D, -1.0D)]
    public double Value { get; set; }
    public List<Element> ElementList { get; set; }
    public List<Node> ConnectNodeList { get; set; }

    public Node() : base()
    {
        ElementList = new List<Element>();
        ConnectNodeList = new List<Node>();
    }
}

