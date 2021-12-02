namespace CSSPDBLocalServices;

public partial interface IMapInfoLocalService
{
    Task<ActionResult<MapInfoModel>> AddMapInfoLocalAsync(TVItem tvItemParent, TVItem tvItem, TVTypeEnum tvType, MapInfoDrawTypeEnum mapInfoDrawType, List<Coord> coordList);
    //Task<ActionResult<MapInfoModel>> AddMapInfoLocalFromAverageAsync(TVItem tvItemParent, TVItem tvItem, TVTypeEnum tvType, MapInfoDrawTypeEnum mapInfoDrawType);
    Task<ActionResult<MapInfoModel>> DeleteMapInfoLocalAsync(TVItem tvItemParent, TVItem tvItem, TVTypeEnum tvType, MapInfoDrawTypeEnum mapInfoDrawType);
    //Task<ActionResult<MapInfoLocalModel>> ModifyMapInfoLocal(MapInfoLocalModel mapInfoLocalModel);
    Task<double> CalculateAreaOfPolygonAsync(List<Coord> NodeList);
    Task<double> CalculateDistanceAsync(double lat1, double long1, double lat2, double long2, double EarthRadius);

}
