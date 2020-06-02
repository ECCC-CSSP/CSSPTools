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
    public partial class MikeSourceControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IMikeSourceService mikeSourceService { get; set; }
        private IMikeSourceController mikeSourceController { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MikeSourceController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(mikeSourceService);
            Assert.NotNull(mikeSourceController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MikeSourceController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionMikeSourceList = await mikeSourceController.Get();
               Assert.Equal(200, ((ObjectResult)actionMikeSourceList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeSourceList.Result).Value);
               List<MikeSource> mikeSourceList = (List<MikeSource>)(((OkObjectResult)actionMikeSourceList.Result).Value);

               int count = ((List<MikeSource>)((OkObjectResult)actionMikeSourceList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(MikeSourceID)
               var actionMikeSource = await mikeSourceController.Get(mikeSourceList[0].MikeSourceID);
               Assert.Equal(200, ((ObjectResult)actionMikeSource.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeSource.Result).Value);
               MikeSource mikeSource = (MikeSource)(((OkObjectResult)actionMikeSource.Result).Value);
               Assert.NotNull(mikeSource);
               Assert.Equal(mikeSourceList[0].MikeSourceID, mikeSource.MikeSourceID);

               // testing Post(MikeSource mikeSource)
               mikeSource.MikeSourceID = 0;
               var actionMikeSourceNew = await mikeSourceController.Post(mikeSource);
               Assert.Equal(200, ((ObjectResult)actionMikeSourceNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeSourceNew.Result).Value);
               MikeSource mikeSourceNew = (MikeSource)(((OkObjectResult)actionMikeSourceNew.Result).Value);
               Assert.NotNull(mikeSourceNew);

               // testing Put(MikeSource mikeSource)
               var actionMikeSourceUpdate = await mikeSourceController.Put(mikeSourceNew);
               Assert.Equal(200, ((ObjectResult)actionMikeSourceUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeSourceUpdate.Result).Value);
               MikeSource mikeSourceUpdate = (MikeSource)(((OkObjectResult)actionMikeSourceUpdate.Result).Value);
               Assert.NotNull(mikeSourceUpdate);

               // testing Delete(MikeSource mikeSource)
               var actionMikeSourceDelete = await mikeSourceController.Delete(mikeSourceUpdate);
               Assert.Equal(200, ((ObjectResult)actionMikeSourceDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMikeSourceDelete.Result).Value);
               MikeSource mikeSourceDelete = (MikeSource)(((OkObjectResult)actionMikeSourceDelete.Result).Value);
               Assert.NotNull(mikeSourceDelete);
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
            Services.AddSingleton<IMikeSourceService, MikeSourceService>();
            Services.AddSingleton<IMikeSourceController, MikeSourceController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            mikeSourceService = Provider.GetService<IMikeSourceService>();
            Assert.NotNull(mikeSourceService);
        
            await mikeSourceService.SetCulture(culture);
        
            mikeSourceController = Provider.GetService<IMikeSourceController>();
            Assert.NotNull(mikeSourceController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
