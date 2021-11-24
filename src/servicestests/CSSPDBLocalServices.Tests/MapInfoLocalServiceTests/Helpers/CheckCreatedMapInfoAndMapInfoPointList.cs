namespace CSSPDBLocalServices.Tests;

public partial class MapInfoLocalServiceTest
{
    private void CheckCreatedMapInfoAndMapInfoPointList(MapInfoModel mapInfoModel)
    {
        MapInfo mapInfoDB = (from c in dbLocal.MapInfos
                             where c.MapInfoID == mapInfoModel.MapInfo.MapInfoID
                             select c).FirstOrDefault();
        Assert.NotNull(mapInfoDB);

        Assert.Equal(DBCommandEnum.Created, mapInfoModel.MapInfo.DBCommand);
        Assert.Equal(mapInfoDB.DBCommand, mapInfoModel.MapInfo.DBCommand);
        Assert.Equal(mapInfoDB.LatMax, mapInfoModel.MapInfo.LatMax);
        Assert.Equal(mapInfoDB.LatMin, mapInfoModel.MapInfo.LatMin);
        Assert.Equal(mapInfoDB.LngMax, mapInfoModel.MapInfo.LngMax);
        Assert.Equal(mapInfoDB.LngMin, mapInfoModel.MapInfo.LngMin);
        Assert.Equal(mapInfoDB.MapInfoDrawType, mapInfoModel.MapInfo.MapInfoDrawType);
        Assert.Equal(mapInfoDB.MapInfoID, mapInfoModel.MapInfo.MapInfoID);
        Assert.Equal(mapInfoDB.TVItemID, mapInfoModel.MapInfo.TVItemID);
        Assert.Equal(mapInfoDB.TVType, mapInfoModel.MapInfo.TVType);
        Assert.Equal(mapInfoDB.MapInfoDrawType, mapInfoModel.MapInfo.MapInfoDrawType);
        Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, mapInfoModel.MapInfo.LastUpdateContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < mapInfoModel.MapInfo.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > mapInfoModel.MapInfo.LastUpdateDate_UTC);

        List<MapInfoPoint> mapInfoPointListDB = (from c in dbLocal.MapInfoPoints
                                                 where c.MapInfoID == mapInfoModel.MapInfo.MapInfoID
                                                 orderby c.Ordinal
                                                 select c).ToList();
        Assert.NotNull(mapInfoPointListDB);
        Assert.NotEmpty(mapInfoPointListDB);

        int index = 0;
        foreach (MapInfoPoint mapInfoPoint in mapInfoPointListDB)
        {
            Assert.Equal(DBCommandEnum.Created, mapInfoModel.MapInfoPointList[index].DBCommand);
            Assert.Equal(mapInfoPoint.DBCommand, mapInfoModel.MapInfoPointList[index].DBCommand);
            Assert.Equal(mapInfoPoint.Lat, mapInfoModel.MapInfoPointList[index].Lat);
            Assert.Equal(mapInfoPoint.Lng, mapInfoModel.MapInfoPointList[index].Lng);
            Assert.Equal(mapInfoPoint.MapInfoID, mapInfoModel.MapInfoPointList[index].MapInfoID);
            Assert.Equal(mapInfoPoint.MapInfoPointID, mapInfoModel.MapInfoPointList[index].MapInfoPointID);
            Assert.Equal(mapInfoPoint.Ordinal, mapInfoModel.MapInfoPointList[index].Ordinal);
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, mapInfoModel.MapInfoPointList[index].LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddMinutes(-1) < mapInfoModel.MapInfoPointList[index].LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddMinutes(1) > mapInfoModel.MapInfoPointList[index].LastUpdateDate_UTC);

            index += 1;
        }
    }
}

