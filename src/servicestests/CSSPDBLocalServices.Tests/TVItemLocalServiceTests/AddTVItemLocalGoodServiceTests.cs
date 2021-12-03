//namespace CSSPDBLocalServices.Tests;

//public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
//{
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Country_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int ParentTVItemID = 0;

//        await CSSPCreateGzFileService.SetLocal(false);

//        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
//        {
//            new ToRecreate() { WebType = WebTypeEnum.WebProvince, TVItemID = ParentTVItemID },
//        };

//        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

//        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

//        TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Country;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);

//        //DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

//        //Assert.True(di.Exists);

//        //List<FileInfo> fiList = di.GetFiles().ToList();

//        //Assert.Equal(2, fiList.Count);

//        //Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllAddresses }.gz").Any());
//        //Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebRoot }.gz").Any());

//        //webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

//        //TVItemModel tvItemModelExist = (from c in webRoot.TVItemModelCountryList
//        //                                where c.TVItem.TVItemID == -1
//        //                                select c).FirstOrDefault();

//        //Assert.NotNull(tvItemModelExist);

//        //WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, -1);

//        //tvItemModelExist = webCountry.TVItemModel;

//        //Assert.NotNull(tvItemModelExist);

//        //WebAllCountries webAllCountries = await CSSPReadGzFileService.GetUncompressJSON<WebAllCountries>(WebTypeEnum.WebAllCountries, 0);

//        //tvItemModelExist = (from c in webAllCountries.TVItemModelList
//        //                    where c.TVItem.TVItemID == -1
//        //                    select c).FirstOrDefault();

//        //Assert.NotNull(tvItemModelExist);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Address_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        // use AddressLocalServiceTest

//        //WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

//        //TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        //TVTypeEnum tvType = TVTypeEnum.Address;
//        //string TVTextEN = "New Item";
//        //string TVTextFR = "Nouveau Item";

//        //TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        //CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        //CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        //CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        //List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;

//        //tvItemModelParentList.Add(tvItemModel);

//        //CheckDBLocal(tvItemModelParentList);
//        ////CheckLocalJsonFileCreated(tvItemModelParentList);

//        //WebAllAddresses webAllAddresses = await CSSPReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, 0);

//        //Address addressExist = (from c in webAllAddresses.AddressList
//        //                        where c.AddressTVItemID == -1
//        //                        select c).FirstOrDefault();

//        //Assert.NotNull(addressExist);

//        //addressExist = (from c in webAllAddresses.AddressList
//        //                where c.AddressID == -1
//        //                select c).FirstOrDefault();

//        //Assert.NotNull(addressExist);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Email_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        // use EmailLocalServiceTest

//        //WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

//        //TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        //TVTypeEnum tvType = TVTypeEnum.Email;
//        //string TVTextEN = "New Item";
//        //string TVTextFR = "Nouveau Item";

//        //TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        //CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        //CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        //CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        //List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;

//        //tvItemModelParentList.Add(tvItemModel);

//        //CheckDBLocal(tvItemModelParentList);
//        ////CheckLocalJsonFileCreated(tvItemModelParentList);

//        //WebAllEmails webAllEmails = await CSSPReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, 0);

//        //Email emailExist = (from c in webAllEmails.EmailList
//        //                    where c.EmailTVItemID == -1
//        //                    select c).FirstOrDefault();

//        //Assert.NotNull(emailExist);

//        //emailExist = (from c in webAllEmails.EmailList
//        //              where c.EmailID == -1
//        //              select c).FirstOrDefault();

//        //Assert.NotNull(emailExist);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Tel_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        // use TelLocalServiceTest

//        //WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, 0);

//        //TVItem tvItemParent = webRoot.TVItemModel.TVItem;
//        //TVTypeEnum tvType = TVTypeEnum.Tel;
//        //string TVTextEN = "New Item";
//        //string TVTextFR = "Nouveau Item";

//        //TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        //CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        //CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        //CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        //List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;

//        //tvItemModelParentList.Add(tvItemModel);

//        //CheckDBLocal(tvItemModelParentList);
//        ////CheckLocalJsonFileCreated(tvItemModelParentList);

//        //WebAllTels webAllTels = await CSSPReadGzFileService.GetUncompressJSON<WebAllTels>(WebTypeEnum.WebAllTels, 0);

//        //Tel telExist = (from c in webAllTels.TelList
//        //                    where c.TelTVItemID == -1
//        //                    select c).FirstOrDefault();

//        //Assert.NotNull(telExist);

//        //telExist = (from c in webAllTels.TelList
//        //              where c.TelID == -1
//        //              select c).FirstOrDefault();

//        //Assert.NotNull(telExist);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Province_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 5;

//        WebCountry webCountry = await CSSPReadGzFileService.GetUncompressJSONAsync<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

//        TVItem tvItemParent = webCountry.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Province;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webCountry.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        ////CheckLocalJsonFileCreated(tvItemModelParentList);

//        //webCountry = await CSSPReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, TVItemID);

//        //TVItemModel tvItemModelExist = (from c in webCountry.TVItemModelProvinceList
//        //                                where c.TVItem.TVItemID == -1
//        //                                select c).FirstOrDefault();

