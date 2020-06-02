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
    public partial class MWQMRunLanguageControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMWQMRunLanguageService mwqmRunLanguageService { get; set; }
        private IMWQMRunLanguageController mwqmRunLanguageController { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunLanguageControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMRunLanguageController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mwqmRunLanguageService);
            Assert.NotNull(mwqmRunLanguageController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMRunLanguageController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionMWQMRunLanguageList = await mwqmRunLanguageController.Get();
               Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageList.Result).Value);
               List<MWQMRunLanguage> mwqmRunLanguageList = (List<MWQMRunLanguage>)(((OkObjectResult)actionMWQMRunLanguageList.Result).Value);

               int count = ((List<MWQMRunLanguage>)((OkObjectResult)actionMWQMRunLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(MWQMRunLanguageID)
               var actionMWQMRunLanguage = await mwqmRunLanguageController.Get(mwqmRunLanguageList[0].MWQMRunLanguageID);
               Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguage.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMRunLanguage.Result).Value);
               MWQMRunLanguage mwqmRunLanguage = (MWQMRunLanguage)(((OkObjectResult)actionMWQMRunLanguage.Result).Value);
               Assert.NotNull(mwqmRunLanguage);
               Assert.Equal(mwqmRunLanguageList[0].MWQMRunLanguageID, mwqmRunLanguage.MWQMRunLanguageID);

               // testing Post(MWQMRunLanguage mwqmRunLanguage)
               mwqmRunLanguage.MWQMRunLanguageID = 0;
               var actionMWQMRunLanguageNew = await mwqmRunLanguageController.Post(mwqmRunLanguage);
               Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageNew.Result).Value);
               MWQMRunLanguage mwqmRunLanguageNew = (MWQMRunLanguage)(((OkObjectResult)actionMWQMRunLanguageNew.Result).Value);
               Assert.NotNull(mwqmRunLanguageNew);

               // testing Put(MWQMRunLanguage mwqmRunLanguage)
               var actionMWQMRunLanguageUpdate = await mwqmRunLanguageController.Put(mwqmRunLanguageNew);
               Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageUpdate.Result).Value);
               MWQMRunLanguage mwqmRunLanguageUpdate = (MWQMRunLanguage)(((OkObjectResult)actionMWQMRunLanguageUpdate.Result).Value);
               Assert.NotNull(mwqmRunLanguageUpdate);

               // testing Delete(MWQMRunLanguage mwqmRunLanguage)
               var actionMWQMRunLanguageDelete = await mwqmRunLanguageController.Delete(mwqmRunLanguageUpdate);
               Assert.Equal(200, ((ObjectResult)actionMWQMRunLanguageDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMRunLanguageDelete.Result).Value);
               MWQMRunLanguage mwqmRunLanguageDelete = (MWQMRunLanguage)(((OkObjectResult)actionMWQMRunLanguageDelete.Result).Value);
               Assert.NotNull(mwqmRunLanguageDelete);
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
            Services.AddSingleton<IMWQMRunLanguageService, MWQMRunLanguageService>();
            Services.AddSingleton<IMWQMRunLanguageController, MWQMRunLanguageController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            mwqmRunLanguageService = Provider.GetService<IMWQMRunLanguageService>();
            Assert.NotNull(mwqmRunLanguageService);
        
            await mwqmRunLanguageService.SetCulture(culture);
        
            mwqmRunLanguageController = Provider.GetService<IMWQMRunLanguageController>();
            Assert.NotNull(mwqmRunLanguageController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
