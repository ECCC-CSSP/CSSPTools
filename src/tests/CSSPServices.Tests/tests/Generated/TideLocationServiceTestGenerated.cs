/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
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
using Xunit;

namespace CSSPServices.Tests
{
    public partial class TideLocationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ITideLocationService tideLocationService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public TideLocationServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TideLocation_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               TideLocation tideLocation = GetFilledRandomTideLocation(""); 

               // List<TideLocation>
               var actionTideLocationList = await tideLocationService.GetTideLocationList();
               Assert.Equal(200, ((ObjectResult)actionTideLocationList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideLocationList.Result).Value);
               List<TideLocation> tideLocationList = (List<TideLocation>)((OkObjectResult)actionTideLocationList.Result).Value;

               int count = ((List<TideLocation>)((OkObjectResult)actionTideLocationList.Result).Value).Count();
                Assert.True(count > 0);

               // Add TideLocation
               var actionTideLocationAdded = await tideLocationService.Add(tideLocation);
               Assert.Equal(200, ((ObjectResult)actionTideLocationAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideLocationAdded.Result).Value);
               TideLocation tideLocationAdded = (TideLocation)((OkObjectResult)actionTideLocationAdded.Result).Value;
               Assert.NotNull(tideLocationAdded);

               // Update TideLocation
               var actionTideLocationUpdated = await tideLocationService.Update(tideLocation);
               Assert.Equal(200, ((ObjectResult)actionTideLocationUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideLocationUpdated.Result).Value);
               TideLocation tideLocationUpdated = (TideLocation)((OkObjectResult)actionTideLocationUpdated.Result).Value;
               Assert.NotNull(tideLocationUpdated);

               // Delete TideLocation
               var actionTideLocationDeleted = await tideLocationService.Delete(tideLocation.TideLocationID);
               Assert.Equal(200, ((ObjectResult)actionTideLocationDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTideLocationDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionTideLocationDeleted.Result).Value;
               Assert.True(retBool);
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
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

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITideLocationService, TideLocationService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            tideLocationService = Provider.GetService<ITideLocationService>();
            Assert.NotNull(tideLocationService);

            return await Task.FromResult(true);
        }
        private TideLocation GetFilledRandomTideLocation(string OmitPropName)
        {
            TideLocation tideLocation = new TideLocation();

            if (OmitPropName != "Zone") tideLocation.Zone = GetRandomInt(0, 10000);
            if (OmitPropName != "Name") tideLocation.Name = GetRandomString("", 5);
            if (OmitPropName != "Prov") tideLocation.Prov = GetRandomString("", 5);
            if (OmitPropName != "sid") tideLocation.sid = GetRandomInt(0, 100000);
            if (OmitPropName != "Lat") tideLocation.Lat = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "Lng") tideLocation.Lng = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "LastUpdateDate_UTC") tideLocation.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tideLocation.LastUpdateContactTVItemID = 2;

            return tideLocation;
        }
        #endregion Functions private
    }
}
