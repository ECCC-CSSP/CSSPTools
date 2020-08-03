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
    public partial class MikeSourceStartEndServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMikeSourceStartEndService MikeSourceStartEndService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private MikeSourceStartEnd mikeSourceStartEnd { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task MikeSourceStartEnd_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");

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
        public async Task MikeSourceStartEnd_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionMikeSourceStartEndList = await MikeSourceStartEndService.GetMikeSourceStartEndList();
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndList.Result).Value);
            List<MikeSourceStartEnd> mikeSourceStartEndList = (List<MikeSourceStartEnd>)((OkObjectResult)actionMikeSourceStartEndList.Result).Value;

            count = mikeSourceStartEndList.Count();

            MikeSourceStartEnd mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mikeSourceStartEnd.MikeSourceStartEndID   (Int32)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.MikeSourceStartEndID = 0;

            var actionMikeSourceStartEnd = await MikeSourceStartEndService.Put(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.MikeSourceStartEndID = 10000000;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Put(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "MikeSource", ExistPlurial = "s", ExistFieldID = "MikeSourceID", AllowableTVtypeList = )]
            // mikeSourceStartEnd.MikeSourceID   (Int32)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.MikeSourceID = 0;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeSourceStartEnd.StartDateAndTime_Local   (DateTime)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.StartDateAndTime_Local = new DateTime();
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.StartDateAndTime_Local = new DateTime(1979, 1, 1);
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // [CSSPBigger(OtherField = StartDateAndTime_Local)]
            // mikeSourceStartEnd.EndDateAndTime_Local   (DateTime)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.EndDateAndTime_Local = new DateTime();
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.EndDateAndTime_Local = new DateTime(1979, 1, 1);
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000000)]
            // mikeSourceStartEnd.SourceFlowStart_m3_day   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [SourceFlowStart_m3_day]

            //CSSPError: Type not implemented [SourceFlowStart_m3_day]

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceFlowStart_m3_day = -1.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceFlowStart_m3_day = 1000001.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000000)]
            // mikeSourceStartEnd.SourceFlowEnd_m3_day   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [SourceFlowEnd_m3_day]

            //CSSPError: Type not implemented [SourceFlowEnd_m3_day]

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceFlowEnd_m3_day = -1.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceFlowEnd_m3_day = 1000001.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000000)]
            // mikeSourceStartEnd.SourcePollutionStart_MPN_100ml   (Int32)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = -1;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 10000001;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000000)]
            // mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml   (Int32)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = -1;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 10000001;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-10, 40)]
            // mikeSourceStartEnd.SourceTemperatureStart_C   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [SourceTemperatureStart_C]

            //CSSPError: Type not implemented [SourceTemperatureStart_C]

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceTemperatureStart_C = -11.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceTemperatureStart_C = 41.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(-10, 40)]
            // mikeSourceStartEnd.SourceTemperatureEnd_C   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [SourceTemperatureEnd_C]

            //CSSPError: Type not implemented [SourceTemperatureEnd_C]

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceTemperatureEnd_C = -11.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceTemperatureEnd_C = 41.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 40)]
            // mikeSourceStartEnd.SourceSalinityStart_PSU   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [SourceSalinityStart_PSU]

            //CSSPError: Type not implemented [SourceSalinityStart_PSU]

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceSalinityStart_PSU = -1.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceSalinityStart_PSU = 41.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 40)]
            // mikeSourceStartEnd.SourceSalinityEnd_PSU   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [SourceSalinityEnd_PSU]

            //CSSPError: Type not implemented [SourceSalinityEnd_PSU]

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceSalinityEnd_PSU = -1.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceSalinityEnd_PSU = 41.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeSourceStartEnd.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.LastUpdateDate_UTC = new DateTime();
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mikeSourceStartEnd.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.LastUpdateContactTVItemID = 0;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.LastUpdateContactTVItemID = 1;
            actionMikeSourceStartEnd = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post MikeSourceStartEnd
            var actionMikeSourceStartEndAdded = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndAdded.Result).Value);
            MikeSourceStartEnd mikeSourceStartEndAdded = (MikeSourceStartEnd)((OkObjectResult)actionMikeSourceStartEndAdded.Result).Value;
            Assert.NotNull(mikeSourceStartEndAdded);

            // List<MikeSourceStartEnd>
            var actionMikeSourceStartEndList = await MikeSourceStartEndService.GetMikeSourceStartEndList();
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndList.Result).Value);
            List<MikeSourceStartEnd> mikeSourceStartEndList = (List<MikeSourceStartEnd>)((OkObjectResult)actionMikeSourceStartEndList.Result).Value;

            int count = ((List<MikeSourceStartEnd>)((OkObjectResult)actionMikeSourceStartEndList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<MikeSourceStartEnd> with skip and take
                var actionMikeSourceStartEndListSkipAndTake = await MikeSourceStartEndService.GetMikeSourceStartEndList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndListSkipAndTake.Result).Value);
                List<MikeSourceStartEnd> mikeSourceStartEndListSkipAndTake = (List<MikeSourceStartEnd>)((OkObjectResult)actionMikeSourceStartEndListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<MikeSourceStartEnd>)((OkObjectResult)actionMikeSourceStartEndListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(mikeSourceStartEndList[0].MikeSourceStartEndID == mikeSourceStartEndListSkipAndTake[0].MikeSourceStartEndID);
            }

            // Get MikeSourceStartEnd With MikeSourceStartEndID
            var actionMikeSourceStartEndGet = await MikeSourceStartEndService.GetMikeSourceStartEndWithMikeSourceStartEndID(mikeSourceStartEndList[0].MikeSourceStartEndID);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndGet.Result).Value);
            MikeSourceStartEnd mikeSourceStartEndGet = (MikeSourceStartEnd)((OkObjectResult)actionMikeSourceStartEndGet.Result).Value;
            Assert.NotNull(mikeSourceStartEndGet);
            Assert.Equal(mikeSourceStartEndGet.MikeSourceStartEndID, mikeSourceStartEndList[0].MikeSourceStartEndID);

            // Put MikeSourceStartEnd
            var actionMikeSourceStartEndUpdated = await MikeSourceStartEndService.Put(mikeSourceStartEnd);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndUpdated.Result).Value);
            MikeSourceStartEnd mikeSourceStartEndUpdated = (MikeSourceStartEnd)((OkObjectResult)actionMikeSourceStartEndUpdated.Result).Value;
            Assert.NotNull(mikeSourceStartEndUpdated);

            // Delete MikeSourceStartEnd
            var actionMikeSourceStartEndDeleted = await MikeSourceStartEndService.Delete(mikeSourceStartEnd.MikeSourceStartEndID);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMikeSourceStartEndDeleted.Result).Value;
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
            Services.AddSingleton<IMikeSourceStartEndService, MikeSourceStartEndService>();

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

            MikeSourceStartEndService = Provider.GetService<IMikeSourceStartEndService>();
            Assert.NotNull(MikeSourceStartEndService);

            return await Task.FromResult(true);
        }
        private MikeSourceStartEnd GetFilledRandomMikeSourceStartEnd(string OmitPropName)
        {
            List<MikeSourceStartEnd> mikeSourceStartEndListToDelete = (from c in dbLocal.MikeSourceStartEnds
                                                               select c).ToList(); 
            
            dbLocal.MikeSourceStartEnds.RemoveRange(mikeSourceStartEndListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            MikeSourceStartEnd mikeSourceStartEnd = new MikeSourceStartEnd();

            if (OmitPropName != "MikeSourceID") mikeSourceStartEnd.MikeSourceID = 1;
            if (OmitPropName != "StartDateAndTime_Local") mikeSourceStartEnd.StartDateAndTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateAndTime_Local") mikeSourceStartEnd.EndDateAndTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "SourceFlowStart_m3_day") mikeSourceStartEnd.SourceFlowStart_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourceFlowEnd_m3_day") mikeSourceStartEnd.SourceFlowEnd_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourcePollutionStart_MPN_100ml") mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourcePollutionEnd_MPN_100ml") mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourceTemperatureStart_C") mikeSourceStartEnd.SourceTemperatureStart_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SourceTemperatureEnd_C") mikeSourceStartEnd.SourceTemperatureEnd_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SourceSalinityStart_PSU") mikeSourceStartEnd.SourceSalinityStart_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "SourceSalinityEnd_PSU") mikeSourceStartEnd.SourceSalinityEnd_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "LastUpdateDate_UTC") mikeSourceStartEnd.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeSourceStartEnd.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "MikeSourceStartEndID") mikeSourceStartEnd.MikeSourceStartEndID = 10000000;

                try
                {
                    dbIM.MikeSources.Add(new MikeSource() { MikeSourceID = 1, MikeSourceTVItemID = 53, IsContinuous = true, Include = false, IsRiver = false, UseHydrometric = false, HydrometricTVItemID = null, DrainageArea_km2 = null, Factor = null, SourceNumberString = "SOURCE_1", LastUpdateDate_UTC = new DateTime(2014, 12, 2, 21, 28, 56), LastUpdateContactTVItemID = 2 });
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

            return mikeSourceStartEnd;
        }
        private void CheckMikeSourceStartEndFields(List<MikeSourceStartEnd> mikeSourceStartEndList)
        {
        }
        #endregion Functions private
    }
}
