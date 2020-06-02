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
    public partial class ReportTypeControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IReportTypeService reportTypeService { get; set; }
        private IReportTypeController reportTypeController { get; set; }
        #endregion Properties

        #region Constructors
        public ReportTypeControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ReportTypeController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(reportTypeService);
            Assert.NotNull(reportTypeController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ReportTypeController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionReportTypeList = await reportTypeController.Get();
                Assert.Equal(200, ((ObjectResult)actionReportTypeList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionReportTypeList.Result).Value);
                List<ReportType> reportTypeList = (List<ReportType>)(((OkObjectResult)actionReportTypeList.Result).Value);

                int count = ((List<ReportType>)((OkObjectResult)actionReportTypeList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(ReportTypeID)
                var actionReportType = await reportTypeController.Get(reportTypeList[0].ReportTypeID);
                Assert.Equal(200, ((ObjectResult)actionReportType.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionReportType.Result).Value);
                ReportType reportType = (ReportType)(((OkObjectResult)actionReportType.Result).Value);
                Assert.NotNull(reportType);
                Assert.Equal(reportTypeList[0].ReportTypeID, reportType.ReportTypeID);

                // testing Post(ReportType reportType)
                reportType.ReportTypeID = 0;
                var actionReportTypeNew = await reportTypeController.Post(reportType);
                Assert.Equal(200, ((ObjectResult)actionReportTypeNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionReportTypeNew.Result).Value);
                ReportType reportTypeNew = (ReportType)(((OkObjectResult)actionReportTypeNew.Result).Value);
                Assert.NotNull(reportTypeNew);

                // testing Put(ReportType reportType)
                var actionReportTypeUpdate = await reportTypeController.Put(reportTypeNew);
                Assert.Equal(200, ((ObjectResult)actionReportTypeUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionReportTypeUpdate.Result).Value);
                ReportType reportTypeUpdate = (ReportType)(((OkObjectResult)actionReportTypeUpdate.Result).Value);
                Assert.NotNull(reportTypeUpdate);

                // testing Delete(ReportType reportType)
                var actionReportTypeDelete = await reportTypeController.Delete(reportTypeUpdate);
                Assert.Equal(200, ((ObjectResult)actionReportTypeDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionReportTypeDelete.Result).Value);
                ReportType reportTypeDelete = (ReportType)(((OkObjectResult)actionReportTypeDelete.Result).Value);
                Assert.NotNull(reportTypeDelete);
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
            Services.AddSingleton<IReportTypeService, ReportTypeService>();
            Services.AddSingleton<IReportTypeController, ReportTypeController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            reportTypeService = Provider.GetService<IReportTypeService>();
            Assert.NotNull(reportTypeService);

            await reportTypeService.SetCulture(culture);

            reportTypeController = Provider.GetService<IReportTypeController>();
            Assert.NotNull(reportTypeController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
