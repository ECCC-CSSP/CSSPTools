/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPEnums;
using LoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPLogServices.Tests
{
    [Collection("Sequential")]
    public partial class CSSPLogServiceTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICSSPLogService CSSPLogService { get; set; }
        private CSSPDBManageContext dbManage { get; set; }
        private string appsettings { get; set; } = "appsettings_cssplogservicestests.json";
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests Generated CRUD
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> CSSPLogServiceSetup(string culture, int ErrNumber = 0)
        {
            if (ErrNumber == 1)
            {
                appsettings = "appsettings_cssplogservicestests_err1.json";
            }

            if (ErrNumber == 2)
            {
                appsettings = "appsettings_cssplogservicestests_err2.json";
            }

            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile(appsettings)
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            FileInfo fiCSSPDBManageTest = new FileInfo("C:\\CSSPDesktop\\cssplocaldatabases\\CSSPDBManage.db");

            if (ErrNumber != 2)
            {

                /* ---------------------------------------------------------------------------------
                 * Creating an empty CSSPDBManage SQLite test database
                 * ---------------------------------------------------------------------------------      
                 */
                Assert.NotNull(Configuration["CSSPDBManage"]);

                string CSSPDBManageTest = Configuration["CSSPDBManage"].Replace(".db", "_test.db");

                Assert.NotNull(Configuration["ComputerName"]);

                FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
                Assert.True(fiCSSPDBManage.Exists);

                fiCSSPDBManageTest = new FileInfo(CSSPDBManageTest);
                try
                {
                    File.Copy(fiCSSPDBManage.FullName, fiCSSPDBManageTest.FullName, true);
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

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<ICSSPLogService, CSSPLogService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            if (ErrNumber != 2)
            {
                CSSPLogService = Provider.GetService<ICSSPLogService>();
                Assert.NotNull(CSSPLogService);

                LoggedInService = Provider.GetService<ILoggedInService>();
                Assert.NotNull(LoggedInService);

                await LoggedInService.SetLoggedInLocalContactInfo();
                Assert.NotNull(LoggedInService.LoggedInContactInfo);
                Assert.NotNull(LoggedInService.LoggedInContactInfo.LoggedInContact);
            }
            else
            {
                try
                {
                    CSSPLogService = Provider.GetService<ICSSPLogService>();
                    Assert.NotNull(CSSPLogService);
                }
                catch (Exception ex)
                {
                    Assert.Equal(string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPDBManage", "LoggedInService"), ex.Message);
                }
            }          

            if (ErrNumber != 2)
            {
                CSSPLogService.CSSPAppName = "CSSPLogService_AppName";
                CSSPLogService.CSSPCommandName = "CSSPLogService_CommandName";

                dbManage = Provider.GetService<CSSPDBManageContext>();
                Assert.NotNull(dbManage);

                List<CommandLog> commandLogToDeleteList = (from c in dbManage.CommandLogs
                                                           select c).ToList();

                try
                {
                    dbManage.RemoveRange(commandLogToDeleteList);
                    dbManage.SaveChanges();
                }
                catch (Exception ex)
                {
                    Assert.True(false, $"Could not delete all CommandLogs from {fiCSSPDBManageTest.FullName}. Ex: { ex.Message }");
                }

            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
