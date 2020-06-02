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
    public partial class MWQMSubsectorLanguageControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMWQMSubsectorLanguageService mwqmSubsectorLanguageService { get; set; }
        private IMWQMSubsectorLanguageController mwqmSubsectorLanguageController { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorLanguageControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSubsectorLanguageController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mwqmSubsectorLanguageService);
            Assert.NotNull(mwqmSubsectorLanguageController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSubsectorLanguageController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionMWQMSubsectorLanguageList = await mwqmSubsectorLanguageController.Get();
               Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSubsectorLanguageList.Result).Value);
               List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = (List<MWQMSubsectorLanguage>)(((OkObjectResult)actionMWQMSubsectorLanguageList.Result).Value);

               int count = ((List<MWQMSubsectorLanguage>)((OkObjectResult)actionMWQMSubsectorLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(MWQMSubsectorLanguageID)
               var actionMWQMSubsectorLanguage = await mwqmSubsectorLanguageController.Get(mwqmSubsectorLanguageList[0].MWQMSubsectorLanguageID);
               Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorLanguage.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSubsectorLanguage.Result).Value);
               MWQMSubsectorLanguage mwqmSubsectorLanguage = (MWQMSubsectorLanguage)(((OkObjectResult)actionMWQMSubsectorLanguage.Result).Value);
               Assert.NotNull(mwqmSubsectorLanguage);
               Assert.Equal(mwqmSubsectorLanguageList[0].MWQMSubsectorLanguageID, mwqmSubsectorLanguage.MWQMSubsectorLanguageID);

               // testing Post(MWQMSubsectorLanguage mwqmSubsectorLanguage)
               mwqmSubsectorLanguage.MWQMSubsectorLanguageID = 0;
               var actionMWQMSubsectorLanguageNew = await mwqmSubsectorLanguageController.Post(mwqmSubsectorLanguage);
               Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorLanguageNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSubsectorLanguageNew.Result).Value);
               MWQMSubsectorLanguage mwqmSubsectorLanguageNew = (MWQMSubsectorLanguage)(((OkObjectResult)actionMWQMSubsectorLanguageNew.Result).Value);
               Assert.NotNull(mwqmSubsectorLanguageNew);

               // testing Put(MWQMSubsectorLanguage mwqmSubsectorLanguage)
               var actionMWQMSubsectorLanguageUpdate = await mwqmSubsectorLanguageController.Put(mwqmSubsectorLanguageNew);
               Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorLanguageUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSubsectorLanguageUpdate.Result).Value);
               MWQMSubsectorLanguage mwqmSubsectorLanguageUpdate = (MWQMSubsectorLanguage)(((OkObjectResult)actionMWQMSubsectorLanguageUpdate.Result).Value);
               Assert.NotNull(mwqmSubsectorLanguageUpdate);

               // testing Delete(MWQMSubsectorLanguage mwqmSubsectorLanguage)
               var actionMWQMSubsectorLanguageDelete = await mwqmSubsectorLanguageController.Delete(mwqmSubsectorLanguageUpdate);
               Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorLanguageDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSubsectorLanguageDelete.Result).Value);
               MWQMSubsectorLanguage mwqmSubsectorLanguageDelete = (MWQMSubsectorLanguage)(((OkObjectResult)actionMWQMSubsectorLanguageDelete.Result).Value);
               Assert.NotNull(mwqmSubsectorLanguageDelete);
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
            Services.AddSingleton<IMWQMSubsectorLanguageService, MWQMSubsectorLanguageService>();
            Services.AddSingleton<IMWQMSubsectorLanguageController, MWQMSubsectorLanguageController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            mwqmSubsectorLanguageService = Provider.GetService<IMWQMSubsectorLanguageService>();
            Assert.NotNull(mwqmSubsectorLanguageService);
        
            await mwqmSubsectorLanguageService.SetCulture(culture);
        
            mwqmSubsectorLanguageController = Provider.GetService<IMWQMSubsectorLanguageController>();
            Assert.NotNull(mwqmSubsectorLanguageController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
