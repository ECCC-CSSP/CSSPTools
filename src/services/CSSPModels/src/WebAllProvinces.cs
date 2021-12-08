namespace CSSPModels;

[NotMapped]
public partial class WebAllProvinces
{
    public List<TVItemModel> TVItemModelList { get; set; }

    public WebAllProvinces()
    {
        TVItemModelList = new List<TVItemModel>();
    }
}

