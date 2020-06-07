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
using System.Transactions;
using Xunit;

namespace CSSPServices.Tests
{
    public partial class MapInfoPointServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IMapInfoPointService mapInfoPointService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public MapInfoPointServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MapInfoPoint_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               MapInfoPoint mapInfoPoint = GetFilledRandomMapInfoPoint(""); 

               // List<MapInfoPoint>
               var actionMapInfoPointList = await mapInfoPointService.GetMapInfoPointList();
               Assert.Equal(200, ((ObjectResult)actionMapInfoPointList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMapInfoPointList.Result).Value);
               List<MapInfoPoint> mapInfoPointList = (List<MapInfoPoint>)((OkObjectResult)actionMapInfoPointList.Result).Value;

               int count = ((List<MapInfoPoint>)((OkObjectResult)actionMapInfoPointList.Result).Value).Count();
                Assert.True(count > 0);

               // Add MapInfoPoint
               var actionMapInfoPointAdded = await mapInfoPointService.Add(mapInfoPoint);
               Assert.Equal(200, ((ObjectResult)actionMapInfoPointAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMapInfoPointAdded.Result).Value);
               MapInfoPoint mapInfoPointAdded = (MapInfoPoint)((OkObjectResult)actionMapInfoPointAdded.Result).Value;
               Assert.NotNull(mapInfoPointAdded);

               // Update MapInfoPoint
               var actionMapInfoPointUpdated = await mapInfoPointService.Update(mapInfoPoint);
               Assert.Equal(200, ((ObjectResult)actionMapInfoPointUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMapInfoPointUpdated.Result).Value);
               MapInfoPoint mapInfoPointUpdated = (MapInfoPoint)((OkObjectResult)actionMapInfoPointUpdated.Result).Value;
               Assert.NotNull(mapInfoPointUpdated);

               // Delete MapInfoPoint
               var actionMapInfoPointDeleted = await mapInfoPointService.Delete(mapInfoPoint.MapInfoPointID);
               Assert.Equal(200, ((ObjectResult)actionMapInfoPointDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMapInfoPointDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionMapInfoPointDeleted.Result).Value;
               Assert.True(retBool);
            }
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
            Services.AddSingleton<IMapInfoPointService, MapInfoPointService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            mapInfoPointService = Provider.GetService<IMapInfoPointService>();
            Assert.NotNull(mapInfoPointService);
        
            await mapInfoPointService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private MapInfoPoint GetFilledRandomMapInfoPoint(string OmitPropName)
        {
            MapInfoPoint mapInfoPoint = new MapInfoPoint();

            if (OmitPropName != "MapInfoID") mapInfoPoint.MapInfoID = 1;
            if (OmitPropName != "Ordinal") mapInfoPoint.Ordinal = GetRandomInt(0, 10);
            if (OmitPropName != "Lat") mapInfoPoint.Lat = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "Lng") mapInfoPoint.Lng = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "LastUpdateDate_UTC") mapInfoPoint.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mapInfoPoint.LastUpdateContactTVItemID = 2;

            return mapInfoPoint;
        }
        #endregion Functions private
    }
}
