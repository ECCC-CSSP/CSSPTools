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
    public partial class SpillControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private ISpillService spillService { get; set; }
        private ISpillController spillController { get; set; }
        #endregion Properties

        #region Constructors
        public SpillControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SpillController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(spillService);
            Assert.NotNull(spillController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SpillController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionSpillList = await spillController.Get();
               Assert.Equal(200, ((ObjectResult)actionSpillList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillList.Result).Value);
               List<Spill> spillList = (List<Spill>)(((OkObjectResult)actionSpillList.Result).Value);

               int count = ((List<Spill>)((OkObjectResult)actionSpillList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(SpillID)
               var actionSpill = await spillController.Get(spillList[0].SpillID);
               Assert.Equal(200, ((ObjectResult)actionSpill.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpill.Result).Value);
               Spill spill = (Spill)(((OkObjectResult)actionSpill.Result).Value);
               Assert.NotNull(spill);
               Assert.Equal(spillList[0].SpillID, spill.SpillID);

               // testing Post(Spill spill)
               spill.SpillID = 0;
               var actionSpillNew = await spillController.Post(spill);
               Assert.Equal(200, ((ObjectResult)actionSpillNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillNew.Result).Value);
               Spill spillNew = (Spill)(((OkObjectResult)actionSpillNew.Result).Value);
               Assert.NotNull(spillNew);

               // testing Put(Spill spill)
               var actionSpillUpdate = await spillController.Put(spillNew);
               Assert.Equal(200, ((ObjectResult)actionSpillUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillUpdate.Result).Value);
               Spill spillUpdate = (Spill)(((OkObjectResult)actionSpillUpdate.Result).Value);
               Assert.NotNull(spillUpdate);

               // testing Delete(Spill spill)
               var actionSpillDelete = await spillController.Delete(spillUpdate);
               Assert.Equal(200, ((ObjectResult)actionSpillDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillDelete.Result).Value);
               Spill spillDelete = (Spill)(((OkObjectResult)actionSpillDelete.Result).Value);
               Assert.NotNull(spillDelete);
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
            Services.AddSingleton<ISpillService, SpillService>();
            Services.AddSingleton<ISpillController, SpillController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            spillService = Provider.GetService<ISpillService>();
            Assert.NotNull(spillService);
        
            await spillService.SetCulture(culture);
        
            spillController = Provider.GetService<ISpillController>();
            Assert.NotNull(spillController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
