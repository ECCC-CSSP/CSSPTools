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
    public partial class ReportSectionControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IReportSectionService reportSectionService { get; set; }
        private IReportSectionController reportSectionController { get; set; }
        #endregion Properties

        #region Constructors
        public ReportSectionControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ReportSectionController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(reportSectionService);
            Assert.NotNull(reportSectionController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ReportSectionController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionReportSectionList = await reportSectionController.Get();
               Assert.Equal(200, ((ObjectResult)actionReportSectionList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionReportSectionList.Result).Value);
               List<ReportSection> reportSectionList = (List<ReportSection>)(((OkObjectResult)actionReportSectionList.Result).Value);

               int count = ((List<ReportSection>)((OkObjectResult)actionReportSectionList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(ReportSectionID)
               var actionReportSection = await reportSectionController.Get(reportSectionList[0].ReportSectionID);
               Assert.Equal(200, ((ObjectResult)actionReportSection.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionReportSection.Result).Value);
               ReportSection reportSection = (ReportSection)(((OkObjectResult)actionReportSection.Result).Value);
               Assert.NotNull(reportSection);
               Assert.Equal(reportSectionList[0].ReportSectionID, reportSection.ReportSectionID);

               // testing Post(ReportSection reportSection)
               reportSection.ReportSectionID = 0;
               var actionReportSectionNew = await reportSectionController.Post(reportSection);
               Assert.Equal(200, ((ObjectResult)actionReportSectionNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionReportSectionNew.Result).Value);
               ReportSection reportSectionNew = (ReportSection)(((OkObjectResult)actionReportSectionNew.Result).Value);
               Assert.NotNull(reportSectionNew);

               // testing Put(ReportSection reportSection)
               var actionReportSectionUpdate = await reportSectionController.Put(reportSectionNew);
               Assert.Equal(200, ((ObjectResult)actionReportSectionUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionReportSectionUpdate.Result).Value);
               ReportSection reportSectionUpdate = (ReportSection)(((OkObjectResult)actionReportSectionUpdate.Result).Value);
               Assert.NotNull(reportSectionUpdate);

               // testing Delete(ReportSection reportSection)
               var actionReportSectionDelete = await reportSectionController.Delete(reportSectionUpdate);
               Assert.Equal(200, ((ObjectResult)actionReportSectionDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionReportSectionDelete.Result).Value);
               ReportSection reportSectionDelete = (ReportSection)(((OkObjectResult)actionReportSectionDelete.Result).Value);
               Assert.NotNull(reportSectionDelete);
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
            Services.AddSingleton<IReportSectionService, ReportSectionService>();
            Services.AddSingleton<IReportSectionController, ReportSectionController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            reportSectionService = Provider.GetService<IReportSectionService>();
            Assert.NotNull(reportSectionService);
        
            await reportSectionService.SetCulture(culture);
        
            reportSectionController = Provider.GetService<IReportSectionController>();
            Assert.NotNull(reportSectionController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
