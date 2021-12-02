namespace CSSPDBLocalServices.Tests;

public partial class AddressLocalServiceTest : CSSPDBLocalServiceTest
{
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_Good_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        { 
            new ToRecreate() { WebType = WebTypeEnum.WebAllAddresses, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllCountries, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllProvinces, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllMunicipalities, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        Address address = FillAddress();

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(address);
        Assert.Equal(200, ((ObjectResult)actionAddressRes.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionAddressRes.Result).Value);
        Address addressRet = (Address)((OkObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(addressRet);

        Assert.Equal(1, (from c in dbLocal.Addresses select c).Count());
        Assert.Equal(2, (from c in dbLocal.TVItems select c).Count());
        Assert.Equal(4, (from c in dbLocal.TVItemLanguages select c).Count());

        Assert.Equal(-1, addressRet.AddressID);
        Assert.Equal(DBCommandEnum.Created, addressRet.DBCommand);
        Assert.Equal(-1, addressRet.AddressTVItemID);
        Assert.Equal(address.AddressType, addressRet.AddressType);
        Assert.Equal(address.CountryTVItemID, addressRet.CountryTVItemID);
        Assert.Equal(address.GoogleAddressText, addressRet.GoogleAddressText);
        Assert.Equal(address.MunicipalityTVItemID, addressRet.MunicipalityTVItemID);
        Assert.Equal(address.PostalCode, addressRet.PostalCode);
        Assert.Equal(address.ProvinceTVItemID, addressRet.ProvinceTVItemID);
        Assert.Equal(address.StreetName, addressRet.StreetName);
        Assert.Equal(address.StreetNumber, addressRet.StreetNumber);
        Assert.Equal(address.StreetType, addressRet.StreetType);
        Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, addressRet.LastUpdateContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < addressRet.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > addressRet.LastUpdateDate_UTC);

        Address addressDB = (from c in dbLocal.Addresses
                             where c.AddressID == -1
                             select c).FirstOrDefault();
        Assert.NotNull(addressDB);
        Assert.Equal(-1, addressDB.AddressTVItemID);

        Assert.Equal(JsonSerializer.Serialize(addressDB), JsonSerializer.Serialize(addressRet));

        TVItem tvItemDB = (from c in dbLocal.TVItems
                           where c.TVItemID == -1
                           select c).FirstOrDefault();
        Assert.NotNull(tvItemDB);
        Assert.Equal(TVTypeEnum.Address, tvItemDB.TVType);

        List<TVItemLanguage> tvItemLanguageListDB = (from c in dbLocal.TVItemLanguages
                                                     where c.TVItemID == -1
                                                     select c).ToList();
        Assert.NotNull(tvItemLanguageListDB);
        Assert.NotEmpty(tvItemLanguageListDB);
        Assert.Equal(2, tvItemLanguageListDB.Count);

        address = FillAddress();

        address.StreetName = "next street name";

        var actionAddressRes2 = await AddressLocalService.AddAddressLocalAsync(address);
        Assert.Equal(200, ((ObjectResult)actionAddressRes2.Result).StatusCode);
        Assert.NotNull(((OkObjectResult)actionAddressRes2.Result).Value);
        Address addressRet2 = (Address)((OkObjectResult)actionAddressRes2.Result).Value;
        Assert.NotNull(addressRet2);

        Assert.Equal(2, (from c in dbLocal.Addresses select c).Count());
        Assert.Equal(3, (from c in dbLocal.TVItems select c).Count());
        Assert.Equal(6, (from c in dbLocal.TVItemLanguages select c).Count());

        Assert.Equal(-2, addressRet2.AddressID);
        Assert.Equal(DBCommandEnum.Created, addressRet2.DBCommand);
        Assert.Equal(-2, addressRet2.AddressTVItemID);
        Assert.Equal(address.AddressType, addressRet2.AddressType);
        Assert.Equal(address.CountryTVItemID, addressRet2.CountryTVItemID);
        Assert.Equal(address.GoogleAddressText, addressRet2.GoogleAddressText);
        Assert.Equal(address.MunicipalityTVItemID, addressRet2.MunicipalityTVItemID);
        Assert.Equal(address.PostalCode, addressRet2.PostalCode);
        Assert.Equal(address.ProvinceTVItemID, addressRet2.ProvinceTVItemID);
        Assert.Equal(address.StreetName, addressRet2.StreetName);
        Assert.Equal(address.StreetNumber, addressRet2.StreetNumber);
        Assert.Equal(address.StreetType, addressRet2.StreetType);
        Assert.Equal(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact.ContactTVItemID, addressRet2.LastUpdateContactTVItemID);
        Assert.True(DateTime.UtcNow.AddMinutes(-1) < addressRet2.LastUpdateDate_UTC);
        Assert.True(DateTime.UtcNow.AddMinutes(1) > addressRet2.LastUpdateDate_UTC);

        Address addressDB2 = (from c in dbLocal.Addresses
                              where c.AddressID == -2
                              select c).FirstOrDefault();
        Assert.NotNull(addressDB2);
        Assert.Equal(-2, addressDB2.AddressTVItemID);

        Assert.Equal(JsonSerializer.Serialize(addressDB), JsonSerializer.Serialize(addressRet));

        TVItem tvItemDB2 = (from c in dbLocal.TVItems
                            where c.TVItemID == -2
                            select c).FirstOrDefault();
        Assert.NotNull(tvItemDB2);

        List<TVItemLanguage> tvItemLanguageListDB2 = (from c in dbLocal.TVItemLanguages
                                                      where c.TVItemID == -2
                                                      select c).ToList();
        Assert.NotNull(tvItemLanguageListDB2);
        Assert.NotEmpty(tvItemLanguageListDB2);
        Assert.Equal(2, tvItemLanguageListDB2.Count);

        WebAllAddresses webAllAddresses = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllAddresses>(WebTypeEnum.WebAllAddresses, 0);

        Address addressWeb = (from c in webAllAddresses.AddressList
                              where c.AddressID == -1
                              select c).FirstOrDefault();
        Assert.NotNull(addressWeb);
        Assert.Equal(-1, addressWeb.AddressTVItemID);

        Address addressWeb2 = (from c in webAllAddresses.AddressList
                               where c.AddressID == -2
                               select c).FirstOrDefault();
        Assert.NotNull(addressWeb2);
        Assert.Equal(-2, addressWeb2.AddressTVItemID);

        WebRoot webRoot = await CSSPReadGzFileService.GetUncompressJSONAsync<WebRoot>(WebTypeEnum.WebRoot, 0);

        List<TVItemModel> tvItemModelParentList = webRoot.TVItemModelParentList;

        TVItemModel tvItemModel = new TVItemModel()
        {
            TVItem = tvItemDB,
            TVItemLanguageList = tvItemLanguageListDB,
        };

        tvItemModelParentList.Add(tvItemModel);

        CheckDBLocal(tvItemModelParentList);

        DirectoryInfo di = new DirectoryInfo(Configuration["CSSPJSONPathLocal"]);

        Assert.True(di.Exists);

        List<FileInfo> fiList = di.GetFiles().ToList();

        Assert.Equal(2, fiList.Count);

        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebAllAddresses }.gz").Any());
        Assert.True(fiList.Where(c => c.Name == $"{ WebTypeEnum.WebRoot }.gz").Any());
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_Unauthorized_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        Address address = FillAddress();

        CSSPLocalLoggedInService.LoggedInContactInfo = null;

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(address);
        Assert.Equal(401, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionAddressRes.Result).Value;
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_Unauthorized2_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        Address address = FillAddress();

        CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact = null;

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(address);
        Assert.Equal(401, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((UnauthorizedObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(CSSPCultureServicesRes.YouDoNotHaveAuthorization, errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_Address_null_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        Address address = FillAddress();

        address = null;

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(address);
        Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "address"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_AddressID_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        Address addressLocalModel = FillAddress();

        addressLocalModel.AddressID = 10;

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(addressLocalModel);
        Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._ShouldBeEqualTo_, "AddressID", "0"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_AddressType_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        Address addressLocalModel = FillAddress();

        addressLocalModel.AddressType = (AddressTypeEnum)10000;

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(addressLocalModel);
        Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "AddressType"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_CountryTVItemID_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        Address addressLocalModel = FillAddress();

        addressLocalModel.CountryTVItemID = 0;

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(addressLocalModel);
        Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "CountryTVItemID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_ProvinceTVItemID_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        Address addressLocalModel = FillAddress();

        addressLocalModel.ProvinceTVItemID = 0;

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(addressLocalModel);
        Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "ProvinceTVItemID "), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_MunicipalityTVItemID_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        Address addressLocalModel = FillAddress();

        addressLocalModel.MunicipalityTVItemID = 0;

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(addressLocalModel);
        Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsRequired, "MunicipalityTVItemID"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_StreetName_length_over_200_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        Address addressLocalModel = FillAddress();

        addressLocalModel.StreetName = "a".PadRight(201);

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(addressLocalModel);
        Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StreetName", "200"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_StreetNumber_length_over_50_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        Address addressLocalModel = FillAddress();

        addressLocalModel.StreetNumber = "a".PadRight(51);

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(addressLocalModel);
        Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "StreetNumber", "50"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_StreetType_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        Address addressLocalModel = FillAddress();

        addressLocalModel.StreetType = (StreetTypeEnum)1000;

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(addressLocalModel);
        Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._IsNotOfType_, "StreetType", "StreetTypeEnum"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_PostalCode_length_over_11_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        Address addressLocalModel = FillAddress();

        addressLocalModel.PostalCode = "a".PadRight(12);

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(addressLocalModel);
        Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "PostalCode", "11"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_GoogelAddressText_length_over_200_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        Address addressLocalModel = FillAddress();

        addressLocalModel.GoogleAddressText = "a".PadRight(201);

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(addressLocalModel);
        Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "GoogleAddressText", "200"), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_Return_Existing_Address_As_It_Already_Exist_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebAllAddresses, TVItemID = 0 },
            //new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
            //new ToRecreate() { WebType = WebTypeEnum.WebAllCountries, TVItemID = 0 },
            //new ToRecreate() { WebType = WebTypeEnum.WebAllProvinces, TVItemID = 0 },
            //new ToRecreate() { WebType = WebTypeEnum.WebAllMunicipalities, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        WebAllAddresses webAllAddresses = await CSSPReadGzFileService.GetUncompressJSONAsync<WebAllAddresses>(WebTypeEnum.WebAllAddresses, 0);

        Assert.True(webAllAddresses.AddressList.Count > 10);

        Address address = FillAddress();

        address = webAllAddresses.AddressList[7];

        int AddressID = address.AddressID;

        address.AddressID = 0;

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(address);
        Assert.Equal(200, ((ObjectResult)actionAddressRes.Result).StatusCode);
        Address addressRet = (Address)((OkObjectResult)actionAddressRes.Result).Value;
        address.AddressID = AddressID;
        Assert.Equal(JsonSerializer.Serialize(address), JsonSerializer.Serialize(addressRet));
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_Country_Not_Found_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebAllAddresses, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllCountries, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllProvinces, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllMunicipalities, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        Address addressLocalModel = FillAddress();

        addressLocalModel.CountryTVItemID = 1000000;

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(addressLocalModel);
        Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Country", "CountryTVItemID", addressLocalModel.CountryTVItemID.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_Province_Not_Found_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebAllAddresses, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllCountries, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllProvinces, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllMunicipalities, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        Address addressLocalModel = FillAddress();

        addressLocalModel.ProvinceTVItemID = 1;

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(addressLocalModel);
        Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Province", "ProvinceTVItemID", addressLocalModel.ProvinceTVItemID.ToString()), errRes.ErrList[0]);
    }
    [Theory]
    [InlineData("en-CA")]
    //[InlineData("fr-CA")]
    public async Task AddAddressLocal_Municipality_Not_Found_Error_Test(string culture)
    {
        Assert.True(await AddressLocalServiceSetupAsync(culture));

        await CSSPCreateGzFileService.SetLocal(false);

        List<ToRecreate> ToRecreateList = new List<ToRecreate>()
        {
            new ToRecreate() { WebType = WebTypeEnum.WebAllAddresses, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebRoot, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllCountries, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllProvinces, TVItemID = 0 },
            new ToRecreate() { WebType = WebTypeEnum.WebAllMunicipalities, TVItemID = 0 },
        };

        await CreateAndLocalizeJsonGzFileAsync(ToRecreateList);

        Address addressLocalModel = FillAddress();

        addressLocalModel.MunicipalityTVItemID = 1;

        var actionAddressRes = await AddressLocalService.AddAddressLocalAsync(addressLocalModel);
        Assert.Equal(400, ((ObjectResult)actionAddressRes.Result).StatusCode);
        ErrRes errRes = (ErrRes)((BadRequestObjectResult)actionAddressRes.Result).Value;
        Assert.NotNull(errRes);
        Assert.NotEmpty(errRes.ErrList);
        Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFind_With_Equal_, "Municipality", "MunicipalityTVItemID", addressLocalModel.MunicipalityTVItemID.ToString()), errRes.ErrList[0]);
    }
}

