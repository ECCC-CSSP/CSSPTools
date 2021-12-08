namespace CSSPModels;

[NotMapped]
public partial class UseRunAndRainValue
{
    public bool UseRun { get; set; }
    [CSSPRange(0.0D, 300.0D)]
    public double RainValue { get; set; }
    public UseRunAndRainValue()
    {
    }
}

