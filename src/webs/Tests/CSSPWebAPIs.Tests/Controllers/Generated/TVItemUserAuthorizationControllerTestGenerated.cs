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
    public partial class TVItemUserAuthorizationControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ITVItemUserAuthorizationService tvItemUserAuthorizationService { get; set; }
        private ITVItemUserAuthorizationController tvItemUserAuthorizationController { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVItemUserAuthorizationController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(tvItemUserAuthorizationService);
            Assert.NotNull(tvItemUserAuthorizationController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVItemUserAuthorizationController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionTVItemUserAuthorizationList = await tvItemUserAuthorizationController.Get();
               Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorizationList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorizationList.Result).Value);
               List<TVItemUserAuthorization> tvItemUserAuthorizationList = (List<TVItemUserAuthorization>)(((OkObjectResult)actionTVItemUserAuthorizationList.Result).Value);

               int count = ((List<TVItemUserAuthorization>)((OkObjectResult)actionTVItemUserAuthorizationList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(TVItemUserAuthorizationID)
               var actionTVItemUserAuthorization = await tvItemUserAuthorizationController.Get(tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
               Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorization.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorization.Result).Value);
               TVItemUserAuthorization tvItemUserAuthorization = (TVItemUserAuthorization)(((OkObjectResult)actionTVItemUserAuthorization.Result).Value);
               Assert.NotNull(tvItemUserAuthorization);
               Assert.Equal(tvItemUserAuthorizationList[0].TVItemUserAuthorizationID, tvItemUserAuthorization.TVItemUserAuthorizationID);

               // testing Post(TVItemUserAuthorization tvItemUserAuthorization)
               tvItemUserAuthorization.TVItemUserAuthorizationID = 0;
               var actionTVItemUserAuthorizationNew = await tvItemUserAuthorizationController.Post(tvItemUserAuthorization);
               Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorizationNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorizationNew.Result).Value);
               TVItemUserAuthorization tvItemUserAuthorizationNew = (TVItemUserAuthorization)(((OkObjectResult)actionTVItemUserAuthorizationNew.Result).Value);
               Assert.NotNull(tvItemUserAuthorizationNew);

               // testing Put(TVItemUserAuthorization tvItemUserAuthorization)
               var actionTVItemUserAuthorizationUpdate = await tvItemUserAuthorizationController.Put(tvItemUserAuthorizationNew);
               Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorizationUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorizationUpdate.Result).Value);
               TVItemUserAuthorization tvItemUserAuthorizationUpdate = (TVItemUserAuthorization)(((OkObjectResult)actionTVItemUserAuthorizationUpdate.Result).Value);
               Assert.NotNull(tvItemUserAuthorizationUpdate);

               // testing Delete(TVItemUserAuthorization tvItemUserAuthorization)
               var actionTVItemUserAuthorizationDelete = await tvItemUserAuthorizationController.Delete(tvItemUserAuthorizationUpdate);
               Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorizationDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorizationDelete.Result).Value);
               TVItemUserAuthorization tvItemUserAuthorizationDelete = (TVItemUserAuthorization)(((OkObjectResult)actionTVItemUserAuthorizationDelete.Result).Value);
               Assert.NotNull(tvItemUserAuthorizationDelete);
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
            Services.AddSingleton<ITVItemUserAuthorizationService, TVItemUserAuthorizationService>();
            Services.AddSingleton<ITVItemUserAuthorizationController, TVItemUserAuthorizationController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            tvItemUserAuthorizationService = Provider.GetService<ITVItemUserAuthorizationService>();
            Assert.NotNull(tvItemUserAuthorizationService);
        
            await tvItemUserAuthorizationService.SetCulture(culture);
        
            tvItemUserAuthorizationController = Provider.GetService<ITVItemUserAuthorizationController>();
            Assert.NotNull(tvItemUserAuthorizationController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
