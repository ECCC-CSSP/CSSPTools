namespace CSSPDBLocalServices.Tests;

public partial class ClassificationLocalServiceTest : CSSPDBLocalServiceTest
{
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task ModifyClassificationLocal_Good_Test(string culture)
    //{
    //    Assert.True(await ClassificationLocalServiceSetup(culture));

    //    int SubsectorTVItemID = 635;

    //    await CSSPCreateGzFileService.SetLocal(false);

    //    List<ToRecreate> ToRecreateList = new List<ToRecreate>()
    //    {
    //        new ToRecreate() { WebType = WebTypeEnum.WebSubsector, TVItemID = SubsectorTVItemID },
    //    };

    //    await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

    //    WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, SubsectorTVItemID);

    //    int ordinal = (from c in webSubsector.ClassificationModelList
    //                   orderby c.Classification.Ordinal descending
    //                   select c.Classification.Ordinal).FirstOrDefault();

    //    List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;

    //    ClassificationTypeEnum classificationType = ClassificationTypeEnum.Approved;

    //    List<Coord> coordList = new List<Coord>()
    //    {
    //        new Coord() { Lat = 23.0D, Lng = -56.0D, Ordinal = 0 },
    //        new Coord() { Lat = 24.0D, Lng = -57.0D, Ordinal = 0 },
    //    };

    //    var actionClassificationRes = await ClassificationLocalService.ModifyClassificationLocalAsync(SubsectorTVItemID, classificationType, coordList);
    //    Assert.Equal(200, ((ObjectResult)actionClassificationRes.Result).StatusCode);
    //    Assert.NotNull(((OkObjectResult)actionClassificationRes.Result).Value);
    //    ClassificationLocalModel classificationLocalModelRet = (ClassificationLocalModel)((OkObjectResult)actionClassificationRes.Result).Value;
    //    Assert.NotNull(classificationLocalModelRet);

    //    // check count of CSSPDBLocal items in tables
    //    Assert.Equal(1, (from c in dbLocal.Classifications select c).Count());
    //    Assert.Equal(tvItemModelParentList.Count + 1, (from c in dbLocal.TVItems select c).Count());
    //    Assert.Equal((tvItemModelParentList.Count * 2) + 2, (from c in dbLocal.TVItemLanguages select c).Count());
    //    Assert.Equal(1, (from c in dbLocal.MapInfos select c).Count());
    //    Assert.Equal(coordList.Count, (from c in dbLocal.MapInfoPoints select c).Count());

    //    // check Classifications table items
    //    Assert.Equal(DBCommandEnum.Created, classificationLocalModelRet.Classification.DBCommand);
    //    Assert.Equal(-1, classificationLocalModelRet.Classification.ClassificationTVItemID);
    //    Assert.Equal(classificationType, classificationLocalModelRet.Classification.ClassificationType);
    //    Assert.Equal(ordinal + 1, classificationLocalModelRet.Classification.Ordinal);
    //    Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, classificationLocalModelRet.Classification.LastUpdateContactTVItemID);
    //    Assert.True(DateTime.UtcNow.AddMinutes(-1) < classificationLocalModelRet.Classification.LastUpdateDate_UTC);
    //    Assert.True(DateTime.UtcNow.AddMinutes(1) > classificationLocalModelRet.Classification.LastUpdateDate_UTC);

    //    Classification classificationDB = (from c in dbLocal.Classifications
    //                                       where c.ClassificationID == -1
    //                                       select c).FirstOrDefault();
    //    Assert.NotNull(classificationDB);

    //    TVItem tvItemDB = (from c in dbLocal.TVItems
    //                       where c.TVItemID == -1
    //                       select c).FirstOrDefault();
    //    Assert.NotNull(tvItemDB);

    //    TVItemLanguage tvItemLanguageENDB = (from c in dbLocal.TVItemLanguages
    //                                         where c.TVItemLanguageID == -1
    //                                         select c).FirstOrDefault();
    //    Assert.NotNull(tvItemLanguageENDB);
    //    Assert.Equal(LanguageEnum.en, tvItemLanguageENDB.Language);

