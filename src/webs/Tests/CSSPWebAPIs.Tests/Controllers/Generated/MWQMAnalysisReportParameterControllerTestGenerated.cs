/* Auto generated from C:\CSSPTools\src\codegen\WebAPIClassNameControllerTestGenerated\bin\Debug\netcoreapp3.1\WebAPIClassNameControllerTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using CSSPWebAPI.Controllers;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using UserServices.Models;
using Xunit;

namespace CSSPWebAPIs.Tests.Controllers
{
    public partial class MWQMAnalysisReportParameterControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMWQMAnalysisReportParameterService mwqmAnalysisReportParameterService { get; set; }
        private IMWQMAnalysisReportParameterController mwqmAnalysisReportParameterController { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMAnalysisReportParameterControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMAnalysisReportParameterController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mwqmAnalysisReportParameterService);
            Assert.NotNull(mwqmAnalysisReportParameterController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMAnalysisReportParameterController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionMWQMAnalysisReportParameterList = await mwqmAnalysisReportParameterController.Get();
                Assert.Equal(200, ((ObjectResult)actionMWQMAnalysisReportParameterList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMAnalysisReportParameterList.Result).Value);
                List<MWQMAnalysisReportParameter> mwqmAnalysisReportParameterList = (List<MWQMAnalysisReportParameter>)((OkObjectResult)actionMWQMAnalysisReportParameterList.Result).Value;

                int count = ((List<MWQMAnalysisReportParameter>)((OkObjectResult)actionMWQMAnalysisReportParameterList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(MWQMAnalysisReportParameterID)
                var actionMWQMAnalysisReportParameter = await mwqmAnalysisReportParameterController.Get(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterID);
                Assert.Equal(200, ((ObjectResult)actionMWQMAnalysisReportParameter.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMAnalysisReportParameter.Result).Value);
                MWQMAnalysisReportParameter mwqmAnalysisReportParameter = (MWQMAnalysisReportParameter)((OkObjectResult)actionMWQMAnalysisReportParameter.Result).Value;
                Assert.NotNull(mwqmAnalysisReportParameter);
                Assert.Equal(mwqmAnalysisReportParameterList[0].MWQMAnalysisReportParameterID, mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID);

                // testing Post(MWQMAnalysisReportParameter mwqmAnalysisReportParameter)
                mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID = 0;
                var actionMWQMAnalysisReportParameterNew = await mwqmAnalysisReportParameterController.Post(mwqmAnalysisReportParameter);
                Assert.Equal(200, ((ObjectResult)actionMWQMAnalysisReportParameterNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMAnalysisReportParameterNew.Result).Value);
                MWQMAnalysisReportParameter mwqmAnalysisReportParameterNew = (MWQMAnalysisReportParameter)((OkObjectResult)actionMWQMAnalysisReportParameterNew.Result).Value;
                Assert.NotNull(mwqmAnalysisReportParameterNew);

                // testing Put(MWQMAnalysisReportParameter mwqmAnalysisReportParameter)
                var actionMWQMAnalysisReportParameterUpdate = await mwqmAnalysisReportParameterController.Put(mwqmAnalysisReportParameterNew);
                Assert.Equal(200, ((ObjectResult)actionMWQMAnalysisReportParameterUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMAnalysisReportParameterUpdate.Result).Value);
                MWQMAnalysisReportParameter mwqmAnalysisReportParameterUpdate = (MWQMAnalysisReportParameter)((OkObjectResult)actionMWQMAnalysisReportParameterUpdate.Result).Value;
                Assert.NotNull(mwqmAnalysisReportParameterUpdate);

                // testing Delete(int mwqmAnalysisReportParameter.MWQMAnalysisReportParameterID)
                var actionMWQMAnalysisReportParameterDelete = await mwqmAnalysisReportParameterController.Delete(mwqmAnalysisReportParameterUpdate.MWQMAnalysisReportParameterID);
                Assert.Equal(200, ((ObjectResult)actionMWQMAnalysisReportParameterDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMWQMAnalysisReportParameterDelete.Result).Value);
                bool retBool2 = (bool)((OkObjectResult)actionMWQMAnalysisReportParameterDelete.Result).Value;
                Assert.True(retBool2);
            }
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();

            Services = new ServiceCollection();

            IConfigurationSection connectionStringsSection = Config.GetSection("ConnectionStrings");
            Services.Configure<ConnectionStringsModel>(connectionStringsSection);

            ConnectionStringsModel connectionStrings = connectionStringsSection.Get<ConnectionStringsModel>();

            Services.AddSingleton<IConfiguration>(Config);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(connectionStrings.TestDB);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionStrings.TestDB));

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IMWQMAnalysisReportParameterService, MWQMAnalysisReportParameterService>();
            Services.AddSingleton<IMWQMAnalysisReportParameterController, MWQMAnalysisReportParameterController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            mwqmAnalysisReportParameterService = Provider.GetService<IMWQMAnalysisReportParameterService>();
            Assert.NotNull(mwqmAnalysisReportParameterService);

            await mwqmAnalysisReportParameterService.SetCulture(culture);

            mwqmAnalysisReportParameterController = Provider.GetService<IMWQMAnalysisReportParameterController>();
            Assert.NotNull(mwqmAnalysisReportParameterController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
