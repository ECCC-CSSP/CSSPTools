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
    public partial class TVItemLanguageControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ITVItemLanguageService tvItemLanguageService { get; set; }
        private ITVItemLanguageController tvItemLanguageController { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLanguageControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVItemLanguageController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(tvItemLanguageService);
            Assert.NotNull(tvItemLanguageController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVItemLanguageController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionTVItemLanguageList = await tvItemLanguageController.Get();
               Assert.Equal(200, ((ObjectResult)actionTVItemLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemLanguageList.Result).Value);
               List<TVItemLanguage> tvItemLanguageList = (List<TVItemLanguage>)(((OkObjectResult)actionTVItemLanguageList.Result).Value);

               int count = ((List<TVItemLanguage>)((OkObjectResult)actionTVItemLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(TVItemLanguageID)
               var actionTVItemLanguage = await tvItemLanguageController.Get(tvItemLanguageList[0].TVItemLanguageID);
               Assert.Equal(200, ((ObjectResult)actionTVItemLanguage.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemLanguage.Result).Value);
               TVItemLanguage tvItemLanguage = (TVItemLanguage)(((OkObjectResult)actionTVItemLanguage.Result).Value);
               Assert.NotNull(tvItemLanguage);
               Assert.Equal(tvItemLanguageList[0].TVItemLanguageID, tvItemLanguage.TVItemLanguageID);

               // testing Post(TVItemLanguage tvItemLanguage)
               tvItemLanguage.TVItemLanguageID = 0;
               var actionTVItemLanguageNew = await tvItemLanguageController.Post(tvItemLanguage);
               Assert.Equal(200, ((ObjectResult)actionTVItemLanguageNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemLanguageNew.Result).Value);
               TVItemLanguage tvItemLanguageNew = (TVItemLanguage)(((OkObjectResult)actionTVItemLanguageNew.Result).Value);
               Assert.NotNull(tvItemLanguageNew);

               // testing Put(TVItemLanguage tvItemLanguage)
               var actionTVItemLanguageUpdate = await tvItemLanguageController.Put(tvItemLanguageNew);
               Assert.Equal(200, ((ObjectResult)actionTVItemLanguageUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemLanguageUpdate.Result).Value);
               TVItemLanguage tvItemLanguageUpdate = (TVItemLanguage)(((OkObjectResult)actionTVItemLanguageUpdate.Result).Value);
               Assert.NotNull(tvItemLanguageUpdate);

               // testing Delete(TVItemLanguage tvItemLanguage)
               var actionTVItemLanguageDelete = await tvItemLanguageController.Delete(tvItemLanguageUpdate);
               Assert.Equal(200, ((ObjectResult)actionTVItemLanguageDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemLanguageDelete.Result).Value);
               TVItemLanguage tvItemLanguageDelete = (TVItemLanguage)(((OkObjectResult)actionTVItemLanguageDelete.Result).Value);
               Assert.NotNull(tvItemLanguageDelete);
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
            Services.AddSingleton<ITVItemLanguageService, TVItemLanguageService>();
            Services.AddSingleton<ITVItemLanguageController, TVItemLanguageController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            tvItemLanguageService = Provider.GetService<ITVItemLanguageService>();
            Assert.NotNull(tvItemLanguageService);
        
            await tvItemLanguageService.SetCulture(culture);
        
            tvItemLanguageController = Provider.GetService<ITVItemLanguageController>();
            Assert.NotNull(tvItemLanguageController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