    //    TVItemLanguage tvItemLanguageFRDB = (from c in dbLocal.TVItemLanguages
    //                                         where c.TVItemLanguageID == -2
    //                                         select c).FirstOrDefault();
    //    Assert.NotNull(tvItemLanguageFRDB);
    //    Assert.Equal(LanguageEnum.fr, tvItemLanguageFRDB.Language);

    //    MapInfo mapInfoDB = (from c in dbLocal.MapInfos
    //                         where c.MapInfoID == -1
    //                         select c).FirstOrDefault();
    //    Assert.NotNull(mapInfoDB);

    //    MapInfoPoint mapInfoPoint1DB = (from c in dbLocal.MapInfoPoints
    //                                    where c.MapInfoPointID == -1
    //                                    select c).FirstOrDefault();
    //    Assert.NotNull(mapInfoPoint1DB);
    //    Assert.Equal(coordList[0].Lat, mapInfoPoint1DB.Lat);
    //    Assert.Equal(coordList[0].Lng, mapInfoPoint1DB.Lng);

    //    MapInfoPoint mapInfoPoint2DB = (from c in dbLocal.MapInfoPoints
    //                                    where c.MapInfoPointID == -2
    //                                    select c).FirstOrDefault();
    //    Assert.NotNull(mapInfoPoint2DB);
    //    Assert.Equal(coordList[1].Lat, mapInfoPoint2DB.Lat);
    //    Assert.Equal(coordList[1].Lng, mapInfoPoint2DB.Lng);

    //    webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, SubsectorTVItemID);

    //    ClassificationModel classificationModelWeb = (from c in webSubsector.ClassificationModelList
    //                                                  where c.Classification.ClassificationID == -1
    //                                                  select c).FirstOrDefault();
    //    Assert.NotNull(classificationModelWeb);

    //    TVItemModel tvItemModel = new TVItemModel()
    //    {
    //        TVItem = webSubsector.TVItemModel.TVItem,
    //        TVItemLanguageList = webSubsector.TVItemModel.TVItemLanguageList,
    //    };

    //    tvItemModelParentList.Add(tvItemModel);

    //    CheckDBLocal(tvItemModelParentList);


    //    DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

    //    Assert.True(di.Exists);

    //    List<FileInfo> fiList = di.GetFiles().ToList();

    //    Assert.Single(fiList);

    //    Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebSubsector }_{ SubsectorTVItemID }.gz").Any());

    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task ModifyClassificationLocal_Unauthorized_Error_Test(string culture)
    //{
    //    Assert.True(await ClassificationLocalServiceSetup(culture));

    //    int SubsectorTVItemID = 0;

    //    ClassificationTypeEnum classificationType = ClassificationTypeEnum.Approved;

    //    List<Coord> coordList = new List<Coord>()
    //    {
    //        new Coord() { Lat = 23.0D, Lng = -56.0D, Ordinal = 0 },
    //        new Coord() { Lat = 24.0D, Lng = -57.0D, Ordinal = 0 },
    //    };

    //    CSSPLocalLoggedInService.LoggedInContactInfo = null;

    //    var actionClassificationRes = await ClassificationLocalService.ModifyClassificationLocalAsync(SubsectorTVItemID, classificationType, coordList);
    //    Assert.Equal(401, ((ObjectResult)actionClassificationRes.Result).StatusCode);
    //    ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionClassificationRes.Result).Value;
    //    Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task ModifyClassificationLocal_Unauthorized2_Error_Test(string culture)
    //{
    //    Assert.True(await ClassificationLocalServiceSetup(culture));

    //    int SubsectorTVItemID = 0;

    //    ClassificationTypeEnum classificationType = ClassificationTypeEnum.Approved;

    //    List<Coord> coordList = new List<Coord>()
    //    {
    //        new Coord() { Lat = 23.0D, Lng = -56.0D, Ordinal = 0 },
    //        new Coord() { Lat = 24.0D, Lng = -57.0D, Ordinal = 0 },
    //    };

    //    CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

    //    var actionClassificationRes = await ClassificationLocalService.ModifyClassificationLocalAsync(SubsectorTVItemID, classificationType, coordList);
    //    Assert.Equal(401, ((ObjectResult)actionClassificationRes.Result).StatusCode);
    //    ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionClassificationRes.Result).Value;
    //    Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task ModifyClassificationLocal_SubsectorTVItemID_Error_Test(string culture)
    //{
    //    Assert.True(await ClassificationLocalServiceSetup(culture));

