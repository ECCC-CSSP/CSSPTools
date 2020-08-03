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

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class AddressServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IAddressService AddressService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private Address address { get; set; }
        #endregion Properties

        #region Constructors
        public AddressServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task Address_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            address = GetFilledRandomAddress("");

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                await DoCRUDTest();
            }
            else
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    await DoCRUDTest();
                }
            }
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task Address_Properties_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionAddressList = await AddressService.GetAddressList();
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

            var actionAddress = await AddressService.Put(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

            address = null;
            address = GetFilledRandomAddress("");
            address.AddressID = 10000000;
            actionAddress = await AddressService.Put(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Address)]
            // address.AddressTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.AddressTVItemID = 0;
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

            address = null;
            address = GetFilledRandomAddress("");
            address.AddressTVItemID = 1;
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // address.AddressType   (AddressTypeEnum)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.AddressType = (AddressTypeEnum)1000000;
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Country)]
            // address.CountryTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.CountryTVItemID = 0;
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

            address = null;
            address = GetFilledRandomAddress("");
            address.CountryTVItemID = 1;
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Province)]
            // address.ProvinceTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.ProvinceTVItemID = 0;
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

            address = null;
            address = GetFilledRandomAddress("");
            address.ProvinceTVItemID = 1;
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Municipality)]
            // address.MunicipalityTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.MunicipalityTVItemID = 0;
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

            address = null;
            address = GetFilledRandomAddress("");
            address.MunicipalityTVItemID = 1;
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(200)]
            // address.StreetName   (String)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.StreetName = GetRandomString("", 201);
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);
            //Assert.AreEqual(count, addressService.GetAddressList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(50)]
            // address.StreetNumber   (String)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.StreetNumber = GetRandomString("", 51);
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);
            //Assert.AreEqual(count, addressService.GetAddressList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // address.StreetType   (StreetTypeEnum)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.StreetType = (StreetTypeEnum)1000000;
            actionAddress = await AddressService.Post(address);
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
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);
            //Assert.AreEqual(count, addressService.GetAddressList().Count());
            address = null;
            address = GetFilledRandomAddress("");
            address.PostalCode = GetRandomString("", 12);
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);
            //Assert.AreEqual(count, addressService.GetAddressList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(200)]
            // [CSSPMinLength(10)]
            // address.GoogleAddressText   (String)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.GoogleAddressText = GetRandomString("", 9);
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);
            //Assert.AreEqual(count, addressService.GetAddressList().Count());
            address = null;
            address = GetFilledRandomAddress("");
            address.GoogleAddressText = GetRandomString("", 201);
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);
            //Assert.AreEqual(count, addressService.GetAddressList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // address.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.LastUpdateDate_UTC = new DateTime();
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);
            address = null;
            address = GetFilledRandomAddress("");
            address.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // address.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            address = null;
            address = GetFilledRandomAddress("");
            address.LastUpdateContactTVItemID = 0;
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

            address = null;
            address = GetFilledRandomAddress("");
            address.LastUpdateContactTVItemID = 1;
            actionAddress = await AddressService.Post(address);
            Assert.IsType<BadRequestObjectResult>(actionAddress.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post Address
            var actionAddressAdded = await AddressService.Post(address);
            Assert.Equal(200, ((ObjectResult)actionAddressAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressAdded.Result).Value);
            Address addressAdded = (Address)((OkObjectResult)actionAddressAdded.Result).Value;
            Assert.NotNull(addressAdded);

            // List<Address>
            var actionAddressList = await AddressService.GetAddressList();
            Assert.Equal(200, ((ObjectResult)actionAddressList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressList.Result).Value);
            List<Address> addressList = (List<Address>)((OkObjectResult)actionAddressList.Result).Value;

            int count = ((List<Address>)((OkObjectResult)actionAddressList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<Address> with skip and take
                var actionAddressListSkipAndTake = await AddressService.GetAddressList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionAddressListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAddressListSkipAndTake.Result).Value);
                List<Address> addressListSkipAndTake = (List<Address>)((OkObjectResult)actionAddressListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<Address>)((OkObjectResult)actionAddressListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(addressList[0].AddressID == addressListSkipAndTake[0].AddressID);
            }

            // Get Address With AddressID
            var actionAddressGet = await AddressService.GetAddressWithAddressID(addressList[0].AddressID);
            Assert.Equal(200, ((ObjectResult)actionAddressGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressGet.Result).Value);
            Address addressGet = (Address)((OkObjectResult)actionAddressGet.Result).Value;
            Assert.NotNull(addressGet);
            Assert.Equal(addressGet.AddressID, addressList[0].AddressID);

            // Put Address
            var actionAddressUpdated = await AddressService.Put(address);
            Assert.Equal(200, ((ObjectResult)actionAddressUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressUpdated.Result).Value);
            Address addressUpdated = (Address)((OkObjectResult)actionAddressUpdated.Result).Value;
            Assert.NotNull(addressUpdated);

            // Delete Address
            var actionAddressDeleted = await AddressService.Delete(address.AddressID);
            Assert.Equal(200, ((ObjectResult)actionAddressDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionAddressDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservices.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            string TestDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAddressService, AddressService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.DBLocation = DBLocationEnum.Local;

            dbIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            AddressService = Provider.GetService<IAddressService>();
            Assert.NotNull(AddressService);

            return await Task.FromResult(true);
        }
        private Address GetFilledRandomAddress(string OmitPropName)
        {
            List<Address> addressListToDelete = (from c in dbLocal.Addresses
                                                               select c).ToList(); 
            
            dbLocal.Addresses.RemoveRange(addressListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

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

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "AddressID") address.AddressID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 46, TVLevel = 1, TVPath = "p1p46", TVType = (TVTypeEnum)2, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2015, 9, 8, 17, 8, 14), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 5, TVLevel = 1, TVPath = "p1p5", TVType = (TVTypeEnum)6, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2017, 8, 8, 16, 36, 15), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 6, TVLevel = 2, TVPath = "p1p5p6", TVType = (TVTypeEnum)18, ParentID = 5, IsActive = true, LastUpdateDate_UTC = new DateTime(2015, 2, 17, 14, 14, 24), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 39, TVLevel = 3, TVPath = "p1p5p6p39", TVType = (TVTypeEnum)15, ParentID = 6, IsActive = true, LastUpdateDate_UTC = new DateTime(2015, 2, 22, 14, 12, 19), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
            }

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
