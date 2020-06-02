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
    public partial class PolSourceSiteEffectControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IPolSourceSiteEffectService polSourceSiteEffectService { get; set; }
        private IPolSourceSiteEffectController polSourceSiteEffectController { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceSiteEffectController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(polSourceSiteEffectService);
            Assert.NotNull(polSourceSiteEffectController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceSiteEffectController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionPolSourceSiteEffectList = await polSourceSiteEffectController.Get();
               Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectList.Result).Value);
               List<PolSourceSiteEffect> polSourceSiteEffectList = (List<PolSourceSiteEffect>)(((OkObjectResult)actionPolSourceSiteEffectList.Result).Value);

               int count = ((List<PolSourceSiteEffect>)((OkObjectResult)actionPolSourceSiteEffectList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(PolSourceSiteEffectID)
               var actionPolSourceSiteEffect = await polSourceSiteEffectController.Get(polSourceSiteEffectList[0].PolSourceSiteEffectID);
               Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffect.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffect.Result).Value);
               PolSourceSiteEffect polSourceSiteEffect = (PolSourceSiteEffect)(((OkObjectResult)actionPolSourceSiteEffect.Result).Value);
               Assert.NotNull(polSourceSiteEffect);
               Assert.Equal(polSourceSiteEffectList[0].PolSourceSiteEffectID, polSourceSiteEffect.PolSourceSiteEffectID);

               // testing Post(PolSourceSiteEffect polSourceSiteEffect)
               polSourceSiteEffect.PolSourceSiteEffectID = 0;
               var actionPolSourceSiteEffectNew = await polSourceSiteEffectController.Post(polSourceSiteEffect);
               Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectNew.Result).Value);
               PolSourceSiteEffect polSourceSiteEffectNew = (PolSourceSiteEffect)(((OkObjectResult)actionPolSourceSiteEffectNew.Result).Value);
               Assert.NotNull(polSourceSiteEffectNew);

               // testing Put(PolSourceSiteEffect polSourceSiteEffect)
               var actionPolSourceSiteEffectUpdate = await polSourceSiteEffectController.Put(polSourceSiteEffectNew);
               Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectUpdate.Result).Value);
               PolSourceSiteEffect polSourceSiteEffectUpdate = (PolSourceSiteEffect)(((OkObjectResult)actionPolSourceSiteEffectUpdate.Result).Value);
               Assert.NotNull(polSourceSiteEffectUpdate);

               // testing Delete(PolSourceSiteEffect polSourceSiteEffect)
               var actionPolSourceSiteEffectDelete = await polSourceSiteEffectController.Delete(polSourceSiteEffectUpdate);
               Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectDelete.Result).Value);
               PolSourceSiteEffect polSourceSiteEffectDelete = (PolSourceSiteEffect)(((OkObjectResult)actionPolSourceSiteEffectDelete.Result).Value);
               Assert.NotNull(polSourceSiteEffectDelete);
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
            Services.AddSingleton<IPolSourceSiteEffectService, PolSourceSiteEffectService>();
            Services.AddSingleton<IPolSourceSiteEffectController, PolSourceSiteEffectController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            polSourceSiteEffectService = Provider.GetService<IPolSourceSiteEffectService>();
            Assert.NotNull(polSourceSiteEffectService);
        
            await polSourceSiteEffectService.SetCulture(culture);
        
            polSourceSiteEffectController = Provider.GetService<IPolSourceSiteEffectController>();
            Assert.NotNull(polSourceSiteEffectController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
