namespace CSSPDBLocalServices.Tests;

public partial class MapInfoLocalServiceTest : CSSPDBLocalServiceTest
{
    private void CheckCreatedLocalFilesAndDBForDeletePolygon(List<TVItemModel> TVItemModelParentList, MapInfoModel mapInfoModel)
    {
        DirectoryInfo di = new DirectoryInfo(Configuration["azure_csspjson_backup"]);
        Assert.True(di.Exists);
        Assert.True(di.GetFiles().Count() == 1);

        di = new DirectoryInfo(Configuration["azure_csspjson_backup_uncompress"]);
        Assert.True(di.Exists);
        Assert.True(di.GetFiles().Count() == 1);

        di = new DirectoryInfo(Configuration["CSSPJSONPath"]);
        Assert.True(di.Exists);
        Assert.True(di.GetFiles().Count() == 1);

        Assert.Equal(1, (from c in dbLocal.MapInfos select c).Count());
        Assert.Equal(mapInfoModel.MapInfoPointList.Count, (from c in dbLocal.MapInfoPoints select c).Count());
    }
}

