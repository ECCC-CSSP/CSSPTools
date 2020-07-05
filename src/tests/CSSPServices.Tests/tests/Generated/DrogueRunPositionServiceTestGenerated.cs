/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
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
using Xunit;

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class DrogueRunPositionServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IDrogueRunPositionService DrogueRunPositionService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private DrogueRunPosition drogueRunPosition { get; set; }
        #endregion Properties

        #region Constructors
        public DrogueRunPositionServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task DrogueRunPosition_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            drogueRunPosition = GetFilledRandomDrogueRunPosition("");

            if (LoggedInService.IsLocal)
            {
                await DoCRUDTest();
            }
            else
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    await DoCRUDTest();
                }
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post DrogueRunPosition
            var actionDrogueRunPositionAdded = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDrogueRunPositionAdded.Result).Value);
            DrogueRunPosition drogueRunPositionAdded = (DrogueRunPosition)((OkObjectResult)actionDrogueRunPositionAdded.Result).Value;
            Assert.NotNull(drogueRunPositionAdded);

            // List<DrogueRunPosition>
            var actionDrogueRunPositionList = await DrogueRunPositionService.GetDrogueRunPositionList();
            Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDrogueRunPositionList.Result).Value);
            List<DrogueRunPosition> drogueRunPositionList = (List<DrogueRunPosition>)((OkObjectResult)actionDrogueRunPositionList.Result).Value;

            int count = ((List<DrogueRunPosition>)((OkObjectResult)actionDrogueRunPositionList.Result).Value).Count();
            Assert.True(count > 0);

            // Put DrogueRunPosition
            var actionDrogueRunPositionUpdated = await DrogueRunPositionService.Put(drogueRunPosition);
            Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDrogueRunPositionUpdated.Result).Value);
            DrogueRunPosition drogueRunPositionUpdated = (DrogueRunPosition)((OkObjectResult)actionDrogueRunPositionUpdated.Result).Value;
            Assert.NotNull(drogueRunPositionUpdated);

            // Delete DrogueRunPosition
            var actionDrogueRunPositionDeleted = await DrogueRunPositionService.Delete(drogueRunPosition.DrogueRunPositionID);
            Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDrogueRunPositionDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionDrogueRunPositionDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{appDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IDrogueRunPositionService, DrogueRunPositionService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            //string IsLocalStr = Config.GetValue<string>("IsLocal");
            //Assert.NotNull(IsLocalStr);

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            DrogueRunPositionService = Provider.GetService<IDrogueRunPositionService>();
            Assert.NotNull(DrogueRunPositionService);

            return await Task.FromResult(true);
        }
        private DrogueRunPosition GetFilledRandomDrogueRunPosition(string OmitPropName)
        {
            List<DrogueRunPosition> drogueRunPositionListToDelete = (from c in dbLocal.DrogueRunPositions
                                                               select c).ToList(); 
            
            dbLocal.DrogueRunPositions.RemoveRange(drogueRunPositionListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

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

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "DrogueRunPositionID") drogueRunPosition.DrogueRunPositionID = 10000000;

                try
                {
                    dbIM.DrogueRuns.Add(new DrogueRun() { DrogueRunID = 1, SubsectorTVItemID = 12, DrogueNumber = 12, DrogueType = (DrogueTypeEnum)2, RunStartDateTime = new DateTime(2018, 10, 11, 12, 42, 7), IsRisingTide = true, LastUpdateDate_UTC = new DateTime(2019, 2, 11, 16, 27, 53), LastUpdateContactTVItemID = 2 });
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
            }

            return drogueRunPosition;
        }
        #endregion Functions private
    }
}
