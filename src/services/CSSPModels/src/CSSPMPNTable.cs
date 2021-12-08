namespace CSSPModels;

[NotMapped]
public partial class CSSPMPNTable
{
    [CSSPRange(0, 5)]
    public int Tube10 { get; set; }
    [CSSPRange(0, 5)]
    public int Tube1_0 { get; set; }
    [CSSPRange(0, 5)]
    public int Tube0_1 { get; set; }
    [CSSPRange(0, 100000000)]
    public int MPN { get; set; }

    public CSSPMPNTable() : base()
    {
    }
}

