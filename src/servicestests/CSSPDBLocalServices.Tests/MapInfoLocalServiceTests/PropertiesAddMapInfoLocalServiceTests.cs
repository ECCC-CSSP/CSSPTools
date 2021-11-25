namespace CSSPDBLocalServices.Tests;

public partial class MapInfoLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Parameters_AddMapInfoLocal_tvItemParent_null_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemParent = null;

        List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, coordList);
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItemParent"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Parameters_AddMapInfoLocal_tvItem_null_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemModel.TVItem = null;

        List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, coordList);
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "tvItem"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Parameters_AddMapInfoLocal_tvItemParent_TVItemID_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemParent.TVItemID = 0;

        List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, coordList);
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVItemID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Parameters_AddMapInfoLocal_tvItemParent_ParentID_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemParent.ParentID = 0;

        List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, coordList);
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.ParentID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Parameters_AddMapInfoLocal_tvItemParent_TVType_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemParent.TVType = (TVTypeEnum)1000;

        List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, coordList);
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItemParent.TVType"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Parameters_AddMapInfoLocal_tvItem_TVItemID_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemModel.TVItem.TVItemID = 0;

        List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, coordList);
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItem.TVItemID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Parameters_AddMapInfoLocal_tvItem_ParentID_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemModel.TVItem.ParentID = 0;

        List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, coordList);
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItem.ParentID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Parameters_AddMapInfoLocal_tvItem_TVType_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemModel.TVItem.TVType = (TVTypeEnum)10000;

        List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, coordList);
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvItem.TVType"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Parameters_AddMapInfoLocal_tvType_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvType = (TVTypeEnum)10000;

        List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, coordList);
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "tvType"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Parameters_AddMapInfoLocal_mapInfoDrawType_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        MapInfoDrawTypeEnum mapInfoDrawType = (MapInfoDrawTypeEnum)10000;

        List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, mapInfoDrawType, coordList);
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "mapInfoDrawType"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Parameters_AddMapInfoLocal_CheckTVTypeParentAndTVType_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvType = TVTypeEnum.Country;

        List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, coordList);
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotAParentTypeOf_, tvItemParent.TVType.ToString(), tvType.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Parameters_AddMapInfoLocal_CheckTVTypeParentAndTVType_notimplemented_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
        TVTypeEnum tvType = TVTypeEnum.Area;

        string TVTextEN = "New Item";
        string TVTextFR = "Nouveau Item";

        var actionTVItemModel = await TVItemLocalService.AddTVItemLocalAsync(tvItemParent, tvType, TVTextEN, TVTextFR);
        Assert.Equal(200, ((ObjectResult)actionTVItemModel.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionTVItemModel.Result).Value);
        TVItemModel tvItemModel = (TVItemModel)((OkObjectResult)actionTVItemModel.Result).Value;
        Assert.NotNull(tvItemModel);

        tvItemParent.TVType = TVTypeEnum.Restricted;

        List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemModel.TVItem, tvType, MapInfoDrawTypeEnum.Point, coordList);
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._NotImplementedYet, tvItemParent.TVType.ToString()) + " --- CSSPDBLocalServices.TVItemLocalService.CheckTVTypeParentAndTVType", errRes.ErrList[0]);
    }

    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task Parameters_AddMapInfoLocal_MapInfo_AlreadyExist_Error_Test(string culture)
    {
        Assert.True(await MapInfoLocalServiceSetup(culture));

        int TVItemID = 7;

        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

        TVItem tvItemParent = webProvince.TVItemModel.TVItem;

        Assert.NotEmpty(webProvince.TVItemModelAreaList);

        TVItem tvItemAreaExist = webProvince.TVItemModelAreaList[0].TVItem;

        List<Coord> coordList = new List<Coord>()
            {
                new Coord() { Lat = 45.0D, Lng = -66.0D, Ordinal = 0 },
                new Coord() { Lat = 46.0D, Lng = -67.0D, Ordinal = 1 },
                new Coord() { Lat = 43.0D, Lng = -68.0D, Ordinal = 2 },
                new Coord() { Lat = 42.0D, Lng = -63.0D, Ordinal = 3 },
                new Coord() { Lat = 44.0D, Lng = -62.0D, Ordinal = 4 },
            };

        var actionMapInfoLocalModelPoint = await MapInfoLocalService.AddMapInfoLocalAsync(tvItemParent, tvItemAreaExist, tvItemAreaExist.TVType, MapInfoDrawTypeEnum.Point, coordList);
        Assert.Equal(400, ((ObjectResult)actionMapInfoLocalModelPoint.Result).StatusCode);
        Assert.NotNull(((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionMapInfoLocalModelPoint.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._AlreadyExists, "MapInfo"), errRes.ErrList[0]);
    }
}

