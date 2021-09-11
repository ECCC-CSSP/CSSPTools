/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Services;
using CSSPEnums;
using LoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using CSSPLogServices.Models;

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
        private CSSPLogServiceConfigModel config { get; set; }
        #endregion Properties

        #region Constructors
        #endregion Constructors

        #region Tests Generated CRUD
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            config = new CSSPLogServiceConfigModel();

            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_cssplogservicestests.json")
               //.AddUserSecrets("9991f472-24ee-41c9-971f-2d92278f2970")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            /* ---------------------------------------------------------------------------------
             * Creating an empty CSSPDBManage SQLite test database
             * ---------------------------------------------------------------------------------      
             */
            config.CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            Assert.NotNull(config.CSSPDBManage);

            config.CSSPDBManageTest = config.CSSPDBManage.Replace(".db", "_test.db");

            config.ComputerName = Configuration.GetValue<string>("ComputerName");
            Assert.NotNull(config.ComputerName);

            FileInfo fiCSSPDBManage = new FileInfo(config.CSSPDBManage);

            Assert.True(fiCSSPDBManage.Exists);

            FileInfo fiCSSPDBManageTest = new FileInfo(config.CSSPDBManageTest);
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

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<ICSSPLogService, CSSPLogService>();

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

            CSSPLogService = Provider.GetService<ICSSPLogService>();
            Assert.NotNull(CSSPLogService);

            CSSPLogService.CSSPAppName = "CSSPLogService_AppName";
            CSSPLogService.CSSPCommandName = "CSSPLogService_CommandName";

            CSSPLogService.FillConfigModel(config);

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

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
