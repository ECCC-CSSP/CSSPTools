namespace CSSPModels;

[NotMapped]
public partial class VPResValues
{
    [CSSPRange(0, -1)]
    public int Conc { get; set; }
    [CSSPRange(0.0D, 10000.0D)]
    public double Dilu { get; set; }
    [CSSPRange(0.0D, 10000.0D)]
    public double FarfieldWidth { get; set; }
    [CSSPRange(0.0D, 100000.0D)]
    public double Distance { get; set; }
    [CSSPRange(0.0D, 100000.0D)]
    public double TheTime { get; set; }
    [CSSPRange(0.0D, 1000.0D)]
    public double Decay { get; set; }

    public VPResValues() : base()
    {
    }
}

