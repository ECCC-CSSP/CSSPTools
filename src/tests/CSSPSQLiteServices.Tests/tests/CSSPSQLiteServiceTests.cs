using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CultureServices.Services;
using LoggedInServices.Services;
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
        [InlineData("fr-CA")]
        public async Task CreateSQLiteCSSPLocalDatabase_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPLocalDatabase();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateSQLiteCSSPFileManagementDatabase_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPFileManagementDatabase();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task CreateSQLiteCSSPLoginDatabase_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPLoginDatabase();
            Assert.True(retBool);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task DBLocalIsEmpty_Good_Test(string culture)
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

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPLocalDatabase();
            Assert.True(retBool);

            retBool = await CSSPSQLiteService.DBLocalIsEmpty();
            Assert.True(retBool);

            LoggedInService.DBLocation = DBLocationEnum.Server;

            var actionAddressList = await AddressService.GetAddressList();
            Assert.Equal(200, ((ObjectResult)actionAddressList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressList.Result).Value);
            List<Address> addressList = (List<Address>)((OkObjectResult)actionAddressList.Result).Value;
            Assert.True(addressList.Count > 0);

            // need to add some informtion in the dbIM so we don't get errors while trying to add an Address
            List<int> TVItemIDList = new List<int>() { addressList[0].AddressTVItemID, addressList[0].CountryTVItemID, addressList[0].ProvinceTVItemID, addressList[0].MunicipalityTVItemID, addressList[0].LastUpdateContactTVItemID };
            foreach (int TVItemID in TVItemIDList)
            {
                LoggedInService.DBLocation = DBLocationEnum.Server;

                var actionTVItem = await TVItemService.GetTVItemWithTVItemID(TVItemID);
                Assert.Equal(200, ((ObjectResult)actionTVItem.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionTVItem.Result).Value);
                TVItem tvItem = (TVItem)((OkObjectResult)actionTVItem.Result).Value;
                Assert.NotNull(tvItem);

                LoggedInService.DBLocation = DBLocationEnum.InMemory;

                var actionTVItem2 = await TVItemService.Post(tvItem);
                Assert.Equal(200, ((ObjectResult)actionTVItem2.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionTVItem2.Result).Value);
                TVItem tvItem2 = (TVItem)((OkObjectResult)actionTVItem2.Result).Value;
            }

            LoggedInService.DBLocation = DBLocationEnum.Local;

            var actionAddress = await AddressService.Post(addressList[0]);
            Assert.Equal(200, ((ObjectResult)actionAddress.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddress.Result).Value);
            Address address = (Address)((OkObjectResult)actionAddress.Result).Value;

            retBool = await CSSPSQLiteService.DBLocalIsEmpty();
            Assert.False(retBool);

            LoggedInService.DBLocation = DBLocationEnum.Local;

            var actionAddress3 = await AddressService.Delete(addressList[0].AddressID);
            Assert.Equal(200, ((ObjectResult)actionAddress3.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddress3.Result).Value);
            bool retBool2 = (bool)((OkObjectResult)actionAddress3.Result).Value;
            Assert.True(retBool2);

            retBool = await CSSPSQLiteService.DBLocalIsEmpty();
            Assert.True(retBool);
        }
        #endregion Tests

        #region Functions private
        #endregion Functions private

    }
}
