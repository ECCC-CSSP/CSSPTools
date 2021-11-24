namespace CSSPDBLocalServices.Tests;

public partial class CSSPDBLocalServiceTest
{
    protected void CheckMapInfoEmpty(MapInfo mapInfo)
    {
        MapInfo mapInfoDB = (from c in dbLocal.MapInfos
                             where c.MapInfoID == mapInfo.MapInfoID
                             select c).FirstOrDefault();
        Assert.Null(mapInfoDB);
    }
}

