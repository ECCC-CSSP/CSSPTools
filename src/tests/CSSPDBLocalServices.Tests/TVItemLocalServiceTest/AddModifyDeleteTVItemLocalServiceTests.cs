/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, false));

            Assert.NotNull(db);
            Assert.NotNull(dbLocal);
            Assert.NotNull(dbManage);
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(LoggedInService);
            Assert.NotNull(LoggedInService.LoggedInContactInfo.LoggedInContact);
            Assert.NotNull(FileService);
            Assert.NotNull(ManageFileService);
            Assert.NotNull(CreateGzFileService);
            Assert.NotNull(ReadGzFileService);
            Assert.NotNull(AppTaskLocalService);
            Assert.NotNull(TVItemLocalService);
            Assert.NotNull(CSSPSQLiteService);

        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_File_Under_Area_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            await CreateCSSPDBLocal();

            int TVItemID = -1;
            int ParentTVItemID = 629;
            string TVTextEN = "New File 1";
            string TVTextFR = "Nouveau File 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebArea;
            TVTypeEnum tvType = TVTypeEnum.File;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed File 1";
            TVTextFR = "Changé File 1";

            await DoModifyFileTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webTypeParent, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_File_Under_Country_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 5;
            string TVTextEN = "New File 1";
            string TVTextFR = "Nouveau File 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebCountry;
            WebTypeEnum webType = WebTypeEnum.WebCountry;
            TVTypeEnum tvType = TVTypeEnum.File;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed File 1";
            TVTextFR = "Changé File 1";

            await DoModifyFileTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_File_Under_Province_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 7;
            string TVTextEN = "New File 1";
            string TVTextFR = "Nouveau File 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebProvince;
            WebTypeEnum webType = WebTypeEnum.WebProvince;
            TVTypeEnum tvType = TVTypeEnum.File;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed File 1";
            TVTextFR = "Changé File 1";

            await DoModifyFileTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_File_Under_Root_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 1;
            string TVTextEN = "New File 1";
            string TVTextFR = "Nouveau File 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebRoot;
            WebTypeEnum webType = WebTypeEnum.WebRoot;
            TVTypeEnum tvType = TVTypeEnum.File;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed File 1";
            TVTextFR = "Changé File 1";

            await DoModifyFileTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_File_Under_Sector_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 633;
            string TVTextEN = "New File 1";
            string TVTextFR = "Nouveau File 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebSector;
            WebTypeEnum webType = WebTypeEnum.WebSector;
            TVTypeEnum tvType = TVTypeEnum.File;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed File 1";
            TVTextFR = "Changé File 1";

            await DoModifyFileTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_File_Under_Subsector_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 635;
            string TVTextEN = "New File 1";
            string TVTextFR = "Nouveau File 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebSubsector;
            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            TVTypeEnum tvType = TVTypeEnum.File;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed File 1";
            TVTextFR = "Changé File 1";

            await DoModifyFileTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_File_Under_Infrastructure_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 28689;
            string TVTextEN = "New File 1";
            string TVTextFR = "Nouveau File 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebMunicipality;
            //TVTypeEnum tvTypeParent = TVTypeEnum.Infrastructure;
            TVTypeEnum tvType = TVTypeEnum.File;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed File 1";
            TVTextFR = "Changé File 1";

            //await DoModifyChildFileTest(TVItemID, ParentTVItemID, GrandParentTVItemID, webTypeGrandParent, tvTypeParent, tvType, TVTextEN, TVTextFR);
            //await CheckChildTVItemAndChildTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, GrandParentTVItemID, webTypeGrandParent, tvTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            //await CheckTVItemParentListExistInDBAndFilesExist(GrandParentTVItemID, webTypeGrandParent);

            //await DoDeleteChildFileTest(TVItemID, ParentTVItemID, GrandParentTVItemID, webTypeGrandParent, tvTypeParent, tvType);
            //await CheckChildTVItemAndChildTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, GrandParentTVItemID, webTypeGrandParent, tvTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            //await CheckTVItemParentListExistInDBAndFilesExist(GrandParentTVItemID, webTypeGrandParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_File_Under_MWQMSite_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            //int TVItemID = -1;
            //int ParentTVItemID = 7429;
            //int GrandParentTVItemID = 635;
            //string TVTextEN = "New File 1";
            //string TVTextFR = "Nouveau File 1";
            //WebTypeEnum webTypeGrandParent = WebTypeEnum.WebSubsector;
            //TVTypeEnum tvTypeParent = TVTypeEnum.MWQMSite;
            //TVTypeEnum tvType = TVTypeEnum.File;

            //await DoAddChildFileTest(GrandParentTVItemID, ParentTVItemID, webTypeGrandParent, tvTypeParent, tvType, TVTextEN, TVTextFR);
            //await CheckChildTVItemAndChildTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, GrandParentTVItemID, webTypeGrandParent, tvTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            //await CheckTVItemParentListExistInDBAndFilesExist(GrandParentTVItemID, webTypeGrandParent);

            //TVTextEN = "Changed File 1";
            //TVTextFR = "Changé File 1";

            //await DoModifyChildFileTest(TVItemID, ParentTVItemID, GrandParentTVItemID, webTypeGrandParent, tvTypeParent, tvType, TVTextEN, TVTextFR);
            //await CheckChildTVItemAndChildTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, GrandParentTVItemID, webTypeGrandParent, tvTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            //await CheckTVItemParentListExistInDBAndFilesExist(GrandParentTVItemID, webTypeGrandParent);

            //await DoDeleteChildFileTest(TVItemID, ParentTVItemID, GrandParentTVItemID, webTypeGrandParent, tvTypeParent, tvType);
            //await CheckChildTVItemAndChildTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, GrandParentTVItemID, webTypeGrandParent, tvTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            //await CheckTVItemParentListExistInDBAndFilesExist(GrandParentTVItemID, webTypeGrandParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Address_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 1;
            string TVTextEN = "New Address 1";
            string TVTextFR = "Nouveau Address 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebRoot;
            //WebTypeEnum webTypeParent2 = WebTypeEnum.WebAllAddresses;
            WebTypeEnum webType = WebTypeEnum.WebAllAddresses;
            TVTypeEnum tvType = TVTypeEnum.Address;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);

            TVTextEN = "Changed Address 1";
            TVTextFR = "Changé Address 1";

            await DoModifyTest(TVItemID, webType, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);

            await DoModifyTest(TVItemID, webType, tvType, TVTextEN, TVTextFR);
            //await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent2, tvType);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Contact_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 1;
            string TVTextEN = "New Contact 1";
            string TVTextFR = "Nouveau Contact 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebRoot;
            WebTypeEnum webTypeParent2 = WebTypeEnum.WebAllContacts;
            WebTypeEnum webType = WebTypeEnum.WebAllContacts;
            TVTypeEnum tvType = TVTypeEnum.Contact;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);

            TVTextEN = "Changed Contact 1";
            TVTextFR = "Changé Contact 1";

            await DoModifyChildAllTest(TVItemID, ParentTVItemID, webType, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent2, tvType);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Country_Add_Modify_Delete_Good_Test2(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 1;
            string TVTextEN = "New Country 1";
            string TVTextFR = "Nouveau Country 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebRoot;
            WebTypeEnum webTypeParent2 = WebTypeEnum.WebAllCountries;
            WebTypeEnum webType = WebTypeEnum.WebAllCountries;
            TVTypeEnum tvType = TVTypeEnum.Country;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);

            TVTextEN = "Changed Country 1";
            TVTextFR = "Changé Country 1";

            await DoModifyChildAllTest(TVItemID, ParentTVItemID, webType, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent2, tvType);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Email_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 1;
            string TVTextEN = "New Email 1";
            string TVTextFR = "Nouveau Email 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebRoot;
            WebTypeEnum webTypeParent2 = WebTypeEnum.WebAllEmails;
            WebTypeEnum webType = WebTypeEnum.WebAllEmails;
            TVTypeEnum tvType = TVTypeEnum.Email;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);

            TVTextEN = "Changed Email 1";
            TVTextFR = "Changé Email 1";

            await DoModifyChildAllTest(TVItemID, ParentTVItemID, webType, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent2, tvType);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Tel_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 1;
            string TVTextEN = "New Tel 1";
            string TVTextFR = "Nouveau Tel 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebRoot;
            WebTypeEnum webTypeParent2 = WebTypeEnum.WebAllTels;
            WebTypeEnum webType = WebTypeEnum.WebAllTels;
            TVTypeEnum tvType = TVTypeEnum.Tel;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);

            TVTextEN = "Changed Tel 1";
            TVTextFR = "Changé Tel 1";

            await DoModifyChildAllTest(TVItemID, ParentTVItemID, webType, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent2, tvType);
            await CheckTVItemAndTVItemLanguageForAll(TVItemID, ParentTVItemID, webType, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Area_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 7;
            string TVTextEN = "New Area 1";
            string TVTextFR = "Nouveau Area 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebProvince;
            WebTypeEnum webType = WebTypeEnum.WebArea;
            TVTypeEnum tvType = TVTypeEnum.Area;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);

            TVTextEN = "Changed Area 1";
            TVTextFR = "Changé Area 1";

            await DoModifyTest(TVItemID, webType, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Classification_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 635;
            string TVTextEN = "New Classification 1";
            string TVTextFR = "Nouveau Classificaiton 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebSubsector;
            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            TVTypeEnum tvType = TVTypeEnum.Classification;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed Classification 1";
            TVTextFR = "Changé Classification 1";

            await DoModifyChildTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_ClimateSite_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 7;
            string TVTextEN = "New Climate Site 1";
            string TVTextFR = "Nouveau Climate Site 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebProvince;
            WebTypeEnum webTypeParent2 = WebTypeEnum.WebClimateSites;
            WebTypeEnum webType = WebTypeEnum.WebClimateSites;
            //WebTypeEnum webTypeParent3 = WebTypeEnum.WebClimateDataValue;
            TVTypeEnum tvType = TVTypeEnum.ClimateSite;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent2, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            //await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webTypeParent3);

            TVTextEN = "Changed Climate Site 1";
            TVTextFR = "Changé Climate Site 1";

            await DoModifyChildTest(TVItemID, ParentTVItemID, webTypeParent2, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent2, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent2);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent2, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent2, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent2);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Country_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 1;
            string TVTextEN = "New Country 1";
            string TVTextFR = "Nouveau Country 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebRoot;
            WebTypeEnum webType = WebTypeEnum.WebCountry;
            TVTypeEnum tvType = TVTypeEnum.Country;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);

            TVTextEN = "Changed Country 1";
            TVTextFR = "Changé Country 1";

            await DoModifyTest(TVItemID, webType, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_HydrometricSite_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 7;
            string TVTextEN = "New Hydrometric Site 1";
            string TVTextFR = "Nouveau Hydrometric Site 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebProvince;
            WebTypeEnum webTypeParent2 = WebTypeEnum.WebHydrometricSites;
            WebTypeEnum webType = WebTypeEnum.WebHydrometricSites;
            //WebTypeEnum webTypeParent3 = WebTypeEnum.WebHydrometricDataValue;
            TVTypeEnum tvType = TVTypeEnum.HydrometricSite;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent2, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            //await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webTypeParent3);

            TVTextEN = "Changed Hydrometric Site 1";
            TVTextFR = "Changé Hydrometric Site 1";

            await DoModifyChildTest(TVItemID, ParentTVItemID, webTypeParent2, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent2, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent2);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent2, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent2, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent2);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Infrastructure_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 27764;
            string TVTextEN = "New Infrastructure 1";
            string TVTextFR = "Nouveau Infrastructure 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebMunicipality;
            WebTypeEnum webType = WebTypeEnum.WebMunicipality;
            TVTypeEnum tvType = TVTypeEnum.Infrastructure;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed Infrastructure 1";
            TVTextFR = "Changé Infrastructure 1";

            await DoModifyChildTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_MikeBoundaryConditionMesh_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 28475;
            string TVTextEN = "New Mike Boundary Condition Mesh 1";
            string TVTextFR = "Nouveau Mike Boundary Condition Mesh 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebMikeScenarios;
            WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;
            TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionMesh;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed Mike Boundary Condition Mesh 1";
            TVTextFR = "Changé Mike Boundary Condition Mesh 1";

            await DoModifyChildTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_MikeBoundaryConditionWebTide_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 28475;
            string TVTextEN = "New Mike Boundary Condition Web Tide 1";
            string TVTextFR = "Nouveau Mike Boundary Condition Web Tide 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebMikeScenarios;
            WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;
            TVTypeEnum tvType = TVTypeEnum.MikeBoundaryConditionMesh;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed Mike Boundary Condition Web Tide 1";
            TVTextFR = "Changé Mike Boundary Condition Web Tide 1";

            await DoModifyChildTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_MikeScenario_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 27764;
            string TVTextEN = "New Mike Scenario 1";
            string TVTextFR = "Nouveau Mike Scenario 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebMunicipality;
            WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;
            TVTypeEnum tvType = TVTypeEnum.MikeScenario;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);

            TVTextEN = "Changed Mike Scenario 1";
            TVTextFR = "Changé Mike Scenario 1";

            await DoModifyTest(TVItemID, webType, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_MikeSource_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 28475;
            string TVTextEN = "New Mike Source 1";
            string TVTextFR = "Nouveau Mike Source 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebMikeScenarios;
            WebTypeEnum webType = WebTypeEnum.WebMikeScenarios;
            TVTypeEnum tvType = TVTypeEnum.MikeSource;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed Mike Source 1";
            TVTextFR = "Changé Mike Source 1";

            await DoModifyChildTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_MWQMRun_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 635;
            string TVTextEN = "New MWQM Run 1";
            string TVTextFR = "Nouveau MWQM Run 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebSubsector;
            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            TVTypeEnum tvType = TVTypeEnum.MWQMRun;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed MWQM Run 1";
            TVTextFR = "Changé MWQM Run 1";

            await DoModifyChildTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_MWQMSite_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 635;
            string TVTextEN = "New MWQM Site 1";
            string TVTextFR = "Nouveau MWQM Site 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebSubsector;
            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            TVTypeEnum tvType = TVTypeEnum.MWQMSite;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed MWQM Site 1";
            TVTextFR = "Changé MWQM Site 1";

            await DoModifyChildTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_PolSourceSite_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 635;
            string TVTextEN = "New Pollution Source Site 1";
            string TVTextFR = "Nouveau Pollution Source Site 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebSubsector;
            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            TVTypeEnum tvType = TVTypeEnum.PolSourceSite;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed Pollution Source Site 1";
            TVTextFR = "Changé Pollution Source Site 1";

            await DoModifyChildTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Province_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 5;
            string TVTextEN = "New Province 1";
            string TVTextFR = "Nouveau Province 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebCountry;
            WebTypeEnum webType = WebTypeEnum.WebProvince;
            TVTypeEnum tvType = TVTypeEnum.Province;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);

            TVTextEN = "Changed Province 1";
            TVTextFR = "Changé Province 1";

            await DoModifyTest(TVItemID, webType, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_RainExceedance_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 5;
            string TVTextEN = "New Rain Exceedance 1";
            string TVTextFR = "Nouveau Rain Exceedance 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebCountry;
            WebTypeEnum webType = WebTypeEnum.WebCountry;
            TVTypeEnum tvType = TVTypeEnum.RainExceedance;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            TVTextEN = "Changed Rain Exceedance 1";
            TVTextFR = "Changé Rain Exceedance 1";

            await DoModifyChildTest(TVItemID, ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguageForTVTypeList(TVItemID, ParentTVItemID, webTypeParent, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(ParentTVItemID, webTypeParent);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Sector_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 629;
            string TVTextEN = "New Sector 1";
            string TVTextFR = "Nouveau Sector 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebArea;
            WebTypeEnum webType = WebTypeEnum.WebSector;
            TVTypeEnum tvType = TVTypeEnum.Sector;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);

            TVTextEN = "Changed Sector 1";
            TVTextFR = "Changé Sector 1";

            await DoModifyTest(TVItemID, webType, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemLocalService_Subsector_Add_Modify_Delete_Good_Test(string culture)
        {
            Assert.True(await Setup(culture, true));

            int TVItemID = -1;
            int ParentTVItemID = 633;
            string TVTextEN = "New Subsector 1";
            string TVTextFR = "Nouveau Subsector 1";
            WebTypeEnum webTypeParent = WebTypeEnum.WebSector;
            WebTypeEnum webType = WebTypeEnum.WebSubsector;
            TVTypeEnum tvType = TVTypeEnum.Subsector;

            await DoAddTest(ParentTVItemID, webTypeParent, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);

            TVTextEN = "Changed Subsector 1";
            TVTextFR = "Changé Subsector 1";

            await DoModifyTest(TVItemID, webType, tvType, TVTextEN, TVTextFR);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Created, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);

            await DoDeleteTest(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
            await CheckTVItemAndTVItemLanguage(TVItemID, webType, tvType, DBCommandEnum.Deleted, TVTextEN, TVTextFR);
            await CheckTVItemParentListExistInDBAndFilesExist(TVItemID, webType);
            await CheckTVItemExistInWebType(TVItemID, webType);
            await CheckTVItemExistInWebTypeParentAsList(TVItemID, ParentTVItemID, webType, webTypeParent, tvType);
        }
    }
}
