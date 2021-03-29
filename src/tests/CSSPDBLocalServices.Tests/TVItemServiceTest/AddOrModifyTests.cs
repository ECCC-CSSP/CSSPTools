/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class TVItemServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemService_AddOrModify_Add_Address_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Root,
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
        public async Task TVItemService_AddOrModify_Add_Area_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Province,
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
        public async Task TVItemService_AddOrModify_Add_Classification_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Subsector,
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
        public async Task TVItemService_AddOrModify_Add_ClimateSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Province,
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
        public async Task TVItemService_AddOrModify_Add_Contact_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Root,
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
        public async Task TVItemService_AddOrModify_Add_Country_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Root,
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
        public async Task TVItemService_AddOrModify_Add_Email_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Root,
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
        public async Task TVItemService_AddOrModify_Add_File_Under_Area_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Area,
                ParentID = 629,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.File,
                TVTextEN = "New File",
                TVTextFR = "Nouveau File"
            };

            ReadGzFileService.webAppLoaded.WebArea = ReadGzFileService.GetUncompressJSON<WebArea>(WebTypeEnum.WebArea, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebArea);

            int StartCount = ReadGzFileService.webAppLoaded.WebArea.TVItemFileList.Count;

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
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 4, "p1p5p7p629p-1", TVTypeEnum.File, 629, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New File", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau File", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebArea.TVItemFileList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            Assert.Equal(postTVItemModel.ParentID, ReadGzFileService.webAppLoaded.WebArea.TVItemFileList[EndCount - 1].TVItemModel.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVType, ReadGzFileService.webAppLoaded.WebArea.TVItemFileList[EndCount - 1].TVItemModel.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVTextEN, ReadGzFileService.webAppLoaded.WebArea.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText);
            Assert.Equal(postTVItemModel.TVTextFR, ReadGzFileService.webAppLoaded.WebArea.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemService_AddOrModify_Add_File_Under_Country_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Country,
                ParentID = 5,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.File,
                TVTextEN = "New File",
                TVTextFR = "Nouveau File"
            };

            ReadGzFileService.webAppLoaded.WebCountry = ReadGzFileService.GetUncompressJSON<WebCountry>(WebTypeEnum.WebCountry, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebCountry);

            int StartCount = ReadGzFileService.webAppLoaded.WebCountry.TVItemFileList.Count;

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
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 2, "p1p5p-1", TVTypeEnum.File, 5, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New File", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau File", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebCountry.TVItemFileList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            Assert.Equal(postTVItemModel.ParentID, ReadGzFileService.webAppLoaded.WebCountry.TVItemFileList[EndCount - 1].TVItemModel.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVType, ReadGzFileService.webAppLoaded.WebCountry.TVItemFileList[EndCount - 1].TVItemModel.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVTextEN, ReadGzFileService.webAppLoaded.WebCountry.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText);
            Assert.Equal(postTVItemModel.TVTextFR, ReadGzFileService.webAppLoaded.WebCountry.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemService_AddOrModify_Add_File_Under_Infrastructure_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                GrandParentTVType = TVTypeEnum.Municipality,
                GrandParentID = 27764, // Bouctouche
                ParentTVType = TVTypeEnum.Infrastructure,
                ParentID = 28689, // WWTP of Bouctouche ,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.File,
                TVTextEN = "New File",
                TVTextFR = "Nouveau File"
            };

            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMunicipality);

            InfrastructureModel infrastructureModel = ReadGzFileService.webAppLoaded.WebMunicipality.InfrastructureModelList.Where(c => c.Infrastructure.InfrastructureTVItemID == postTVItemModel.ParentID).FirstOrDefault();
            Assert.NotNull(infrastructureModel);

            int StartCount = infrastructureModel.TVItemFileList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, (int)postTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMunicipality);

            infrastructureModel = ReadGzFileService.webAppLoaded.WebMunicipality.InfrastructureModelList.Where(c => c.Infrastructure.InfrastructureTVItemID == postTVItemModel.ParentID).FirstOrDefault();
            Assert.NotNull(infrastructureModel);

            WebBase TVItemInfrastructure = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemInfrastructureList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault();
            Assert.NotNull(TVItemInfrastructure);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 4);

            tvItemParentList.Add(TVItemInfrastructure);
            Assert.True(tvItemParentList.Count == 5);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 5, "p1p5p7p27764p28689p-1", TVTypeEnum.File, 28689, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New File", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau File", TranslationStatusEnum.Translated);

            int EndCount = infrastructureModel.TVItemFileList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            Assert.Equal(postTVItemModel.ParentID, infrastructureModel.TVItemFileList[EndCount - 1].TVItemModel.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVType, infrastructureModel.TVItemFileList[EndCount - 1].TVItemModel.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVTextEN, infrastructureModel.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText);
            Assert.Equal(postTVItemModel.TVTextFR, infrastructureModel.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText);       
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemService_AddOrModify_Add_File_Under_MikeScenario_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.MikeScenario,
                ParentID = 28475,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.File,
                TVTextEN = "New File",
                TVTextFR = "Nouveau File"
            };

            ReadGzFileService.webAppLoaded.WebMikeScenario = ReadGzFileService.GetUncompressJSON<WebMikeScenario>(WebTypeEnum.WebMikeScenario, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMikeScenario);

            int StartCount = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemFileList.Count;

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
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 5, "p1p5p7p27764p28475p-1", TVTypeEnum.File, 28475, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New File", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau File", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemFileList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            Assert.Equal(postTVItemModel.ParentID, ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemFileList[EndCount - 1].TVItemModel.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVType, ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemFileList[EndCount - 1].TVItemModel.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVTextEN, ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText);
            Assert.Equal(postTVItemModel.TVTextFR, ReadGzFileService.webAppLoaded.WebMikeScenario.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemService_AddOrModify_Add_File_Under_Municipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Municipality,
                ParentID = 27764,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.File,
                TVTextEN = "New File",
                TVTextFR = "Nouveau File"
            };

            ReadGzFileService.webAppLoaded.WebMunicipality = ReadGzFileService.GetUncompressJSON<WebMunicipality>(WebTypeEnum.WebMunicipality, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMunicipality);

            int StartCount = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemFileList.Count;

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
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 4, "p1p5p7p27764p-1", TVTypeEnum.File, 27764, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New File", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau File", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebMunicipality.TVItemFileList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            Assert.Equal(postTVItemModel.ParentID, ReadGzFileService.webAppLoaded.WebMunicipality.TVItemFileList[EndCount - 1].TVItemModel.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVType, ReadGzFileService.webAppLoaded.WebMunicipality.TVItemFileList[EndCount - 1].TVItemModel.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVTextEN, ReadGzFileService.webAppLoaded.WebMunicipality.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText);
            Assert.Equal(postTVItemModel.TVTextFR, ReadGzFileService.webAppLoaded.WebMunicipality.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemService_AddOrModify_Add_File_Under_MWQMSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                GrandParentTVType = TVTypeEnum.Subsector,
                GrandParentID = 635, // Bouctouche
                ParentTVType = TVTypeEnum.MWQMSite,
                ParentID = 7460, // WWTP of Bouctouche ,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.File,
                TVTextEN = "New File",
                TVTextFR = "Nouveau File"
            };

            ReadGzFileService.webAppLoaded.WebMWQMSite = ReadGzFileService.GetUncompressJSON<WebMWQMSite>(WebTypeEnum.WebMWQMSite, (int)postTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMWQMSite);

            MWQMSiteModel MWQMSiteModel = ReadGzFileService.webAppLoaded.WebMWQMSite.MWQMSiteModelList.Where(c => c.MWQMSite.MWQMSiteTVItemID == postTVItemModel.ParentID).FirstOrDefault();
            Assert.NotNull(MWQMSiteModel);

            int StartCount = MWQMSiteModel.TVItemFileList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebMWQMSite = ReadGzFileService.GetUncompressJSON<WebMWQMSite>(WebTypeEnum.WebMWQMSite, (int)postTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebMWQMSite);

            MWQMSiteModel = ReadGzFileService.webAppLoaded.WebMWQMSite.MWQMSiteModelList.Where(c => c.MWQMSite.MWQMSiteTVItemID == postTVItemModel.ParentID).FirstOrDefault();
            Assert.NotNull(MWQMSiteModel);

            WebBase TVItemMWQMSite = ReadGzFileService.webAppLoaded.WebMWQMSite.MWQMSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault();
            Assert.NotNull(TVItemMWQMSite);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebMWQMSite.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 6);

            tvItemParentList.Add(TVItemMWQMSite);
            Assert.True(tvItemParentList.Count == 7);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 7, "p1p5p7p629p633p635p7460p-1", TVTypeEnum.File, 7460, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New File", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau File", TranslationStatusEnum.Translated);

            int EndCount = MWQMSiteModel.TVItemFileList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            Assert.Equal(postTVItemModel.ParentID, MWQMSiteModel.TVItemFileList[EndCount - 1].TVItemModel.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVType, MWQMSiteModel.TVItemFileList[EndCount - 1].TVItemModel.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVTextEN, MWQMSiteModel.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText);
            Assert.Equal(postTVItemModel.TVTextFR, MWQMSiteModel.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemService_AddOrModify_Add_File_Under_PolSourceSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                GrandParentTVType = TVTypeEnum.Subsector,
                GrandParentID = 635, // Bouctouche
                ParentTVType = TVTypeEnum.PolSourceSite,
                ParentID = 202451, // WWTP of Bouctouche ,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.File,
                TVTextEN = "New File",
                TVTextFR = "Nouveau File"
            };

            ReadGzFileService.webAppLoaded.WebPolSourceSite = ReadGzFileService.GetUncompressJSON<WebPolSourceSite>(WebTypeEnum.WebPolSourceSite, (int)postTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebPolSourceSite);

            PolSourceSiteModel PolSourceSiteModel = ReadGzFileService.webAppLoaded.WebPolSourceSite.PolSourceSiteModelList.Where(c => c.PolSourceSite.PolSourceSiteTVItemID == postTVItemModel.ParentID).FirstOrDefault();
            Assert.NotNull(PolSourceSiteModel);

            int StartCount = PolSourceSiteModel.TVItemFileList.Count;

            var actionPostTVItemModelRes = await PostTVItemModelService.AddOrModify(postTVItemModel);
            Assert.Equal(200, ((ObjectResult)actionPostTVItemModelRes.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPostTVItemModelRes.Result).Value);
            bool boolRet = (bool)((OkObjectResult)actionPostTVItemModelRes.Result).Value;
            Assert.True(boolRet);

            ReadGzFileService.webAppLoaded.WebPolSourceSite = ReadGzFileService.GetUncompressJSON<WebPolSourceSite>(WebTypeEnum.WebPolSourceSite, (int)postTVItemModel.GrandParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebPolSourceSite);

            PolSourceSiteModel = ReadGzFileService.webAppLoaded.WebPolSourceSite.PolSourceSiteModelList.Where(c => c.PolSourceSite.PolSourceSiteTVItemID == postTVItemModel.ParentID).FirstOrDefault();
            Assert.NotNull(PolSourceSiteModel);

            WebBase TVItemPolSourceSite = ReadGzFileService.webAppLoaded.WebPolSourceSite.PolSourceSiteModelList.Where(c => c.TVItemModel.TVItem.TVItemID == postTVItemModel.ParentID).FirstOrDefault();
            Assert.NotNull(TVItemPolSourceSite);

            List<WebBase> tvItemParentList = ReadGzFileService.webAppLoaded.WebPolSourceSite.TVItemParentList;
            Assert.NotNull(tvItemParentList);
            Assert.True(tvItemParentList.Count == 6);

            tvItemParentList.Add(TVItemPolSourceSite);
            Assert.True(tvItemParentList.Count == 7);

            CompareTVItemParentListInDB(tvItemParentList);
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 7, "p1p5p7p629p633p635p202451p-1", TVTypeEnum.File, 202451, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New File", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau File", TranslationStatusEnum.Translated);

            int EndCount = PolSourceSiteModel.TVItemFileList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            Assert.Equal(postTVItemModel.ParentID, PolSourceSiteModel.TVItemFileList[EndCount - 1].TVItemModel.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVType, PolSourceSiteModel.TVItemFileList[EndCount - 1].TVItemModel.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVTextEN, PolSourceSiteModel.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText);
            Assert.Equal(postTVItemModel.TVTextFR, PolSourceSiteModel.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemService_AddOrModify_Add_File_Under_Province_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Province,
                ParentID = 7,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.File,
                TVTextEN = "New File",
                TVTextFR = "Nouveau File"
            };

            ReadGzFileService.webAppLoaded.WebProvince = ReadGzFileService.GetUncompressJSON<WebProvince>(WebTypeEnum.WebProvince, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebProvince);

            int StartCount = ReadGzFileService.webAppLoaded.WebProvince.TVItemFileList.Count;

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
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 3, "p1p5p7p-1", TVTypeEnum.File, 7, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New File", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau File", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebProvince.TVItemFileList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            Assert.Equal(postTVItemModel.ParentID, ReadGzFileService.webAppLoaded.WebProvince.TVItemFileList[EndCount - 1].TVItemModel.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVType, ReadGzFileService.webAppLoaded.WebProvince.TVItemFileList[EndCount - 1].TVItemModel.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVTextEN, ReadGzFileService.webAppLoaded.WebProvince.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText);
            Assert.Equal(postTVItemModel.TVTextFR, ReadGzFileService.webAppLoaded.WebProvince.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemService_AddOrModify_Add_File_Under_Root_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Root,
                ParentID = 1,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.File,
                TVTextEN = "New File",
                TVTextFR = "Nouveau File"
            };

            ReadGzFileService.webAppLoaded.WebRoot = ReadGzFileService.GetUncompressJSON<WebRoot>(WebTypeEnum.WebRoot, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebRoot);

            int StartCount = ReadGzFileService.webAppLoaded.WebRoot.TVItemFileList.Count;

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
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 1, "p1p-1", TVTypeEnum.File, 1, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New File", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau File", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebRoot.TVItemFileList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            Assert.Equal(postTVItemModel.ParentID, ReadGzFileService.webAppLoaded.WebRoot.TVItemFileList[EndCount - 1].TVItemModel.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVType, ReadGzFileService.webAppLoaded.WebRoot.TVItemFileList[EndCount - 1].TVItemModel.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVTextEN, ReadGzFileService.webAppLoaded.WebRoot.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText);
            Assert.Equal(postTVItemModel.TVTextFR, ReadGzFileService.webAppLoaded.WebRoot.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemService_AddOrModify_Add_File_Under_Sector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Sector,
                ParentID = 633,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.File,
                TVTextEN = "New File",
                TVTextFR = "Nouveau File"
            };

            ReadGzFileService.webAppLoaded.WebSector = ReadGzFileService.GetUncompressJSON<WebSector>(WebTypeEnum.WebSector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSector);

            int StartCount = ReadGzFileService.webAppLoaded.WebSector.TVItemFileList.Count;

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
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 5, "p1p5p7p629p633p-1", TVTypeEnum.File, 633, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New File", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau File", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebSector.TVItemFileList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            Assert.Equal(postTVItemModel.ParentID, ReadGzFileService.webAppLoaded.WebSector.TVItemFileList[EndCount - 1].TVItemModel.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVType, ReadGzFileService.webAppLoaded.WebSector.TVItemFileList[EndCount - 1].TVItemModel.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVTextEN, ReadGzFileService.webAppLoaded.WebSector.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText);
            Assert.Equal(postTVItemModel.TVTextFR, ReadGzFileService.webAppLoaded.WebSector.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemService_AddOrModify_Add_File_Under_Subsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Subsector,
                ParentID = 635,
                TVItemID = 0, // 0 == add, > 0 == change
                TVType = TVTypeEnum.File,
                TVTextEN = "New File",
                TVTextFR = "Nouveau File"
            };

            ReadGzFileService.webAppLoaded.WebSubsector = ReadGzFileService.GetUncompressJSON<WebSubsector>(WebTypeEnum.WebSubsector, postTVItemModel.ParentID, WebTypeYearEnum.Year1980).GetAwaiter().GetResult();
            Assert.NotNull(ReadGzFileService.webAppLoaded.WebSubsector);

            int StartCount = ReadGzFileService.webAppLoaded.WebSubsector.TVItemFileList.Count;

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
            CompareTVItemAddInDB(-1, DBCommandEnum.Created, 6, "p1p5p7p629p633p635p-1", TVTypeEnum.File, 635, true);
            CompareTVItemLanguageAddInDB(-1, DBCommandEnum.Created, -1, LanguageEnum.en, "New File", TranslationStatusEnum.Translated);
            CompareTVItemLanguageAddInDB(-2, DBCommandEnum.Created, -1, LanguageEnum.fr, "Nouveau File", TranslationStatusEnum.Translated);

            int EndCount = ReadGzFileService.webAppLoaded.WebSubsector.TVItemFileList.Count;
            Assert.Equal(StartCount + 1, EndCount);
            Assert.Equal(postTVItemModel.ParentID, ReadGzFileService.webAppLoaded.WebSubsector.TVItemFileList[EndCount - 1].TVItemModel.TVItem.ParentID);
            Assert.Equal(postTVItemModel.TVType, ReadGzFileService.webAppLoaded.WebSubsector.TVItemFileList[EndCount - 1].TVItemModel.TVItem.TVType);
            Assert.Equal(postTVItemModel.TVTextEN, ReadGzFileService.webAppLoaded.WebSubsector.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.en].TVText);
            Assert.Equal(postTVItemModel.TVTextFR, ReadGzFileService.webAppLoaded.WebSubsector.TVItemFileList[EndCount - 1].TVItemModel.TVItemLanguageList[(int)LanguageEnum.fr].TVText);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemService_AddOrModify_Add_HydrometricSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Province,
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
        public async Task TVItemService_AddOrModify_Add_Infrastructure_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Municipality,
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
        public async Task TVItemService_AddOrModify_Add_MikeBoundaryConditionMesh_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.MikeScenario,
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
        public async Task TVItemService_AddOrModify_Add_MikeBoundaryConditionWebTide_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.MikeScenario,
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
        public async Task TVItemService_AddOrModify_Add_MikeScenario_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Municipality,
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
        public async Task TVItemService_AddOrModify_Add_MikeSource_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.MikeScenario,
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
        public async Task TVItemService_AddOrModify_Add_Municipality_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Province,
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
        public async Task TVItemService_AddOrModify_Add_MWQMRun_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Subsector,
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
        public async Task TVItemService_AddOrModify_Add_MWQMSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Subsector,
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
        public async Task TVItemService_AddOrModify_Add_PolSourceSite_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Subsector,
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
        public async Task TVItemService_AddOrModify_Add_Province_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Country,
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
        public async Task TVItemService_AddOrModify_Add_RainExceedance_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Country,
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
        public async Task TVItemService_AddOrModify_Add_Sector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Area,
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
        public async Task TVItemService_AddOrModify_Add_Subsector_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Sector,
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
        public async Task TVItemService_AddOrModify_Add_Tel_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Root,
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
        public async Task TVItemService_AddOrModify_Add_Country_Than_Change_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Root,
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
                ParentTVType = TVTypeEnum.Root,
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
        public async Task TVItemService_AddOrModify_Modify_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            // this will try to add a new TVItem with its TVItemLanguage (EN, FR)
            PostTVItemModel postTVItemModel = new PostTVItemModel()
            {
                ParentTVType = TVTypeEnum.Root,
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
                ParentTVType = TVTypeEnum.Root,
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
        public async Task TVItemService_AddOrModify_Missing_ParentID_Error_Test(string culture)
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

            List<TVItem> tvItemList = (from c in dbLocal.TVItems
                                       orderby c.TVItemID
                                       select c).ToList();

            Assert.True(tvItemList.Count == 0);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemService_AddOrModify_Missing_Variables_Error_Test(string culture)
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

            List<TVItem> tvItemList = (from c in dbLocal.TVItems
                                       orderby c.TVItemID
                                       select c).ToList();

            Assert.True(tvItemList.Count == 0);
        }
    }
}
