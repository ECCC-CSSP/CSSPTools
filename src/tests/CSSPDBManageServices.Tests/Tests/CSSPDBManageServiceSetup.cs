using CSSPCultureServices.Services;
using LoggedInServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ManageServices.Tests
{
    [Collection("Sequential")]
    public partial class ManageServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection Services { get; set; }
        private IServiceProvider Provider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICommandLogService CommandLogService { get; set; }
        private IManageFileService ManageFileService { get; set; }
        private CSSPDBManageContext dbManage { get; set; }
        #endregion Properties

        #region Constructors
        public ManageServicesTests()
        {
        }
        #endregion Constructors

        #region Tests
        #endregion Tests

        #region Functions private
        private async Task<bool> CSSPDBManageServiceSetup(string culture)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings_csspdbmanageservicestests.json")
                .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ICommandLogService, CommandLogService>();
            Services.AddSingleton<IManageFileService, ManageFileService>();

            Assert.NotNull(Configuration["CSSPDBManage"]);

            FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"].Replace("_test", ""));
            Assert.True(fiCSSPDBManage.Exists);

            FileInfo fiCSSPDBManageTest = new FileInfo(Configuration["CSSPDBManage"]);
            if (!fiCSSPDBManageTest.Exists)
            {
                try
                {
                    File.Copy(fiCSSPDBManage.FullName, fiCSSPDBManageTest.FullName);
                }
                catch (Exception ex)
                {
                    Assert.True(false, $"Could not copy {fiCSSPDBManage.FullName} to {fiCSSPDBManageTest.FullName}. Ex: {ex.Message}");
                }
            }

            /* ---------------------------------------------------------------------------------
             * CSSPDBManageContext
             * ---------------------------------------------------------------------------------      
             */
            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManageTest.FullName }");
            });

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            ManageFileService = Provider.GetService<IManageFileService>();
            Assert.NotNull(ManageFileService);

            CommandLogService = Provider.GetService<ICommandLogService>();
            Assert.NotNull(CommandLogService);

            dbManage = Provider.GetService<CSSPDBManageContext>();
            Assert.NotNull(dbManage);

            List<CommandLog> commandLogToDeleteList = (from c in dbManage.CommandLogs
                                                       select c).ToList();

            try
            {
                dbManage.CommandLogs.RemoveRange(commandLogToDeleteList);
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Could not delete all CommandLogs from {fiCSSPDBManageTest.FullName}. Ex: { ex.Message }");
            }

            List<ManageFile> manageFileToDeleteList = (from c in dbManage.ManageFiles
                                                       select c).ToList();

            try
            {
                dbManage.ManageFiles.RemoveRange(manageFileToDeleteList);
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Could not delete all ManageFiles from {fiCSSPDBManageTest.FullName}. Ex: { ex.Message }");
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
