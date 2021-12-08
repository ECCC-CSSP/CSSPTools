namespace CSSPModels;

[NotMapped]
public partial class WebAllSearch
{
    public List<TVItemModel> TVItemModelList { get; set; }

    public WebAllSearch()
    {
        TVItemModelList = new List<TVItemModel>();
    }
}

