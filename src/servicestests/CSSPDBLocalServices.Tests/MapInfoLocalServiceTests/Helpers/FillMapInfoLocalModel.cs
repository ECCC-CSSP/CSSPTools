//namespace CSSPDBLocalServices.Tests;

//public partial class MapInfoLocalServiceTest
//{
//    private MapInfoLocalModel FillMapInfoLocalModel(TVItem tvItem, TVTypeEnum tvType, MapInfoDrawTypeEnum mapInfoDrawType)
//    {
//        MapInfoLocalModel mapInfoLocalModel = new MapInfoLocalModel();

//        MapInfo mapInfo = new MapInfo()
//        {
//            DBCommand = DBCommandEnum.Created,
//            LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
//            LastUpdateDate_UTC = DateTime.UtcNow,
//            LatMax = 45.4D,
//            LatMin = 44.9D,
//            LngMax = -65.4D,
//            LngMin = -64.9D,
//            MapInfoDrawType = mapInfoDrawType,
//            MapInfoID = 0,
//            TVItemID = tvItem.TVItemID,
//            TVType = tvType,
//        };

//        mapInfoLocalModel.MapInfo = mapInfo;

//        List<Coord> coordList = new List<Coord>()
//            {
//                new Coord() { Lat = 45.0D, Lng = -65.0D, Ordinal = 0 },
//                new Coord() { Lat = 45.1D, Lng = -65.1D, Ordinal = 1 },
//                new Coord() { Lat = 45.2D, Lng = -65.2D, Ordinal = 2 },
//                new Coord() { Lat = 45.3D, Lng = -65.3D, Ordinal = 3 },
//            };

//        if (mapInfoDrawType == MapInfoDrawTypeEnum.Point)
//        {
//            MapInfoPoint mapInfoPoint = new MapInfoPoint()
//            {
//                DBCommand = DBCommandEnum.Created,
//                LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
//                LastUpdateDate_UTC = DateTime.UtcNow,
//                Lat = coordList[0].Lat,
//                Lng = coordList[0].Lng,
//                MapInfoID = 0,
//                MapInfoPointID = 0,
//                Ordinal = 0,
//            };

//            mapInfoLocalModel.MapInfoPointList.Add(mapInfoPoint);
//        }
//        else
//        {
//            int count = 0;
//            foreach (Coord coord in coordList)
//            {
//                MapInfoPoint mapInfoPoint = new MapInfoPoint()
//                {
//                    DBCommand = DBCommandEnum.Created,
//                    LastUpdateContactTVItemID = CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID,
//                    LastUpdateDate_UTC = DateTime.UtcNow,
//                    Lat = coord.Lat,
//                    Lng = coord.Lng,
//                    MapInfoID = 0,
//                    MapInfoPointID = 0,
//                    Ordinal = count,
//                };

//                mapInfoLocalModel.MapInfoPointList.Add(mapInfoPoint);

//                count += 1;
//            }
//        }

//        return mapInfoLocalModel;
//    }
//}
