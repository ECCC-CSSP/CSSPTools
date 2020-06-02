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
    public partial class MWQMSiteStartEndDateControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMWQMSiteStartEndDateService mwqmSiteStartEndDateService { get; set; }
        private IMWQMSiteStartEndDateController mwqmSiteStartEndDateController { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSiteStartEndDateController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mwqmSiteStartEndDateService);
            Assert.NotNull(mwqmSiteStartEndDateController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSiteStartEndDateController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionMWQMSiteStartEndDateList = await mwqmSiteStartEndDateController.Get();
               Assert.Equal(200, ((ObjectResult)actionMWQMSiteStartEndDateList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSiteStartEndDateList.Result).Value);
               List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = (List<MWQMSiteStartEndDate>)(((OkObjectResult)actionMWQMSiteStartEndDateList.Result).Value);

               int count = ((List<MWQMSiteStartEndDate>)((OkObjectResult)actionMWQMSiteStartEndDateList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(MWQMSiteStartEndDateID)
               var actionMWQMSiteStartEndDate = await mwqmSiteStartEndDateController.Get(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID);
               Assert.Equal(200, ((ObjectResult)actionMWQMSiteStartEndDate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSiteStartEndDate.Result).Value);
               MWQMSiteStartEndDate mwqmSiteStartEndDate = (MWQMSiteStartEndDate)(((OkObjectResult)actionMWQMSiteStartEndDate.Result).Value);
               Assert.NotNull(mwqmSiteStartEndDate);
               Assert.Equal(mwqmSiteStartEndDateList[0].MWQMSiteStartEndDateID, mwqmSiteStartEndDate.MWQMSiteStartEndDateID);

               // testing Post(MWQMSiteStartEndDate mwqmSiteStartEndDate)
               mwqmSiteStartEndDate.MWQMSiteStartEndDateID = 0;
               var actionMWQMSiteStartEndDateNew = await mwqmSiteStartEndDateController.Post(mwqmSiteStartEndDate);
               Assert.Equal(200, ((ObjectResult)actionMWQMSiteStartEndDateNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSiteStartEndDateNew.Result).Value);
               MWQMSiteStartEndDate mwqmSiteStartEndDateNew = (MWQMSiteStartEndDate)(((OkObjectResult)actionMWQMSiteStartEndDateNew.Result).Value);
               Assert.NotNull(mwqmSiteStartEndDateNew);

               // testing Put(MWQMSiteStartEndDate mwqmSiteStartEndDate)
               var actionMWQMSiteStartEndDateUpdate = await mwqmSiteStartEndDateController.Put(mwqmSiteStartEndDateNew);
               Assert.Equal(200, ((ObjectResult)actionMWQMSiteStartEndDateUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSiteStartEndDateUpdate.Result).Value);
               MWQMSiteStartEndDate mwqmSiteStartEndDateUpdate = (MWQMSiteStartEndDate)(((OkObjectResult)actionMWQMSiteStartEndDateUpdate.Result).Value);
               Assert.NotNull(mwqmSiteStartEndDateUpdate);

               // testing Delete(MWQMSiteStartEndDate mwqmSiteStartEndDate)
               var actionMWQMSiteStartEndDateDelete = await mwqmSiteStartEndDateController.Delete(mwqmSiteStartEndDateUpdate);
               Assert.Equal(200, ((ObjectResult)actionMWQMSiteStartEndDateDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSiteStartEndDateDelete.Result).Value);
               MWQMSiteStartEndDate mwqmSiteStartEndDateDelete = (MWQMSiteStartEndDate)(((OkObjectResult)actionMWQMSiteStartEndDateDelete.Result).Value);
               Assert.NotNull(mwqmSiteStartEndDateDelete);
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
            Services.AddSingleton<IMWQMSiteStartEndDateService, MWQMSiteStartEndDateService>();
            Services.AddSingleton<IMWQMSiteStartEndDateController, MWQMSiteStartEndDateController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            mwqmSiteStartEndDateService = Provider.GetService<IMWQMSiteStartEndDateService>();
            Assert.NotNull(mwqmSiteStartEndDateService);
        
            await mwqmSiteStartEndDateService.SetCulture(culture);
        
            mwqmSiteStartEndDateController = Provider.GetService<IMWQMSiteStartEndDateController>();
            Assert.NotNull(mwqmSiteStartEndDateController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
