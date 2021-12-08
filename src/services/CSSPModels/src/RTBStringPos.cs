namespace CSSPModels;

[NotMapped]
public partial class RTBStringPos
{
    [CSSPRange(0, -1)]
    public int StartPos { get; set; }
    [CSSPRange(0, -1)]
    public int EndPos { get; set; }
    [CSSPMaxLength(100)]
    public string Text { get; set; }
    [CSSPMaxLength(100)]
    public string TagText { get; set; }

    public RTBStringPos() : base()
    {
    }
}

