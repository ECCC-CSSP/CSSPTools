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
    public partial class PolSourceSiteEffectDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IPolSourceSiteEffectDBService PolSourceSiteEffectDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private PolSourceSiteEffect polSourceSiteEffect { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PolSourceSiteEffectDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PolSourceSiteEffectDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PolSourceSiteEffect_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionPolSourceSiteEffectList = await PolSourceSiteEffectDBService.GetPolSourceSiteEffectList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectList.Result).Value);
            List<PolSourceSiteEffect> polSourceSiteEffectList = (List<PolSourceSiteEffect>)((OkObjectResult)actionPolSourceSiteEffectList.Result).Value;

            count = polSourceSiteEffectList.Count();

            PolSourceSiteEffect polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // polSourceSiteEffect.PolSourceSiteEffectID   (Int32)
            // -----------------------------------

            polSourceSiteEffect = null;
            polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");
            polSourceSiteEffect.PolSourceSiteEffectID = 0;

            var actionPolSourceSiteEffect = await PolSourceSiteEffectDBService.Put(polSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffect.Result);

            polSourceSiteEffect = null;
            polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");
            polSourceSiteEffect.PolSourceSiteEffectID = 10000000;
            actionPolSourceSiteEffect = await PolSourceSiteEffectDBService.Put(polSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffect.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure,PolSourceSite)]
            // polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID   (Int32)
            // -----------------------------------

            polSourceSiteEffect = null;
            polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");
            polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID = 0;
            actionPolSourceSiteEffect = await PolSourceSiteEffectDBService.Post(polSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffect.Result);

            polSourceSiteEffect = null;
            polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");
            polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID = 1;
            actionPolSourceSiteEffect = await PolSourceSiteEffectDBService.Post(polSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffect.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
            // polSourceSiteEffect.MWQMSiteTVItemID   (Int32)
            // -----------------------------------

            polSourceSiteEffect = null;
            polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");
            polSourceSiteEffect.MWQMSiteTVItemID = 0;
            actionPolSourceSiteEffect = await PolSourceSiteEffectDBService.Post(polSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffect.Result);

            polSourceSiteEffect = null;
            polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");
            polSourceSiteEffect.MWQMSiteTVItemID = 1;
            actionPolSourceSiteEffect = await PolSourceSiteEffectDBService.Post(polSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffect.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(250)]
            // polSourceSiteEffect.PolSourceSiteEffectTermIDs   (String)
            // -----------------------------------

            polSourceSiteEffect = null;
            polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");
            polSourceSiteEffect.PolSourceSiteEffectTermIDs = GetRandomString("", 251);
            actionPolSourceSiteEffect = await PolSourceSiteEffectDBService.Post(polSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffect.Result);
            //Assert.AreEqual(count, polSourceSiteEffectDBService.GetPolSourceSiteEffectList().Count());

            // -----------------------------------
            // Is Nullable
            // polSourceSiteEffect.Comments   (String)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = File)]
            // polSourceSiteEffect.AnalysisDocumentTVItemID   (Int32)
            // -----------------------------------

            polSourceSiteEffect = null;
            polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");
            polSourceSiteEffect.AnalysisDocumentTVItemID = 0;
            actionPolSourceSiteEffect = await PolSourceSiteEffectDBService.Post(polSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffect.Result);

            polSourceSiteEffect = null;
            polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");
            polSourceSiteEffect.AnalysisDocumentTVItemID = 1;
            actionPolSourceSiteEffect = await PolSourceSiteEffectDBService.Post(polSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffect.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // polSourceSiteEffect.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            polSourceSiteEffect = null;
            polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");
            polSourceSiteEffect.LastUpdateDate_UTC = new DateTime();
            actionPolSourceSiteEffect = await PolSourceSiteEffectDBService.Post(polSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffect.Result);
            polSourceSiteEffect = null;
            polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");
            polSourceSiteEffect.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionPolSourceSiteEffect = await PolSourceSiteEffectDBService.Post(polSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffect.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // polSourceSiteEffect.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            polSourceSiteEffect = null;
            polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");
            polSourceSiteEffect.LastUpdateContactTVItemID = 0;
            actionPolSourceSiteEffect = await PolSourceSiteEffectDBService.Post(polSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffect.Result);

            polSourceSiteEffect = null;
            polSourceSiteEffect = GetFilledRandomPolSourceSiteEffect("");
            polSourceSiteEffect.LastUpdateContactTVItemID = 1;
            actionPolSourceSiteEffect = await PolSourceSiteEffectDBService.Post(polSourceSiteEffect);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffect.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post PolSourceSiteEffect
            var actionPolSourceSiteEffectAdded = await PolSourceSiteEffectDBService.Post(polSourceSiteEffect);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectAdded.Result).Value);
            PolSourceSiteEffect polSourceSiteEffectAdded = (PolSourceSiteEffect)((OkObjectResult)actionPolSourceSiteEffectAdded.Result).Value;
            Assert.NotNull(polSourceSiteEffectAdded);

            // List<PolSourceSiteEffect>
            var actionPolSourceSiteEffectList = await PolSourceSiteEffectDBService.GetPolSourceSiteEffectList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectList.Result).Value);
            List<PolSourceSiteEffect> polSourceSiteEffectList = (List<PolSourceSiteEffect>)((OkObjectResult)actionPolSourceSiteEffectList.Result).Value;

            int count = ((List<PolSourceSiteEffect>)((OkObjectResult)actionPolSourceSiteEffectList.Result).Value).Count();
            Assert.True(count > 0);

            // List<PolSourceSiteEffect> with skip and take
            var actionPolSourceSiteEffectListSkipAndTake = await PolSourceSiteEffectDBService.GetPolSourceSiteEffectList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectListSkipAndTake.Result).Value);
            List<PolSourceSiteEffect> polSourceSiteEffectListSkipAndTake = (List<PolSourceSiteEffect>)((OkObjectResult)actionPolSourceSiteEffectListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<PolSourceSiteEffect>)((OkObjectResult)actionPolSourceSiteEffectListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(polSourceSiteEffectList[0].PolSourceSiteEffectID == polSourceSiteEffectListSkipAndTake[0].PolSourceSiteEffectID);

            // Get PolSourceSiteEffect With PolSourceSiteEffectID
            var actionPolSourceSiteEffectGet = await PolSourceSiteEffectDBService.GetPolSourceSiteEffectWithPolSourceSiteEffectID(polSourceSiteEffectList[0].PolSourceSiteEffectID);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectGet.Result).Value);
            PolSourceSiteEffect polSourceSiteEffectGet = (PolSourceSiteEffect)((OkObjectResult)actionPolSourceSiteEffectGet.Result).Value;
            Assert.NotNull(polSourceSiteEffectGet);
            Assert.Equal(polSourceSiteEffectGet.PolSourceSiteEffectID, polSourceSiteEffectList[0].PolSourceSiteEffectID);

            // Put PolSourceSiteEffect
            var actionPolSourceSiteEffectUpdated = await PolSourceSiteEffectDBService.Put(polSourceSiteEffect);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectUpdated.Result).Value);
            PolSourceSiteEffect polSourceSiteEffectUpdated = (PolSourceSiteEffect)((OkObjectResult)actionPolSourceSiteEffectUpdated.Result).Value;
            Assert.NotNull(polSourceSiteEffectUpdated);

            // Delete PolSourceSiteEffect
            var actionPolSourceSiteEffectDeleted = await PolSourceSiteEffectDBService.Delete(polSourceSiteEffect.PolSourceSiteEffectID);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionPolSourceSiteEffectDeleted.Result).Value;
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

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IPolSourceSiteEffectDBService, PolSourceSiteEffectDBService>();

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

            PolSourceSiteEffectDBService = Provider.GetService<IPolSourceSiteEffectDBService>();
            Assert.NotNull(PolSourceSiteEffectDBService);

            return await Task.FromResult(true);
        }
        private PolSourceSiteEffect GetFilledRandomPolSourceSiteEffect(string OmitPropName)
        {
            PolSourceSiteEffect polSourceSiteEffect = new PolSourceSiteEffect();

            if (OmitPropName != "PolSourceSiteOrInfrastructureTVItemID") polSourceSiteEffect.PolSourceSiteOrInfrastructureTVItemID = 41;
            if (OmitPropName != "MWQMSiteTVItemID") polSourceSiteEffect.MWQMSiteTVItemID = 44;
            if (OmitPropName != "PolSourceSiteEffectTermIDs") polSourceSiteEffect.PolSourceSiteEffectTermIDs = GetRandomString("", 5);
            if (OmitPropName != "Comments") polSourceSiteEffect.Comments = GetRandomString("", 20);
            if (OmitPropName != "AnalysisDocumentTVItemID") polSourceSiteEffect.AnalysisDocumentTVItemID = 42;
            if (OmitPropName != "LastUpdateDate_UTC") polSourceSiteEffect.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceSiteEffect.LastUpdateContactTVItemID = 2;



            return polSourceSiteEffect;
        }
        private void CheckPolSourceSiteEffectFields(List<PolSourceSiteEffect> polSourceSiteEffectList)
        {
            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectList[0].PolSourceSiteEffectTermIDs))
            {
                Assert.False(string.IsNullOrWhiteSpace(polSourceSiteEffectList[0].PolSourceSiteEffectTermIDs));
            }
            if (!string.IsNullOrWhiteSpace(polSourceSiteEffectList[0].Comments))
            {
                Assert.False(string.IsNullOrWhiteSpace(polSourceSiteEffectList[0].Comments));
            }
            if (polSourceSiteEffectList[0].AnalysisDocumentTVItemID != null)
            {
                Assert.NotNull(polSourceSiteEffectList[0].AnalysisDocumentTVItemID);
            }
        }

        #endregion Functions private
    }
}
