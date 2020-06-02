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
    public partial class TVItemStatControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ITVItemStatService tvItemStatService { get; set; }
        private ITVItemStatController tvItemStatController { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemStatControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVItemStatController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(tvItemStatService);
            Assert.NotNull(tvItemStatController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVItemStatController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionTVItemStatList = await tvItemStatController.Get();
               Assert.Equal(200, ((ObjectResult)actionTVItemStatList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemStatList.Result).Value);
               List<TVItemStat> tvItemStatList = (List<TVItemStat>)(((OkObjectResult)actionTVItemStatList.Result).Value);

               int count = ((List<TVItemStat>)((OkObjectResult)actionTVItemStatList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(TVItemStatID)
               var actionTVItemStat = await tvItemStatController.Get(tvItemStatList[0].TVItemStatID);
               Assert.Equal(200, ((ObjectResult)actionTVItemStat.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemStat.Result).Value);
               TVItemStat tvItemStat = (TVItemStat)(((OkObjectResult)actionTVItemStat.Result).Value);
               Assert.NotNull(tvItemStat);
               Assert.Equal(tvItemStatList[0].TVItemStatID, tvItemStat.TVItemStatID);

               // testing Post(TVItemStat tvItemStat)
               tvItemStat.TVItemStatID = 0;
               var actionTVItemStatNew = await tvItemStatController.Post(tvItemStat);
               Assert.Equal(200, ((ObjectResult)actionTVItemStatNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemStatNew.Result).Value);
               TVItemStat tvItemStatNew = (TVItemStat)(((OkObjectResult)actionTVItemStatNew.Result).Value);
               Assert.NotNull(tvItemStatNew);

               // testing Put(TVItemStat tvItemStat)
               var actionTVItemStatUpdate = await tvItemStatController.Put(tvItemStatNew);
               Assert.Equal(200, ((ObjectResult)actionTVItemStatUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemStatUpdate.Result).Value);
               TVItemStat tvItemStatUpdate = (TVItemStat)(((OkObjectResult)actionTVItemStatUpdate.Result).Value);
               Assert.NotNull(tvItemStatUpdate);

               // testing Delete(TVItemStat tvItemStat)
               var actionTVItemStatDelete = await tvItemStatController.Delete(tvItemStatUpdate);
               Assert.Equal(200, ((ObjectResult)actionTVItemStatDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemStatDelete.Result).Value);
               TVItemStat tvItemStatDelete = (TVItemStat)(((OkObjectResult)actionTVItemStatDelete.Result).Value);
               Assert.NotNull(tvItemStatDelete);
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
            Services.AddSingleton<ITVItemStatService, TVItemStatService>();
            Services.AddSingleton<ITVItemStatController, TVItemStatController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            tvItemStatService = Provider.GetService<ITVItemStatService>();
            Assert.NotNull(tvItemStatService);
        
            await tvItemStatService.SetCulture(culture);
        
            tvItemStatController = Provider.GetService<ITVItemStatController>();
            Assert.NotNull(tvItemStatController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