    //    int SubsectorTVItemID = 0;

    //    ClassificationTypeEnum classificationType = ClassificationTypeEnum.Approved;

    //    List<Coord> coordList = new List<Coord>()
    //    {
    //        new Coord() { Lat = 23.0D, Lng = -56.0D, Ordinal = 0 },
    //        new Coord() { Lat = 24.0D, Lng = -57.0D, Ordinal = 0 },
    //    };

    //    var actionClassificationRes = await ClassificationLocalService.ModifyClassificationLocalAsync(SubsectorTVItemID, classificationType, coordList);
    //    Assert.Equal(400, ((ObjectResult)actionClassificationRes.Result).StatusCode);
    //    ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionClassificationRes.Result).Value;
    //    Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "SubsectorTVItemID"), errRes.ErrList[0]);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task ModifyClassificationLocal_ClassificationTypeEnum_Error_Test(string culture)
    //{
    //    Assert.True(await ClassificationLocalServiceSetup(culture));

    //    int SubsectorTVItemID = 635;

    //    ClassificationTypeEnum classificationType = (ClassificationTypeEnum)100000;

    //    List<Coord> coordList = new List<Coord>()
    //    {
    //        new Coord() { Lat = 23.0D, Lng = -56.0D, Ordinal = 0 },
    //        new Coord() { Lat = 24.0D, Lng = -57.0D, Ordinal = 0 },
    //    };

    //    var actionClassificationRes = await ClassificationLocalService.ModifyClassificationLocalAsync(SubsectorTVItemID, classificationType, coordList);
    //    Assert.Equal(400, ((ObjectResult)actionClassificationRes.Result).StatusCode);
    //    ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionClassificationRes.Result).Value;
    //    Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "ClassificationType"), errRes.ErrList[0]);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task ModifyClassificationLocal_coordList_null_Error_Test(string culture)
    //{
    //    Assert.True(await ClassificationLocalServiceSetup(culture));

    //    int SubsectorTVItemID = 635;

    //    ClassificationTypeEnum classificationType = ClassificationTypeEnum.Approved;

    //    List<Coord> coordList = new List<Coord>()
    //    {
    //        new Coord() { Lat = 23.0D, Lng = -56.0D, Ordinal = 0 },
    //        new Coord() { Lat = 24.0D, Lng = -57.0D, Ordinal = 0 },
    //    };

    //    coordList = null;

    //    var actionClassificationRes = await ClassificationLocalService.ModifyClassificationLocalAsync(SubsectorTVItemID, classificationType, coordList);
    //    Assert.Equal(400, ((ObjectResult)actionClassificationRes.Result).StatusCode);
    //    ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionClassificationRes.Result).Value;
    //    Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "coordList"), errRes.ErrList[0]);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task ModifyClassificationLocal_coordList_NeedAtLeast2Points_Error_Test(string culture)
    //{
    //    Assert.True(await ClassificationLocalServiceSetup(culture));

    //    int SubsectorTVItemID = 635;

    //    ClassificationTypeEnum classificationType = ClassificationTypeEnum.Approved;

    //    List<Coord> coordList = new List<Coord>()
    //    {
    //        new Coord() { Lat = 23.0D, Lng = -56.0D, Ordinal = 0 },
    //        //new Coord() { Lat = 24.0D, Lng = -57.0D, Ordinal = 0 },
    //    };

    //    var actionClassificationRes = await ClassificationLocalService.ModifyClassificationLocalAsync(SubsectorTVItemID, classificationType, coordList);
    //    Assert.Equal(400, ((ObjectResult)actionClassificationRes.Result).StatusCode);
    //    ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionClassificationRes.Result).Value;
    //    Assert.Equal(string.Format(CSSPCultureServicesRes._NeedsAtLeast2Points, "coordList"), errRes.ErrList[0]);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task ModifyClassificationLocal_Lat_MinValueMinus90_Error_Test(string culture)
    //{
    //    Assert.True(await ClassificationLocalServiceSetup(culture));

