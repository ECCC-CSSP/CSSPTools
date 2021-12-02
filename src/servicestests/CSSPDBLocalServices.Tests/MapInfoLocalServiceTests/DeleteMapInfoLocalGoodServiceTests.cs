namespace CSSPDBLocalServices.Tests;

public partial class MapInfoLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteMapInfoLocal_Area_Good_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetupAsync(culture));

        int ParentTVItemID = 7;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebProvince, TVItemID = ParentTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, ParentTVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        Assert.NotEmpty(webProvince.TVItemModelAreaList);

        TVItemModel tvItemModel = webProvince.TVItemModelAreaList[0];

        await CheckDeletedMapInfo(tvItemParent, tvItemModel, tvType, MapInfoDrawTypeEnum.Point);

        CheckCreatedLocalFilesAndDBForDeletePoint(webProvince.TVItemModelParentList);

        await ClearSomeTablesOfCSSPDBLocalAsync(TableList);

        await CheckDeletedMapInfo(tvItemParent, tvItemModel, tvType, MapInfoDrawTypeEnum.Polygon);

        MapInfoModel mapInfoModel = (from c in tvItemModel.MapInfoModelList
                                     where c.MapInfo.MapInfoDrawType == MapInfoDrawTypeEnum.Polygon
                                     select c).FirstOrDefault();
        Assert.NotNull(mapInfoModel);

        CheckCreatedLocalFilesAndDBForDeletePolygon(webProvince.TVItemModelParentList, mapInfoModel);
    }

    /* will need to create all the other tests */
}

