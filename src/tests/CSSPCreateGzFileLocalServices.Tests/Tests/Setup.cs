using CSSPEnums;
using CSSPDBModels;
using CreateGzFileLocalServices;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using CSSPDBServices;
using LoggedInServices;
using CSSPHelperModels;
using CSSPScrambleServices;
using CSSPDBPreferenceModels;
using ReadGzFileServices;
using CSSPDBFilesManagementServices;
using DownloadFileServices;
using CSSPDBPreferenceServices;
using CSSPDBFilesManagementModels;
using CSSPDBLocalServices;

namespace CreateGzFileLocalServices.Tests
{
    public partial class CreateGzFileLocalServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IPostTVItemModelService PostTVItemModelService { get; set; }
        private IReadGzFileService ReadGzFileService { get; set; }
        private ICreateGzFileLocalService CreateGzFileLocalService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private CSSPDBLocalContext dbLocalTest { get; set; }
        private string CSSPJSONPathLocal { get; set; }
        private Contact contact { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests Generated CRUD
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspcreategzfilelocalservicestests.json")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
            Assert.NotNull(CSSPJSONPathLocal);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPDBFilesManagementService, CSSPDBFilesManagementService>();
            Services.AddSingleton<IPostTVItemModelService, PostTVItemModelService>();
            Services.AddSingleton<IDownloadFileService, DownloadFileService>();
            Services.AddSingleton<IReadGzFileService, ReadGzFileService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IScrambleService, ScrambleService>();
            Services.AddSingleton<IPreferenceService, PreferenceService>();
            Services.AddSingleton<ICreateGzFileLocalService, CreateGzFileLocalService>();

            /* ---------------------------------------------------------------------------------
             * using CSSPDBLocalTest
             * ---------------------------------------------------------------------------------
             */
            string CSSPDBLocalTest = Configuration.GetValue<string>("CSSPDBLocalTest");
            Assert.NotNull(CSSPDBLocalTest);

            FileInfo fiCSSPDBLocalTest = new FileInfo(CSSPDBLocalTest);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocalTest.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBFilesManagement
             * ---------------------------------------------------------------------------------
             */
            string CSSPDBFilesManagementFileName = Configuration.GetValue<string>("CSSPDBFilesManagement");
            Assert.NotNull(CSSPDBFilesManagementFileName);

            FileInfo fiCSSPDBFilesManagementFileName = new FileInfo(CSSPDBFilesManagementFileName);

            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBFilesManagementFileName.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using CSSPDBPreference
             * ---------------------------------------------------------------------------------
             */
            string CSSPDBPreferenceFileName = Configuration.GetValue<string>("CSSPDBPreference");
            Assert.NotNull(CSSPDBPreferenceFileName);

            FileInfo fiCSSPDBPreferenceFileName = new FileInfo(CSSPDBPreferenceFileName);

            Services.AddDbContext<CSSPDBPreferenceContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBPreferenceFileName.FullName }");
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            await LoggedInService.SetLoggedInLocalContactInfo();
            Assert.NotNull(LoggedInService.LoggedInContactInfo);

            CreateGzFileLocalService = Provider.GetService<ICreateGzFileLocalService>();
            Assert.NotNull(CreateGzFileLocalService);

            ReadGzFileService = Provider.GetService<IReadGzFileService>();
            Assert.NotNull(ReadGzFileService);

            PostTVItemModelService = Provider.GetService<IPostTVItemModelService>();
            Assert.NotNull(PostTVItemModelService);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            Assert.True(await LoggedInService.SetLoggedInLocalContactInfo());

            dbLocalTest = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocalTest);

            List<string> ExistingTableList = new List<string>();

            using (var command = dbLocalTest.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
                dbLocalTest.Database.OpenConnection();
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        ExistingTableList.Add(result.GetString(0));
                    }
                }
            }

            foreach (string tableName in ExistingTableList)
            {
                string TableIDName = "";

                if (tableName.StartsWith("AspNet") || tableName.StartsWith("DeviceCode") || tableName.StartsWith("Persisted")) continue;

                if (tableName == "Addresses")
                {
                    TableIDName = tableName.Substring(0, tableName.Length - 2) + "ID";
                }
                else
                {
                    TableIDName = tableName.Substring(0, tableName.Length - 1) + "ID";
                }

                dbLocalTest.Database.ExecuteSqlRaw($"DELETE FROM { tableName }");
            }
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
