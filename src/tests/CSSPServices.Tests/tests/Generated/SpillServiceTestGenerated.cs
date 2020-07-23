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
    public partial class SpillServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ISpillService SpillService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private Spill spill { get; set; }
        #endregion Properties

        #region Constructors
        public SpillServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task Spill_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            spill = GetFilledRandomSpill("");

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
        public async Task Spill_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionSpillList = await SpillService.GetSpillList();
            Assert.Equal(200, ((ObjectResult)actionSpillList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillList.Result).Value);
            List<Spill> spillList = (List<Spill>)((OkObjectResult)actionSpillList.Result).Value;

            count = spillList.Count();

            Spill spill = GetFilledRandomSpill("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // spill.SpillID   (Int32)
            // -----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.SpillID = 0;

            var actionSpill = await SpillService.Put(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.SpillID = 10000000;
            actionSpill = await SpillService.Put(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Municipality)]
            // spill.MunicipalityTVItemID   (Int32)
            // -----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.MunicipalityTVItemID = 0;
            actionSpill = await SpillService.Post(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.MunicipalityTVItemID = 1;
            actionSpill = await SpillService.Post(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
            // spill.InfrastructureTVItemID   (Int32)
            // -----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.InfrastructureTVItemID = 0;
            actionSpill = await SpillService.Post(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.InfrastructureTVItemID = 1;
            actionSpill = await SpillService.Post(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // spill.StartDateTime_Local   (DateTime)
            // -----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.StartDateTime_Local = new DateTime();
            actionSpill = await SpillService.Post(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);
            spill = null;
            spill = GetFilledRandomSpill("");
            spill.StartDateTime_Local = new DateTime(1979, 1, 1);
            actionSpill = await SpillService.Post(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);

            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // [CSSPBigger(OtherField = StartDateTime_Local)]
            // spill.EndDateTime_Local   (DateTime)
            // -----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.EndDateTime_Local = new DateTime(1979, 1, 1);
            actionSpill = await SpillService.Post(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000000)]
            // spill.AverageFlow_m3_day   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [AverageFlow_m3_day]

            //CSSPError: Type not implemented [AverageFlow_m3_day]

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.AverageFlow_m3_day = -1.0D;
            actionSpill = await SpillService.Post(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);
            //Assert.AreEqual(count, spillService.GetSpillList().Count());
            spill = null;
            spill = GetFilledRandomSpill("");
            spill.AverageFlow_m3_day = 1000001.0D;
            actionSpill = await SpillService.Post(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);
            //Assert.AreEqual(count, spillService.GetSpillList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // spill.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.LastUpdateDate_UTC = new DateTime();
            actionSpill = await SpillService.Post(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);
            spill = null;
            spill = GetFilledRandomSpill("");
            spill.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionSpill = await SpillService.Post(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // spill.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.LastUpdateContactTVItemID = 0;
            actionSpill = await SpillService.Post(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);

            spill = null;
            spill = GetFilledRandomSpill("");
            spill.LastUpdateContactTVItemID = 1;
            actionSpill = await SpillService.Post(spill);
            Assert.IsType<BadRequestObjectResult>(actionSpill.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post Spill
            var actionSpillAdded = await SpillService.Post(spill);
            Assert.Equal(200, ((ObjectResult)actionSpillAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillAdded.Result).Value);
            Spill spillAdded = (Spill)((OkObjectResult)actionSpillAdded.Result).Value;
            Assert.NotNull(spillAdded);

            // List<Spill>
            var actionSpillList = await SpillService.GetSpillList();
            Assert.Equal(200, ((ObjectResult)actionSpillList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillList.Result).Value);
            List<Spill> spillList = (List<Spill>)((OkObjectResult)actionSpillList.Result).Value;

            int count = ((List<Spill>)((OkObjectResult)actionSpillList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<Spill> with skip and take
                var actionSpillListSkipAndTake = await SpillService.GetSpillList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionSpillListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionSpillListSkipAndTake.Result).Value);
                List<Spill> spillListSkipAndTake = (List<Spill>)((OkObjectResult)actionSpillListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<Spill>)((OkObjectResult)actionSpillListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(spillList[0].SpillID == spillListSkipAndTake[0].SpillID);
            }

            // Get Spill With SpillID
            var actionSpillGet = await SpillService.GetSpillWithSpillID(spillList[0].SpillID);
            Assert.Equal(200, ((ObjectResult)actionSpillGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillGet.Result).Value);
            Spill spillGet = (Spill)((OkObjectResult)actionSpillGet.Result).Value;
            Assert.NotNull(spillGet);
            Assert.Equal(spillGet.SpillID, spillList[0].SpillID);

            // Put Spill
            var actionSpillUpdated = await SpillService.Put(spill);
            Assert.Equal(200, ((ObjectResult)actionSpillUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillUpdated.Result).Value);
            Spill spillUpdated = (Spill)((OkObjectResult)actionSpillUpdated.Result).Value;
            Assert.NotNull(spillUpdated);

            // Delete Spill
            var actionSpillDeleted = await SpillService.Delete(spill.SpillID);
            Assert.Equal(200, ((ObjectResult)actionSpillDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionSpillDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservices.json")
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

            Services.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ISpillService, SpillService>();

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

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            SpillService = Provider.GetService<ISpillService>();
            Assert.NotNull(SpillService);

            return await Task.FromResult(true);
        }
        private Spill GetFilledRandomSpill(string OmitPropName)
        {
            List<Spill> spillListToDelete = (from c in dbLocal.Spills
                                                               select c).ToList(); 
            
            dbLocal.Spills.RemoveRange(spillListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            Spill spill = new Spill();

            if (OmitPropName != "MunicipalityTVItemID") spill.MunicipalityTVItemID = 39;
            if (OmitPropName != "InfrastructureTVItemID") spill.InfrastructureTVItemID = 41;
            if (OmitPropName != "StartDateTime_Local") spill.StartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_Local") spill.EndDateTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "AverageFlow_m3_day") spill.AverageFlow_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") spill.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") spill.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "SpillID") spill.SpillID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 39, TVLevel = 3, TVPath = "p1p5p6p39", TVType = (TVTypeEnum)15, ParentID = 6, IsActive = true, LastUpdateDate_UTC = new DateTime(2015, 2, 22, 14, 12, 19), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 41, TVLevel = 4, TVPath = "p1p5p6p39p41", TVType = (TVTypeEnum)10, ParentID = 39, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 21, 29, 23), LastUpdateContactTVItemID = 2});
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

            return spill;
        }
        private void CheckSpillFields(List<Spill> spillList)
        {
            if (spillList[0].InfrastructureTVItemID != null)
            {
                Assert.NotNull(spillList[0].InfrastructureTVItemID);
            }
            if (spillList[0].EndDateTime_Local != null)
            {
                Assert.NotNull(spillList[0].EndDateTime_Local);
            }
        }
        #endregion Functions private
    }
}