    //    int SubsectorTVItemID = 635;

    //    ClassificationTypeEnum classificationType = ClassificationTypeEnum.Approved;

    //    List<Coord> coordList = new List<Coord>()
    //    {
    //        new Coord() { Lat = -123.0D, Lng = -56.0D, Ordinal = 0 },
    //        new Coord() { Lat = 24.0D, Lng = -57.0D, Ordinal = 0 },
    //    };

    //    var actionClassificationRes = await ClassificationLocalService.ModifyClassificationLocalAsync(SubsectorTVItemID, classificationType, coordList);
    //    Assert.Equal(400, ((ObjectResult)actionClassificationRes.Result).StatusCode);
    //    ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionClassificationRes.Result).Value;
    //    Assert.Equal(string.Format(CSSPCultureServicesRes._MinValueIs_, "Lat", "-90"), errRes.ErrList[0]);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task ModifyClassificationLocal_Lat_MaxValue90_Error_Test(string culture)
    //{
    //    Assert.True(await ClassificationLocalServiceSetup(culture));

    //    int SubsectorTVItemID = 635;

    //    ClassificationTypeEnum classificationType = ClassificationTypeEnum.Approved;

    //    List<Coord> coordList = new List<Coord>()
    //    {
    //        new Coord() { Lat = 123.0D, Lng = -56.0D, Ordinal = 0 },
    //        new Coord() { Lat = 24.0D, Lng = -57.0D, Ordinal = 0 },
    //    };

    //    var actionClassificationRes = await ClassificationLocalService.ModifyClassificationLocalAsync(SubsectorTVItemID, classificationType, coordList);
    //    Assert.Equal(400, ((ObjectResult)actionClassificationRes.Result).StatusCode);
    //    ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionClassificationRes.Result).Value;
    //    Assert.Equal(string.Format(CSSPCultureServicesRes._MaxValueIs_, "Lat", "90"), errRes.ErrList[0]);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task ModifyClassificationLocal_Lng_MinValueMinus180_Error_Test(string culture)
    //{
    //    Assert.True(await ClassificationLocalServiceSetup(culture));

    //    int SubsectorTVItemID = 635;

    //    ClassificationTypeEnum classificationType = ClassificationTypeEnum.Approved;

    //    List<Coord> coordList = new List<Coord>()
    //    {
    //        new Coord() { Lat = 23.0D, Lng = -256.0D, Ordinal = 0 },
    //        new Coord() { Lat = 24.0D, Lng = -57.0D, Ordinal = 0 },
    //    };

    //    var actionClassificationRes = await ClassificationLocalService.ModifyClassificationLocalAsync(SubsectorTVItemID, classificationType, coordList);
    //    Assert.Equal(400, ((ObjectResult)actionClassificationRes.Result).StatusCode);
    //    ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionClassificationRes.Result).Value;
    //    Assert.Equal(string.Format(CSSPCultureServicesRes._MinValueIs_, "Lng", "-180"), errRes.ErrList[0]);
    //}
    //[Theory]
    //[InlineData("en-CA")]
    ////[InlineData("fr-CA")]
    //public async Task ModifyClassificationLocal_Lng_MaxValue180_Error_Test(string culture)
    //{
    //    Assert.True(await ClassificationLocalServiceSetup(culture));

    //    int SubsectorTVItemID = 635;

    //    ClassificationTypeEnum classificationType = ClassificationTypeEnum.Approved;

    //    List<Coord> coordList = new List<Coord>()
    //    {
    //        new Coord() { Lat = 23.0D, Lng = -56.0D, Ordinal = 0 },
    //        new Coord() { Lat = 24.0D, Lng = 257.0D, Ordinal = 0 },
    //    };

    //    var actionClassificationRes = await ClassificationLocalService.ModifyClassificationLocalAsync(SubsectorTVItemID, classificationType, coordList);
    //    Assert.Equal(400, ((ObjectResult)actionClassificationRes.Result).StatusCode);
    //    ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionClassificationRes.Result).Value;
    //    Assert.Equal(string.Format(CSSPCultureServicesRes._MaxValueIs_, "Lng", "180"), errRes.ErrList[0]);
    //}
}

