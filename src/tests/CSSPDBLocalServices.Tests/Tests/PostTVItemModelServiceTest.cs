/* 
 *  Manually Edited
 *  
 */

using CSSPEnums;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;
using System.ComponentModel.DataAnnotations;
using CSSPCultureServices.Resources;
using LoggedInServices;
using CSSPDBModels;
using ReadGzFileServices;
using CSSPScrambleServices;
using DownloadFileServices;
using CSSPDBFilesManagementServices;
using CSSPDBPreferenceServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc.Formatters;
using CSSPDBPreferenceModels;
using CSSPDBFilesManagementModels;
using CreateGzFileLocalServices;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class PostTVItemModelServiceTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IPostTVItemModelService PostTVItemModelService { get; set; }
        private IReadGzFileService ReadGzFileService { get; set; }
        private ICreateGzFileLocalService CreateGzFileLocalService { get; set; }
        private CSSPDBLocalContext dbLocalTest { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string CSSPJSONPath { get; set; }
        private string CSSPJSONPathLocal { get; set; }
        private string CSSPAzureUrl { get; set; }
        #endregion Properties

        #region Constructors
        public PostTVItemModelServiceTest()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_Tel_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 1,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Tel,
                TVTextEN = "New Tel",
                TVTextFR = "Nouveau Tel"
            };

            ReadGzFileService.webAppLoaded.WebAllTels = ReadGzFileService.GetUncompressJSON<WebAllTels>(WebTypeEnum.WebAllTels, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllTels);

            int StartCount = ReadGzFileService.webAppLoaded.WebAllTels.TVItemAllTelList.Count;
            //int StartCount2 = ReadGzFileService.webAppLoaded.WebAllTels.TelList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 1);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 1, "p1p-1", TVTypeEnum.Tel, 1, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New Tel", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau Tel", TranslationStatusEnum.Translated);

            ReadGzFileService.webAppLoaded.WebAllTels = ReadGzFileService.GetUncompressJSON<WebAllTels>(WebTypeEnum.WebAllTels, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllTels);

            int EndCount = ReadGzFileService.webAppLoaded.WebAllTels.TVItemAllTelList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebAllTels.TVItemAllTelList[EndCount - 1]);

            //int EndCount2 = ReadGzFileService.webAppLoaded.WebAllTels.TelList.Count;
            //Assert.Equal(StartCount2 + 1, EndCount2);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_Email_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 1,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Email,
                TVTextEN = "New Email",
                TVTextFR = "Nouveau Email"
            };

            ReadGzFileService.webAppLoaded.WebAllEmails = ReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllEmails);

            int StartCount = ReadGzFileService.webAppLoaded.WebAllEmails.TVItemAllEmailList.Count;
            //int StartCount2 = ReadGzFileService.webAppLoaded.WebAllEmails.EmailList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 1);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 1, "p1p-1", TVTypeEnum.Email, 1, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New Email", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau Email", TranslationStatusEnum.Translated);

            ReadGzFileService.webAppLoaded.WebAllEmails = ReadGzFileService.GetUncompressJSON<WebAllEmails>(WebTypeEnum.WebAllEmails, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllEmails);

            int EndCount = ReadGzFileService.webAppLoaded.WebAllEmails.TVItemAllEmailList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebAllEmails.TVItemAllEmailList[EndCount - 1]);

            //int EndCount2 = ReadGzFileService.webAppLoaded.WebAllEmails.EmailList.Count;
            //Assert.Equal(StartCount2 + 1, EndCount2);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_Address_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 1,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Address,
                TVTextEN = "New Address",
                TVTextFR = "Nouveau Address"
            };

            ReadGzFileService.webAppLoaded.WebAllAddresses = ReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllAddresses);

            int StartCount = ReadGzFileService.webAppLoaded.WebAllAddresses.TVItemAllAddressList.Count;
            //int StartCount2 = ReadGzFileService.webAppLoaded.WebAllAddresss.AddressList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 1);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 1, "p1p-1", TVTypeEnum.Address, 1, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New Address", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau Address", TranslationStatusEnum.Translated);

            ReadGzFileService.webAppLoaded.WebAllAddresses = ReadGzFileService.GetUncompressJSON<WebAllAddresses>(WebTypeEnum.WebAllAddresses, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllAddresses);

            int EndCount = ReadGzFileService.webAppLoaded.WebAllAddresses.TVItemAllAddressList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebAllAddresses.TVItemAllAddressList[EndCount - 1]);

            //int EndCount2 = ReadGzFileService.webAppLoaded.WebAllAddresss.AddressList.Count;
            //Assert.Equal(StartCount2 + 1, EndCount2);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_Contact_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 1,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Contact,
                TVTextEN = "New Contact",
                TVTextFR = "Nouveau Contact"
            };

            ReadGzFileService.webAppLoaded.WebAllContacts = ReadGzFileService.GetUncompressJSON<WebAllContacts>(WebTypeEnum.WebAllContacts, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllContacts);

            int StartCount = ReadGzFileService.webAppLoaded.WebAllContacts.TVItemAllContactList.Count;
            //int StartCount2 = ReadGzFileService.webAppLoaded.WebAllContacts.ContactList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 1);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 1, "p1p-1", TVTypeEnum.Contact, 1, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New Contact", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau Contact", TranslationStatusEnum.Translated);

            ReadGzFileService.webAppLoaded.WebAllContacts = ReadGzFileService.GetUncompressJSON<WebAllContacts>(WebTypeEnum.WebAllContacts, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllContacts);

            int EndCount = ReadGzFileService.webAppLoaded.WebAllContacts.TVItemAllContactList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebAllContacts.TVItemAllContactList[EndCount - 1]);

            //int EndCount2 = ReadGzFileService.webAppLoaded.WebAllContacts.ContactList.Count;
            //Assert.Equal(StartCount2 + 1, EndCount2);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_Country_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 1,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Country,
                TVTextEN = "France",    
                TVTextFR = "France (fr)"
            };

            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            int StartCount = ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList.Count;

            ReadGzFileService.webAppLoaded.WebAllCountries = ReadGzFileService.GetUncompressJSON<WebAllCountries>(WebTypeEnum.WebAllCountries, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllCountries);

            int StartCount2 = ReadGzFileService.webAppLoaded.WebAllCountries.TVItemAllCountryList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 1);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 1, "p1p-1", TVTypeEnum.Country, 1, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "France", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "France (fr)", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList[EndCount - 1]);

            ReadGzFileService.webAppLoaded.WebAllCountries = ReadGzFileService.GetUncompressJSON<WebAllCountries>(WebTypeEnum.WebAllCountries, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllCountries);

            int EndCount2 = ReadGzFileService.webAppLoaded.WebAllCountries.TVItemAllCountryList.Count;
            Assert.Equal(StartCount2 + 1, EndCount2);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebAllCountries.TVItemAllCountryList[EndCount2 - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_Province_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 5,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Province,
                TVTextEN = "New Province",
                TVTextFR = "Nouvelle Province"
            };

            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebCountry);

            int StartCount = ReadGzFileService.webAppLoaded.WebCountry.TVItemProvinceList.Count;

            ReadGzFileService.webAppLoaded.WebAllProvinces = ReadGzFileService.GetUncompressJSON<WebAllProvinces>(WebTypeEnum.WebAllProvinces, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllProvinces);

            int StartCount2 = ReadGzFileService.webAppLoaded.WebAllProvinces.TVItemAllProvinceList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebCountry);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 2);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 2, "p1p5p-1", TVTypeEnum.Province, 5, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New Province", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouvelle Province", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebCountry.TVItemProvinceList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebCountry.TVItemProvinceList[EndCount - 1]);

            ReadGzFileService.webAppLoaded.WebAllProvinces = ReadGzFileService.GetUncompressJSON<WebAllProvinces>(WebTypeEnum.WebAllProvinces, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllProvinces);

            int EndCount2 = ReadGzFileService.webAppLoaded.WebAllProvinces.TVItemAllProvinceList.Count;
            Assert.Equal(StartCount2 + 1, EndCount2);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebAllProvinces.TVItemAllProvinceList[EndCount2 - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_RainExceedance_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 5,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.RainExceedance,
                TVTextEN = "New RainExceedance",
                TVTextFR = "Nouvelle RainExceedance"
            };

            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebCountry);

            int StartCount = ReadGzFileService.webAppLoaded.WebCountry.TVItemRainExceedanceList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebCountry);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebCountry.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 2);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 2, "p1p5p-1", TVTypeEnum.RainExceedance, 5, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New RainExceedance", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouvelle RainExceedance", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebCountry.TVItemRainExceedanceList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebCountry.TVItemRainExceedanceList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_Area_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 7,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Area,
                TVTextEN = "New Area",
                TVTextFR = "Nouvelle Région"
            };

            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebProvince);

            int StartCount = ReadGzFileService.webAppLoaded.WebProvince.TVItemAreaList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebProvince);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 3);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 3, "p1p5p7p-1", TVTypeEnum.Area, 7, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New Area", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouvelle Région", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebProvince.TVItemAreaList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebProvince.TVItemAreaList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_ClimateSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 7,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.ClimateSite,
                TVTextEN = "New ClimateSite",
                TVTextFR = "Nouvelle ClimateSite"
            };

            ReadGzFileService.webAppLoaded.WebClimateSite = ReadGzFileService.GetUncompressJSON<WebClimateSite>(WebTypeEnum.WebClimateSite, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebClimateSite);

            int StartCount = ReadGzFileService.webAppLoaded.WebClimateSite.TVItemClimateSiteList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebProvince);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 3);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 3, "p1p5p7p-1", TVTypeEnum.ClimateSite, 7, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New ClimateSite", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouvelle ClimateSite", TranslationStatusEnum.Translated);

            ReadGzFileService.webAppLoaded.WebClimateSite = ReadGzFileService.GetUncompressJSON<WebClimateSite>(WebTypeEnum.WebClimateSite, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebClimateSite);

            int EndCount = ReadGzFileService.webAppLoaded.WebClimateSite.TVItemClimateSiteList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebClimateSite.TVItemClimateSiteList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_HydrometricSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 7,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.HydrometricSite,
                TVTextEN = "New HydrometricSite",
                TVTextFR = "Nouvelle HydrometricSite"
            };

            ReadGzFileService.webAppLoaded.WebHydrometricSite = ReadGzFileService.GetUncompressJSON<WebHydrometricSite>(WebTypeEnum.WebHydrometricSite, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebHydrometricSite);

            int StartCount = ReadGzFileService.webAppLoaded.WebHydrometricSite.TVItemHydrometricSiteList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebProvince);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 3);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 3, "p1p5p7p-1", TVTypeEnum.HydrometricSite, 7, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New HydrometricSite", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouvelle HydrometricSite", TranslationStatusEnum.Translated);

            ReadGzFileService.webAppLoaded.WebHydrometricSite = ReadGzFileService.GetUncompressJSON<WebHydrometricSite>(WebTypeEnum.WebHydrometricSite, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebHydrometricSite);

            int EndCount = ReadGzFileService.webAppLoaded.WebHydrometricSite.TVItemHydrometricSiteList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebHydrometricSite.TVItemHydrometricSiteList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_Sector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 629,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Sector,
                TVTextEN = "New Sector",
                TVTextFR = "Nouveau Secteur"
            };

            ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebArea);

            int StartCount = ReadGzFileService.webAppLoaded.WebArea.TVItemSectorList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebArea);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebArea.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 4);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 4, "p1p5p7p629p-1", TVTypeEnum.Sector, 629, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New Sector", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau Secteur", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebArea.TVItemSectorList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebArea.TVItemSectorList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_Subsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 633,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Subsector,
                TVTextEN = "New Subsector",
                TVTextFR = "Nouveau Sous-secteur"
            };

            ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSector);

            int StartCount = ReadGzFileService.webAppLoaded.WebSector.TVItemSubsectorList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSector);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebSector.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 5);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 5, "p1p5p7p629p633p-1", TVTypeEnum.Subsector, 633, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New Subsector", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau Sous-secteur", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebSector.TVItemSubsectorList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebSector.TVItemSubsectorList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_PolSourceSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 635,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.PolSourceSite,
                TVTextEN = "New PolSourceSite",
                TVTextFR = "Nouvelle PolSourceSite"
            };

            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSubsector);

            int StartCount = ReadGzFileService.webAppLoaded.WebSubsector.TVItemPolSourceSiteList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSubsector);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 6);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 6, "p1p5p7p629p633p635p-1", TVTypeEnum.PolSourceSite, 635, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New PolSourceSite", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouvelle PolSourceSite", TranslationStatusEnum.Translated);

            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSubsector);

            int EndCount = ReadGzFileService.webAppLoaded.WebSubsector.TVItemPolSourceSiteList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebSubsector.TVItemPolSourceSiteList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_MWQMSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 635,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.MWQMSite,
                TVTextEN = "New MWQM Site",
                TVTextFR = "Nouveau PCCSM Site"
            };

            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSubsector);

            int StartCount = ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMSiteList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSubsector);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 6);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 6, "p1p5p7p629p633p635p-1", TVTypeEnum.MWQMSite, 635, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New MWQM Site", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau PCCSM Site", TranslationStatusEnum.Translated);

            //ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            //Assert.NotNull(ReadGzFileService.webAppLoaded.WebSubsector);

            int EndCount = ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMSiteList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMSiteList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_MWQMRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 635,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.MWQMRun,
                TVTextEN = "New MWQM Run",
                TVTextFR = "Nouveau PCCSM Rondonnée"
            };

            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSubsector);

            int StartCount = ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMRunList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSubsector);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 6);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 6, "p1p5p7p629p633p635p-1", TVTypeEnum.MWQMRun, 635, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New MWQM Run", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau PCCSM Rondonnée", TranslationStatusEnum.Translated);

            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSubsector);

            int EndCount = ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMRunList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebSubsector.TVItemMWQMRunList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_Classification_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 635,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Classification,
                TVTextEN = "New Classification",
                TVTextFR = "Nouveau Classification"
            };

            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSubsector);

            int StartCount = ReadGzFileService.webAppLoaded.WebSubsector.TVItemClassificationList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSubsector);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebSubsector.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 6);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 6, "p1p5p7p629p633p635p-1", TVTypeEnum.Classification, 635, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New Classification", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau Classification", TranslationStatusEnum.Translated);

            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSubsector);

            int EndCount = ReadGzFileService.webAppLoaded.WebSubsector.TVItemClassificationList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebSubsector.TVItemClassificationList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_Municipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 7,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Municipality,
                TVTextEN = "New Municipality",
                TVTextFR = "Nouvelle Municipalité"
            };

            ReadGzFileService.webAppLoaded.WebMunicipalities = ReadGzFileService.GetUncompressJSON<WebMunicipalities>(WebTypeEnum.WebMunicipalities, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMunicipalities);

            int StartCount = ReadGzFileService.webAppLoaded.WebMunicipalities.TVItemMunicipalityList.Count;

            ReadGzFileService.webAppLoaded.WebAllMunicipalities = ReadGzFileService.GetUncompressJSON<WebAllMunicipalities>(WebTypeEnum.WebAllMunicipalities, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllMunicipalities);

            int StartCount2 = ReadGzFileService.webAppLoaded.WebAllMunicipalities.TVItemAllMunicipalityList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebProvince);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebProvince.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 3);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 3, "p1p5p7p-1", TVTypeEnum.Municipality, 7, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New Municipality", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouvelle Municipalité", TranslationStatusEnum.Translated);

            ReadGzFileService.webAppLoaded.WebMunicipalities = ReadGzFileService.GetUncompressJSON<WebMunicipalities>(WebTypeEnum.WebMunicipalities, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMunicipalities);

            int EndCount = ReadGzFileService.webAppLoaded.WebMunicipalities.TVItemMunicipalityList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebMunicipalities.TVItemMunicipalityList[EndCount - 1]);

            ReadGzFileService.webAppLoaded.WebAllMunicipalities = ReadGzFileService.GetUncompressJSON<WebAllMunicipalities>(WebTypeEnum.WebAllMunicipalities, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebAllMunicipalities);

            int EndCount2 = ReadGzFileService.webAppLoaded.WebAllMunicipalities.TVItemAllMunicipalityList.Count;
            Assert.Equal(StartCount2 + 1, EndCount2);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebAllMunicipalities.TVItemAllMunicipalityList[EndCount2 - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_MikeScenario_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 27764,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.MikeScenario,
                TVTextEN = "New MikeScenario",
                TVTextFR = "Nouveau MikeScenario"
            };

            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMunicipality);

            int StartCount = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemMikeScenarioList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMunicipality);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 4);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 4, "p1p5p7p27764p-1", TVTypeEnum.MikeScenario, 27764, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New MikeScenario", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau MikeScenario", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemMikeScenarioList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebMunicipality.TVItemMikeScenarioList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_MikeSource_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 28475,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.MikeSource,
                TVTextEN = "New MikeSource",
                TVTextFR = "Nouveau MikeSource"
            };

            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMikeScenario);

            int StartCount = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeSourceList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMikeScenario);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 5);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 5, "p1p5p7p27764p28475p-1", TVTypeEnum.MikeSource, 28475, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New MikeSource", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau MikeSource", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeSourceList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeSourceList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_MikeBoundaryConditionMesh_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 28475,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.MikeBoundaryConditionMesh,
                TVTextEN = "New MikeBoundaryConditionMesh",
                TVTextFR = "Nouveau MikeBoundaryConditionMesh"
            };

            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMikeScenario);

            int StartCount = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeBoundaryConditionMeshList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMikeScenario);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 5);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 5, "p1p5p7p27764p28475p-1", TVTypeEnum.MikeBoundaryConditionMesh, 28475, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New MikeBoundaryConditionMesh", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau MikeBoundaryConditionMesh", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeBoundaryConditionMeshList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeBoundaryConditionMeshList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_MikeBoundaryConditionWebTide_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 28475,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.MikeBoundaryConditionWebTide,
                TVTextEN = "New MikeBoundaryConditionWebTide",
                TVTextFR = "Nouveau MikeBoundaryConditionWebTide"
            };

            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMikeScenario);

            int StartCount = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeBoundaryConditionWebTideList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMikeScenario);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 5);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 5, "p1p5p7p27764p28475p-1", TVTypeEnum.MikeBoundaryConditionWebTide, 28475, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New MikeBoundaryConditionWebTide", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau MikeBoundaryConditionWebTide", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeBoundaryConditionWebTideList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemMikeBoundaryConditionWebTideList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_Infrastructure_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 27764,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Infrastructure,
                TVTextEN = "New Infrastructure",
                TVTextFR = "Nouveau Infrastructure"
            };

            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMunicipality);

            int StartCount = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemInfrastructureList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMunicipality);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 4);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 4, "p1p5p7p27764p-1", TVTypeEnum.Infrastructure, 27764, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New Infrastructure", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau Infrastructure", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemInfrastructureList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebMunicipality.TVItemInfrastructureList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Add_Country_Than_Change_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 1,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Country,
                TVTextEN = "France",
                TVTextFR = "France (fr)"
            };

            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            int StartCount = ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 1);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 1, "p1p-1", TVTypeEnum.Country, 1, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "France", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "France (fr)", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList[EndCount - 1]);

            // Change on Create and change on item already in DBLocal
            postTVItemModel = new PostTVItemModel()
            {
                ParentID = 1,
                TVItemID = -1, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Country,
                TVTextEN = "France2",
                TVTextFR = "France (fr)2"
            };

            // Just change so same number of Country
            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            int StartCount2 = ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList.Count;

            actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 1);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 1, "p1p-1", TVTypeEnum.Country, 1, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "France2", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "France (fr)2", TranslationStatusEnum.Translated);

            EndCount = ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList.Count;
            Assert.Equal(StartCount2, EndCount);
            CompareWebItem(postTVItemModel, ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList[EndCount - 1]);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Modify_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // this will try to add a new TVItem with its TVItemLanguage (EN, FR)
            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentID = 1,
                TVItemID = 5, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Country,
                TVTextEN = "Renamed Canada",
                TVTextFR = "Canada"
            };

            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            int StartCount = ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 1);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(5, DBCommandEnum.Original, 1, "p1p5", TVTypeEnum.Country, 1, true);
            CompareTVItemLanguageAddInDB(9, DBCommandEnum.Modified, 5, LanguageEnum.en, "Renamed Canada", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(10, DBCommandEnum.Original, 5, LanguageEnum.fr, "Canada", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList.Count;
            Assert.Equal(StartCount, EndCount);

            // Change on changes and change on item already in DBLocal
            postTVItemModel = new PostTVItemModel()
            {
                ParentID = 1,
                TVItemID = 5, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Country,
                TVTextEN = "Renamed2 Canada",
                TVTextFR = "Renomé Canada"
            };

            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            int StartCount2 = ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList.Count;

            actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            tvItemParentList = ReadGzFileService.webAppLoaded.WebRoot.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 1);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(5, DBCommandEnum.Original, 1, "p1p5", TVTypeEnum.Country, 1, true);
            CompareTVItemLanguageAddInDB(9, DBCommandEnum.Modified, 5, LanguageEnum.en, "Renamed2 Canada", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(10, DBCommandEnum.Modified, 5, LanguageEnum.fr, "Renomé Canada", TranslationStatusEnum.Translated);

            EndCount = ReadGzFileService.webAppLoaded.WebRoot.TVItemCountryList.Count;
            Assert.Equal(StartCount2, EndCount);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Missing_ParentID_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // this will try to add a new TVItem with its TVItemLanguage (EN, FR)
            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                //ParentID = 1,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.Country,
                TVTextEN = "France",
                TVTextFR = "France (fr)"
            };

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "ParentID"))).Any());

            List<TVItem> tvItemList = (from c in dbLocalTest.TVItems
                                       orderby c.TVItemID
                                       select c).ToList();

            Assert.True(tvItemList.Count == 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PostTVItemModel_AddOrModify_Missing_Variables_Error_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // this will try to add a new TVItem with its TVItemLanguage (EN, FR)
            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                //ParentID = 1,
                TVItemID = 0, // 0 == add, > 0 == change
                //TVType = TVTypeEnum.Country,
                //TVTextEN = "France",
                //TVTextFR = "France (fr)"
            };

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(400, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value);
            var validationResultList = ((BadRequestObjectResult)actionPostTVItemModelRes.Result).Value;
            List<ValidationResult> vrList = ((IEnumerable<ValidationResult>)validationResultList).ToList();
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "ParentID"))).Any());
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVType"))).Any());
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextEN"))).Any());
            Assert.True(vrList.Where(c => c.ErrorMessage.Contains(string.Format(CSSPCultureServicesRes._IsRequired, "TVTextFR"))).Any());

            List<TVItem> tvItemList = (from c in dbLocalTest.TVItems
                                       orderby c.TVItemID
                                       select c).ToList();

            Assert.True(tvItemList.Count == 0);
        }
        #endregion Tests Generated

        #region Functions private
        private void CompareTVItemAddInDB(int TVItemID, DBCommandEnum DBCommand, int TVLevel, string TVPath, TVTypeEnum TVType, int ParentID, bool IsActive)
        {
            TVItem tvItem = (from c in dbLocalTest.TVItems
                             where c.TVItemID == TVItemID
                             select c).FirstOrDefault();

            Assert.Equal(TVItemID, tvItem.TVItemID);
            Assert.Equal(DBCommand, tvItem.DBCommand);
            Assert.Equal(TVLevel, tvItem.TVLevel);
            Assert.Equal(TVPath, tvItem.TVPath);
            Assert.Equal(TVType, tvItem.TVType);
            Assert.Equal(ParentID, tvItem.ParentID);
            Assert.Equal(IsActive, tvItem.IsActive);
            Assert.True(tvItem.LastUpdateDate_UTC.Year > 1979);
            Assert.True(tvItem.LastUpdateContactTVItemID > 0);

        }
        private void CompareTVItemLanguageAddInDB(int TVItemLanguageID, DBCommandEnum DBCommand, int TVItemID, LanguageEnum Language, string TVText, TranslationStatusEnum TranslationStatus)
        {
            TVItemLanguage tvItemLanguage = new TVItemLanguage();

            tvItemLanguage = (from c in dbLocalTest.TVItemLanguages
                              where c.TVItemLanguageID == TVItemLanguageID
                              select c).FirstOrDefault();

            Assert.NotNull(tvItemLanguage);
            Assert.Equal(TVItemLanguageID, tvItemLanguage.TVItemLanguageID);
            Assert.Equal(DBCommand, tvItemLanguage.DBCommand);
            Assert.Equal(TVItemID, tvItemLanguage.TVItemID);
            Assert.Equal(Language, tvItemLanguage.Language);
            Assert.Equal(TVText, tvItemLanguage.TVText);
            Assert.Equal(TranslationStatus, tvItemLanguage.TranslationStatus);
            Assert.True(tvItemLanguage.LastUpdateDate_UTC.Year > 1979);
            Assert.True(tvItemLanguage.LastUpdateContactTVItemID > 0);
        }
        private void CompareTVItemParentListInDB(List<WebBase> tvItemParentList)
        {
            TVItem tvItem = new TVItem();
            TVItemLanguage tvItemLanguage = new TVItemLanguage();

            List<TVItem> tvItemList = (from c in dbLocalTest.TVItems
                                       orderby c.TVItemID
                                       select c).ToList();

            Assert.Equal(tvItemParentList.Count + 1, tvItemList.Count);

            foreach (WebBase webBase in tvItemParentList)
            {
                tvItem = (from c in dbLocalTest.TVItems
                          where c.TVItemID == webBase.TVItemModel.TVItem.TVItemID
                          select c).FirstOrDefault();

                Assert.NotNull(tvItem);
                Assert.Equal(webBase.TVItemModel.TVItem.TVItemID, tvItem.TVItemID);
                Assert.Equal(webBase.TVItemModel.TVItem.DBCommand, tvItem.DBCommand);
                Assert.Equal(webBase.TVItemModel.TVItem.TVLevel, tvItem.TVLevel);
                Assert.Equal(webBase.TVItemModel.TVItem.TVPath, tvItem.TVPath);
                Assert.Equal(webBase.TVItemModel.TVItem.TVType, tvItem.TVType);
                Assert.Equal(webBase.TVItemModel.TVItem.ParentID, tvItem.ParentID);
                Assert.Equal(webBase.TVItemModel.TVItem.IsActive, tvItem.IsActive);
                Assert.True(tvItem.LastUpdateDate_UTC.Year > 1979);
                Assert.True(tvItem.LastUpdateContactTVItemID > 0);


                foreach (LanguageEnum lang in new List<LanguageEnum>() { LanguageEnum.en, LanguageEnum.fr })
                {
                    tvItemLanguage = (from c in dbLocalTest.TVItemLanguages
                                      where c.TVItemID == webBase.TVItemModel.TVItem.TVItemID
                                      && c.Language == lang
                                      select c).FirstOrDefault();

                    Assert.NotNull(tvItemLanguage);
                    Assert.Equal(webBase.TVItemModel.TVItemLanguageList[(int)lang].TVItemLanguageID, tvItemLanguage.TVItemLanguageID);
                    Assert.Equal(webBase.TVItemModel.TVItemLanguageList[(int)lang].DBCommand, tvItemLanguage.DBCommand);
                    Assert.Equal(webBase.TVItemModel.TVItemLanguageList[(int)lang].TVItemID, tvItemLanguage.TVItemID);
                    Assert.Equal(webBase.TVItemModel.TVItemLanguageList[(int)lang].Language, tvItemLanguage.Language);
                    Assert.Equal(webBase.TVItemModel.TVItemLanguageList[(int)lang].TVText, tvItemLanguage.TVText);
                    Assert.Equal(webBase.TVItemModel.TVItemLanguageList[(int)lang].TranslationStatus, tvItemLanguage.TranslationStatus);
                    Assert.True(tvItemLanguage.LastUpdateDate_UTC.Year > 1979);
                    Assert.True(tvItemLanguage.LastUpdateContactTVItemID > 0);
                }
            }
        }
        private void CompareWebItem(PostTVItemModel postTVItemModel, WebBase webBase)
        {
            Assert.Equal(postTVItemModel.ParentID, webBase.TVItemModel.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVType, webBase.TVItemModel.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVTextEN, webBase.TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText);
            Assert.Equal(postTVItemModel.TVTextFR, webBase.TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText);
        }
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalservicestests.json")
               .AddUserSecrets("86d17aa8-ffaa-4834-b06c-95bdec59d59b")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            Assert.NotNull(AzureStoreCSSPJSONPath);

            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            Assert.NotNull(CSSPJSONPath);

            CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
            Assert.NotNull(CSSPJSONPathLocal);

            DirectoryInfo di = new DirectoryInfo($"{ CSSPJSONPathLocal }");
            if (di.Exists)
            {
                try
                {
                    di.Delete(true);
                    di.Create(); // creates "C:\\CSSPDesktop\\csspjsonlocaltest\\"
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }
            else
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            /* ---------------------------------------------------------------------------------
             * using Copying CSSPDBLocal To CSSPDBLocalTest
             * ---------------------------------------------------------------------------------      
             */

            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            string CSSPDBLocalTest = Configuration.GetValue<string>("CSSPDBLocalTest");
            Assert.NotNull(CSSPDBLocalTest);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);
            FileInfo fiCSSPDBLocalTest = new FileInfo(CSSPDBLocalTest);

            if (!fiCSSPDBLocal.Exists)
            {
                Assert.True(false, $"File does not exist { fiCSSPDBLocal.FullName }");
            }

            if (!fiCSSPDBLocalTest.Exists)
            {
                try
                {
                    File.Copy(fiCSSPDBLocal.FullName, fiCSSPDBLocalTest.FullName);
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            /* ---------------------------------------------------------------------------------
             * using CSSPDBLocalContext
             * ---------------------------------------------------------------------------------      
             */

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocalTest.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBFilesManagement
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBFilesManagementFileName = Configuration.GetValue<string>("CSSPDBFilesManagement");
            Assert.NotNull(CSSPDBFilesManagementFileName);

            FileInfo fiCSSPDBFilesManagementFileName = new FileInfo(CSSPDBFilesManagementFileName);

            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFilesManagementFileName.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBPreference
             * ---------------------------------------------------------------------------------
             */
            string CSSPDBPreference = Configuration.GetValue<string>("CSSPDBPreference");
            Assert.NotNull(CSSPDBPreference);

            FileInfo fiCSSPDBPreference = new FileInfo(CSSPDBPreference);

            Services.AddDbContext<CSSPDBPreferenceContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBPreference.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IScrambleService, ScrambleService>();
            Services.AddSingleton<ICSSPDBFilesManagementService, CSSPDBFilesManagementService>();
            Services.AddSingleton<IPreferenceService, PreferenceService>();
            Services.AddSingleton<IDownloadFileService, DownloadFileService>();
            Services.AddSingleton<IReadGzFileService, ReadGzFileService>();
            Services.AddSingleton<ICreateGzFileLocalService, CreateGzFileLocalService>();
            Services.AddSingleton<IPostTVItemModelService, PostTVItemModelService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            Assert.True(await LoggedInService.SetLoggedInLocalContactInfo());

            dbLocalTest = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocalTest);

            PostTVItemModelService = Provider.GetService<IPostTVItemModelService>();
            Assert.NotNull(PostTVItemModelService);

            ReadGzFileService = Provider.GetService<IReadGzFileService>();
            Assert.NotNull(ReadGzFileService);

            CreateGzFileLocalService = Provider.GetService<ICreateGzFileLocalService>();
            Assert.NotNull(CreateGzFileLocalService);

            List<string> ExistingTableList = new List<string>();

            using (var command = dbLocalTest.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
                dbLocalTest.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        ExistingTableList.Add(result.GetString(0));
                    }
                }
            }

            foreach (string tableName in ExistingTableList)
            {
                string TableIDName = "";

                if (tableName.StartsWith("AspNet") || tableName.StartsWith("DeviceCode") || tableName.StartsWith("Persisted")) continue;

                if (tableName == "Addresses")
                {
                    TableIDName = tableName.Substring(0, tableName.Length - 2) + "ID";
                }
                else
                {
                    TableIDName = tableName.Substring(0, tableName.Length - 1) + "ID";
                }

                dbLocalTest.Database.ExecuteSqlRaw($"DELETE FROM { tableName }");
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
