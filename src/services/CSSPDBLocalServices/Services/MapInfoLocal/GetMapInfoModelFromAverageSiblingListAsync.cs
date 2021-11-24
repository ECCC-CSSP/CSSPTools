namespace CSSPDBLocalServices;

public partial class MapInfoLocalService : ControllerBase, IMapInfoLocalService
{
    private async Task<MapInfoModel> GetMapInfoModelFromAverageSiblingListAsync(List<MapInfoModel> mapInfoModelList, TVItem tvItem, TVTypeEnum tvType, MapInfoDrawTypeEnum mapInfoDrawType, double PolygonSize)
    {
        MapInfoModel mapInfoModelNew = new MapInfoModel();

        List<double> LatMaxList = new List<double>();
        List<double> LatMinList = new List<double>();
        List<double> LngMaxList = new List<double>();
        List<double> LngMinList = new List<double>();

        List<double> LatList = new List<double>();
        List<double> LngList = new List<double>();

        foreach (MapInfoModel mapInfoModel in mapInfoModelList)
        {
            LatMaxList.Add(mapInfoModel.MapInfo.LatMax);
            LatMinList.Add(mapInfoModel.MapInfo.LatMin);
            LngMaxList.Add(mapInfoModel.MapInfo.LngMax);
            LngMinList.Add(mapInfoModel.MapInfo.LngMin);

            foreach (MapInfoPoint mapInfoPoint in mapInfoModel.MapInfoPointList)
            {
                LatList.Add(mapInfoPoint.Lat);
                LngList.Add(mapInfoPoint.Lng);
            }
        }

        MapInfo mapInfo = new MapInfo()
        {
            DBCommand = DBCommandEnum.Created,
            LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
            LastUpdateDate_UTC = DateTime.UtcNow,
            LatMax = 0.0D,
            LatMin = 0.0D,
            LngMax = 0.0D,
            LngMin = 0.0D,
            MapInfoDrawType = mapInfoDrawType,
            MapInfoID = 0,
            TVItemID = tvItem.TVItemID,
            TVType = tvType,
        };

        mapInfo.LatMax = LatMaxList.Average() + PolygonSize;
        mapInfo.LatMin = LatMinList.Average() - PolygonSize;
        mapInfo.LngMax = LngMaxList.Average() + PolygonSize;
        mapInfo.LngMin = LngMinList.Average() - PolygonSize;

        double LatAverage = LatList.Average();
        double LngAverage = LngList.Average();

        List<MapInfoPoint> mapInfoPointList = new List<MapInfoPoint>();

        if (mapInfoDrawType == MapInfoDrawTypeEnum.Point)
        {
            MapInfoPoint mapInfoPoint = new MapInfoPoint()
            {
                DBCommand = DBCommandEnum.Created,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
                Lat = LatAverage,
                Lng = LngAverage,
                MapInfoID = 0,
                MapInfoPointID = 0,
                Ordinal = 0,
            };

            mapInfoPointList.Add(mapInfoPoint);
        }
        else
        {
            MapInfoPoint mapInfoPointBottomLeft = new MapInfoPoint()
            {
                DBCommand = DBCommandEnum.Created,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
                Lat = LatAverage - PolygonSize,
                Lng = LngAverage - PolygonSize,
                MapInfoID = 0,
                MapInfoPointID = 0,
                Ordinal = 0,
            };

            mapInfoPointList.Add(mapInfoPointBottomLeft);

            MapInfoPoint mapInfoPointBottomRight = new MapInfoPoint()
            {
                DBCommand = DBCommandEnum.Created,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
                Lat = LatAverage - PolygonSize,
                Lng = LngAverage + PolygonSize,
                MapInfoID = 0,
                MapInfoPointID = 0,
                Ordinal = 1,
            };

            mapInfoPointList.Add(mapInfoPointBottomRight);

            MapInfoPoint mapInfoPointTopRight = new MapInfoPoint()
            {
                DBCommand = DBCommandEnum.Created,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
                Lat = LatAverage + PolygonSize,
                Lng = LngAverage + PolygonSize,
                MapInfoID = 0,
                MapInfoPointID = 0,
                Ordinal = 2,
            };

            mapInfoPointList.Add(mapInfoPointTopRight);

            MapInfoPoint mapInfoPointTopLeft = new MapInfoPoint()
            {
                DBCommand = DBCommandEnum.Created,
                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                LastUpdateDate_UTC = DateTime.UtcNow,
                Lat = LatAverage + PolygonSize,
                Lng = LngAverage - PolygonSize,
                MapInfoID = 0,
                MapInfoPointID = 0,
                Ordinal = 3,
            };

            mapInfoPointList.Add(mapInfoPointTopLeft);

            if (mapInfoDrawType == MapInfoDrawTypeEnum.Polygon)
            {
                MapInfoPoint mapInfoPointBottomLeft2 = new MapInfoPoint()
                {
                    DBCommand = DBCommandEnum.Created,
                    LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
                    LastUpdateDate_UTC = DateTime.UtcNow,
                    Lat = LatAverage + PolygonSize,
                    Lng = LngAverage - PolygonSize,
                    MapInfoID = 0,
                    MapInfoPointID = 0,
                    Ordinal = 4,
                };

                mapInfoPointList.Add(mapInfoPointBottomLeft2);
            }
        }

        mapInfoModelNew.MapInfo = mapInfo;
        mapInfoModelNew.MapInfoPointList = mapInfoPointList;

        return await Task.FromResult(mapInfoModelNew);
    }

}