//        //Assert.NotNull(tvItemModelExist);

//        //WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, -1);

//        //tvItemModelExist = webProvince.TVItemModel;

//        //Assert.NotNull(tvItemModelExist);

//        //WebAllProvinces webAllProvinces = await CSSPReadGzFileService.GetUncompressJSON<WebAllProvinces>(WebTypeEnum.WebAllProvinces, 0);

//        //tvItemModelExist = (from c in webAllProvinces.TVItemModelList
//        //                    where c.TVItem.TVItemID == -1
//        //                    select c).FirstOrDefault();

//        //Assert.NotNull(tvItemModelExist);

//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_RainExceedance_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        // no testing required
//        // RainExceedance does not have TVItems and TVItemLanguages
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_EmailDistributionList_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        // no testing required
//        // EmailDistributionList does not have TVItems and TVItemLanguages
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Area_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 7;

//        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Area;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        ////CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_SamplingPlan_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 7;

//        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.SamplingPlan;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        ////CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Municipality_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 7;

//        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Municipality;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_ClimateSite_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 7;

//        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.ClimateSite;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_HydrometricSite_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 7;

//        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.HydrometricSite;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_TideSite_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 7;

//        WebProvince webProvince = await CSSPReadGzFileService.GetUncompressJSONAsync<WebProvince>(WebTypeEnum.WebProvince, TVItemID);

//        TVItem tvItemParent = webProvince.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.TideSite;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webProvince.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Infrastructure_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Infrastructure;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webMunicipality.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_MikeScenario_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMunicipality webMunicipality = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMunicipality>(WebTypeEnum.WebMunicipality, TVItemID);

//        TVItem tvItemParent = webMunicipality.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.MikeScenario;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webMunicipality.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_MikeSource_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.MikeSource;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
//        Assert.NotNull(mikeScenarioModel);

//        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

//        tvItemModelParentList.Add(mikeScenarioModel.TVItemModel);
//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_MikeBoundaryConditionMesh_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionMesh;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
//        Assert.NotNull(mikeScenarioModel);

//        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

//        tvItemModelParentList.Add(mikeScenarioModel.TVItemModel);
//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_MikeBoundaryConditionWebTide_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 27764;

//        WebMikeScenarios webMikeScenarios = await CSSPReadGzFileService.GetUncompressJSONAsync<WebMikeScenarios>(WebTypeEnum.WebMikeScenarios, TVItemID);

//        TVItem tvItemParent = webMikeScenarios.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionWebTide;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        MikeScenarioModel mikeScenarioModel = webMikeScenarios.MikeScenarioModelList[0];
//        Assert.NotNull(mikeScenarioModel);

//        tvItemParent = mikeScenarioModel.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webMikeScenarios.TVItemModelParentList;

//        tvItemModelParentList.Add(mikeScenarioModel.TVItemModel);
//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Sector_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 629;

//        WebArea webArea = await CSSPReadGzFileService.GetUncompressJSONAsync<WebArea>(WebTypeEnum.WebArea, TVItemID);

//        TVItem tvItemParent = webArea.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Sector;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webArea.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webArea.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Subsector_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 633;

//        WebSector webSector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSector>(WebTypeEnum.WebSector, TVItemID);

//        TVItem tvItemParent = webSector.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Subsector;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webSector.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webSector.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_MWQMRun_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

//        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.MWQMRun;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webSubsector.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_MWQMSite_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

//        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.MWQMSite;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webSubsector.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_PolSourceSite_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

//        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.PolSourceSite;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webSubsector.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//    [Theory]
//    [InlineData("en-CA")]
//    //[InlineData("fr-CA")]
//    public async Task AddTVItemLocal_Classification_Good_Test(string culture)
//    {
//        Assert.True(await TVItemLocalServiceSetup(culture));

//        int TVItemID = 635;

//        WebSubsector webSubsector = await CSSPReadGzFileService.GetUncompressJSONAsync<WebSubsector>(WebTypeEnum.WebSubsector, TVItemID);

//        TVItem tvItemParent = webSubsector.TVItemModel.TVItem;
//        TVTypeEnum tvType = TVTypeEnum.Classification;
//        string TVTextEN = "New Item";
//        string TVTextFR = "Nouveau Item";

//        tvItemParent = webSubsector.TVItemModel.TVItem;
//        Assert.NotNull(tvItemParent);

//        TVItemModel tvItemModel = await CheckAddTVItemLocal(tvItemParent, tvType, TVTextEN, TVTextFR);

//        CheckTVItem(tvItemModel, DBCommandEnum.Created);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextEN, LanguageEnum.en);
//        CheckTVItemLanguage(tvItemModel, DBCommandEnum.Created, TVTextFR, LanguageEnum.fr);

//        List<TVItemModel> tvItemModelParentList = webSubsector.TVItemModelParentList;

//        tvItemModelParentList.Add(tvItemModel);

//        CheckDBLocal(tvItemModelParentList);
//        //CheckLocalJsonFileCreated(tvItemModelParentList);
//    }
//}

