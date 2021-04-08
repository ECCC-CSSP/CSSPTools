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
using DownloadFileServices;
using CSSPDBFilesManagementModels;
using CSSPDBLocalServices;
using FilesManagementServices;

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
        private ITVItemLocalService PostTVItemModelService { get; set; }
        private IReadGzFileService ReadGzFileService { get; set; }
        private ICreateGzFileLocalService CreateGzFileLocalService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IScrambleService ScrambleService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private string CSSPJSONPath { get; set; }
        private string CSSPJSONPathLocal { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private string AzureStore { get; set; }
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
               .AddUserSecrets("188587c9-b0c4-4f06-a16f-0845e3f1b425")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            Assert.NotNull(AzureStoreCSSPJSONPath);

            CSSPJSONPath = Configuration.GetValue<string>("CSSPJSONPath");
            Assert.NotNull(CSSPJSONPath);

            CSSPJSONPathLocal = Configuration.GetValue<string>("CSSPJSONPathLocal");
            Assert.NotNull(CSSPJSONPathLocal);

            DirectoryInfo di = new DirectoryInfo($"{ CSSPJSONPathLocal }");
            Assert.True(di.Exists);

            try
            {
                di.Delete(true);
                di.Create();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            if (!fiCSSPDBLocal.Exists)
            {
                Assert.True(false, $"File does not exist { fiCSSPDBLocal.FullName }");
            }

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IFilesManagementService, FilesManagementService>();
            Services.AddSingleton<ITVItemLocalService, TVItemLocalService>();
            Services.AddSingleton<IDownloadFileService, DownloadFileService>();
            Services.AddSingleton<IReadGzFileService, ReadGzFileService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IScrambleService, ScrambleService>();
            Services.AddSingleton<ICreateGzFileLocalService, CreateGzFileLocalService>();

            /* ---------------------------------------------------------------------------------
             * using CSSPDBLocal
             * ---------------------------------------------------------------------------------
             */

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
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

            PostTVItemModelService = Provider.GetService<ITVItemLocalService>();
            Assert.NotNull(PostTVItemModelService);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            Assert.True(await LoggedInService.SetLoggedInLocalContactInfo());

            ScrambleService = Provider.GetService<IScrambleService>();
            Assert.NotNull(ScrambleService);

            AzureStore = ScrambleService.Descramble(Configuration.GetValue<string>("AzureStore"));
            Assert.NotNull(AzureStore);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            ClearAllTable();

            return await Task.FromResult(true);
        }
        private void ClearAllTable()
        {
            List<string> ExistingTableList = new List<string>();

            using (var command = dbLocal.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%'";
                dbLocal.Database.OpenConnection();
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
                dbLocal.Database.ExecuteSqlRaw($"DELETE FROM { tableName }");
            }
        }
        #endregion Functions private
    }
}
