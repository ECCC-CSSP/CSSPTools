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
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IEnums Enums { get; set; }
        private IAddressService AddressService { get; set; }
        private ITVItemService TVItemService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private ICSSPDBFilesManagementService CSSPDBFilesManagementService { get; set; }
        private ICSSPSQLiteService CSSPSQLiteService { get; set; }
        private IAspNetUserService AspNetUserService { get; set; }
        private ILoginModelService LoginModelService { get; set; }
        private IRegisterModelService RegisterModelService { get; set; }
        private IContactService ContactService { get; set; }
        private FileInfo fiCSSPDBLocal { get; set; }
        private FileInfo fiCSSPDBSearch { get; set; }
        private FileInfo fiCSSPDBLogin { get; set; }
        private FileInfo fiCSSPDBFilesManagement { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Functions public
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservicestests.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            string TestDBConnString = Configuration.GetValue<string>("TestDB");
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
            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            // doing CSSPDBSearch
            string CSSPDBSearch = Configuration.GetValue<string>("CSSPDBSearch");
            Assert.NotNull(CSSPDBSearch);

            fiCSSPDBSearch = new FileInfo(CSSPDBSearch);

            Services.AddDbContext<CSSPDBSearchContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBSearch.FullName }");
            });

            // doing CSSPLoginDB
            string CSSPLoginDB = Configuration.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPLoginDB);

            fiCSSPDBLogin = new FileInfo(CSSPLoginDB);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            // doing CSSPFilesManagementDB
            string CSSPFilesManagementDB = Configuration.GetValue<string>("CSSPDBFilesManagement");
            Assert.NotNull(CSSPFilesManagementDB);

            fiCSSPDBFilesManagement = new FileInfo(CSSPFilesManagementDB);

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
            Services.AddSingleton<ICSSPDBFilesManagementService, CSSPDBFilesManagementService>();
            Services.AddSingleton<IAspNetUserService, AspNetUserService>();
            Services.AddSingleton<ILoginModelService, LoginModelService>();
            Services.AddSingleton<IRegisterModelService, RegisterModelService>();
            Services.AddSingleton<IContactService, ContactService>();
            Services.AddSingleton<ICSSPSQLiteService, CSSPSQLiteService>();
            Services.AddSingleton<ICreateGzFileService, CreateGzFileService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Configuration.GetValue<string>("Id");
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

            CSSPDBFilesManagementService = Provider.GetService<ICSSPDBFilesManagementService>();
            Assert.NotNull(CSSPDBFilesManagementService);

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
