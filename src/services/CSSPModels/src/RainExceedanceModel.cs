namespace CSSPModels;

[NotMapped]
public partial class RainExceedanceModel
{
    public TVItemModel TVItemModel { get; set; }
    public RainExceedance RainExceedance { get; set; }
    public List<RainExceedanceClimateSite> RainExceedanceClimateSiteList { get; set; }

    public RainExceedanceModel()
    {
        TVItemModel = new TVItemModel();
        RainExceedance = new RainExceedance();
        RainExceedanceClimateSiteList = new List<RainExceedanceClimateSite>();
    }
}

