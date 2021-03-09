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
        private IScrambleService ScrambleService { get; set; }
        private CSSPDBLocalContext dbLocalTest { get; set; }
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
            if (di.Exists)
            {
                try
                {
                    di.Delete(true);
                    di.Create(); // creates "C:\\CSSPDesktop\\csspjsonlocaltest\\"
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }
            else
            {
                try
                {
                    di.Create();
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            /* ---------------------------------------------------------------------------------
             * using Copying CSSPDBLocal To CSSPDBLocalTest
             * ---------------------------------------------------------------------------------      
             */

            string CSSPDBLocal = Configuration.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            string CSSPDBLocalTest = Configuration.GetValue<string>("CSSPDBLocalTest");
            Assert.NotNull(CSSPDBLocalTest);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);
            FileInfo fiCSSPDBLocalTest = new FileInfo(CSSPDBLocalTest);

            if (!fiCSSPDBLocal.Exists)
            {
                Assert.True(false, $"File does not exist { fiCSSPDBLocal.FullName }");
            }

            if (!fiCSSPDBLocalTest.Exists)
            {
                try
                {
                    File.Copy(fiCSSPDBLocal.FullName, fiCSSPDBLocalTest.FullName);
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }
            else
            {
                if (fiCSSPDBLocalTest.Length < 200)
                {
                    try
                    {
                        fiCSSPDBLocalTest.Delete();
                        File.Copy(fiCSSPDBLocal.FullName, fiCSSPDBLocalTest.FullName);
                    }
                    catch (Exception ex)
                    {
                        Assert.True(false, ex.Message);
                    }
                }
            }


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

            ScrambleService = Provider.GetService<IScrambleService>();
            Assert.NotNull(ScrambleService);

            AzureStore = ScrambleService.Descramble(Configuration.GetValue<string>("AzureStore"));
            Assert.NotNull(AzureStore);

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
