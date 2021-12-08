namespace CSSPModels;

[NotMapped]
public partial class ClassificationModel
{
    public TVItemModel TVItemModel { get; set; }
    public Classification Classification { get; set; }

    public ClassificationModel()
    {
        TVItemModel = new TVItemModel();
        Classification = new Classification();
    }
}

