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

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class CSSPSQLiteServiceTests : TestHelper
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
        private ITVItemService TVItemService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        private FileInfo fiCSSPDBLocal { get; set; }
        private FileInfo fiCSSPLoginDB { get; set; }
        private FileInfo fiCSSPFilesManagementDB { get; set; }
        #endregion Properties

        #region Constructors
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

            bool retBool = await CSSPSQLiteService.CreateSQLiteCSSPLocalDatabase();
            Assert.True(retBool);

            retBool = await CSSPSQLiteService.DBLocalIsEmpty();
            Assert.True(retBool);

            LoggedInService.IsLocal = false;

            var actionAddressList = await AddressService.GetAddressList();
            Assert.Equal(200, ((ObjectResult)actionAddressList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAddressList.Result).Value);
            List<Address> addressList = (List<Address>)((OkObjectResult)actionAddressList.Result).Value;

            if (addressList.Count > 0)
            {
                LoggedInService.IsLocal = false;

                // need to add some informtion in the dbIM so we don't get errors while trying to add an Address
                try
                {
                    List<int> TVItemIDList = new List<int>() { addressList[0].AddressTVItemID, addressList[0].CountryTVItemID, addressList[0].ProvinceTVItemID, addressList[0].MunicipalityTVItemID, addressList[0].LastUpdateContactTVItemID };
                    foreach (int TVItemID in TVItemIDList)
                    {
                        var actionTVItem = await TVItemService.GetTVItemWithTVItemID(TVItemID);
                        Assert.Equal(200, ((ObjectResult)actionTVItem.Result).StatusCode);
                        Assert.NotNull(((OkObjectResult)actionTVItem.Result).Value);
                        TVItem tvItem = (TVItem)((OkObjectResult)actionTVItem.Result).Value;
                        Assert.NotNull(tvItem);

                        LoggedInService.IsLocal = false;

                        var actionTVItem2 = await TVItemService.Post(tvItem);
                        Assert.Equal(200, ((ObjectResult)actionTVItem2.Result).StatusCode);
                        Assert.NotNull(((OkObjectResult)actionTVItem2.Result).Value);
                        TVItem tvItem2 = (TVItem)((OkObjectResult)actionTVItem2.Result).Value;
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }

                LoggedInService.IsLocal = true;

                var actionAddress = await AddressService.Post(addressList[0]);
                Assert.Equal(200, ((ObjectResult)actionAddress.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionAddress.Result).Value);
                Address address = (Address)((OkObjectResult)actionAddress.Result).Value;
            }

            retBool = await CSSPSQLiteService.DBLocalIsEmpty();
            Assert.False(retBool);
        }
        #endregion Tests

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservices.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

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

            // doing CSSPDBLocal
            string CSSPDBLocal = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            fiCSSPDBLocal = new FileInfo(CSSPDBLocal.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            // doing CSSPLoginDB
            string CSSPLoginDB = Config.GetValue<string>("CSSPLoginDB");
            Assert.NotNull(CSSPLoginDB);

            fiCSSPLoginDB = new FileInfo(CSSPLoginDB.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPLoginDBContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPLoginDB.FullName }");
            });

            // doing CSSPFilesManagementDB
            string CSSPFilesManagementDB = Config.GetValue<string>("CSSPFilesManagementDB");
            Assert.NotNull(CSSPFilesManagementDB);

            fiCSSPFilesManagementDB = new FileInfo(CSSPFilesManagementDB.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPFilesManagementDBContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPFilesManagementDB.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAddressService, AddressService>();
            Services.AddSingleton<ITVItemService, TVItemService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.IsLocal = true;

            //dbIM = Provider.GetService<InMemoryDBContext>();
            //Assert.NotNull(dbIM);

            //dbLocal = Provider.GetService<CSSPDBLocalContext>();
            //Assert.NotNull(dbLocal);

            AddressService = Provider.GetService<IAddressService>();
            Assert.NotNull(AddressService);

            TVItemService = Provider.GetService<ITVItemService>();
            Assert.NotNull(TVItemService);

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            Assert.NotNull(CSSPSQLiteService);

            return await Task.FromResult(true);
        }
        #endregion Functions private

    }
}
