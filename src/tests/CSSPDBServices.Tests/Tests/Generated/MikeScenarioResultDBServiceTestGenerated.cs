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
    public partial class MikeScenarioResultDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMikeScenarioResultDBService MikeScenarioResultDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private MikeScenarioResult mikeScenarioResult { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioResultDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DB]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MikeScenarioResultDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MikeScenarioResult_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionMikeScenarioResultList = await MikeScenarioResultDBService.GetMikeScenarioResultList();
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultList.Result).Value);
            List<MikeScenarioResult> mikeScenarioResultList = (List<MikeScenarioResult>)((OkObjectResult)actionMikeScenarioResultList.Result).Value;

            count = mikeScenarioResultList.Count();

            MikeScenarioResult mikeScenarioResult = GetFilledRandomMikeScenarioResult("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mikeScenarioResult.MikeScenarioResultID   (Int32)
            // -----------------------------------

            mikeScenarioResult = null;
            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
            mikeScenarioResult.MikeScenarioResultID = 0;

            var actionMikeScenarioResult = await MikeScenarioResultDBService.Put(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);

            mikeScenarioResult = null;
            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
            mikeScenarioResult.MikeScenarioResultID = 10000000;
            actionMikeScenarioResult = await MikeScenarioResultDBService.Put(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeScenario)]
            // mikeScenarioResult.MikeScenarioTVItemID   (Int32)
            // -----------------------------------

            mikeScenarioResult = null;
            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
            mikeScenarioResult.MikeScenarioTVItemID = 0;
            actionMikeScenarioResult = await MikeScenarioResultDBService.Post(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);

            mikeScenarioResult = null;
            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
            mikeScenarioResult.MikeScenarioTVItemID = 1;
            actionMikeScenarioResult = await MikeScenarioResultDBService.Post(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);


            // -----------------------------------
            // Is Nullable
            // mikeScenarioResult.MikeResultsJSON   (String)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeScenarioResult.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mikeScenarioResult = null;
            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
            mikeScenarioResult.LastUpdateDate_UTC = new DateTime();
            actionMikeScenarioResult = await MikeScenarioResultDBService.Post(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);
            mikeScenarioResult = null;
            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
            mikeScenarioResult.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMikeScenarioResult = await MikeScenarioResultDBService.Post(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mikeScenarioResult.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mikeScenarioResult = null;
            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
            mikeScenarioResult.LastUpdateContactTVItemID = 0;
            actionMikeScenarioResult = await MikeScenarioResultDBService.Post(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);

            mikeScenarioResult = null;
            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
            mikeScenarioResult.LastUpdateContactTVItemID = 1;
            actionMikeScenarioResult = await MikeScenarioResultDBService.Post(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post MikeScenarioResult
            var actionMikeScenarioResultAdded = await MikeScenarioResultDBService.Post(mikeScenarioResult);
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultAdded.Result).Value);
            MikeScenarioResult mikeScenarioResultAdded = (MikeScenarioResult)((OkObjectResult)actionMikeScenarioResultAdded.Result).Value;
            Assert.NotNull(mikeScenarioResultAdded);

            // List<MikeScenarioResult>
            var actionMikeScenarioResultList = await MikeScenarioResultDBService.GetMikeScenarioResultList();
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultList.Result).Value);
            List<MikeScenarioResult> mikeScenarioResultList = (List<MikeScenarioResult>)((OkObjectResult)actionMikeScenarioResultList.Result).Value;

            int count = ((List<MikeScenarioResult>)((OkObjectResult)actionMikeScenarioResultList.Result).Value).Count();
            Assert.True(count > 0);

            // List<MikeScenarioResult> with skip and take
            var actionMikeScenarioResultListSkipAndTake = await MikeScenarioResultDBService.GetMikeScenarioResultList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultListSkipAndTake.Result).Value);
            List<MikeScenarioResult> mikeScenarioResultListSkipAndTake = (List<MikeScenarioResult>)((OkObjectResult)actionMikeScenarioResultListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<MikeScenarioResult>)((OkObjectResult)actionMikeScenarioResultListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(mikeScenarioResultList[0].MikeScenarioResultID == mikeScenarioResultListSkipAndTake[0].MikeScenarioResultID);

            // Get MikeScenarioResult With MikeScenarioResultID
            var actionMikeScenarioResultGet = await MikeScenarioResultDBService.GetMikeScenarioResultWithMikeScenarioResultID(mikeScenarioResultList[0].MikeScenarioResultID);
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultGet.Result).Value);
            MikeScenarioResult mikeScenarioResultGet = (MikeScenarioResult)((OkObjectResult)actionMikeScenarioResultGet.Result).Value;
            Assert.NotNull(mikeScenarioResultGet);
            Assert.Equal(mikeScenarioResultGet.MikeScenarioResultID, mikeScenarioResultList[0].MikeScenarioResultID);

            // Put MikeScenarioResult
            var actionMikeScenarioResultUpdated = await MikeScenarioResultDBService.Put(mikeScenarioResult);
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultUpdated.Result).Value);
            MikeScenarioResult mikeScenarioResultUpdated = (MikeScenarioResult)((OkObjectResult)actionMikeScenarioResultUpdated.Result).Value;
            Assert.NotNull(mikeScenarioResultUpdated);

            // Delete MikeScenarioResult
            var actionMikeScenarioResultDeleted = await MikeScenarioResultDBService.Delete(mikeScenarioResult.MikeScenarioResultID);
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMikeScenarioResultDeleted.Result).Value;
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
            Services.AddSingleton<IMikeScenarioResultDBService, MikeScenarioResultDBService>();

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

            MikeScenarioResultDBService = Provider.GetService<IMikeScenarioResultDBService>();
            Assert.NotNull(MikeScenarioResultDBService);

            return await Task.FromResult(true);
        }
        private MikeScenarioResult GetFilledRandomMikeScenarioResult(string OmitPropName)
        {
            MikeScenarioResult mikeScenarioResult = new MikeScenarioResult();

            if (OmitPropName != "MikeScenarioTVItemID") mikeScenarioResult.MikeScenarioTVItemID = 51;
            if (OmitPropName != "MikeResultsJSON") mikeScenarioResult.MikeResultsJSON = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") mikeScenarioResult.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeScenarioResult.LastUpdateContactTVItemID = 2;



            return mikeScenarioResult;
        }
        private void CheckMikeScenarioResultFields(List<MikeScenarioResult> mikeScenarioResultList)
        {
            if (!string.IsNullOrWhiteSpace(mikeScenarioResultList[0].MikeResultsJSON))
            {
                Assert.False(string.IsNullOrWhiteSpace(mikeScenarioResultList[0].MikeResultsJSON));
            }
        }

        #endregion Functions private
    }
}
