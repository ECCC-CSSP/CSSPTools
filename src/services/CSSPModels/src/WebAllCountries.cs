namespace CSSPModels;

[NotMapped]
public partial class WebAllCountries
{
    public List<TVItemModel> TVItemModelList { get; set; }

    public WebAllCountries()
    {
        TVItemModelList = new List<TVItemModel>();
    }
}

