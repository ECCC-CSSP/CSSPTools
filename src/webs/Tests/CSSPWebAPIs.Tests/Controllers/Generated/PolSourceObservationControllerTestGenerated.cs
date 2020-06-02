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
    public partial class PolSourceObservationControllerTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private CSSPDBContext db { get; set; }
        private ILoggedInService loggedInService { get; set; }
        private IPolSourceObservationService polSourceObservationService { get; set; }
        private IPolSourceObservationController polSourceObservationController { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationControllerTest()
        {
        }
        #endregion Constructors

        #region Functions public
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceObservationController_Constructor_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);
            Assert.NotNull(loggedInService);
            Assert.NotNull(polSourceObservationService);
            Assert.NotNull(polSourceObservationController);
        }
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceObservationController_CRUD_Good_Test(string culture)
        {
            bool retBool = await Setup(new CultureInfo(culture));
            Assert.True(retBool);

            using (TransactionScope ts = new TransactionScope())
            {
                // testing Get
               var actionPolSourceObservationList = await polSourceObservationController.Get();
               Assert.Equal(200, ((ObjectResult)actionPolSourceObservationList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceObservationList.Result).Value);
               List<PolSourceObservation> polSourceObservationList = (List<PolSourceObservation>)(((OkObjectResult)actionPolSourceObservationList.Result).Value);

               int count = ((List<PolSourceObservation>)((OkObjectResult)actionPolSourceObservationList.Result).Value).Count();
                Assert.True(count > 0);

               // testing Get(PolSourceObservationID)
               var actionPolSourceObservation = await polSourceObservationController.Get(polSourceObservationList[0].PolSourceObservationID);
               Assert.Equal(200, ((ObjectResult)actionPolSourceObservation.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceObservation.Result).Value);
               PolSourceObservation polSourceObservation = (PolSourceObservation)(((OkObjectResult)actionPolSourceObservation.Result).Value);
               Assert.NotNull(polSourceObservation);
               Assert.Equal(polSourceObservationList[0].PolSourceObservationID, polSourceObservation.PolSourceObservationID);

               // testing Post(PolSourceObservation polSourceObservation)
               polSourceObservation.PolSourceObservationID = 0;
               var actionPolSourceObservationNew = await polSourceObservationController.Post(polSourceObservation);
               Assert.Equal(200, ((ObjectResult)actionPolSourceObservationNew.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceObservationNew.Result).Value);
               PolSourceObservation polSourceObservationNew = (PolSourceObservation)(((OkObjectResult)actionPolSourceObservationNew.Result).Value);
               Assert.NotNull(polSourceObservationNew);

               // testing Put(PolSourceObservation polSourceObservation)
               var actionPolSourceObservationUpdate = await polSourceObservationController.Put(polSourceObservationNew);
               Assert.Equal(200, ((ObjectResult)actionPolSourceObservationUpdate.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceObservationUpdate.Result).Value);
               PolSourceObservation polSourceObservationUpdate = (PolSourceObservation)(((OkObjectResult)actionPolSourceObservationUpdate.Result).Value);
               Assert.NotNull(polSourceObservationUpdate);

               // testing Delete(PolSourceObservation polSourceObservation)
               var actionPolSourceObservationDelete = await polSourceObservationController.Delete(polSourceObservationUpdate);
               Assert.Equal(200, ((ObjectResult)actionPolSourceObservationDelete.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionPolSourceObservationDelete.Result).Value);
               PolSourceObservation polSourceObservationDelete = (PolSourceObservation)(((OkObjectResult)actionPolSourceObservationDelete.Result).Value);
               Assert.NotNull(polSourceObservationDelete);
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
            Services.AddSingleton<IPolSourceObservationService, PolSourceObservationService>();
            Services.AddSingleton<IPolSourceObservationController, PolSourceObservationController>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            loggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(loggedInService);
        
            polSourceObservationService = Provider.GetService<IPolSourceObservationService>();
            Assert.NotNull(polSourceObservationService);
        
            await polSourceObservationService.SetCulture(culture);
        
            polSourceObservationController = Provider.GetService<IPolSourceObservationController>();
            Assert.NotNull(polSourceObservationController);
        
            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
