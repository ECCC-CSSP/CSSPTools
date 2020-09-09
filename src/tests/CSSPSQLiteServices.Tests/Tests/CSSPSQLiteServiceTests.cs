using CSSPEnums;
using CSSPModels;
using CSSPSQLiteServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.ComponentModel.DataAnnotations;

namespace CSSPSQLiteServices.Tests
{
    [Collection("Sequential")]
    public partial class CSSPSQLiteServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CSSPSQLiteServiceTests()
        {

        }
        #endregion Constructors

        #region Tests
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSQLiteService_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSQLiteService_CreateSQLiteCSSPDBLocal_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBLocal();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSQLiteService_CreateSQLiteCSSPDBSearch_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBSearch();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSQLiteService_CreateSQLiteCSSPDBFileManagement_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBFilesManagement();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSQLiteService_CreateSQLiteCSSPDBLogin_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBLogin();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSQLiteService_CSSPDBLocalIsEmpty_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            try
            {
                fiCSSPDBLocal.Delete();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBLocal();
            Assert.True(retBool);

            retBool = await CSSPSQLiteService.CSSPDBLocalIsEmpty();
            Assert.True(retBool);

            // will need to add some information to CSSPDBLocal to fully check if CSSPDBLocalIsEmpty is really working

            //var actionAddressList = await AddressService.GetAddressList();
            //Assert.Equal(200, ((ObjectResult)actionAddressList.Result).StatusCode);
            //Assert.NotNull(((OkObjectResult)actionAddressList.Result).Value);
            //List<Address> addressList = (List<Address>)((OkObjectResult)actionAddressList.Result).Value;
            //Assert.True(addressList.Count > 0);

            //// need to add some informtion in the dbIM so we don't get errors while trying to add an Address
            //List<int> TVItemIDList = new List<int>() { addressList[0].AddressTVItemID, addressList[0].CountryTVItemID, addressList[0].ProvinceTVItemID, addressList[0].MunicipalityTVItemID, addressList[0].LastUpdateContactTVItemID };
            //foreach (int TVItemID in TVItemIDList)
            //{
            //    var actionTVItem = await TVItemService.GetTVItemWithTVItemID(TVItemID);
            //    Assert.Equal(200, ((ObjectResult)actionTVItem.Result).StatusCode);
            //    Assert.NotNull(((OkObjectResult)actionTVItem.Result).Value);
            //    TVItem tvItem = (TVItem)((OkObjectResult)actionTVItem.Result).Value;
            //    Assert.NotNull(tvItem);

            //    var actionTVItem2 = await TVItemService.Post(tvItem);
            //    Assert.Equal(200, ((ObjectResult)actionTVItem2.Result).StatusCode);
            //    Assert.NotNull(((OkObjectResult)actionTVItem2.Result).Value);
            //    TVItem tvItem2 = (TVItem)((OkObjectResult)actionTVItem2.Result).Value;
            //}

            //var actionAddress = await AddressService.Post(addressList[0]);
            //Assert.Equal(200, ((ObjectResult)actionAddress.Result).StatusCode);
            //Assert.NotNull(((OkObjectResult)actionAddress.Result).Value);
            //Address address = (Address)((OkObjectResult)actionAddress.Result).Value;

            //retBool = await CSSPSQLiteService.CSSPDBLocalIsEmpty();
            //Assert.False(retBool);

            //var actionAddress3 = await AddressService.Delete(addressList[0].AddressID);
            //Assert.Equal(200, ((ObjectResult)actionAddress3.Result).StatusCode);
            //Assert.NotNull(((OkObjectResult)actionAddress3.Result).Value);
            //bool retBool2 = (bool)((OkObjectResult)actionAddress3.Result).Value;
            //Assert.True(retBool2);

            //retBool = await CSSPSQLiteService.CSSPDBLocalIsEmpty();
            //Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSQLiteService_CSSPDBSearchIsEmpty_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            try
            {
                fiCSSPDBSearch.Delete();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBSearch();
            Assert.True(retBool);

            retBool = await CSSPSQLiteService.CSSPDBSearchIsEmpty();
            Assert.True(retBool);

            // will need to add some information to CSSPDBLocal to fully check if CSSPDBSearchIsEmpty is really working

            //var actionTVItemList = await TVItemService.GetTVItemList();
            //Assert.Equal(200, ((ObjectResult)actionTVItemList.Result).StatusCode);
            //Assert.NotNull(((OkObjectResult)actionTVItemList.Result).Value);
            //List<TVItem> tvItemList = (List<TVItem>)((OkObjectResult)actionTVItemList.Result).Value;
            //Assert.True(tvItemList.Count > 0);



            retBool = await CSSPSQLiteService.CSSPDBSearchIsEmpty();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSQLiteService_CSSPDBFileManagementIsEmpty_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            try
            {
                fiCSSPDBFilesManagement.Delete();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBFilesManagement();
            Assert.True(retBool);

            retBool = await CSSPSQLiteService.CSSPDBFilesManagementIsEmpty();
            Assert.True(retBool);

            CSSPFile csspFileNew = new CSSPFile()
            {
                AzureStorage = "csspstorage",
                AzureFileName = "ThisFileName.json",
                AzureCreationTimeUTC = DateTime.Now,
                AzureETag = "SomeRandomText",
            };

            // will need to add some information to CSSPDBLocal to fully check if CSSPDBFilesManagementIsEmpty is really working

            //var actionCSSPFile = await CSSPDBFilesManagementService.Post(csspFileNew);
            //Assert.Equal(200, ((ObjectResult)actionCSSPFile.Result).StatusCode);
            //Assert.NotNull(((OkObjectResult)actionCSSPFile.Result).Value);
            //CSSPFile csspFile = (CSSPFile)((OkObjectResult)actionCSSPFile.Result).Value;
            //Assert.NotNull(csspFile);

            //retBool = await CSSPSQLiteService.CSSPDBFilesManagementIsEmpty();
            //Assert.False(retBool);

            //var actionCSSPFileDelete = await CSSPDBFilesManagementService.Delete(csspFile.CSSPFileID);
            //Assert.Equal(200, ((ObjectResult)actionCSSPFileDelete.Result).StatusCode);
            //Assert.NotNull(((OkObjectResult)actionCSSPFileDelete.Result).Value);
            //retBool = (bool)((OkObjectResult)actionCSSPFileDelete.Result).Value;
            //Assert.True(retBool);

            retBool = await CSSPSQLiteService.CSSPDBFilesManagementIsEmpty();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task CSSPSQLiteService_CSSPDBLoginIsEmpty_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            try
            {
                fiCSSPDBFilesManagement.Delete();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPDBLogin();
            Assert.True(retBool);

            retBool = await CSSPSQLiteService.CSSPDBLoginIsEmpty();
            Assert.True(retBool);

            RegisterModel registerModelNew = new RegisterModel()
            {
                FirstName = "TestFirstName",
                Initial = "TestInit",
                LastName = "TestLastName",
                LoginEmail = "TestLoginEmail@Somewhere.com",
                Password = "TestPassword",
                ConfirmPassword = "TestPassword",
            };

            // will need to add some information to CSSPDBLocal to fully check if CSSPDBLoginIsEmpty is really working

            //var actionContact = await ContactService.Register(registerModelNew);
            //Assert.Equal(200, ((ObjectResult)actionContact.Result).StatusCode);
            //Assert.NotNull(((OkObjectResult)actionContact.Result).Value);
            //Contact contact = (Contact)((OkObjectResult)actionContact.Result).Value;
            //Assert.NotNull(contact);

            //retBool = await CSSPSQLiteService.CSSPDBLoginIsEmpty();
            //Assert.False(retBool);

            //var actionContactDelete = await ContactService.Delete(contact.ContactID);
            //Assert.Equal(200, ((ObjectResult)actionContactDelete.Result).StatusCode);
            //Assert.NotNull(((OkObjectResult)actionContactDelete.Result).Value);
            //retBool = (bool)((OkObjectResult)actionContactDelete.Result).Value;
            //Assert.True(retBool);

            //var actionAspNetUser = await AspNetUserService.Delete(contact.Id);
            //Assert.Equal(200, ((ObjectResult)actionAspNetUser.Result).StatusCode);
            //Assert.NotNull(((OkObjectResult)actionAspNetUser.Result).Value);
            //retBool = (bool)((OkObjectResult)actionAspNetUser.Result).Value;
            //Assert.True(retBool);

            retBool = await CSSPSQLiteService.CSSPDBLoginIsEmpty();
            Assert.True(retBool);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private

    }
}
