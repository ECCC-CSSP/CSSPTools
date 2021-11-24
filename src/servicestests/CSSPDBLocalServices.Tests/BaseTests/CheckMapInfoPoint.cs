namespace CSSPDBLocalServices.Tests;

public partial class CSSPDBLocalServiceTest
{
    protected void CheckMapInfoPoint(MapInfoPoint mapInfoPoint, DBCommandEnum dbCommand)
    {
        MapInfoPoint mapInfoPointDB = (from c in dbLocal.MapInfoPoints
                                       where c.MapInfoPointID == mapInfoPoint.MapInfoPointID
                                       select c).FirstOrDefault();
        Assert.NotNull(mapInfoPointDB);

        Assert.Equal(dbCommand, mapInfoPoint.DBCommand);
        Assert.Equal(mapInfoPointDB.DBCommand, mapInfoPoint.DBCommand);
        Assert.Equal(mapInfoPointDB.Lat, mapInfoPoint.Lat);
        Assert.Equal(mapInfoPointDB.Lng, mapInfoPoint.Lng);
        Assert.Equal(mapInfoPointDB.MapInfoID, mapInfoPoint.MapInfoID);
        Assert.Equal(mapInfoPointDB.MapInfoPointID, mapInfoPoint.MapInfoPointID);
        Assert.Equal(mapInfoPointDB.Ordinal, mapInfoPoint.Ordinal);

        if (dbCommand != DBCommandEnum.Original)
        {
            Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, mapInfoPoint.LastUpdateContactTVItemID);
            Assert.True(DateTime.UtcNow.AddMinutes(-1) < mapInfoPoint.LastUpdateDate_UTC);
            Assert.True(DateTime.UtcNow.AddMinutes(1) > mapInfoPoint.LastUpdateDate_UTC);
        }
        else
        {
            Assert.Equal(mapInfoPointDB.LastUpdateContactTVItemID, mapInfoPoint.LastUpdateContactTVItemID);
            Assert.Equal(mapInfoPointDB.LastUpdateDate_UTC, mapInfoPoint.LastUpdateDate_UTC);
        }
    }
}

