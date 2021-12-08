namespace CSSPModels;

[NotMapped]
public partial class WebAllTideLocations
{
    public List<TideLocation> TideLocationList { get; set; }

    public WebAllTideLocations()
    {
        TideLocationList = new List<TideLocation>();
    }
}

