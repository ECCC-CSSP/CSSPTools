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
using LocalServices;
using System.Threading;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class MikeScenarioResultDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IMikeScenarioResultDBLocalService MikeScenarioResultDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private MikeScenarioResult mikeScenarioResult { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioResultDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocal]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MikeScenarioResultDBLocal_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocal]

        #region Tests Generated [DBLocal] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MikeScenarioResultDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated [DBLocal] CRUD

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

            var actionMikeScenarioResultList = await MikeScenarioResultDBLocalService.GetMikeScenarioResultList();
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

            var actionMikeScenarioResult = await MikeScenarioResultDBLocalService.Put(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);

            mikeScenarioResult = null;
            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
            mikeScenarioResult.MikeScenarioResultID = 10000000;
            actionMikeScenarioResult = await MikeScenarioResultDBLocalService.Put(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeScenario)]
            // mikeScenarioResult.MikeScenarioTVItemID   (Int32)
            // -----------------------------------

            mikeScenarioResult = null;
            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
            mikeScenarioResult.MikeScenarioTVItemID = 0;
            actionMikeScenarioResult = await MikeScenarioResultDBLocalService.Post(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);

            mikeScenarioResult = null;
            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
            mikeScenarioResult.MikeScenarioTVItemID = 1;
            actionMikeScenarioResult = await MikeScenarioResultDBLocalService.Post(mikeScenarioResult);
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
            actionMikeScenarioResult = await MikeScenarioResultDBLocalService.Post(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);
            mikeScenarioResult = null;
            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
            mikeScenarioResult.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMikeScenarioResult = await MikeScenarioResultDBLocalService.Post(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mikeScenarioResult.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mikeScenarioResult = null;
            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
            mikeScenarioResult.LastUpdateContactTVItemID = 0;
            actionMikeScenarioResult = await MikeScenarioResultDBLocalService.Post(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);

            mikeScenarioResult = null;
            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");
            mikeScenarioResult.LastUpdateContactTVItemID = 1;
            actionMikeScenarioResult = await MikeScenarioResultDBLocalService.Post(mikeScenarioResult);
            Assert.IsType<BadRequestObjectResult>(actionMikeScenarioResult.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post MikeScenarioResult
            var actionMikeScenarioResultAdded = await MikeScenarioResultDBLocalService.Post(mikeScenarioResult);
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultAdded.Result).Value);
            MikeScenarioResult mikeScenarioResultAdded = (MikeScenarioResult)((OkObjectResult)actionMikeScenarioResultAdded.Result).Value;
            Assert.NotNull(mikeScenarioResultAdded);

            // List<MikeScenarioResult>
            var actionMikeScenarioResultList = await MikeScenarioResultDBLocalService.GetMikeScenarioResultList();
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultList.Result).Value);
            List<MikeScenarioResult> mikeScenarioResultList = (List<MikeScenarioResult>)((OkObjectResult)actionMikeScenarioResultList.Result).Value;

            int count = ((List<MikeScenarioResult>)((OkObjectResult)actionMikeScenarioResultList.Result).Value).Count();
            Assert.True(count > 0);

            // Get MikeScenarioResult With MikeScenarioResultID
            var actionMikeScenarioResultGet = await MikeScenarioResultDBLocalService.GetMikeScenarioResultWithMikeScenarioResultID(mikeScenarioResultList[0].MikeScenarioResultID);
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultGet.Result).Value);
            MikeScenarioResult mikeScenarioResultGet = (MikeScenarioResult)((OkObjectResult)actionMikeScenarioResultGet.Result).Value;
            Assert.NotNull(mikeScenarioResultGet);
            Assert.Equal(mikeScenarioResultGet.MikeScenarioResultID, mikeScenarioResultList[0].MikeScenarioResultID);

            // Put MikeScenarioResult
            var actionMikeScenarioResultUpdated = await MikeScenarioResultDBLocalService.Put(mikeScenarioResult);
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultUpdated.Result).Value);
            MikeScenarioResult mikeScenarioResultUpdated = (MikeScenarioResult)((OkObjectResult)actionMikeScenarioResultUpdated.Result).Value;
            Assert.NotNull(mikeScenarioResultUpdated);

            // Delete MikeScenarioResult
            var actionMikeScenarioResultDeleted = await MikeScenarioResultDBLocalService.Delete(mikeScenarioResult.MikeScenarioResultID);
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMikeScenarioResultDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLoginFileName = Config.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IMikeScenarioResultDBLocalService, MikeScenarioResultDBLocalService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            dbLocalIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbLocalIM);

            MikeScenarioResultDBLocalService = Provider.GetService<IMikeScenarioResultDBLocalService>();
            Assert.NotNull(MikeScenarioResultDBLocalService);

            return await Task.FromResult(true);
        }
        private MikeScenarioResult GetFilledRandomMikeScenarioResult(string OmitPropName)
        {
            MikeScenarioResult mikeScenarioResult = new MikeScenarioResult();

            if (OmitPropName != "MikeScenarioTVItemID") mikeScenarioResult.MikeScenarioTVItemID = 51;
            if (OmitPropName != "MikeResultsJSON") mikeScenarioResult.MikeResultsJSON = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") mikeScenarioResult.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeScenarioResult.LastUpdateContactTVItemID = 2;

            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 51, TVLevel = 4, TVPath = "p1p5p6p39p51", TVType = (TVTypeEnum)13, ParentID = 39, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 21, 28, 56), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }
            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }


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