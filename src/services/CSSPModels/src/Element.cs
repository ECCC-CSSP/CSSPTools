namespace CSSPModels;

[NotMapped]
public partial class Element
{
    [CSSPRange(1, -1)]
    public int ID { get; set; }
    [CSSPRange(1, -1)]
    public int Type { get; set; }
    [CSSPRange(1, -1)]
    public int NumbOfNodes { get; set; }
    [CSSPRange(-1.0D, -1.0D)]
    public double Value { get; set; }
    [CSSPRange(-1.0D, -1.0D)]
    public double XNode0 { get; set; }
    [CSSPRange(-1.0D, -1.0D)]
    public double YNode0 { get; set; }
    [CSSPRange(-1.0D, -1.0D)]
    public double ZNode0 { get; set; }
    public List<Node> NodeList { get; set; }

    public Element() : base()
    {
        NodeList = new List<Node>();
    }
}

