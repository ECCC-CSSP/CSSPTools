/* Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceTestGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
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
using Xunit;

namespace CSSPServices.Tests
{
    public partial class AddressServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IAddressService addressService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public AddressServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task Address_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            Address address = GetFilledRandomAddress(""); 

            // List<Address>
            var actionAddressList = await addressService.GetAddressList();
            Assert.Equal(200, ((ObjectResult)actionAddressList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressList.Result).Value);
            List<Address> addressList = (List<Address>)(((OkObjectResult)actionAddressList.Result).Value);

            int count = ((List<Address>)((OkObjectResult)actionAddressList.Result).Value).Count();
            Assert.True(count > 0);

            // Add Address
            var actionAddressAdded = await addressService.Add(address);
            Assert.Equal(200, ((ObjectResult)actionAddressAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressAdded.Result).Value);
            Address addressAdded = (Address)(((OkObjectResult)actionAddressAdded.Result).Value);
            Assert.NotNull(addressAdded);

            // Update Address
            var actionAddressUpdated = await addressService.Update(address);
            Assert.Equal(200, ((ObjectResult)actionAddressUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressUpdated.Result).Value);
            Address addressUpdated = (Address)(((OkObjectResult)actionAddressUpdated.Result).Value);
            Assert.NotNull(addressUpdated);

            // Delete Address
            var actionAddressDeleted = await addressService.Delete(address);
            Assert.Equal(200, ((ObjectResult)actionAddressDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressDeleted.Result).Value);
            Address addressDeleted = (Address)(((OkObjectResult)actionAddressDeleted.Result).Value);
            Assert.NotNull(addressDeleted);
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();
        
            Services = new ServiceCollection();
        
            Services.AddSingleton<IConfiguration>(Config);
        
            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);
        
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });
        
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAddressService, AddressService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            addressService = Provider.GetService<IAddressService>();
            Assert.NotNull(addressService);
        
            await addressService.SetCulture(culture);
        
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
        #endregion Functions private
    }
}