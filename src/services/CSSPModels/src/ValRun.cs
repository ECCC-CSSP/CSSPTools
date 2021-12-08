namespace CSSPModels;

[NotMapped]
public partial class ValRun
{
    [CSSPRange(1.0D, 10000000.0D)]
    public double val { get; set; }
    [CSSPRange(1, 20)]
    public int run { get; set; }

    public ValRun()
    {
    }
}

