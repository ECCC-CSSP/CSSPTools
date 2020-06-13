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
    public partial class DrogueRunPositionServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private IDrogueRunPositionService drogueRunPositionService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public DrogueRunPositionServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task DrogueRunPosition_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               DrogueRunPosition drogueRunPosition = GetFilledRandomDrogueRunPosition(""); 

               // List<DrogueRunPosition>
               var actionDrogueRunPositionList = await drogueRunPositionService.GetDrogueRunPositionList();
               Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionDrogueRunPositionList.Result).Value);
               List<DrogueRunPosition> drogueRunPositionList = (List<DrogueRunPosition>)((OkObjectResult)actionDrogueRunPositionList.Result).Value;

               int count = ((List<DrogueRunPosition>)((OkObjectResult)actionDrogueRunPositionList.Result).Value).Count();
                Assert.True(count > 0);

               // Add DrogueRunPosition
               var actionDrogueRunPositionAdded = await drogueRunPositionService.Add(drogueRunPosition);
               Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionDrogueRunPositionAdded.Result).Value);
               DrogueRunPosition drogueRunPositionAdded = (DrogueRunPosition)((OkObjectResult)actionDrogueRunPositionAdded.Result).Value;
               Assert.NotNull(drogueRunPositionAdded);

               // Update DrogueRunPosition
               var actionDrogueRunPositionUpdated = await drogueRunPositionService.Update(drogueRunPosition);
               Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionDrogueRunPositionUpdated.Result).Value);
               DrogueRunPosition drogueRunPositionUpdated = (DrogueRunPosition)((OkObjectResult)actionDrogueRunPositionUpdated.Result).Value;
               Assert.NotNull(drogueRunPositionUpdated);

               // Delete DrogueRunPosition
               var actionDrogueRunPositionDeleted = await drogueRunPositionService.Delete(drogueRunPosition.DrogueRunPositionID);
               Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionDrogueRunPositionDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionDrogueRunPositionDeleted.Result).Value;
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
            Services.AddSingleton<IDrogueRunPositionService, DrogueRunPositionService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            drogueRunPositionService = Provider.GetService<IDrogueRunPositionService>();
            Assert.NotNull(drogueRunPositionService);

            return await Task.FromResult(true);
        }
        private DrogueRunPosition GetFilledRandomDrogueRunPosition(string OmitPropName)
        {
            DrogueRunPosition drogueRunPosition = new DrogueRunPosition();

            if (OmitPropName != "DrogueRunID") drogueRunPosition.DrogueRunID = 1;
            if (OmitPropName != "Ordinal") drogueRunPosition.Ordinal = GetRandomInt(0, 100000);
            if (OmitPropName != "StepLat") drogueRunPosition.StepLat = GetRandomDouble(-180.0D, 180.0D);
            if (OmitPropName != "StepLng") drogueRunPosition.StepLng = GetRandomDouble(-90.0D, 90.0D);
            if (OmitPropName != "StepDateTime_Local") drogueRunPosition.StepDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "CalculatedSpeed_m_s") drogueRunPosition.CalculatedSpeed_m_s = GetRandomDouble(0.0D, 10.0D);
            if (OmitPropName != "CalculatedDirection_deg") drogueRunPosition.CalculatedDirection_deg = GetRandomDouble(0.0D, 360.0D);
            if (OmitPropName != "LastUpdateDate_UTC") drogueRunPosition.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") drogueRunPosition.LastUpdateContactTVItemID = 2;

            return drogueRunPosition;
        }
        #endregion Functions private
    }
}
