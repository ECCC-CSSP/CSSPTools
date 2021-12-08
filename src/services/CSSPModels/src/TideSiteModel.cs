namespace CSSPModels;

[NotMapped]
public partial class TideSiteModel
{
    public TVItemModel TVItemModel { get; set; }
    public TideSite TideSite { get; set; }
    public List<TideDataValue> TideDataValueList { get; set; }

    public TideSiteModel()
    {
        TideDataValueList = new List<TideDataValue>();
    }
}

