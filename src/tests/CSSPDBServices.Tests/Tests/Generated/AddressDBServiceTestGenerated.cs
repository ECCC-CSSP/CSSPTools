/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
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

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class AddressDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IAddressDBService AddressDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private Address address { get; set; }
        #endregion Properties

        #region Constructors
        public AddressDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddressDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task AddressDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            address = GetFilledRandomAddress("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task Address_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionAddressList = await AddressDBService.GetAddressList();
            Assert.Equal(200, ((ObjectResult)actionAddressList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressList.Result).Value);
            List<Address> addressList = (List<Address>)((OkObjectResult)actionAddressList.Result).Value;

            count = addressList.Count();

            Address address = GetFilledRandomAddress("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // address.AddressID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.AddressID = 0;

            var actionAddress = await AddressDBService.Put(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

            address = null;
            address = GetFilledRandomAddress("");
            address.AddressID = 10000000;
            actionAddress = await AddressDBService.Put(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Address)]
            // address.AddressTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.AddressTVItemID = 0;
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

            address = null;
            address = GetFilledRandomAddress("");
            address.AddressTVItemID = 1;
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // address.AddressType   (AddressTypeEnum)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.AddressType = (AddressTypeEnum)1000000;
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Country)]
            // address.CountryTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.CountryTVItemID = 0;
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

            address = null;
            address = GetFilledRandomAddress("");
            address.CountryTVItemID = 1;
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Province)]
            // address.ProvinceTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.ProvinceTVItemID = 0;
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

            address = null;
            address = GetFilledRandomAddress("");
            address.ProvinceTVItemID = 1;
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Municipality)]
            // address.MunicipalityTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.MunicipalityTVItemID = 0;
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

            address = null;
            address = GetFilledRandomAddress("");
            address.MunicipalityTVItemID = 1;
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(200)]
            // address.StreetName   (String)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.StreetName = GetRandomString("", 201);
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);
            //Assert.AreEqual(count, addressDBService.GetAddressList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(50)]
            // address.StreetNumber   (String)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.StreetNumber = GetRandomString("", 51);
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);
            //Assert.AreEqual(count, addressDBService.GetAddressList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // address.StreetType   (StreetTypeEnum)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.StreetType = (StreetTypeEnum)1000000;
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(11)]
            // [CSSPMinLength(6)]
            // address.PostalCode   (String)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.PostalCode = GetRandomString("", 5);
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);
            //Assert.AreEqual(count, addressDBService.GetAddressList().Count());
            address = null;
            address = GetFilledRandomAddress("");
            address.PostalCode = GetRandomString("", 12);
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);
            //Assert.AreEqual(count, addressDBService.GetAddressList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(200)]
            // [CSSPMinLength(10)]
            // address.GoogleAddressText   (String)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.GoogleAddressText = GetRandomString("", 9);
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);
            //Assert.AreEqual(count, addressDBService.GetAddressList().Count());
            address = null;
            address = GetFilledRandomAddress("");
            address.GoogleAddressText = GetRandomString("", 201);
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);
            //Assert.AreEqual(count, addressDBService.GetAddressList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // address.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.LastUpdateDate_UTC = new DateTime();
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);
            address = null;
            address = GetFilledRandomAddress("");
            address.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // address.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.LastUpdateContactTVItemID = 0;
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

            address = null;
            address = GetFilledRandomAddress("");
            address.LastUpdateContactTVItemID = 1;
            actionAddress = await AddressDBService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post Address
            var actionAddressAdded = await AddressDBService.Post(address);
            Assert.Equal(200, ((ObjectResult)actionAddressAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressAdded.Result).Value);
            Address addressAdded = (Address)((OkObjectResult)actionAddressAdded.Result).Value;
            Assert.NotNull(addressAdded);

            // List<Address>
            var actionAddressList = await AddressDBService.GetAddressList();
            Assert.Equal(200, ((ObjectResult)actionAddressList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressList.Result).Value);
            List<Address> addressList = (List<Address>)((OkObjectResult)actionAddressList.Result).Value;

            int count = ((List<Address>)((OkObjectResult)actionAddressList.Result).Value).Count();
            Assert.True(count > 0);

            // List<Address> with skip and take
            var actionAddressListSkipAndTake = await AddressDBService.GetAddressList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionAddressListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressListSkipAndTake.Result).Value);
            List<Address> addressListSkipAndTake = (List<Address>)((OkObjectResult)actionAddressListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<Address>)((OkObjectResult)actionAddressListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(addressList[0].AddressID == addressListSkipAndTake[0].AddressID);

            // Get Address With AddressID
            var actionAddressGet = await AddressDBService.GetAddressWithAddressID(addressList[0].AddressID);
            Assert.Equal(200, ((ObjectResult)actionAddressGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressGet.Result).Value);
            Address addressGet = (Address)((OkObjectResult)actionAddressGet.Result).Value;
            Assert.NotNull(addressGet);
            Assert.Equal(addressGet.AddressID, addressList[0].AddressID);

            // Put Address
            var actionAddressUpdated = await AddressDBService.Put(address);
            Assert.Equal(200, ((ObjectResult)actionAddressUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressUpdated.Result).Value);
            Address addressUpdated = (Address)((OkObjectResult)actionAddressUpdated.Result).Value;
            Assert.NotNull(addressUpdated);

            // Delete Address
            var actionAddressDeleted = await AddressDBService.Delete(address.AddressID);
            Assert.Equal(200, ((ObjectResult)actionAddressDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionAddressDeleted.Result).Value;
            Assert.True(retBool);

            db.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("70c662c1-a1a8-4b2c-b594-d7834bb5e6db")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAddressDBService, AddressDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            AddressDBService = Provider.GetService<IAddressDBService>();
            Assert.NotNull(AddressDBService);

            return await Task.FromResult(true);
        }
        private Address GetFilledRandomAddress(string OmitPropName)
        {
            Address address = new Address();

            if (OmitPropName != "AddressTVItemID") address.AddressTVItemID = 46;
            if (OmitPropName != "AddressType") address.AddressType = (AddressTypeEnum)GetRandomEnumType(typeof(AddressTypeEnum));
            if (OmitPropName != "CountryTVItemID") address.CountryTVItemID = 5;
            if (OmitPropName != "ProvinceTVItemID") address.ProvinceTVItemID = 6;
            if (OmitPropName != "MunicipalityTVItemID") address.MunicipalityTVItemID = 39;
            if (OmitPropName != "StreetName") address.StreetName = GetRandomString("", 5);
            if (OmitPropName != "StreetNumber") address.StreetNumber = GetRandomString("", 5);
            if (OmitPropName != "StreetType") address.StreetType = (StreetTypeEnum)GetRandomEnumType(typeof(StreetTypeEnum));
            if (OmitPropName != "PostalCode") address.PostalCode = GetRandomString("", 11);
            if (OmitPropName != "GoogleAddressText") address.GoogleAddressText = GetRandomString("", 15);
            if (OmitPropName != "LastUpdateDate_UTC") address.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") address.LastUpdateContactTVItemID = 2;



            return address;
        }
        private void CheckAddressFields(List<Address> addressList)
        {
            if (!string.IsNullOrWhiteSpace(addressList[0].StreetName))
            {
                Assert.False(string.IsNullOrWhiteSpace(addressList[0].StreetName));
            }
            if (!string.IsNullOrWhiteSpace(addressList[0].StreetNumber))
            {
                Assert.False(string.IsNullOrWhiteSpace(addressList[0].StreetNumber));
            }
            if (addressList[0].StreetType != null)
            {
                Assert.NotNull(addressList[0].StreetType);
            }
            if (!string.IsNullOrWhiteSpace(addressList[0].PostalCode))
            {
                Assert.False(string.IsNullOrWhiteSpace(addressList[0].PostalCode));
            }
            if (!string.IsNullOrWhiteSpace(addressList[0].GoogleAddressText))
            {
                Assert.False(string.IsNullOrWhiteSpace(addressList[0].GoogleAddressText));
            }
        }

        #endregion Functions private
    }
}
