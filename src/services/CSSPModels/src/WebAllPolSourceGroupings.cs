namespace CSSPModels;

[NotMapped]
public partial class WebAllPolSourceGroupings
{
    public List<PolSourceGroupingModel> PolSourceGroupingModelList { get; set; }

    public WebAllPolSourceGroupings()
    {
        PolSourceGroupingModelList = new List<PolSourceGroupingModel>();
    }
}

