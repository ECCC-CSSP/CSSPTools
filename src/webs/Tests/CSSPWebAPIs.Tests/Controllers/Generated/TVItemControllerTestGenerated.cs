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
    public partial class TVItemControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ITVItemService tvItemService { get; set; }
        private ITVItemController tvItemController { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVItemController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(tvItemService);
            Assert.NotNull(tvItemController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVItemController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionTVItemList = await tvItemController.Get();
               Assert.Equal(200, ((ObjectResult)actionTVItemList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemList.Result).Value);
               List<TVItem> tvItemList = (List<TVItem>)(((OkObjectResult)actionTVItemList.Result).Value);

               int count = ((List<TVItem>)((OkObjectResult)actionTVItemList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(TVItemID)
               var actionTVItem = await tvItemController.Get(tvItemList[0].TVItemID);
               Assert.Equal(200, ((ObjectResult)actionTVItem.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItem.Result).Value);
               TVItem tvItem = (TVItem)(((OkObjectResult)actionTVItem.Result).Value);
               Assert.NotNull(tvItem);
               Assert.Equal(tvItemList[0].TVItemID, tvItem.TVItemID);

               // testing Post(TVItem tvItem)
               tvItem.TVItemID = 0;
               tvItem.ParentID = tvItemList[1].ParentID;
               tvItem.TVLevel = 1; 
               tvItem.TVPath = "Timbucto";
               tvItem.TVType = TVTypeEnum.Country;
               var actionTVItemNew = await tvItemController.Post(tvItem);
               Assert.Equal(200, ((ObjectResult)actionTVItemNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemNew.Result).Value);
               TVItem tvItemNew = (TVItem)(((OkObjectResult)actionTVItemNew.Result).Value);
               Assert.NotNull(tvItemNew);

               // testing Put(TVItem tvItem)
               var actionTVItemUpdate = await tvItemController.Put(tvItemNew);
               Assert.Equal(200, ((ObjectResult)actionTVItemUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemUpdate.Result).Value);
               TVItem tvItemUpdate = (TVItem)(((OkObjectResult)actionTVItemUpdate.Result).Value);
               Assert.NotNull(tvItemUpdate);

               // testing Delete(TVItem tvItem)
               var actionTVItemDelete = await tvItemController.Delete(tvItemUpdate);
               Assert.Equal(200, ((ObjectResult)actionTVItemDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemDelete.Result).Value);
               TVItem tvItemDelete = (TVItem)(((OkObjectResult)actionTVItemDelete.Result).Value);
               Assert.NotNull(tvItemDelete);
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
            Services.AddSingleton<ITVItemService, TVItemService>();
            Services.AddSingleton<ITVItemController, TVItemController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            tvItemService = Provider.GetService<ITVItemService>();
            Assert.NotNull(tvItemService);
        
            await tvItemService.SetCulture(culture);
        
            tvItemController = Provider.GetService<ITVItemController>();
            Assert.NotNull(tvItemController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
