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
    public partial class SpillLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ISpillLanguageService SpillLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private SpillLanguage spillLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task SpillLanguage_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            spillLanguage = GetFilledRandomSpillLanguage("");

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
        public async Task SpillLanguage_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionSpillLanguageList = await SpillLanguageService.GetSpillLanguageList();
            Assert.Equal(200, ((ObjectResult)actionSpillLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillLanguageList.Result).Value);
            List<SpillLanguage> spillLanguageList = (List<SpillLanguage>)((OkObjectResult)actionSpillLanguageList.Result).Value;

            count = spillLanguageList.Count();

            SpillLanguage spillLanguage = GetFilledRandomSpillLanguage("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // spillLanguage.SpillLanguageID   (Int32)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.SpillLanguageID = 0;

            var actionSpillLanguage = await SpillLanguageService.Put(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.SpillLanguageID = 10000000;
            actionSpillLanguage = await SpillLanguageService.Put(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "Spill", ExistPlurial = "s", ExistFieldID = "SpillID", AllowableTVtypeList = )]
            // spillLanguage.SpillID   (Int32)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.SpillID = 0;
            actionSpillLanguage = await SpillLanguageService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // spillLanguage.Language   (LanguageEnum)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.Language = (LanguageEnum)1000000;
            actionSpillLanguage = await SpillLanguageService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // spillLanguage.SpillComment   (String)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("SpillComment");
            actionSpillLanguage = await SpillLanguageService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // spillLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
            actionSpillLanguage = await SpillLanguageService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // spillLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.LastUpdateDate_UTC = new DateTime();
            actionSpillLanguage = await SpillLanguageService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);
            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionSpillLanguage = await SpillLanguageService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // spillLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.LastUpdateContactTVItemID = 0;
            actionSpillLanguage = await SpillLanguageService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);

            spillLanguage = null;
            spillLanguage = GetFilledRandomSpillLanguage("");
            spillLanguage.LastUpdateContactTVItemID = 1;
            actionSpillLanguage = await SpillLanguageService.Post(spillLanguage);
            Assert.IsType<BadRequestObjectResult>(actionSpillLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post SpillLanguage
            var actionSpillLanguageAdded = await SpillLanguageService.Post(spillLanguage);
            Assert.Equal(200, ((ObjectResult)actionSpillLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillLanguageAdded.Result).Value);
            SpillLanguage spillLanguageAdded = (SpillLanguage)((OkObjectResult)actionSpillLanguageAdded.Result).Value;
            Assert.NotNull(spillLanguageAdded);

            // List<SpillLanguage>
            var actionSpillLanguageList = await SpillLanguageService.GetSpillLanguageList();
            Assert.Equal(200, ((ObjectResult)actionSpillLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillLanguageList.Result).Value);
            List<SpillLanguage> spillLanguageList = (List<SpillLanguage>)((OkObjectResult)actionSpillLanguageList.Result).Value;

            int count = ((List<SpillLanguage>)((OkObjectResult)actionSpillLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<SpillLanguage> with skip and take
                var actionSpillLanguageListSkipAndTake = await SpillLanguageService.GetSpillLanguageList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionSpillLanguageListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionSpillLanguageListSkipAndTake.Result).Value);
                List<SpillLanguage> spillLanguageListSkipAndTake = (List<SpillLanguage>)((OkObjectResult)actionSpillLanguageListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<SpillLanguage>)((OkObjectResult)actionSpillLanguageListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(spillLanguageList[0].SpillLanguageID == spillLanguageListSkipAndTake[0].SpillLanguageID);
            }

            // Get SpillLanguage With SpillLanguageID
            var actionSpillLanguageGet = await SpillLanguageService.GetSpillLanguageWithSpillLanguageID(spillLanguageList[0].SpillLanguageID);
            Assert.Equal(200, ((ObjectResult)actionSpillLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillLanguageGet.Result).Value);
            SpillLanguage spillLanguageGet = (SpillLanguage)((OkObjectResult)actionSpillLanguageGet.Result).Value;
            Assert.NotNull(spillLanguageGet);
            Assert.Equal(spillLanguageGet.SpillLanguageID, spillLanguageList[0].SpillLanguageID);

            // Put SpillLanguage
            var actionSpillLanguageUpdated = await SpillLanguageService.Put(spillLanguage);
            Assert.Equal(200, ((ObjectResult)actionSpillLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillLanguageUpdated.Result).Value);
            SpillLanguage spillLanguageUpdated = (SpillLanguage)((OkObjectResult)actionSpillLanguageUpdated.Result).Value;
            Assert.NotNull(spillLanguageUpdated);

            // Delete SpillLanguage
            var actionSpillLanguageDeleted = await SpillLanguageService.Delete(spillLanguage.SpillLanguageID);
            Assert.Equal(200, ((ObjectResult)actionSpillLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSpillLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionSpillLanguageDeleted.Result).Value;
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
            Services.AddSingleton<ISpillLanguageService, SpillLanguageService>();

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

            SpillLanguageService = Provider.GetService<ISpillLanguageService>();
            Assert.NotNull(SpillLanguageService);

            return await Task.FromResult(true);
        }
        private SpillLanguage GetFilledRandomSpillLanguage(string OmitPropName)
        {
            List<SpillLanguage> spillLanguageListToDelete = (from c in dbLocal.SpillLanguages
                                                               select c).ToList(); 
            
            dbLocal.SpillLanguages.RemoveRange(spillLanguageListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            SpillLanguage spillLanguage = new SpillLanguage();

            if (OmitPropName != "SpillID") spillLanguage.SpillID = 1;
            if (OmitPropName != "Language") spillLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "SpillComment") spillLanguage.SpillComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") spillLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") spillLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") spillLanguage.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "SpillLanguageID") spillLanguage.SpillLanguageID = 10000000;

                try
                {
                    dbIM.Spills.Add(new Spill() { SpillID = 1, MunicipalityTVItemID = 39, InfrastructureTVItemID = 41, StartDateTime_Local = new DateTime(2015, 8, 27, 14, 56, 23), EndDateTime_Local = new DateTime(2015, 8, 27, 20, 56, 23), AverageFlow_m3_day = 34.5, LastUpdateDate_UTC = new DateTime(2020, 8, 27, 14, 56, 23), LastUpdateContactTVItemID = 2 });
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

            return spillLanguage;
        }
        private void CheckSpillLanguageFields(List<SpillLanguage> spillLanguageList)
        {
            Assert.False(string.IsNullOrWhiteSpace(spillLanguageList[0].SpillComment));
        }
        #endregion Functions private
    }
}
