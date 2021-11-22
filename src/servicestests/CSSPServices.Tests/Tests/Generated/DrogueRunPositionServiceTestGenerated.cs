/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Services;
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
using System.ComponentModel.DataAnnotations;
using CSSPCultureServices.Resources;

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
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IDrogueRunPositionService DrogueRunPositionService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private DrogueRunPosition drogueRunPosition { get; set; }
        #endregion Properties

        #region Constructors
        public DrogueRunPositionServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task DrogueRunPosition_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            drogueRunPosition = GetFilledRandomDrogueRunPosition("");

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
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

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task DrogueRunPosition_Properties_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionDrogueRunPositionList = await DrogueRunPositionService.GetDrogueRunPositionList();
            Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDrogueRunPositionList.Result).Value);
            List<DrogueRunPosition> drogueRunPositionList = (List<DrogueRunPosition>)((OkObjectResult)actionDrogueRunPositionList.Result).Value;

            count = drogueRunPositionList.Count();

            DrogueRunPosition drogueRunPosition = GetFilledRandomDrogueRunPosition("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // drogueRunPosition.DrogueRunPositionID   (Int32)
            // -----------------------------------

            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.DrogueRunPositionID = 0;

            var actionDrogueRunPosition = await DrogueRunPositionService.Put(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);

            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.DrogueRunPositionID = 10000000;
            actionDrogueRunPosition = await DrogueRunPositionService.Put(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "DrogueRun", ExistPlurial = "s", ExistFieldID = "DrogueRunID", AllowableTVtypeList = )]
            // drogueRunPosition.DrogueRunID   (Int32)
            // -----------------------------------

            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.DrogueRunID = 0;
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100000)]
            // drogueRunPosition.Ordinal   (Int32)
            // -----------------------------------

            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.Ordinal = -1;
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);
            //Assert.AreEqual(count, drogueRunPositionService.GetDrogueRunPositionList().Count());
            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.Ordinal = 100001;
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);
            //Assert.AreEqual(count, drogueRunPositionService.GetDrogueRunPositionList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-180, 180)]
            // drogueRunPosition.StepLat   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [StepLat]

            //CSSPError: Type not implemented [StepLat]

            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.StepLat = -181.0D;
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);
            //Assert.AreEqual(count, drogueRunPositionService.GetDrogueRunPositionList().Count());
            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.StepLat = 181.0D;
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);
            //Assert.AreEqual(count, drogueRunPositionService.GetDrogueRunPositionList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-90, 90)]
            // drogueRunPosition.StepLng   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [StepLng]

            //CSSPError: Type not implemented [StepLng]

            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.StepLng = -91.0D;
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);
            //Assert.AreEqual(count, drogueRunPositionService.GetDrogueRunPositionList().Count());
            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.StepLng = 91.0D;
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);
            //Assert.AreEqual(count, drogueRunPositionService.GetDrogueRunPositionList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // drogueRunPosition.StepDateTime_Local   (DateTime)
            // -----------------------------------

            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.StepDateTime_Local = new DateTime();
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);
            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.StepDateTime_Local = new DateTime(1979, 1, 1);
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10)]
            // drogueRunPosition.CalculatedSpeed_m_s   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [CalculatedSpeed_m_s]

            //CSSPError: Type not implemented [CalculatedSpeed_m_s]

            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.CalculatedSpeed_m_s = -1.0D;
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);
            //Assert.AreEqual(count, drogueRunPositionService.GetDrogueRunPositionList().Count());
            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.CalculatedSpeed_m_s = 11.0D;
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);
            //Assert.AreEqual(count, drogueRunPositionService.GetDrogueRunPositionList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 360)]
            // drogueRunPosition.CalculatedDirection_deg   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [CalculatedDirection_deg]

            //CSSPError: Type not implemented [CalculatedDirection_deg]

            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.CalculatedDirection_deg = -1.0D;
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);
            //Assert.AreEqual(count, drogueRunPositionService.GetDrogueRunPositionList().Count());
            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.CalculatedDirection_deg = 361.0D;
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);
            //Assert.AreEqual(count, drogueRunPositionService.GetDrogueRunPositionList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // drogueRunPosition.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.LastUpdateDate_UTC = new DateTime();
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);
            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // drogueRunPosition.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.LastUpdateContactTVItemID = 0;
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);

            drogueRunPosition = null;
            drogueRunPosition = GetFilledRandomDrogueRunPosition("");
            drogueRunPosition.LastUpdateContactTVItemID = 1;
            actionDrogueRunPosition = await DrogueRunPositionService.Post(drogueRunPosition);
            Assert.IsType<BadRequestObjectResult>(actionDrogueRunPosition.Result);

        }
        #endregion Tests Generated Properties

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

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<DrogueRunPosition> with skip and take
                var actionDrogueRunPositionListSkipAndTake = await DrogueRunPositionService.GetDrogueRunPositionList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionDrogueRunPositionListSkipAndTake.Result).Value);
                List<DrogueRunPosition> drogueRunPositionListSkipAndTake = (List<DrogueRunPosition>)((OkObjectResult)actionDrogueRunPositionListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<DrogueRunPosition>)((OkObjectResult)actionDrogueRunPositionListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(drogueRunPositionList[0].DrogueRunPositionID == drogueRunPositionListSkipAndTake[0].DrogueRunPositionID);
            }

            // Get DrogueRunPosition With DrogueRunPositionID
            var actionDrogueRunPositionGet = await DrogueRunPositionService.GetDrogueRunPositionWithDrogueRunPositionID(drogueRunPositionList[0].DrogueRunPositionID);
            Assert.Equal(200, ((ObjectResult)actionDrogueRunPositionGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDrogueRunPositionGet.Result).Value);
            DrogueRunPosition drogueRunPositionGet = (DrogueRunPosition)((OkObjectResult)actionDrogueRunPositionGet.Result).Value;
            Assert.NotNull(drogueRunPositionGet);
            Assert.Equal(drogueRunPositionGet.DrogueRunPositionID, drogueRunPositionList[0].DrogueRunPositionID);

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
               .AddJsonFile("appsettings_csspservicestests.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            string TestDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IDrogueRunPositionService, DrogueRunPositionService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.DBLocation = DBLocationEnum.Local;

            dbIM = Provider.GetService<CSSPDBInMemoryContext>();
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

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
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
        private void CheckDrogueRunPositionFields(List<DrogueRunPosition> drogueRunPositionList)
        {
        }
        #endregion Functions private
    }
}