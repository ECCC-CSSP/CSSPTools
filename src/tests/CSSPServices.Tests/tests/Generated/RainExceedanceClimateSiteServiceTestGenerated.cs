/* Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceTestGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
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
using Xunit;

namespace CSSPServices.Tests
{
    public partial class RainExceedanceClimateSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IRainExceedanceClimateSiteService rainExceedanceClimateSiteService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public RainExceedanceClimateSiteServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task RainExceedanceClimateSite_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            RainExceedanceClimateSite rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite(""); 

            // List<RainExceedanceClimateSite>
            var actionRainExceedanceClimateSiteList = await rainExceedanceClimateSiteService.GetRainExceedanceClimateSiteList();
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value);
            List<RainExceedanceClimateSite> rainExceedanceClimateSiteList = (List<RainExceedanceClimateSite>)(((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value);

            int count = ((List<RainExceedanceClimateSite>)((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value).Count();
            Assert.True(count > 0);

            // Add RainExceedanceClimateSite
            var actionRainExceedanceClimateSiteAdded = await rainExceedanceClimateSiteService.Add(rainExceedanceClimateSite);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteAdded.Result).Value);
            RainExceedanceClimateSite rainExceedanceClimateSiteAdded = (RainExceedanceClimateSite)(((OkObjectResult)actionRainExceedanceClimateSiteAdded.Result).Value);
            Assert.NotNull(rainExceedanceClimateSiteAdded);

            // Update RainExceedanceClimateSite
            var actionRainExceedanceClimateSiteUpdated = await rainExceedanceClimateSiteService.Update(rainExceedanceClimateSite);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteUpdated.Result).Value);
            RainExceedanceClimateSite rainExceedanceClimateSiteUpdated = (RainExceedanceClimateSite)(((OkObjectResult)actionRainExceedanceClimateSiteUpdated.Result).Value);
            Assert.NotNull(rainExceedanceClimateSiteUpdated);

            // Delete RainExceedanceClimateSite
            var actionRainExceedanceClimateSiteDeleted = await rainExceedanceClimateSiteService.Delete(rainExceedanceClimateSite);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteDeleted.Result).Value);
            RainExceedanceClimateSite rainExceedanceClimateSiteDeleted = (RainExceedanceClimateSite)(((OkObjectResult)actionRainExceedanceClimateSiteDeleted.Result).Value);
            Assert.NotNull(rainExceedanceClimateSiteDeleted);
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();
        
            Services = new ServiceCollection();
        
            Services.AddSingleton<IConfiguration>(Config);
        
            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);
        
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });
        
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IRainExceedanceClimateSiteService, RainExceedanceClimateSiteService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            rainExceedanceClimateSiteService = Provider.GetService<IRainExceedanceClimateSiteService>();
            Assert.NotNull(rainExceedanceClimateSiteService);
        
            await rainExceedanceClimateSiteService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private RainExceedanceClimateSite GetFilledRandomRainExceedanceClimateSite(string OmitPropName)
        {
            RainExceedanceClimateSite rainExceedanceClimateSite = new RainExceedanceClimateSite();

            if (OmitPropName != "RainExceedanceTVItemID") rainExceedanceClimateSite.RainExceedanceTVItemID = 56;
            if (OmitPropName != "ClimateSiteTVItemID") rainExceedanceClimateSite.ClimateSiteTVItemID = 7;
            if (OmitPropName != "LastUpdateDate_UTC") rainExceedanceClimateSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") rainExceedanceClimateSite.LastUpdateContactTVItemID = 2;

            return rainExceedanceClimateSite;
        }
        #endregion Functions private
    }
}
