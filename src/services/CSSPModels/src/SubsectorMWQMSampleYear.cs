namespace CSSPModels;

[NotMapped]
public partial class SubsectorMWQMSampleYear
{
    [CSSPRange(1, -1)]
    public int SubsectorTVItemID { get; set; }
    public int Year { get; set; }
    [CSSPAfter(Year = 1980)]
    public DateTime EarliestDate { get; set; }
    [CSSPAfter(Year = 1980)]
    [CSSPBigger(OtherField = "EarliestDate")]
    public DateTime LatestDate { get; set; }

    public SubsectorMWQMSampleYear() : base()
    {
    }
}

