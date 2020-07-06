/* Auto generated from C:\CSSPTools\src\codegen\Tests\_package\netcoreapp3.1\testhost.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using CultureServices.Services;
using LoggedInServices.Services;
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
using UserServices.Models;
using Xunit;

namespace CSSPWebAPIs.Tests.Controllers
{
    public partial class AddressControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ICultureService CultureService { get; set; }
        private IAddressService addressService { get; set; }
        private IAddressController addressController { get; set; }
        #endregion Properties

        #region Constructors
        public AddressControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task AddressController_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
            Assert.NotNull(loggedInService);
            Assert.NotNull(addressService);
            Assert.NotNull(addressController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task AddressController_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionAddressList = await addressController.Get();
                Assert.Equal(200, ((ObjectResult)actionAddressList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAddressList.Result).Value);
                List<Address> addressList = (List<Address>)((OkObjectResult)actionAddressList.Result).Value;

                int count = ((List<Address>)((OkObjectResult)actionAddressList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(AddressID)
                var actionAddress = await addressController.Get(addressList[0].AddressID);
                Assert.Equal(200, ((ObjectResult)actionAddress.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAddress.Result).Value);
                Address address = (Address)((OkObjectResult)actionAddress.Result).Value;
                Assert.NotNull(address);
                Assert.Equal(addressList[0].AddressID, address.AddressID);

                // testing Post(Address address)
                address.AddressID = 0;
                var actionAddressNew = await addressController.Post(address);
                Assert.Equal(200, ((ObjectResult)actionAddressNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAddressNew.Result).Value);
                Address addressNew = (Address)((OkObjectResult)actionAddressNew.Result).Value;
                Assert.NotNull(addressNew);

                // testing Put(Address address)
                var actionAddressUpdate = await addressController.Put(addressNew);
                Assert.Equal(200, ((ObjectResult)actionAddressUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAddressUpdate.Result).Value);
                Address addressUpdate = (Address)((OkObjectResult)actionAddressUpdate.Result).Value;
                Assert.NotNull(addressUpdate);

                // testing Delete(int address.AddressID)
                var actionAddressDelete = await addressController.Delete(addressUpdate.AddressID);
                Assert.Equal(200, ((ObjectResult)actionAddressDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAddressDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionAddressDelete.Result).Value;
                Assert.True(retBool2);
            }
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();

            Services = new ServiceCollection();

            IConfigurationSection connectionStringsSection = Config.GetSection("ConnectionStrings");
            Services.Configure<ConnectionStringsModel>(connectionStringsSection);

            ConnectionStringsModel connectionStrings = connectionStringsSection.Get<ConnectionStringsModel>();

            Services.AddSingleton<IConfiguration>(Config);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(connectionStrings.TestDB);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionStrings.TestDB));

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IAddressService, AddressService>();
            Services.AddSingleton<IAddressController, AddressController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            addressService = Provider.GetService<IAddressService>();
            Assert.NotNull(addressService);

            addressController = Provider.GetService<IAddressController>();
            Assert.NotNull(addressController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
