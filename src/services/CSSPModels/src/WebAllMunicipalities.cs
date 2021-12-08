namespace CSSPModels;

[NotMapped]
public partial class WebAllMunicipalities
{
    public List<TVItemModel> TVItemModelList { get; set; }

    public WebAllMunicipalities()
    {
        TVItemModelList = new List<TVItemModel>();
    }
}

