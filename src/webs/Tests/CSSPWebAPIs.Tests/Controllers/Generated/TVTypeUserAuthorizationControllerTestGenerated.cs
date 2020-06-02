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
    public partial class TVTypeUserAuthorizationControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ITVTypeUserAuthorizationService tvTypeUserAuthorizationService { get; set; }
        private ITVTypeUserAuthorizationController tvTypeUserAuthorizationController { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVTypeUserAuthorizationController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(tvTypeUserAuthorizationService);
            Assert.NotNull(tvTypeUserAuthorizationController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVTypeUserAuthorizationController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionTVTypeUserAuthorizationList = await tvTypeUserAuthorizationController.Get();
               Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationList.Result).Value);
               List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = (List<TVTypeUserAuthorization>)(((OkObjectResult)actionTVTypeUserAuthorizationList.Result).Value);

               int count = ((List<TVTypeUserAuthorization>)((OkObjectResult)actionTVTypeUserAuthorizationList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(TVTypeUserAuthorizationID)
               var actionTVTypeUserAuthorization = await tvTypeUserAuthorizationController.Get(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
               Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorization.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorization.Result).Value);
               TVTypeUserAuthorization tvTypeUserAuthorization = (TVTypeUserAuthorization)(((OkObjectResult)actionTVTypeUserAuthorization.Result).Value);
               Assert.NotNull(tvTypeUserAuthorization);
               Assert.Equal(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID, tvTypeUserAuthorization.TVTypeUserAuthorizationID);

               // testing Post(TVTypeUserAuthorization tvTypeUserAuthorization)
               tvTypeUserAuthorization.TVTypeUserAuthorizationID = 0;
               var actionTVTypeUserAuthorizationNew = await tvTypeUserAuthorizationController.Post(tvTypeUserAuthorization);
               Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationNew.Result).Value);
               TVTypeUserAuthorization tvTypeUserAuthorizationNew = (TVTypeUserAuthorization)(((OkObjectResult)actionTVTypeUserAuthorizationNew.Result).Value);
               Assert.NotNull(tvTypeUserAuthorizationNew);

               // testing Put(TVTypeUserAuthorization tvTypeUserAuthorization)
               var actionTVTypeUserAuthorizationUpdate = await tvTypeUserAuthorizationController.Put(tvTypeUserAuthorizationNew);
               Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationUpdate.Result).Value);
               TVTypeUserAuthorization tvTypeUserAuthorizationUpdate = (TVTypeUserAuthorization)(((OkObjectResult)actionTVTypeUserAuthorizationUpdate.Result).Value);
               Assert.NotNull(tvTypeUserAuthorizationUpdate);

               // testing Delete(TVTypeUserAuthorization tvTypeUserAuthorization)
               var actionTVTypeUserAuthorizationDelete = await tvTypeUserAuthorizationController.Delete(tvTypeUserAuthorizationUpdate);
               Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationDelete.Result).Value);
               TVTypeUserAuthorization tvTypeUserAuthorizationDelete = (TVTypeUserAuthorization)(((OkObjectResult)actionTVTypeUserAuthorizationDelete.Result).Value);
               Assert.NotNull(tvTypeUserAuthorizationDelete);
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
            Services.AddSingleton<ITVTypeUserAuthorizationService, TVTypeUserAuthorizationService>();
            Services.AddSingleton<ITVTypeUserAuthorizationController, TVTypeUserAuthorizationController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            tvTypeUserAuthorizationService = Provider.GetService<ITVTypeUserAuthorizationService>();
            Assert.NotNull(tvTypeUserAuthorizationService);
        
            await tvTypeUserAuthorizationService.SetCulture(culture);
        
            tvTypeUserAuthorizationController = Provider.GetService<ITVTypeUserAuthorizationController>();
            Assert.NotNull(tvTypeUserAuthorizationController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
