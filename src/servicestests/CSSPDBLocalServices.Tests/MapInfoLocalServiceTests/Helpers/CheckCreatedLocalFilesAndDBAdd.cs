namespace CSSPDBLocalServices.Tests;

public partial class MapInfoLocalServiceTest : CSSPDBLocalServiceTest
{
    private void CheckCreatedLocalFilesAndDBForAdd(List<TVItemModel> TVItemModelParentList, bool IsSubItemInJsonFile = false)
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

        if (IsSubItemInJsonFile)
        {
            Assert.Equal(TVItemModelParentList.Count + 2, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(2 * (TVItemModelParentList.Count + 2), (from c in dbLocal.TVItemLanguages select c).Count());
        }
        else
        {
            Assert.Equal(TVItemModelParentList.Count + 1, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(2 * (TVItemModelParentList.Count + 1), (from c in dbLocal.TVItemLanguages select c).Count());
        }
        Assert.Equal(6, (from c in dbLocal.MapInfos select c).Count());
        Assert.Equal(22, (from c in dbLocal.MapInfoPoints select c).Count());
    }
}

