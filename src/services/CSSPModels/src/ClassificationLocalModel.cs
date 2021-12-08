namespace CSSPModels;

[NotMapped]
public partial class ClassificationLocalModel
{
    public TVItem TVItemParent { get; set; }
    public TVItemModel TVItemModel { get; set; }
    public Classification Classification { get; set; }
    public ClassificationLocalModel()
    {

    }
}

