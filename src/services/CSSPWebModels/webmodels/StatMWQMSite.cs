namespace CSSPWebModels;

[NotMapped]
public partial class StatMWQMSite
{
    public TVItemModel TVItemModel { get; set; }
    public MWQMSiteModel MWQMSiteModel { get; set; }
    public List<StatMWQMSiteSample> StatMWQMSiteSampleList { get; set; }
    public double SalinityAverage { get; set; }

    public StatMWQMSite() : base()
    {
    }
}

