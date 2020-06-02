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
    public partial class MWQMSampleControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMWQMSampleService mwqmSampleService { get; set; }
        private IMWQMSampleController mwqmSampleController { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSampleController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mwqmSampleService);
            Assert.NotNull(mwqmSampleController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSampleController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionMWQMSampleList = await mwqmSampleController.Get();
               Assert.Equal(200, ((ObjectResult)actionMWQMSampleList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSampleList.Result).Value);
               List<MWQMSample> mwqmSampleList = (List<MWQMSample>)(((OkObjectResult)actionMWQMSampleList.Result).Value);

               int count = ((List<MWQMSample>)((OkObjectResult)actionMWQMSampleList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(MWQMSampleID)
               var actionMWQMSample = await mwqmSampleController.Get(mwqmSampleList[0].MWQMSampleID);
               Assert.Equal(200, ((ObjectResult)actionMWQMSample.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSample.Result).Value);
               MWQMSample mwqmSample = (MWQMSample)(((OkObjectResult)actionMWQMSample.Result).Value);
               Assert.NotNull(mwqmSample);
               Assert.Equal(mwqmSampleList[0].MWQMSampleID, mwqmSample.MWQMSampleID);

               // testing Post(MWQMSample mwqmSample)
               mwqmSample.MWQMSampleID = 0;
               var actionMWQMSampleNew = await mwqmSampleController.Post(mwqmSample);
               Assert.Equal(200, ((ObjectResult)actionMWQMSampleNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSampleNew.Result).Value);
               MWQMSample mwqmSampleNew = (MWQMSample)(((OkObjectResult)actionMWQMSampleNew.Result).Value);
               Assert.NotNull(mwqmSampleNew);

               // testing Put(MWQMSample mwqmSample)
               var actionMWQMSampleUpdate = await mwqmSampleController.Put(mwqmSampleNew);
               Assert.Equal(200, ((ObjectResult)actionMWQMSampleUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSampleUpdate.Result).Value);
               MWQMSample mwqmSampleUpdate = (MWQMSample)(((OkObjectResult)actionMWQMSampleUpdate.Result).Value);
               Assert.NotNull(mwqmSampleUpdate);

               // testing Delete(MWQMSample mwqmSample)
               var actionMWQMSampleDelete = await mwqmSampleController.Delete(mwqmSampleUpdate);
               Assert.Equal(200, ((ObjectResult)actionMWQMSampleDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSampleDelete.Result).Value);
               MWQMSample mwqmSampleDelete = (MWQMSample)(((OkObjectResult)actionMWQMSampleDelete.Result).Value);
               Assert.NotNull(mwqmSampleDelete);
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
            Services.AddSingleton<IMWQMSampleService, MWQMSampleService>();
            Services.AddSingleton<IMWQMSampleController, MWQMSampleController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            mwqmSampleService = Provider.GetService<IMWQMSampleService>();
            Assert.NotNull(mwqmSampleService);
        
            await mwqmSampleService.SetCulture(culture);
        
            mwqmSampleController = Provider.GetService<IMWQMSampleController>();
            Assert.NotNull(mwqmSampleController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
