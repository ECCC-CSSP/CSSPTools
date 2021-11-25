namespace CSSPWebModels;

[NotMapped]
public partial class ClimateSiteModel
{
    public TVItemModel TVItemModel { get; set; }
    public ClimateSite ClimateSite { get; set; }
    public List<ClimateDataValue> ClimateDataValueList { get; set; }

    public ClimateSiteModel()
    {
        TVItemModel = new TVItemModel();
        ClimateSite = new ClimateSite();
        ClimateDataValueList = new List<ClimateDataValue>();
    }
}

