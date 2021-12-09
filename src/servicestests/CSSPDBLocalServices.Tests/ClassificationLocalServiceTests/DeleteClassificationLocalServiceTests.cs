namespace CSSPDBLocalServices.Tests;

public partial class ClassificationLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteClassificationLocal_Good_Test(string culture)
    {
        Assert.True(await ClassificationLocalServiceSetupAsync(culture));

        int SubsectorTVItemID = 635;

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebSubsector, TVItemID = SubsectorTVItemID },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, SubsectorTVItemID);

        List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;

        Assert.NotEmpty(webSubsector.ClassificationModelList);

        ClassificationModel classificationModel = webSubsector.ClassificationModelList[0];

        var actionClassificationRes = await ClassificationLocalService.DeleteClassificationLocalAsync(SubsectorTVItemID, classificationModel.Classification.ClassificationTVItemID);
        Assert.Equal(200, ((ObjectResult)actionClassificationRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionClassificationRes.Result).Value);
        ClassificationLocalModel classificationLocalModelRet = (ClassificationLocalModel)((OkObjectResult)actionClassificationRes.Result).Value;
        Assert.NotNull(classificationLocalModelRet);

        Classification classificationDB = (from c in dbLocal.Classifications
                                           where c.ClassificationTVItemID == classificationModel.Classification.ClassificationTVItemID
                                           select c).FirstOrDefault();
        Assert.NotNull(classificationDB);
        Assert.Equal(DBCommandEnum.Deleted, classificationDB.DBCommand);

        TVItem tvItemDB = (from c in dbLocal.TVItems
                           where c.TVItemID == classificationModel.Classification.ClassificationTVItemID
                           select c).FirstOrDefault();
        Assert.NotNull(tvItemDB);
        Assert.Equal(DBCommandEnum.Deleted, tvItemDB.DBCommand);

        List<TVItemLanguage> tvItemLanguageDBList = (from c in dbLocal.TVItemLanguages
                                                     where c.TVItemID == classificationModel.Classification.ClassificationTVItemID
                                                     select c).ToList();
        Assert.NotNull(tvItemLanguageDBList);
        Assert.NotEmpty(tvItemLanguageDBList);
        Assert.Equal(DBCommandEnum.Deleted, tvItemLanguageDBList[0].DBCommand);
        Assert.Equal(DBCommandEnum.Deleted, tvItemLanguageDBList[1].DBCommand);

        MapInfo mapInfoDB = (from c in dbLocal.MapInfos
                             where c.TVItemID == classificationModel.Classification.ClassificationTVItemID
                             && c.MapInfoDrawType == MapInfoDrawTypeEnum.Polyline
                             select c).FirstOrDefault();
        Assert.NotNull(mapInfoDB);
        Assert.Equal(DBCommandEnum.Deleted, mapInfoDB.DBCommand);

        List<MapInfoPoint> mapInfoPointDBList = (from c in dbLocal.MapInfoPoints
                                                 where c.MapInfoID == mapInfoDB.MapInfoID
                                                 select c).ToList();
        Assert.NotNull(mapInfoPointDBList);
        Assert.NotEmpty(mapInfoPointDBList);
        foreach(MapInfoPoint mapInfoPoint in mapInfoPointDBList)
        {
            Assert.Equal(DBCommandEnum.Deleted, mapInfoPoint.DBCommand);
        }

        webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, SubsectorTVItemID);

        ClassificationModel classificationModelWeb = (from c in webSubsector.ClassificationModelList
                                                      where c.Classification.ClassificationTVItemID == classificationModel.Classification.ClassificationTVItemID
                                                      select c).FirstOrDefault();
        Assert.NotNull(classificationModelWeb);

        TVItemModel tvItemModel = new TVItemModel()
        {
            TVItem = webSubsector.TVItemModel.TVItem,
            TVItemLanguageList = webSubsector.TVItemModel.TVItemLanguageList,
        };

        tvItemModelParentList.Add(tvItemModel);

        CheckDBLocal(tvItemModelParentList);

        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

        Assert.True(di.Exists);

        List<FileInfo> fiList = di.GetFiles().ToList();

        Assert.Single(fiList);

        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebSubsector }_{ SubsectorTVItemID }.gz").Any());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteClassificationLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await ClassificationLocalServiceSetupAsync(culture));

        int SubsectorTVItemID = 0;
        int ClassificationTVItemID = 0;

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionClassificationRes = await ClassificationLocalService.DeleteClassificationLocalAsync(SubsectorTVItemID, ClassificationTVItemID);
        Assert.Equal(401, ((ObjectResult)actionClassificationRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionClassificationRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteClassificationLocal_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await ClassificationLocalServiceSetupAsync(culture));

        int SubsectorTVItemID = 0;
        int ClassificationTVItemID = 0;

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionClassificationRes = await ClassificationLocalService.DeleteClassificationLocalAsync(SubsectorTVItemID, ClassificationTVItemID);
        Assert.Equal(401, ((ObjectResult)actionClassificationRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionClassificationRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task DeleteClassificationLocal_SubsectorTVItemID_Error_Test(string culture)
    {
        Assert.True(await ClassificationLocalServiceSetupAsync(culture));

        int SubsectorTVItemID = 0;
        int ClassificationTVItemID = 0;

        var actionClassificationRes = await ClassificationLocalService.DeleteClassificationLocalAsync(SubsectorTVItemID, ClassificationTVItemID);
        Assert.Equal(400, ((ObjectResult)actionClassificationRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionClassificationRes.Result).Value;
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "SubsectorTVItemID"), errRes.ErrList[0]);
    }
}

