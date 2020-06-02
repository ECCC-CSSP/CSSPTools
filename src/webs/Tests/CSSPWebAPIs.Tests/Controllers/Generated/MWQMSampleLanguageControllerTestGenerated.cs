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
    public partial class MWQMSampleLanguageControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMWQMSampleLanguageService mwqmSampleLanguageService { get; set; }
        private IMWQMSampleLanguageController mwqmSampleLanguageController { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleLanguageControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSampleLanguageController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mwqmSampleLanguageService);
            Assert.NotNull(mwqmSampleLanguageController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSampleLanguageController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionMWQMSampleLanguageList = await mwqmSampleLanguageController.Get();
               Assert.Equal(200, ((ObjectResult)actionMWQMSampleLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSampleLanguageList.Result).Value);
               List<MWQMSampleLanguage> mwqmSampleLanguageList = (List<MWQMSampleLanguage>)(((OkObjectResult)actionMWQMSampleLanguageList.Result).Value);

               int count = ((List<MWQMSampleLanguage>)((OkObjectResult)actionMWQMSampleLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(MWQMSampleLanguageID)
               var actionMWQMSampleLanguage = await mwqmSampleLanguageController.Get(mwqmSampleLanguageList[0].MWQMSampleLanguageID);
               Assert.Equal(200, ((ObjectResult)actionMWQMSampleLanguage.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSampleLanguage.Result).Value);
               MWQMSampleLanguage mwqmSampleLanguage = (MWQMSampleLanguage)(((OkObjectResult)actionMWQMSampleLanguage.Result).Value);
               Assert.NotNull(mwqmSampleLanguage);
               Assert.Equal(mwqmSampleLanguageList[0].MWQMSampleLanguageID, mwqmSampleLanguage.MWQMSampleLanguageID);

               // testing Post(MWQMSampleLanguage mwqmSampleLanguage)
               mwqmSampleLanguage.MWQMSampleLanguageID = 0;
               var actionMWQMSampleLanguageNew = await mwqmSampleLanguageController.Post(mwqmSampleLanguage);
               Assert.Equal(200, ((ObjectResult)actionMWQMSampleLanguageNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSampleLanguageNew.Result).Value);
               MWQMSampleLanguage mwqmSampleLanguageNew = (MWQMSampleLanguage)(((OkObjectResult)actionMWQMSampleLanguageNew.Result).Value);
               Assert.NotNull(mwqmSampleLanguageNew);

               // testing Put(MWQMSampleLanguage mwqmSampleLanguage)
               var actionMWQMSampleLanguageUpdate = await mwqmSampleLanguageController.Put(mwqmSampleLanguageNew);
               Assert.Equal(200, ((ObjectResult)actionMWQMSampleLanguageUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSampleLanguageUpdate.Result).Value);
               MWQMSampleLanguage mwqmSampleLanguageUpdate = (MWQMSampleLanguage)(((OkObjectResult)actionMWQMSampleLanguageUpdate.Result).Value);
               Assert.NotNull(mwqmSampleLanguageUpdate);

               // testing Delete(MWQMSampleLanguage mwqmSampleLanguage)
               var actionMWQMSampleLanguageDelete = await mwqmSampleLanguageController.Delete(mwqmSampleLanguageUpdate);
               Assert.Equal(200, ((ObjectResult)actionMWQMSampleLanguageDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSampleLanguageDelete.Result).Value);
               MWQMSampleLanguage mwqmSampleLanguageDelete = (MWQMSampleLanguage)(((OkObjectResult)actionMWQMSampleLanguageDelete.Result).Value);
               Assert.NotNull(mwqmSampleLanguageDelete);
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
            Services.AddSingleton<IMWQMSampleLanguageService, MWQMSampleLanguageService>();
            Services.AddSingleton<IMWQMSampleLanguageController, MWQMSampleLanguageController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            mwqmSampleLanguageService = Provider.GetService<IMWQMSampleLanguageService>();
            Assert.NotNull(mwqmSampleLanguageService);
        
            await mwqmSampleLanguageService.SetCulture(culture);
        
            mwqmSampleLanguageController = Provider.GetService<IMWQMSampleLanguageController>();
            Assert.NotNull(mwqmSampleLanguageController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
