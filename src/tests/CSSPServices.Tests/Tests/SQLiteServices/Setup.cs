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
        protected IConfiguration Config { get; set; }
        protected IServiceProvider Provider { get; set; }
        protected IServiceCollection Services { get; set; }
        protected ICSSPCultureService CSSPCultureService { get; set; }
        protected ILoggedInService LoggedInService { get; set; }
        protected IEnums Enums { get; set; }
        protected IAddressService AddressService { get; set; }
        protected ITVItemService TVItemService { get; set; }
        protected CSSPDBContext db { get; set; }
        protected CSSPDBLocalContext dbLocal { get; set; }
        protected CSSPDBInMemoryContext dbIM { get; set; }
        protected ICSSPFileService CSSPFileService { get; set; }
        protected ICSSPSQLiteService CSSPSQLiteService { get; set; }
        protected IAspNetUserService AspNetUserService { get; set; }
        protected ILoginModelService LoginModelService { get; set; }
        protected IRegisterModelService RegisterModelService { get; set; }
        protected IContactService ContactService { get; set; }
        protected FileInfo fiCSSPDBLocal { get; set; }
        protected FileInfo fiCSSPDBLogin { get; set; }
        protected FileInfo fiCSSPDBFilesManagement { get; set; }
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

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
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
            string CSSPLoginDB = Config.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPLoginDB);

            fiCSSPDBLogin = new FileInfo(CSSPLoginDB.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            // doing CSSPFilesManagementDB
            string CSSPFilesManagementDB = Config.GetValue<string>("CSSPDBFilesManagement");
            Assert.NotNull(CSSPFilesManagementDB);

            fiCSSPDBFilesManagement = new FileInfo(CSSPFilesManagementDB.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFilesManagement.FullName }");
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(TestDBConnString));

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAddressService, AddressService>();
            Services.AddSingleton<ITVItemService, TVItemService>();
            Services.AddSingleton<ICSSPFileService, CSSPFileService>();
            Services.AddSingleton<IAspNetUserService, AspNetUserService>();
            Services.AddSingleton<ILoginModelService, LoginModelService>();
            Services.AddSingleton<IRegisterModelService, RegisterModelService>();
            Services.AddSingleton<IContactService, ContactService>();
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

            CSSPFileService = Provider.GetService<ICSSPFileService>();
            Assert.NotNull(CSSPFileService);

            AspNetUserService = Provider.GetService<IAspNetUserService>();
            Assert.NotNull(AspNetUserService);

            LoginModelService = Provider.GetService<ILoginModelService>();
            Assert.NotNull(LoginModelService);

            RegisterModelService = Provider.GetService<IRegisterModelService>();
            Assert.NotNull(RegisterModelService);

            ContactService = Provider.GetService<IContactService>();
            Assert.NotNull(ContactService);

            CSSPSQLiteService = Provider.GetService<ICSSPSQLiteService>();
            Assert.NotNull(CSSPSQLiteService);

            return await Task.FromResult(true);
        }
        #endregion Functions public
    }
}
