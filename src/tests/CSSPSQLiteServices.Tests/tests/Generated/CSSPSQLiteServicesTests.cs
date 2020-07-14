using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPSQLiteServices;
using CSSPSQLiteServices.Services;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSSPSQLiteServices.Tests
{
    public partial class CSSPSQLiteServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IAddressService AddressService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private Address address { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests
        [Fact]
        public async Task CreateSQLiteCSSPLocalDatabase_Good_Test()
        {
            Assert.True(await Setup());

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPLocalDatabase();
            Assert.True(retBool);
        }
        [Fact]
        public async Task CreateSQLiteCSSPFileManagementDatabase_Good_Test()
        {
            Assert.True(await Setup());

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPFileManagementDatabase();
            Assert.True(retBool);
        }
        [Fact]
        public async Task CreateSQLiteCSSPLoginDatabase_Good_Test()
        {
            Assert.True(await Setup());

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPLoginDatabase();
            Assert.True(retBool);
        }
        [Fact]
        public async Task DBContainsInfo_Good_Test()
        {
            Assert.True(await Setup());

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiCSSPDBLocal = new FileInfo(appDataPath + "\\cssp\\cssplocaldatabases\\CSSPDBLocal.db");

            bool retBool = await CSSPSQLiteService.DBContainsInfo(fiCSSPDBLocal);
            Assert.True(retBool);

            var actionAddressList = await AddressService.GetAddressList();
            Assert.Equal(200, ((ObjectResult)actionAddressList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressList.Result).Value);
            List<Address> addressList = (List<Address>)((OkObjectResult)actionAddressList.Result).Value;

            if (addressList.Count > 0)
            {
                try
                {
                    dbLocal.Addresses.Add(addressList[0]);
                    dbLocal.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
        #endregion Tests

        #region Functions private
        private async Task<bool> Setup()
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspsqliteservices.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAddressService, AddressService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture("en-CA");

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            //string IsLocalStr = Config.GetValue<string>("IsLocal");
            //Assert.NotNull(IsLocalStr);

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            AddressService = Provider.GetService<IAddressService>();
            Assert.NotNull(AddressService);

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            Assert.NotNull(CSSPSQLiteService);

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
