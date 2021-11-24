namespace CSSPDBLocalServices.Tests;

public partial class CSSPDBLocalServiceTest
{
    protected void CheckMapInfo(MapInfo mapInfo, DBCommandEnum dbCommand)
    {
        MapInfo mapInfoDB = (from c in dbLocal.MapInfos
                             where c.MapInfoID == mapInfo.MapInfoID
                             select c).FirstOrDefault();
        Assert.NotNull(mapInfoDB);

        Assert.Equal(dbCommand, mapInfo.DBCommand);
        Assert.Equal(mapInfoDB.DBCommand, mapInfo.DBCommand);
        Assert.Equal(mapInfoDB.LatMax, mapInfo.LatMax);
        Assert.Equal(mapInfoDB.LatMin, mapInfo.LatMin);
        Assert.Equal(mapInfoDB.LngMax, mapInfo.LngMax);
        Assert.Equal(mapInfoDB.LngMin, mapInfo.LngMin);
        Assert.Equal(mapInfoDB.MapInfoDrawType, mapInfo.MapInfoDrawType);
        Assert.Equal(mapInfoDB.MapInfoID, mapInfo.MapInfoID);
        Assert.Equal(mapInfoDB.TVItemID, mapInfo.TVItemID);
        Assert.Equal(mapInfoDB.TVType, mapInfo.TVType);

        if (dbCommand != DBCommandEnum.Original)
        {
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, mapInfo.LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddMinutes(-1) < mapInfo.LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddMinutes(1) > mapInfo.LastUpdateDate_UTC);
        }
        else
        {
            Assert.Equal(mapInfoDB.LastUpdateContactTVItemID, mapInfo.LastUpdateContactTVItemID);
            Assert.Equal(mapInfoDB.LastUpdateDate_UTC, mapInfo.LastUpdateDate_UTC);
        }
    }
}

