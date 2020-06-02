﻿//using CSSPEnums;
//using CSSPModels;
//using CSSPServices;
//using CSSPWebAPI.Controllers;
//using LoggedInServices.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Threading.Tasks;
//using UserServices.Models;
//using Xunit;

//namespace CSSPWebAPIs.Tests.Controllers
//{
//    public class AddressControllerTests_Good
//    {
//        #region Variables
//        #endregion Variables

//        #region Properties
//        private IConfiguration Config { get; set; }
//        private IServiceProvider Provider { get; set; }
//        private IServiceCollection Services { get; set; }
//        private CSSPDBContext db { get; set; }
//        private ILoggedInService loggedInService { get; set; }
//        private IAddressService addressService { get; set; }
//        private IAddressController addressController { get; set; }
//        #endregion Properties

//        #region Constructors
//        public AddressControllerTests_Good()
//        {
//        }
//        #endregion Constructors

//        #region Functions public
//        [Theory]
//        [InlineData("en-CA")]
//        [InlineData("fr-CA")]
//        public async Task AddressController_Constructor_Good_Test(string culture)
//        {
//            bool retBool = await Setup(new CultureInfo(culture));
//            Assert.True(retBool);
//            Assert.NotNull(loggedInService);
//            Assert.NotNull(addressService);
//            Assert.NotNull(addressController);
//        }
//        [Theory]
//        [InlineData("en-CA")]
//        [InlineData("fr-CA")]
//        public async Task AddressController_CRUD_Good_Test(string culture)
//        {
//            bool retBool = await Setup(new CultureInfo(culture));
//            Assert.True(retBool);

//            // testing Get
//            var actionAddressList = await addressController.Get();
//            Assert.Equal(200, ((ObjectResult)actionAddressList.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionAddressList.Result).Value);
//            List<Address> addressList = (List<Address>)(((OkObjectResult)actionAddressList.Result).Value);

//            int count = ((List<Address>)((OkObjectResult)actionAddressList.Result).Value).Count();
//            Assert.True(count > 0);

//            // testing Get(AddressID)
//            var actionAddress = await addressController.Get(addressList[0].AddressID);
//            Assert.Equal(200, ((ObjectResult)actionAddress.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionAddress.Result).Value);
//            Address address = (Address)(((OkObjectResult)actionAddress.Result).Value);
//            Assert.NotNull(address);
//            Assert.Equal(addressList[0].AddressID, address.AddressID);

//            // testing Post(Address address)
//            address.AddressID = 0;
//            var actionAddressNew = await addressController.Post(address);
//            Assert.Equal(200, ((ObjectResult)actionAddressNew.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionAddressNew.Result).Value);
//            Address addressNew = (Address)(((OkObjectResult)actionAddressNew.Result).Value);
//            Assert.NotNull(addressNew);

//            // testing Put(Address address)
//            var actionAddressUpdate = await addressController.Put(addressNew);
//            Assert.Equal(200, ((ObjectResult)actionAddressUpdate.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionAddressUpdate.Result).Value);
//            Address addressUpdate = (Address)(((OkObjectResult)actionAddressUpdate.Result).Value);
//            Assert.NotNull(addressUpdate);

//            // testing Delete(Address address)
//            var actionAddressDelete = await addressController.Delete(addressUpdate);
//            Assert.Equal(200, ((ObjectResult)actionAddressDelete.Result).StatusCode);
//            Assert.NotNull(((OkObjectResult)actionAddressDelete.Result).Value);
//            Address addressDelete = (Address)(((OkObjectResult)actionAddressDelete.Result).Value);
//            Assert.NotNull(addressDelete);
//        }
//        #endregion Functions public

//        #region Functions private
//        private async Task<bool> Setup(CultureInfo culture)
//        {
//            Config = new ConfigurationBuilder()
//               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
//               .AddJsonFile("appsettings.json")
//               .Build();

//            Services = new ServiceCollection();

//            IConfigurationSection connectionStringsSection = Config.GetSection("ConnectionStrings");
//            Services.Configure<ConnectionStringsModel>(connectionStringsSection);

//            ConnectionStringsModel connectionStrings = connectionStringsSection.Get<ConnectionStringsModel>();

//            Services.AddSingleton<IConfiguration>(Config);

//            Services.AddDbContext<CSSPDBContext>(options =>
//            {
//                options.UseSqlServer(connectionStrings.TestDB);
//            });

//            Services.AddDbContext<ApplicationDbContext>(options =>
//                options.UseSqlServer(connectionStrings.TestDB));

//            Services.AddIdentityCore<ApplicationUser>()
//                .AddEntityFrameworkStores<ApplicationDbContext>();

//            Services.AddSingleton<IEnums, Enums>();
//            Services.AddSingleton<ILoggedInService, LoggedInService>();
//            Services.AddSingleton<IAddressService, AddressService>();
//            Services.AddSingleton<IAddressController, AddressController>();

//            Provider = Services.BuildServiceProvider();
//            Assert.NotNull(Provider);

//            loggedInService = Provider.GetService<ILoggedInService>();
//            Assert.NotNull(loggedInService);

//            addressService = Provider.GetService<IAddressService>();
//            Assert.NotNull(addressService);

//            await addressService.SetCulture(culture);

//            addressController = Provider.GetService<IAddressController>();
//            Assert.NotNull(addressController);

//            return await Task.FromResult(true);
//        }
//        #endregion Functions private
//    }
//}
