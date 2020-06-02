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
    public partial class PolSourceSiteEffectTermControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IPolSourceSiteEffectTermService polSourceSiteEffectTermService { get; set; }
        private IPolSourceSiteEffectTermController polSourceSiteEffectTermController { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceSiteEffectTermController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(polSourceSiteEffectTermService);
            Assert.NotNull(polSourceSiteEffectTermController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceSiteEffectTermController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionPolSourceSiteEffectTermList = await polSourceSiteEffectTermController.Get();
               Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTermList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTermList.Result).Value);
               List<PolSourceSiteEffectTerm> polSourceSiteEffectTermList = (List<PolSourceSiteEffectTerm>)(((OkObjectResult)actionPolSourceSiteEffectTermList.Result).Value);

               int count = ((List<PolSourceSiteEffectTerm>)((OkObjectResult)actionPolSourceSiteEffectTermList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(PolSourceSiteEffectTermID)
               var actionPolSourceSiteEffectTerm = await polSourceSiteEffectTermController.Get(polSourceSiteEffectTermList[0].PolSourceSiteEffectTermID);
               Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTerm.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTerm.Result).Value);
               PolSourceSiteEffectTerm polSourceSiteEffectTerm = (PolSourceSiteEffectTerm)(((OkObjectResult)actionPolSourceSiteEffectTerm.Result).Value);
               Assert.NotNull(polSourceSiteEffectTerm);
               Assert.Equal(polSourceSiteEffectTermList[0].PolSourceSiteEffectTermID, polSourceSiteEffectTerm.PolSourceSiteEffectTermID);

               // testing Post(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
               polSourceSiteEffectTerm.PolSourceSiteEffectTermID = 0;
               var actionPolSourceSiteEffectTermNew = await polSourceSiteEffectTermController.Post(polSourceSiteEffectTerm);
               Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTermNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTermNew.Result).Value);
               PolSourceSiteEffectTerm polSourceSiteEffectTermNew = (PolSourceSiteEffectTerm)(((OkObjectResult)actionPolSourceSiteEffectTermNew.Result).Value);
               Assert.NotNull(polSourceSiteEffectTermNew);

               // testing Put(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
               var actionPolSourceSiteEffectTermUpdate = await polSourceSiteEffectTermController.Put(polSourceSiteEffectTermNew);
               Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTermUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTermUpdate.Result).Value);
               PolSourceSiteEffectTerm polSourceSiteEffectTermUpdate = (PolSourceSiteEffectTerm)(((OkObjectResult)actionPolSourceSiteEffectTermUpdate.Result).Value);
               Assert.NotNull(polSourceSiteEffectTermUpdate);

               // testing Delete(PolSourceSiteEffectTerm polSourceSiteEffectTerm)
               var actionPolSourceSiteEffectTermDelete = await polSourceSiteEffectTermController.Delete(polSourceSiteEffectTermUpdate);
               Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTermDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTermDelete.Result).Value);
               PolSourceSiteEffectTerm polSourceSiteEffectTermDelete = (PolSourceSiteEffectTerm)(((OkObjectResult)actionPolSourceSiteEffectTermDelete.Result).Value);
               Assert.NotNull(polSourceSiteEffectTermDelete);
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
            Services.AddSingleton<IPolSourceSiteEffectTermService, PolSourceSiteEffectTermService>();
            Services.AddSingleton<IPolSourceSiteEffectTermController, PolSourceSiteEffectTermController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            polSourceSiteEffectTermService = Provider.GetService<IPolSourceSiteEffectTermService>();
            Assert.NotNull(polSourceSiteEffectTermService);
        
            await polSourceSiteEffectTermService.SetCulture(culture);
        
            polSourceSiteEffectTermController = Provider.GetService<IPolSourceSiteEffectTermController>();
            Assert.NotNull(polSourceSiteEffectTermController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
