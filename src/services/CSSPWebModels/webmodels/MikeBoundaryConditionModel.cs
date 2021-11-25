namespace CSSPWebModels;

[NotMapped]
public partial class MikeBoundaryConditionModel
{
    public TVItemModel TVItemModel { get; set; }
    public MikeBoundaryCondition MikeBoundaryCondition { get; set; }

    public MikeBoundaryConditionModel()
    {
        TVItemModel = new TVItemModel();
        MikeBoundaryCondition = new MikeBoundaryCondition();
    }
}

