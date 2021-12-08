namespace CSSPModels;

[NotMapped]
public partial class LastUpdateAndTVText
{
    [CSSPAfter(Year = 1980)]
    public DateTime LastUpdateAndTVTextDate_UTC { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime LastUpdateDate_Local { get; set; }
    [CSSPMaxLength(200)]
    [CSSPMinLength(1)]
    public string TVText { get; set; }

    public LastUpdateAndTVText() : base()
    {
    }
}

