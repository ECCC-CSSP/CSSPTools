namespace CSSPModels;

[NotMapped]
public partial class InfrastructureModelPath
{
    public InfrastructureModel InfrastructureModel { get; set; }
    public List<InfrastructureModelPath> InfrastructureModelChildList { get; set; }
    public int Count { get; set; }
    public bool ShowOnMap { get; set; }

    public InfrastructureModelPath()
    {
    }
}

