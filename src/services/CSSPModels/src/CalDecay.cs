namespace CSSPModels;

[NotMapped]
public partial class CalDecay
{
    [CSSPRange(0.0D, -1.0D)]
    public double Decay { get; set; }

    public CalDecay() : base()
    {
    }
}

