namespace CSSPModels;

[NotMapped]
public partial class TVItemModelInfrastructureModel
{
    public List<TVItemModel> TVItemModeWithInfrastructurelList { get; set; }
    public List<TVItemModel> TVItemModelWithoutInfrastructureList { get; set; }

    public TVItemModelInfrastructureModel()
    {
        TVItemModeWithInfrastructurelList = new List<TVItemModel>();
        TVItemModelWithoutInfrastructureList = new List<TVItemModel>();
    }
}

