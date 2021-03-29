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
using LoggedInServices;
using CSSPDBCommandLogModels;
using CSSPDBCommandLogServices;
using System.Linq;
using CSSPScrambleServices;

namespace CommandLogServices.Tests
{
    public partial class CommandLogServicesTests
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceCollection Services { get; set; }
        private IServiceProvider Provider { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICommandLogService CommandLogService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private string CommandLogFileName { get; set; }
        private string CommandLogFileNameTest { get; set; }
        private string CSSPDBPreferenceFileName { get; set; }
        private CSSPDBCommandLogContext dbCommandLog { get; set; }
        #endregion Properties

        #region Constructors
        public CommandLogServicesTests()
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
                .AddJsonFile("appsettings_csspdbcommandlogservicestests.json")
                .AddUserSecrets("48e29e5a-1f36-42a7-ad09-cc1f51c56c46")
                .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);
            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IScrambleService, ScrambleService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<ICommandLogService, CommandLogService>();

            CommandLogFileName = Configuration.GetValue<string>("CSSPDBCommandLog");
            Assert.NotNull(CommandLogFileName);

            FileInfo fiCommandLogFileName = new FileInfo(CommandLogFileName);
            Assert.True(fiCommandLogFileName.Exists);

            CommandLogFileNameTest = Configuration.GetValue<string>("CSSPDBCommandLogTest");
            Assert.NotNull(CommandLogFileName);

            FileInfo fiCommandLogFileNameTest = new FileInfo(CommandLogFileNameTest);
            if (!fiCommandLogFileNameTest.Exists)
            {
                try
                {
                    File.Copy(fiCommandLogFileName.FullName, fiCommandLogFileNameTest.FullName);
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
             * using CommandLogs
             * ---------------------------------------------------------------------------------      
             */

            Services.AddDbContext<CSSPDBCommandLogContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCommandLogFileNameTest.FullName }");
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

            CommandLogService = Provider.GetService<ICommandLogService>();
            Assert.NotNull(CommandLogService);

            dbCommandLog = Provider.GetService<CSSPDBCommandLogContext>();
            Assert.NotNull(dbCommandLog);

            List<CommandLog> commandLogList = (from c in dbCommandLog.CommandLogs
                                            select c).ToList();

            try
            {
                dbCommandLog.CommandLogs.RemoveRange(commandLogList);
                dbCommandLog.SaveChanges();
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
