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
    public partial class PolSourceObservationIssueControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IPolSourceObservationIssueService polSourceObservationIssueService { get; set; }
        private IPolSourceObservationIssueController polSourceObservationIssueController { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceObservationIssueController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(polSourceObservationIssueService);
            Assert.NotNull(polSourceObservationIssueController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceObservationIssueController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
                var actionPolSourceObservationIssueList = await polSourceObservationIssueController.Get();
                Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueList.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueList.Result).Value);
                List<PolSourceObservationIssue> polSourceObservationIssueList = (List<PolSourceObservationIssue>)(((OkObjectResult)actionPolSourceObservationIssueList.Result).Value);

                int count = ((List<PolSourceObservationIssue>)((OkObjectResult)actionPolSourceObservationIssueList.Result).Value).Count();
                Assert.True(count > 0);

                // testing Get(PolSourceObservationIssueID)
                var actionPolSourceObservationIssue = await polSourceObservationIssueController.Get(polSourceObservationIssueList[0].PolSourceObservationIssueID);
                Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssue.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssue.Result).Value);
                PolSourceObservationIssue polSourceObservationIssue = (PolSourceObservationIssue)(((OkObjectResult)actionPolSourceObservationIssue.Result).Value);
                Assert.NotNull(polSourceObservationIssue);
                Assert.Equal(polSourceObservationIssueList[0].PolSourceObservationIssueID, polSourceObservationIssue.PolSourceObservationIssueID);

                // testing Post(PolSourceObservationIssue polSourceObservationIssue)
                polSourceObservationIssue.PolSourceObservationIssueID = 0;
                var actionPolSourceObservationIssueNew = await polSourceObservationIssueController.Post(polSourceObservationIssue);
                Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueNew.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueNew.Result).Value);
                PolSourceObservationIssue polSourceObservationIssueNew = (PolSourceObservationIssue)(((OkObjectResult)actionPolSourceObservationIssueNew.Result).Value);
                Assert.NotNull(polSourceObservationIssueNew);

                // testing Put(PolSourceObservationIssue polSourceObservationIssue)
                var actionPolSourceObservationIssueUpdate = await polSourceObservationIssueController.Put(polSourceObservationIssueNew);
                Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueUpdate.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueUpdate.Result).Value);
                PolSourceObservationIssue polSourceObservationIssueUpdate = (PolSourceObservationIssue)(((OkObjectResult)actionPolSourceObservationIssueUpdate.Result).Value);
                Assert.NotNull(polSourceObservationIssueUpdate);

                // testing Delete(PolSourceObservationIssue polSourceObservationIssue)
                var actionPolSourceObservationIssueDelete = await polSourceObservationIssueController.Delete(polSourceObservationIssueUpdate);
                Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueDelete.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueDelete.Result).Value);
                PolSourceObservationIssue polSourceObservationIssueDelete = (PolSourceObservationIssue)(((OkObjectResult)actionPolSourceObservationIssueDelete.Result).Value);
                Assert.NotNull(polSourceObservationIssueDelete);
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
            Services.AddSingleton<IPolSourceObservationIssueService, PolSourceObservationIssueService>();
            Services.AddSingleton<IPolSourceObservationIssueController, PolSourceObservationIssueController>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);

            polSourceObservationIssueService = Provider.GetService<IPolSourceObservationIssueService>();
            Assert.NotNull(polSourceObservationIssueService);

            await polSourceObservationIssueService.SetCulture(culture);

            polSourceObservationIssueController = Provider.GetService<IPolSourceObservationIssueController>();
            Assert.NotNull(polSourceObservationIssueController);

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
