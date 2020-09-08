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
using LoggedInServices;

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class MikeSourceStartEndDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMikeSourceStartEndDBService MikeSourceStartEndDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private MikeSourceStartEnd mikeSourceStartEnd { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DB]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MikeSourceStartEndDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MikeSourceStartEnd_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionMikeSourceStartEndList = await MikeSourceStartEndDBService.GetMikeSourceStartEndList();
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

            var actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Put(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.MikeSourceStartEndID = 10000000;
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Put(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "MikeSource", ExistPlurial = "s", ExistFieldID = "MikeSourceID", AllowableTVtypeList = )]
            // mikeSourceStartEnd.MikeSourceID   (Int32)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.MikeSourceID = 0;
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeSourceStartEnd.StartDateAndTime_Local   (DateTime)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.StartDateAndTime_Local = new DateTime();
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.StartDateAndTime_Local = new DateTime(1979, 1, 1);
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
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
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.EndDateAndTime_Local = new DateTime(1979, 1, 1);
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
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
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceFlowStart_m3_day = 1000001.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndDBService.GetMikeSourceStartEndList().Count());

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
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceFlowEnd_m3_day = 1000001.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndDBService.GetMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000000)]
            // mikeSourceStartEnd.SourcePollutionStart_MPN_100ml   (Int32)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = -1;
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = 10000001;
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndDBService.GetMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000000)]
            // mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml   (Int32)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = -1;
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = 10000001;
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndDBService.GetMikeSourceStartEndList().Count());

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
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceTemperatureStart_C = 41.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndDBService.GetMikeSourceStartEndList().Count());

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
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceTemperatureEnd_C = 41.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndDBService.GetMikeSourceStartEndList().Count());

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
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceSalinityStart_PSU = 41.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndDBService.GetMikeSourceStartEndList().Count());

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
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndService.GetMikeSourceStartEndList().Count());
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.SourceSalinityEnd_PSU = 41.0D;
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            //Assert.AreEqual(count, mikeSourceStartEndDBService.GetMikeSourceStartEndList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeSourceStartEnd.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.LastUpdateDate_UTC = new DateTime();
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);
            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mikeSourceStartEnd.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.LastUpdateContactTVItemID = 0;
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);

            mikeSourceStartEnd = null;
            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");
            mikeSourceStartEnd.LastUpdateContactTVItemID = 1;
            actionMikeSourceStartEnd = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.IsType<BadRequestObjectResult>(actionMikeSourceStartEnd.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post MikeSourceStartEnd
            var actionMikeSourceStartEndAdded = await MikeSourceStartEndDBService.Post(mikeSourceStartEnd);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndAdded.Result).Value);
            MikeSourceStartEnd mikeSourceStartEndAdded = (MikeSourceStartEnd)((OkObjectResult)actionMikeSourceStartEndAdded.Result).Value;
            Assert.NotNull(mikeSourceStartEndAdded);

            // List<MikeSourceStartEnd>
            var actionMikeSourceStartEndList = await MikeSourceStartEndDBService.GetMikeSourceStartEndList();
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndList.Result).Value);
            List<MikeSourceStartEnd> mikeSourceStartEndList = (List<MikeSourceStartEnd>)((OkObjectResult)actionMikeSourceStartEndList.Result).Value;

            int count = ((List<MikeSourceStartEnd>)((OkObjectResult)actionMikeSourceStartEndList.Result).Value).Count();
            Assert.True(count > 0);

            // List<MikeSourceStartEnd> with skip and take
            var actionMikeSourceStartEndListSkipAndTake = await MikeSourceStartEndDBService.GetMikeSourceStartEndList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndListSkipAndTake.Result).Value);
            List<MikeSourceStartEnd> mikeSourceStartEndListSkipAndTake = (List<MikeSourceStartEnd>)((OkObjectResult)actionMikeSourceStartEndListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<MikeSourceStartEnd>)((OkObjectResult)actionMikeSourceStartEndListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(mikeSourceStartEndList[0].MikeSourceStartEndID == mikeSourceStartEndListSkipAndTake[0].MikeSourceStartEndID);

            // Get MikeSourceStartEnd With MikeSourceStartEndID
            var actionMikeSourceStartEndGet = await MikeSourceStartEndDBService.GetMikeSourceStartEndWithMikeSourceStartEndID(mikeSourceStartEndList[0].MikeSourceStartEndID);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndGet.Result).Value);
            MikeSourceStartEnd mikeSourceStartEndGet = (MikeSourceStartEnd)((OkObjectResult)actionMikeSourceStartEndGet.Result).Value;
            Assert.NotNull(mikeSourceStartEndGet);
            Assert.Equal(mikeSourceStartEndGet.MikeSourceStartEndID, mikeSourceStartEndList[0].MikeSourceStartEndID);

            // Put MikeSourceStartEnd
            var actionMikeSourceStartEndUpdated = await MikeSourceStartEndDBService.Put(mikeSourceStartEnd);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndUpdated.Result).Value);
            MikeSourceStartEnd mikeSourceStartEndUpdated = (MikeSourceStartEnd)((OkObjectResult)actionMikeSourceStartEndUpdated.Result).Value;
            Assert.NotNull(mikeSourceStartEndUpdated);

            // Delete MikeSourceStartEnd
            var actionMikeSourceStartEndDeleted = await MikeSourceStartEndDBService.Delete(mikeSourceStartEnd.MikeSourceStartEndID);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMikeSourceStartEndDeleted.Result).Value;
            Assert.True(retBool);

            db.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("70c662c1-a1a8-4b2c-b594-d7834bb5e6db")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IMikeSourceStartEndDBService, MikeSourceStartEndDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            MikeSourceStartEndDBService = Provider.GetService<IMikeSourceStartEndDBService>();
            Assert.NotNull(MikeSourceStartEndDBService);

            return await Task.FromResult(true);
        }
        private MikeSourceStartEnd GetFilledRandomMikeSourceStartEnd(string OmitPropName)
        {
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



            return mikeSourceStartEnd;
        }
        private void CheckMikeSourceStartEndFields(List<MikeSourceStartEnd> mikeSourceStartEndList)
        {
        }

        #endregion Functions private
    }
}
