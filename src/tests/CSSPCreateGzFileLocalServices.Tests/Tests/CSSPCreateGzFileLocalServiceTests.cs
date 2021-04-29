using CSSPEnums;
using CSSPDBModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using CSSPWebModels;
using System.Collections.Generic;
using System.Linq;

namespace CreateGzFileLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class CreateGzFileLocalServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        // see under GzFileServices Setup.cs
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CreateGzFileLocalService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }

        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebAllAddresses_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllAddresses;
        //    int TVItemID = 0;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    // need to add an address when PostAddressModel is completed
        //    // replace PostTVItemModel by PostAddressModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Area,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Sector,
        //    //    TVTextEN = "New Sector",
        //    //    TVTextFR = "Nouveau Secteur"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllAddresses>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllAddresses webAllAddresses = (WebAllAddresses)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllAddresses);
        //    Assert.NotNull(webAllAddresses.AddressList);
        //    Assert.True(webAllAddresses.AddressList.Where(c => c.AddressID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebAllContacts_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllContacts;
        //    int TVItemID = 0;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    // need to add an address when PostContactModel is completed
        //    // replace PostTVItemModel by PostContactModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Area,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Sector,
        //    //    TVTextEN = "New Sector",
        //    //    TVTextFR = "Nouveau Secteur"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllContacts>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllContacts webAllContacts = (WebAllContacts)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllContacts);
        //    Assert.NotNull(webAllContacts.ContactList);
        //    Assert.True(webAllContacts.ContactList.Where(c => c.ContactID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebAllCountries_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllCountries;
        //    int TVItemID = 1;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Root,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.Country,
        //        TVTextEN = "New Country",
        //        TVTextFR = "Nouveau Pays"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllCountries>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllCountries webAllCountries = (WebAllCountries)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllCountries);
        //    Assert.NotNull(webAllCountries.TVItemAllCountryList);
        //    Assert.True(webAllCountries.TVItemAllCountryList.Where(c => c.TVItemModel.TVItem.TVItemID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebAllEmails_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllEmails;
        //    int TVItemID = 1;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    // need to add an address when PostEmailModel is completed
        //    // replace PostTVItemModel by PostEmailModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Root,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Email,
        //    //    TVTextEN = "New Email",
        //    //    TVTextFR = "Nouveau Courriel"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllEmails>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllEmails webAllEmails = (WebAllEmails)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllEmails);
        //    Assert.NotNull(webAllEmails.EmailList);
        //    Assert.True(webAllEmails.EmailList.Where(c => c.EmailID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebAllHelpDocs_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllHelpDocs;
        //    int TVItemID = 0;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    // need to add an address when PostHelpDocsModel is completed
        //    // replace PostTVItemModel by PostHelpDocsModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Root,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Email,
        //    //    TVTextEN = "New Email",
        //    //    TVTextFR = "Nouveau Courriel"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllHelpDocs>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllHelpDocs webAllHelpDocs = (WebAllHelpDocs)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllHelpDocs);
        //    Assert.NotNull(webAllHelpDocs.HelpDocList);
        //    Assert.True(webAllHelpDocs.HelpDocList.Where(c => c.HelpDocID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebAllMunicipalities_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllMunicipalities;
        //    int TVItemID = 7;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Province,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.Municipality,
        //        TVTextEN = "New Municipality",
        //        TVTextFR = "Nouvelle Municipalité"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllMunicipalities>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllMunicipalities webAllMunicipalities = (WebAllMunicipalities)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllMunicipalities);
        //    Assert.NotNull(webAllMunicipalities.TVItemAllMunicipalityList);
        //    Assert.True(webAllMunicipalities.TVItemAllMunicipalityList.Where(c => c.TVItemModel.TVItem.TVItemID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebAllMWQMLookupMPNs_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllMWQMLookupMPNs;
        //    int TVItemID = 0;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    // need to add an address when PostMWQMLookupMPNsModel is completed
        //    // replace PostTVItemModel by PostMWQMLookupMPNsModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Root,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Email,
        //    //    TVTextEN = "New Email",
        //    //    TVTextFR = "Nouveau Courriel"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);


        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllMWQMLookupMPNs>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllMWQMLookupMPNs webAllMWQMLookupMPNs = (WebAllMWQMLookupMPNs)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllMWQMLookupMPNs);
        //    Assert.NotNull(webAllMWQMLookupMPNs.MWQMLookupMPNList);
        //    Assert.True(webAllMWQMLookupMPNs.MWQMLookupMPNList.Where(c => c.MWQMLookupMPNID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebAllPolSourceGroupings_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllPolSourceGroupings;
        //    int TVItemID = 0;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

        //    // need to add an address when PostPolSourceGroupingsModel is completed
        //    // replace PostTVItemModel by PostPolSourceGroupingsModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Root,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Email,
        //    //    TVTextEN = "New Email",
        //    //    TVTextFR = "Nouveau Courriel"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllPolSourceGroupings>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllPolSourceGroupings webAllPolSourceGroupings = (WebAllPolSourceGroupings)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllPolSourceGroupings);
        //    Assert.NotNull(webAllPolSourceGroupings.PolSourceGroupingList);
        //    Assert.True(webAllPolSourceGroupings.PolSourceGroupingList.Where(c => c.PolSourceGroupingID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebAllPolSourceSiteEffectTerms_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllPolSourceSiteEffectTerms;
        //    int TVItemID = 0;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

        //    // need to add an address when PostPolSourceSiteEffectTermsModel is completed
        //    // replace PostTVItemModel by PostPolSourceSiteEffectTermsModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Root,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Email,
        //    //    TVTextEN = "New Email",
        //    //    TVTextFR = "Nouveau Courriel"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllPolSourceSiteEffectTerms>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllPolSourceSiteEffectTerms webAllPolSourceSiteEffectTerms = (WebAllPolSourceSiteEffectTerms)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllPolSourceSiteEffectTerms);
        //    Assert.NotNull(webAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList);
        //    Assert.True(webAllPolSourceSiteEffectTerms.PolSourceSiteEffectTermList.Where(c => c.PolSourceSiteEffectTermID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebAllProvinces_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllProvinces;
        //    int TVItemID = 5;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Country,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.Province,
        //        TVTextEN = "New Province",
        //        TVTextFR = "Nouvelle Province"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllProvinces>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllProvinces webAllProvinces = (WebAllProvinces)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllProvinces);
        //    Assert.NotNull(webAllProvinces.TVItemAllProvinceList);
        //    Assert.True(webAllProvinces.TVItemAllProvinceList.Where(c => c.TVItemModel.TVItem.TVItemID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebAllReportTypes_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllReportTypes;
        //    int TVItemID = 0;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

        //    // need to add an address when PostReportTypeModel is completed
        //    // replace PostTVItemModel by PostReportTypeModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Root,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Email,
        //    //    TVTextEN = "New Email",
        //    //    TVTextFR = "Nouveau Courriel"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllReportTypes>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllReportTypes webAllReportTypes = (WebAllReportTypes)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllReportTypes);
        //    Assert.NotNull(webAllReportTypes.ReportTypeModelList);
        //    Assert.True(webAllReportTypes.ReportTypeModelList.Where(c => c.ReportType.ReportTypeID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebAllTels_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllTels;
        //    int TVItemID = 0;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    // need to add an address when PostTelModel is completed
        //    // replace PostTVItemModel by PostTelModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Root,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Email,
        //    //    TVTextEN = "New Email",
        //    //    TVTextFR = "Nouveau Courriel"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllTels>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllTels webAllTels = (WebAllTels)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllTels);
        //    Assert.NotNull(webAllTels.TelList);
        //    Assert.True(webAllTels.TelList.Where(c => c.TelID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebAllTideLocations_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllTideLocations;
        //    int TVItemID = 0;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

        //    // need to add an address when PostTideLocationModel is completed
        //    // replace PostTVItemModel by PostTideLocationModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Root,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Email,
        //    //    TVTextEN = "New Email",
        //    //    TVTextFR = "Nouveau Courriel"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllTideLocations>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllTideLocations webAllTideLocations = (WebAllTideLocations)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllTideLocations);
        //    Assert.NotNull(webAllTideLocations.TideLocationList);
        //    Assert.True(webAllTideLocations.TideLocationList.Where(c => c.TideLocationID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocalWebAllTVItemLanguages_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllTVItemLanguages;
        //    int TVItemID = 629;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Area,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.Sector,
        //        TVTextEN = "New Sector",
        //        TVTextFR = "Nouveau Secteur"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllTVItemLanguages>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllTVItemLanguages webAllTVItemLanguages = (WebAllTVItemLanguages)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllTVItemLanguages);
        //    Assert.NotNull(webAllTVItemLanguages.TVItemLanguageList);
        //    Assert.True(webAllTVItemLanguages.TVItemLanguageList.Where(c => c.TVItemID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebAllTVItems_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebAllTVItems;
        //    int TVItemID = 629;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Area,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.Sector,
        //        TVTextEN = "New Sector",
        //        TVTextFR = "Nouveau Secteur"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebAllTVItems>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebAllTVItems webAllTVItems = (WebAllTVItems)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webAllTVItems);
        //    Assert.NotNull(webAllTVItems.TVItemList);
        //    Assert.True(webAllTVItems.TVItemList.Where(c => c.TVItemID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebArea_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebArea;
        //    int TVItemID = 629;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Area,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.Sector,
        //        TVTextEN = "New Sector",
        //        TVTextFR = "Nouveau Secteur"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebArea>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebArea webArea = (WebArea)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webArea);
        //    Assert.NotNull(webArea.TVItemModel);
        //    Assert.True(webArea.TVItemSectorList.Where(c => c.TVItemModel.TVItemLanguageList[0].TVText == postTVItemModel.TVTextEN).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebClimateDataValue_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebClimateDataValue;
        //    int TVItemID = 229465;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    // need to add an address when PostClimateDataValueModel is completed
        //    // replace PostTVItemModel by PostClimateDataValueModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Root,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Email,
        //    //    TVTextEN = "New Email",
        //    //    TVTextFR = "Nouveau Courriel"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebClimateDataValue>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebClimateDataValue webClimateDataValue = (WebClimateDataValue)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webClimateDataValue);
        //    Assert.NotNull(webClimateDataValue.ClimateDataValueList);
        //    Assert.True(webClimateDataValue.ClimateDataValueList.Where(c => c.ClimateDataValueID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebClimateSite_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebClimateSite;
        //    int TVItemID = 7;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Province,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.ClimateSite,
        //        TVTextEN = "New ClimateSite",
        //        TVTextFR = "Nouveau ClimateSite"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebClimateSite>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebClimateSite webClimateSite = (WebClimateSite)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webClimateSite);
        //    Assert.NotNull(webClimateSite.TVItemClimateSiteList);
        //    Assert.True(webClimateSite.TVItemClimateSiteList.Where(c => c.TVItemModel.TVItemLanguageList[0].TVText == postTVItemModel.TVTextEN).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebCountry_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebCountry;
        //    int TVItemID = 5;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Country,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.Province,
        //        TVTextEN = "New Province",
        //        TVTextFR = "Nouveau Province"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebCountry>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebCountry webCountry = (WebCountry)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webCountry);
        //    Assert.NotNull(webCountry.TVItemProvinceList);
        //    Assert.True(webCountry.TVItemProvinceList.Where(c => c.TVItemModel.TVItemLanguageList[0].TVText == postTVItemModel.TVTextEN).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebDrogueRun_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebDrogueRun;
        //    int TVItemID = 556;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    // need to add an address when PostDrogueRunModel is completed
        //    // replace PostTVItemModel by PostDrogueModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Root,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Email,
        //    //    TVTextEN = "New Email",
        //    //    TVTextFR = "Nouveau Courriel"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebDrogueRun>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebDrogueRun webDrogueRun = (WebDrogueRun)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webDrogueRun);
        //    Assert.NotNull(webDrogueRun.DrogueRunList);
        //    Assert.True(webDrogueRun.DrogueRunList.Where(c => c.DrogueRunID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebHydrometricDataValue_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebHydrometricDataValue;
        //    int TVItemID = 51705;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    // need to add an address when PostHydrometricDataValueModel is completed
        //    // replace PostTVItemModel by PostHydrometricDataValueModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Root,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Email,
        //    //    TVTextEN = "New Email",
        //    //    TVTextFR = "Nouveau Courriel"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebHydrometricDataValue>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebHydrometricDataValue webHydrometricDataValue = (WebHydrometricDataValue)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webHydrometricDataValue);
        //    Assert.NotNull(webHydrometricDataValue.HydrometricDataValueList);
        //    Assert.True(webHydrometricDataValue.HydrometricDataValueList.Where(c => c.HydrometricDataValueID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebHydrometricSite_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebHydrometricSite;
        //    int TVItemID = 7;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Province,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.HydrometricSite,
        //        TVTextEN = "New HydrometricSite",
        //        TVTextFR = "Nouveau HydrometricSite"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebHydrometricSite>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebHydrometricSite webHydrometricSite = (WebHydrometricSite)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webHydrometricSite);
        //    Assert.NotNull(webHydrometricSite.TVItemHydrometricSiteList);
        //    Assert.True(webHydrometricSite.TVItemHydrometricSiteList.Where(c => c.TVItemModel.TVItemLanguageList[0].TVText == postTVItemModel.TVTextEN).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebMikeScenario_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebMikeScenario;
        //    int TVItemID = 12281;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Municipality,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.MikeScenario,
        //        TVTextEN = "New MikeScenario",
        //        TVTextFR = "Nouveau MikeScenario"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebMikeScenario>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebMikeScenario webMikeScenario = (WebMikeScenario)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webMikeScenario);
        //    Assert.NotNull(webMikeScenario.TVItemMikeSourceList);
        //    Assert.True(webMikeScenario.TVItemMikeSourceList.Where(c => c.TVItemModel.TVItemLanguageList[0].TVText == postTVItemModel.TVTextEN).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebMunicipalities_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebMunicipalities;
        //    int TVItemID = 7;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Province,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.Municipality,
        //        TVTextEN = "New Municipality",
        //        TVTextFR = "Nouveau Municipality"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebMunicipalities>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebMunicipalities webMunicipalities = (WebMunicipalities)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webMunicipalities);
        //    Assert.NotNull(webMunicipalities.TVItemMunicipalityList);
        //    Assert.True(webMunicipalities.TVItemMunicipalityList.Where(c => c.TVItemModel.TVItemLanguageList[0].TVText == postTVItemModel.TVTextEN).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebMunicipality_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebMunicipality;
        //    int TVItemID = 27764;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Municipality,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.Infrastructure,
        //        TVTextEN = "New Infrastructure",
        //        TVTextFR = "Nouveau Infrastructure"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebMunicipality>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebMunicipality webMunicipality = (WebMunicipality)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webMunicipality);
        //    Assert.NotNull(webMunicipality.TVItemInfrastructureList);
        //    Assert.True(webMunicipality.TVItemInfrastructureList.Where(c => c.TVItemModel.TVItemLanguageList[0].TVText == postTVItemModel.TVTextEN).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebMWQMRun_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebMWQMRun;
        //    int TVItemID = 635;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    // need to add an address when PostMWQMRunModel is completed
        //    // replace PostTVItemModel by PostMWQMRunModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Municipality,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Infrastructure,
        //    //    TVTextEN = "New Infrastructure",
        //    //    TVTextFR = "Nouveau Infrastructure"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebMWQMRun>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebMWQMRun webMWQMRun = (WebMWQMRun)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webMWQMRun);
        //    Assert.NotNull(webMWQMRun.MWQMRunModelList);
        //    Assert.True(webMWQMRun.MWQMRunModelList.Where(c => c.MWQMRun.MWQMRunID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_Web10YearOfSample1980_1989FromSubsector_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
        //    int TVItemID = 635;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    // need to add an address when PostMWQMSampleModel is completed
        //    // replace PostTVItemModel by PostMWQMSampleModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Municipality,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Infrastructure,
        //    //    TVTextEN = "New Infrastructure",
        //    //    TVTextFR = "Nouveau Infrastructure"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webMWQMSample);
        //    Assert.NotNull(webMWQMSample.MWQMSampleList);
        //    Assert.True(webMWQMSample.MWQMSampleList.Where(c => c.MWQMSampleID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_Web10YearOfSample1990_1999FromSubsector(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
        //    int TVItemID = 635;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1990;

        //    // need to add an address when PostMWQMSampleModel is completed
        //    // replace PostTVItemModel by PostMWQMSampleModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Municipality,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Infrastructure,
        //    //    TVTextEN = "New Infrastructure",
        //    //    TVTextFR = "Nouveau Infrastructure"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webMWQMSample);
        //    Assert.NotNull(webMWQMSample.MWQMSampleList);
        //    Assert.True(webMWQMSample.MWQMSampleList.Where(c => c.MWQMSampleID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_Web10YearOfSample2000_2009FromSubsector(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
        //    int TVItemID = 635;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2000;

        //    // need to add an address when PostMWQMSampleModel is completed
        //    // replace PostTVItemModel by PostMWQMSampleModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Municipality,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Infrastructure,
        //    //    TVTextEN = "New Infrastructure",
        //    //    TVTextFR = "Nouveau Infrastructure"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webMWQMSample);
        //    Assert.NotNull(webMWQMSample.MWQMSampleList);
        //    Assert.True(webMWQMSample.MWQMSampleList.Where(c => c.MWQMSampleID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_Web10YearOfSample2010_2019FromSubsector(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
        //    int TVItemID = 635;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

        //    // need to add an address when PostMWQMSampleModel is completed
        //    // replace PostTVItemModel by PostMWQMSampleModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Municipality,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Infrastructure,
        //    //    TVTextEN = "New Infrastructure",
        //    //    TVTextFR = "Nouveau Infrastructure"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webMWQMSample);
        //    Assert.NotNull(webMWQMSample.MWQMSampleList);
        //    Assert.True(webMWQMSample.MWQMSampleList.Where(c => c.MWQMSampleID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_Web10YearOfSample2020_2029FromSubsector(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
        //    int TVItemID = 635;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2020;

        //    // need to add an address when PostMWQMSampleModel is completed
        //    // replace PostTVItemModel by PostMWQMSampleModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Municipality,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Infrastructure,
        //    //    TVTextEN = "New Infrastructure",
        //    //    TVTextFR = "Nouveau Infrastructure"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webMWQMSample);
        //    Assert.NotNull(webMWQMSample.MWQMSampleList);
        //    Assert.True(webMWQMSample.MWQMSampleList.Where(c => c.MWQMSampleID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_Web10YearOfSample2030_2039FromSubsector(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
        //    int TVItemID = 635;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2030;

        //    // need to add an address when PostMWQMSampleModel is completed
        //    // replace PostTVItemModel by PostMWQMSampleModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Municipality,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Infrastructure,
        //    //    TVTextEN = "New Infrastructure",
        //    //    TVTextFR = "Nouveau Infrastructure"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webMWQMSample);
        //    Assert.NotNull(webMWQMSample.MWQMSampleList);
        //    Assert.True(webMWQMSample.MWQMSampleList.Where(c => c.MWQMSampleID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_Web10YearOfSample2040_2049FromSubsector(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
        //    int TVItemID = 635;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2040;

        //    // need to add an address when PostMWQMSampleModel is completed
        //    // replace PostTVItemModel by PostMWQMSampleModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Municipality,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Infrastructure,
        //    //    TVTextEN = "New Infrastructure",
        //    //    TVTextFR = "Nouveau Infrastructure"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webMWQMSample);
        //    Assert.NotNull(webMWQMSample.MWQMSampleList);
        //    Assert.True(webMWQMSample.MWQMSampleList.Where(c => c.MWQMSampleID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_Web10YearOfSample2050_2059FromSubsector(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebMWQMSample;
        //    int TVItemID = 635;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2050;

        //    // need to add an address when PostMWQMSampleModel is completed
        //    // replace PostTVItemModel by PostMWQMSampleModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Municipality,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Infrastructure,
        //    //    TVTextEN = "New Infrastructure",
        //    //    TVTextFR = "Nouveau Infrastructure"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebMWQMSample>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebMWQMSample webMWQMSample = (WebMWQMSample)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webMWQMSample);
        //    Assert.NotNull(webMWQMSample.MWQMSampleList);
        //    Assert.True(webMWQMSample.MWQMSampleList.Where(c => c.MWQMSampleID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebMWQMSite_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebMWQMSite;
        //    int TVItemID = 635;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

        //    // need to add an address when PostMWQMSiteModel is completed
        //    // replace PostTVItemModel by PostMWQMSiteModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Municipality,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Infrastructure,
        //    //    TVTextEN = "New Infrastructure",
        //    //    TVTextFR = "Nouveau Infrastructure"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebMWQMSite>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebMWQMSite webMWQMSite = (WebMWQMSite)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webMWQMSite);
        //    Assert.NotNull(webMWQMSite.MWQMSiteModelList);
        //    Assert.True(webMWQMSite.MWQMSiteModelList.Where(c => c.MWQMSite.MWQMSiteID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebPolSourceSite_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebPolSourceSite;
        //    int TVItemID = 635;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

        //    // need to add an address when PostPolSourceSiteModel is completed
        //    // replace PostTVItemModel by PostPolSourceSiteModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Municipality,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Infrastructure,
        //    //    TVTextEN = "New Infrastructure",
        //    //    TVTextFR = "Nouveau Infrastructure"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebPolSourceSite>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebPolSourceSite webPolSourceSite = (WebPolSourceSite)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webPolSourceSite);
        //    Assert.NotNull(webPolSourceSite.PolSourceSiteModelList);
        //    Assert.True(webPolSourceSite.PolSourceSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebProvince_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebProvince;
        //    int TVItemID = 7;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Province,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.Area,
        //        TVTextEN = "New Area",
        //        TVTextFR = "Nouveau Area"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebProvince>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebProvince webProvince = (WebProvince)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webProvince);
        //    Assert.NotNull(webProvince.TVItemAreaList);
        //    Assert.True(webProvince.TVItemAreaList.Where(c => c.TVItemModel.TVItem.TVItemID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebRoot_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebRoot;
        //    int TVItemID = 0;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Root,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.Country,
        //        TVTextEN = "New Country",
        //        TVTextFR = "Nouveau Country"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebRoot>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebRoot webRoot = (WebRoot)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webRoot);
        //    Assert.NotNull(webRoot.TVItemCountryList);
        //    Assert.True(webRoot.TVItemCountryList.Where(c => c.TVItemModel.TVItem.TVItemID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebSamplingPlan_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebSamplingPlan;
        //    int TVItemID = 8; // TVItemID is SamplingPlanID in this case
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

        //    // need to add an address when PostSamplingPlanModel is completed
        //    // replace PostTVItemModel by PostSamplingPlanModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Root,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Country,
        //    //    TVTextEN = "New Country",
        //    //    TVTextFR = "Nouveau Country"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebSamplingPlan>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebSamplingPlan webSamplingPlan = (WebSamplingPlan)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webSamplingPlan);
        //    Assert.NotNull(webSamplingPlan.SamplingPlanModel);
        //    Assert.True(webSamplingPlan.SamplingPlanModel.SamplingPlanSubsectorModelList.Where(c => c.SamplingPlanSubsector.SamplingPlanSubsectorID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebSector_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebSector;
        //    int TVItemID = 633;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Sector,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.Subsector,
        //        TVTextEN = "New Subsector",
        //        TVTextFR = "Nouveau Subsector"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebSector>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebSector webSector = (WebSector)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webSector);
        //    Assert.NotNull(webSector.TVItemSubsectorList);
        //    Assert.True(webSector.TVItemSubsectorList.Where(c => c.TVItemModel.TVItem.TVItemID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebSubsector_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebSubsector;
        //    int TVItemID = 635;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year2010;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Subsector,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.MWQMSite,
        //        TVTextEN = "New MWQMSite",
        //        TVTextFR = "Nouveau MWQMSite"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebSubsector>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebSubsector webSubsector = (WebSubsector)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webSubsector);
        //    Assert.NotNull(webSubsector.TVItemMWQMSiteList);
        //    Assert.True(webSubsector.TVItemMWQMSiteList.Where(c => c.TVItemModel.TVItem.TVItemID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebTideDataValue_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebTideDataValue;
        //    int TVItemID = 229465;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    // need to add an address when PostTideDataValueModel is completed
        //    // replace PostTVItemModel by PostTideDataValueModel

        //    //PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    //{
        //    //    ParentTVType = TVTypeEnum.Root,
        //    //    ParentID = TVItemID,
        //    //    TVItemID = 0, // 0 == add, > 0 == change
        //    //    TVType = TVTypeEnum.Country,
        //    //    TVTextEN = "New Country",
        //    //    TVTextFR = "Nouveau Country"
        //    //};

        //    //var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    //Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    //Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    //bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    //Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebTideDataValue>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebTideDataValue webTideDataValue = (WebTideDataValue)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webTideDataValue);
        //    Assert.NotNull(webTideDataValue.TideDataValueList);
        //    Assert.True(webTideDataValue.TideDataValueList.Where(c => c.TideDataValueID < 0).Any());
        //}
        //[Theory]
        //[InlineData("en-CA")]
        ////[InlineData("fr-CA")]
        //public async Task CreateGzFileLocalService_CreateGzFileLocal_WebTideSite_Good_Test(string culture)
        //{
        //    Assert.True(await Setup(culture));

        //    WebTypeEnum webType = WebTypeEnum.WebTideSite;
        //    int TVItemID = 7;
        //    WebTypeYearEnum webTypeYear = WebTypeYearEnum.Year1980;

        //    PostTVItemModel postTVItemModel = new PostTVItemModel()
        //    {
        //        ParentTVType = TVTypeEnum.Province,
        //        ParentID = TVItemID,
        //        TVItemID = 0, // 0 == add, > 0 == change
        //        TVType = TVTypeEnum.TideSite,
        //        TVTextEN = "New TideSite",
        //        TVTextFR = "Nouveau TideSite"
        //    };

        //    var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModifyLocal(postTVItemModel);
        //    Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
        //    bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
        //    Assert.True(boolRet);

        //    // Create gz
        //    var actionRes = await CreateGzFileLocalService.CreateGzFileLocal(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes.Result).Value);
        //    Assert.True((bool)((OkObjectResult)actionRes.Result).Value);

        //    // Read gz
        //    var actionRes2 = await ReadGzFileService.ReadJSON<WebTideSite>(webType, TVItemID, webTypeYear);
        //    Assert.Equal(200, ((ObjectResult)actionRes2.Result).StatusCode);
        //    Assert.NotNull(((OkObjectResult)actionRes2.Result).Value);
        //    WebTideSite webTideSite = (WebTideSite)((OkObjectResult)actionRes2.Result).Value;
        //    Assert.NotNull(webTideSite);
        //    Assert.NotNull(webTideSite.TideSiteList);
        //    Assert.True(webTideSite.TideSiteList.Where(c => c.TideSiteID < 0).Any());
        //}
        #endregion Tests 

        #region Functions private
        #endregion Functions private
    }
}
