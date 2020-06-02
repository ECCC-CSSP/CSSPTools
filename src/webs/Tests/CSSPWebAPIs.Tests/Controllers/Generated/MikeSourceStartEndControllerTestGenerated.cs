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
    public partial class MikeSourceStartEndControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMikeSourceStartEndService mikeSourceStartEndService { get; set; }
        private IMikeSourceStartEndController mikeSourceStartEndController { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MikeSourceStartEndController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mikeSourceStartEndService);
            Assert.NotNull(mikeSourceStartEndController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MikeSourceStartEndController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionMikeSourceStartEndList = await mikeSourceStartEndController.Get();
               Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndList.Result).Value);
               List<MikeSourceStartEnd> mikeSourceStartEndList = (List<MikeSourceStartEnd>)(((OkObjectResult)actionMikeSourceStartEndList.Result).Value);

               int count = ((List<MikeSourceStartEnd>)((OkObjectResult)actionMikeSourceStartEndList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(MikeSourceStartEndID)
               var actionMikeSourceStartEnd = await mikeSourceStartEndController.Get(mikeSourceStartEndList[0].MikeSourceStartEndID);
               Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEnd.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeSourceStartEnd.Result).Value);
               MikeSourceStartEnd mikeSourceStartEnd = (MikeSourceStartEnd)(((OkObjectResult)actionMikeSourceStartEnd.Result).Value);
               Assert.NotNull(mikeSourceStartEnd);
               Assert.Equal(mikeSourceStartEndList[0].MikeSourceStartEndID, mikeSourceStartEnd.MikeSourceStartEndID);

               // testing Post(MikeSourceStartEnd mikeSourceStartEnd)
               mikeSourceStartEnd.MikeSourceStartEndID = 0;
               var actionMikeSourceStartEndNew = await mikeSourceStartEndController.Post(mikeSourceStartEnd);
               Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndNew.Result).Value);
               MikeSourceStartEnd mikeSourceStartEndNew = (MikeSourceStartEnd)(((OkObjectResult)actionMikeSourceStartEndNew.Result).Value);
               Assert.NotNull(mikeSourceStartEndNew);

               // testing Put(MikeSourceStartEnd mikeSourceStartEnd)
               var actionMikeSourceStartEndUpdate = await mikeSourceStartEndController.Put(mikeSourceStartEndNew);
               Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndUpdate.Result).Value);
               MikeSourceStartEnd mikeSourceStartEndUpdate = (MikeSourceStartEnd)(((OkObjectResult)actionMikeSourceStartEndUpdate.Result).Value);
               Assert.NotNull(mikeSourceStartEndUpdate);

               // testing Delete(MikeSourceStartEnd mikeSourceStartEnd)
               var actionMikeSourceStartEndDelete = await mikeSourceStartEndController.Delete(mikeSourceStartEndUpdate);
               Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndDelete.Result).Value);
               MikeSourceStartEnd mikeSourceStartEndDelete = (MikeSourceStartEnd)(((OkObjectResult)actionMikeSourceStartEndDelete.Result).Value);
               Assert.NotNull(mikeSourceStartEndDelete);
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
            Services.AddSingleton<IMikeSourceStartEndService, MikeSourceStartEndService>();
            Services.AddSingleton<IMikeSourceStartEndController, MikeSourceStartEndController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            mikeSourceStartEndService = Provider.GetService<IMikeSourceStartEndService>();
            Assert.NotNull(mikeSourceStartEndService);
        
            await mikeSourceStartEndService.SetCulture(culture);
        
            mikeSourceStartEndController = Provider.GetService<IMikeSourceStartEndController>();
            Assert.NotNull(mikeSourceStartEndController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
