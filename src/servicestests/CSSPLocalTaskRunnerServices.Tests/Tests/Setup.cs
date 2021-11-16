/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace CSSPLocalTaskRunnerServices.Tests
{
    public partial class LocalTaskRunnerServiceTest
    {
        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
        private ICSSPLocalTaskRunnerService LocalTaskRunnerService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public LocalTaskRunnerServiceTest()
        {

        }
        #endregion Constructors

        private async Task<bool> Setup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_cssplocaltaskrunnerservicestests.json")
               .AddUserSecrets("9b381dff-914a-456f-baba-fda3113cecd2")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            /* ---------------------------------------------------------------------------------
             * CSSPDBManageContext
             * ---------------------------------------------------------------------------------
             */
            string CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            Assert.NotNull(CSSPDBManage);

            FileInfo fiCSSPDBManage = new FileInfo(CSSPDBManage);

            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
            });

            /* ---------------------------------------------------------------------------------
             * using AzureCSSPDB
             * ---------------------------------------------------------------------------------      
             */
            string AzureCSSPDB = Configuration.GetValue<string>("AzureCSSPDB");
            Assert.NotNull(AzureCSSPDB);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(AzureCSSPDB);
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPLocalTaskRunnerService, LocalTaskRunnerService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
            Assert.NotNull(CSSPLocalLoggedInService);

            Assert.True(await CSSPLocalLoggedInService.SetLoggedInContactInfo());

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            LocalTaskRunnerService = Provider.GetService<ICSSPLocalTaskRunnerService>();
            Assert.NotNull(LocalTaskRunnerService);

            return await Task.FromResult(true);
        }
    }
}
