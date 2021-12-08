namespace CSSPModels;

[NotMapped]
public partial class WebAllUseOfSites
{
    public List<UseOfSite> UseOfSiteList { get; set; }

    public WebAllUseOfSites()
    {
        UseOfSiteList = new List<UseOfSite>();
    }
}

