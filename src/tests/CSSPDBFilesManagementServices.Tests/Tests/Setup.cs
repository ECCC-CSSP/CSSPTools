using CSSPDBModels;
using CSSPCultureServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPDBPreferenceModels;
using CSSPDBFilesManagementModels;
using LoggedInServices;
using System.Linq;
using CSSPScrambleServices;

namespace FilesManagementServices.Tests
{
    public partial class FilesManagementServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection Services { get; set; }
        private IServiceProvider Provider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IFilesManagementService FilesManagementService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private string FilesManagementFileName { get; set; }
        private string FilesManagementFileNameTest { get; set; }
        private string CSSPDBPreferenceFileName { get; set; }
        private CSSPDBFilesManagementContext dbFile { get; set; }
        #endregion Properties

        #region Constructors
        public FilesManagementServicesTests()
        {
        }
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings_csspdbfilesmanagementervicestests.json")
                .AddUserSecrets("27667b6d-6208-4074-be00-1041ba61f0c0")
                .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);
            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IScrambleService, ScrambleService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IFilesManagementService, FilesManagementService>();


            FilesManagementFileName = Configuration.GetValue<string>("CSSPDBFilesManagement");
            Assert.NotNull(FilesManagementFileName);

            FileInfo fiFilesManagementFileName = new FileInfo(FilesManagementFileName);
            Assert.True(fiFilesManagementFileName.Exists);

            FilesManagementFileNameTest = Configuration.GetValue<string>("CSSPDBFilesManagementTest");
            Assert.NotNull(FilesManagementFileName);

            FileInfo fiFilesManagementFileNameTest = new FileInfo(FilesManagementFileNameTest);
            if (!fiFilesManagementFileNameTest.Exists)
            {
                try
                {
                    File.Copy(fiFilesManagementFileName.FullName, fiFilesManagementFileNameTest.FullName);
                }
                catch (Exception ex)
                {
                    Assert.True(false, ex.Message);
                }
            }

            /* ---------------------------------------------------------------------------------
             * using CSSPDBPreference
             * ---------------------------------------------------------------------------------      
             */
            CSSPDBPreferenceFileName = Configuration.GetValue<string>("CSSPDBPreference");
            Assert.NotNull(CSSPDBPreferenceFileName);

            FileInfo fiCSSPDBPreference = new FileInfo(CSSPDBPreferenceFileName);
            Assert.True(fiCSSPDBPreference.Exists);

            Services.AddDbContext<CSSPDBPreferenceContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBPreference.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using FilesManagements
             * ---------------------------------------------------------------------------------      
             */

            Services.AddDbContext<CSSPDBFilesManagementContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiFilesManagementFileNameTest.FullName }");
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
            Assert.NotNull(LoggedInService.LoggedInContactInfo.LoggedInContact);

            FilesManagementService = Provider.GetService<IFilesManagementService>();
            Assert.NotNull(FilesManagementService);

            dbFile = Provider.GetService<CSSPDBFilesManagementContext>();
            Assert.NotNull(dbFile);

            List<FilesManagement> fmList = (from c in dbFile.FilesManagements
                                            select c).ToList();

            try
            {
                dbFile.FilesManagements.RemoveRange(fmList);
                dbFile.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
