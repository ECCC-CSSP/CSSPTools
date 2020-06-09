/* Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceTestGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
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
    public partial class BoxModelResultServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private IBoxModelResultService boxModelResultService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelResultServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task BoxModelResult_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               BoxModelResult boxModelResult = GetFilledRandomBoxModelResult(""); 

               // List<BoxModelResult>
               var actionBoxModelResultList = await boxModelResultService.GetBoxModelResultList();
               Assert.Equal(200, ((ObjectResult)actionBoxModelResultList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelResultList.Result).Value);
               List<BoxModelResult> boxModelResultList = (List<BoxModelResult>)((OkObjectResult)actionBoxModelResultList.Result).Value;

               int count = ((List<BoxModelResult>)((OkObjectResult)actionBoxModelResultList.Result).Value).Count();
                Assert.True(count > 0);

               // Add BoxModelResult
               var actionBoxModelResultAdded = await boxModelResultService.Add(boxModelResult);
               Assert.Equal(200, ((ObjectResult)actionBoxModelResultAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelResultAdded.Result).Value);
               BoxModelResult boxModelResultAdded = (BoxModelResult)((OkObjectResult)actionBoxModelResultAdded.Result).Value;
               Assert.NotNull(boxModelResultAdded);

               // Update BoxModelResult
               var actionBoxModelResultUpdated = await boxModelResultService.Update(boxModelResult);
               Assert.Equal(200, ((ObjectResult)actionBoxModelResultUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelResultUpdated.Result).Value);
               BoxModelResult boxModelResultUpdated = (BoxModelResult)((OkObjectResult)actionBoxModelResultUpdated.Result).Value;
               Assert.NotNull(boxModelResultUpdated);

               // Delete BoxModelResult
               var actionBoxModelResultDeleted = await boxModelResultService.Delete(boxModelResult.BoxModelResultID);
               Assert.Equal(200, ((ObjectResult)actionBoxModelResultDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionBoxModelResultDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionBoxModelResultDeleted.Result).Value;
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
            Services.AddSingleton<IBoxModelResultService, BoxModelResultService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            boxModelResultService = Provider.GetService<IBoxModelResultService>();
            Assert.NotNull(boxModelResultService);

            return await Task.FromResult(true);
        }
        private BoxModelResult GetFilledRandomBoxModelResult(string OmitPropName)
        {
            BoxModelResult boxModelResult = new BoxModelResult();

            if (OmitPropName != "BoxModelID") boxModelResult.BoxModelID = 1;
            if (OmitPropName != "BoxModelResultType") boxModelResult.BoxModelResultType = (BoxModelResultTypeEnum)GetRandomEnumType(typeof(BoxModelResultTypeEnum));
            if (OmitPropName != "Volume_m3") boxModelResult.Volume_m3 = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "Surface_m2") boxModelResult.Surface_m2 = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "Radius_m") boxModelResult.Radius_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "LeftSideDiameterLineAngle_deg") boxModelResult.LeftSideDiameterLineAngle_deg = GetRandomDouble(0.0D, 360.0D);
            if (OmitPropName != "CircleCenterLatitude") boxModelResult.CircleCenterLatitude = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "CircleCenterLongitude") boxModelResult.CircleCenterLongitude = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "FixLength") boxModelResult.FixLength = true;
            if (OmitPropName != "FixWidth") boxModelResult.FixWidth = true;
            if (OmitPropName != "RectLength_m") boxModelResult.RectLength_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "RectWidth_m") boxModelResult.RectWidth_m = GetRandomDouble(0.0D, 100000.0D);
            if (OmitPropName != "LeftSideLineAngle_deg") boxModelResult.LeftSideLineAngle_deg = GetRandomDouble(0.0D, 360.0D);
            if (OmitPropName != "LeftSideLineStartLatitude") boxModelResult.LeftSideLineStartLatitude = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "LeftSideLineStartLongitude") boxModelResult.LeftSideLineStartLongitude = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "LastUpdateDate_UTC") boxModelResult.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") boxModelResult.LastUpdateContactTVItemID = 2;

            return boxModelResult;
        }
        #endregion Functions private
    }
}
