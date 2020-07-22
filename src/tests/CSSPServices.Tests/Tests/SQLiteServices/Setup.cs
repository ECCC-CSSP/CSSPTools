using CSSPEnums;
using CSSPModels;
using CSSPServices;
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

namespace CSSPSQLiteServices.Tests
{
    public partial class CSSPSQLiteServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        public IConfiguration Config { get; set; }
        public IServiceProvider Provider { get; set; }
        public IServiceCollection Services { get; set; }
        public ICSSPCultureService CSSPCultureService { get; set; }
        public ILoggedInService LoggedInService { get; set; }
        public IAddressService AddressService { get; set; }
        public ITVItemService TVItemService { get; set; }
        public CSSPDBContext db { get; set; }
        public CSSPDBLocalContext dbLocal { get; set; }
        public InMemoryDBContext dbIM { get; set; }
        public ICSSPSQLiteService CSSPSQLiteService { get; set; }
        public FileInfo fiCSSPDBLocal { get; set; }
        public FileInfo fiCSSPLoginDB { get; set; }
        public FileInfo fiCSSPFilesManagementDB { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public
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

            string TestDBConnString = Config.GetValue<string>("TestDB");
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

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAddressService, AddressService>();
            Services.AddSingleton<ITVItemService, TVItemService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();

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
        #endregion Functions public
    }
}
