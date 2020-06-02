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
    public partial class TVItemLinkControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ITVItemLinkService tvItemLinkService { get; set; }
        private ITVItemLinkController tvItemLinkController { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemLinkControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVItemLinkController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(tvItemLinkService);
            Assert.NotNull(tvItemLinkController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVItemLinkController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionTVItemLinkList = await tvItemLinkController.Get();
               Assert.Equal(200, ((ObjectResult)actionTVItemLinkList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemLinkList.Result).Value);
               List<TVItemLink> tvItemLinkList = (List<TVItemLink>)(((OkObjectResult)actionTVItemLinkList.Result).Value);

               int count = ((List<TVItemLink>)((OkObjectResult)actionTVItemLinkList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(TVItemLinkID)
               var actionTVItemLink = await tvItemLinkController.Get(tvItemLinkList[0].TVItemLinkID);
               Assert.Equal(200, ((ObjectResult)actionTVItemLink.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemLink.Result).Value);
               TVItemLink tvItemLink = (TVItemLink)(((OkObjectResult)actionTVItemLink.Result).Value);
               Assert.NotNull(tvItemLink);
               Assert.Equal(tvItemLinkList[0].TVItemLinkID, tvItemLink.TVItemLinkID);

               // testing Post(TVItemLink tvItemLink)
               tvItemLink.TVItemLinkID = 0;
               var actionTVItemLinkNew = await tvItemLinkController.Post(tvItemLink);
               Assert.Equal(200, ((ObjectResult)actionTVItemLinkNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemLinkNew.Result).Value);
               TVItemLink tvItemLinkNew = (TVItemLink)(((OkObjectResult)actionTVItemLinkNew.Result).Value);
               Assert.NotNull(tvItemLinkNew);

               // testing Put(TVItemLink tvItemLink)
               var actionTVItemLinkUpdate = await tvItemLinkController.Put(tvItemLinkNew);
               Assert.Equal(200, ((ObjectResult)actionTVItemLinkUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemLinkUpdate.Result).Value);
               TVItemLink tvItemLinkUpdate = (TVItemLink)(((OkObjectResult)actionTVItemLinkUpdate.Result).Value);
               Assert.NotNull(tvItemLinkUpdate);

               // testing Delete(TVItemLink tvItemLink)
               var actionTVItemLinkDelete = await tvItemLinkController.Delete(tvItemLinkUpdate);
               Assert.Equal(200, ((ObjectResult)actionTVItemLinkDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVItemLinkDelete.Result).Value);
               TVItemLink tvItemLinkDelete = (TVItemLink)(((OkObjectResult)actionTVItemLinkDelete.Result).Value);
               Assert.NotNull(tvItemLinkDelete);
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
            Services.AddSingleton<ITVItemLinkService, TVItemLinkService>();
            Services.AddSingleton<ITVItemLinkController, TVItemLinkController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            tvItemLinkService = Provider.GetService<ITVItemLinkService>();
            Assert.NotNull(tvItemLinkService);
        
            await tvItemLinkService.SetCulture(culture);
        
            tvItemLinkController = Provider.GetService<ITVItemLinkController>();
            Assert.NotNull(tvItemLinkController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
