namespace CSSPModels;

[NotMapped]
public partial class TVItemSubsectorAndMWQMSite
{
    public TVItem TVItemSubsector { get; set; }
    public List<TVItem> TVItemMWQMSiteList { get; set; }
    public TVItem TVItemMWQMSiteDuplicate { get; set; }

    public TVItemSubsectorAndMWQMSite() : base()
    {
        TVItemMWQMSiteList = new List<TVItem>();
    }
}

