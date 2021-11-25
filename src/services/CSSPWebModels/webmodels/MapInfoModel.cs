namespace CSSPWebModels;

[NotMapped]
public partial class MapInfoModel
{
    public MapInfo MapInfo { get; set; }
    public List<MapInfoPoint> MapInfoPointList { get; set; }

    public MapInfoModel()
    {
        MapInfo = new MapInfo();
        MapInfoPointList = new List<MapInfoPoint>();
    }
}

