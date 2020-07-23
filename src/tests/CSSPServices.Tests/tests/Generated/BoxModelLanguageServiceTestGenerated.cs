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
    public partial class BoxModelLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IBoxModelLanguageService BoxModelLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private BoxModelLanguage boxModelLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public BoxModelLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task BoxModelLanguage_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            boxModelLanguage = GetFilledRandomBoxModelLanguage("");

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
        public async Task BoxModelLanguage_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionBoxModelLanguageList = await BoxModelLanguageService.GetBoxModelLanguageList();
            Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelLanguageList.Result).Value);
            List<BoxModelLanguage> boxModelLanguageList = (List<BoxModelLanguage>)((OkObjectResult)actionBoxModelLanguageList.Result).Value;

            count = boxModelLanguageList.Count();

            BoxModelLanguage boxModelLanguage = GetFilledRandomBoxModelLanguage("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // boxModelLanguage.BoxModelLanguageID   (Int32)
            // -----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.BoxModelLanguageID = 0;

            var actionBoxModelLanguage = await BoxModelLanguageService.Put(boxModelLanguage);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelLanguage.Result);

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.BoxModelLanguageID = 10000000;
            actionBoxModelLanguage = await BoxModelLanguageService.Put(boxModelLanguage);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "BoxModel", ExistPlurial = "s", ExistFieldID = "BoxModelID", AllowableTVtypeList = )]
            // boxModelLanguage.BoxModelID   (Int32)
            // -----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.BoxModelID = 0;
            actionBoxModelLanguage = await BoxModelLanguageService.Post(boxModelLanguage);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // boxModelLanguage.Language   (LanguageEnum)
            // -----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.Language = (LanguageEnum)1000000;
            actionBoxModelLanguage = await BoxModelLanguageService.Post(boxModelLanguage);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // boxModelLanguage.ScenarioName   (String)
            // -----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("ScenarioName");
            actionBoxModelLanguage = await BoxModelLanguageService.Post(boxModelLanguage);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelLanguage.Result);

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.ScenarioName = GetRandomString("", 251);
            actionBoxModelLanguage = await BoxModelLanguageService.Post(boxModelLanguage);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelLanguage.Result);
            //Assert.AreEqual(count, boxModelLanguageService.GetBoxModelLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // boxModelLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
            actionBoxModelLanguage = await BoxModelLanguageService.Post(boxModelLanguage);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // boxModelLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.LastUpdateDate_UTC = new DateTime();
            actionBoxModelLanguage = await BoxModelLanguageService.Post(boxModelLanguage);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelLanguage.Result);
            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionBoxModelLanguage = await BoxModelLanguageService.Post(boxModelLanguage);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // boxModelLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.LastUpdateContactTVItemID = 0;
            actionBoxModelLanguage = await BoxModelLanguageService.Post(boxModelLanguage);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelLanguage.Result);

            boxModelLanguage = null;
            boxModelLanguage = GetFilledRandomBoxModelLanguage("");
            boxModelLanguage.LastUpdateContactTVItemID = 1;
            actionBoxModelLanguage = await BoxModelLanguageService.Post(boxModelLanguage);
            Assert.IsType<BadRequestObjectResult>(actionBoxModelLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post BoxModelLanguage
            var actionBoxModelLanguageAdded = await BoxModelLanguageService.Post(boxModelLanguage);
            Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelLanguageAdded.Result).Value);
            BoxModelLanguage boxModelLanguageAdded = (BoxModelLanguage)((OkObjectResult)actionBoxModelLanguageAdded.Result).Value;
            Assert.NotNull(boxModelLanguageAdded);

            // List<BoxModelLanguage>
            var actionBoxModelLanguageList = await BoxModelLanguageService.GetBoxModelLanguageList();
            Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelLanguageList.Result).Value);
            List<BoxModelLanguage> boxModelLanguageList = (List<BoxModelLanguage>)((OkObjectResult)actionBoxModelLanguageList.Result).Value;

            int count = ((List<BoxModelLanguage>)((OkObjectResult)actionBoxModelLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<BoxModelLanguage> with skip and take
                var actionBoxModelLanguageListSkipAndTake = await BoxModelLanguageService.GetBoxModelLanguageList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionBoxModelLanguageListSkipAndTake.Result).Value);
                List<BoxModelLanguage> boxModelLanguageListSkipAndTake = (List<BoxModelLanguage>)((OkObjectResult)actionBoxModelLanguageListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<BoxModelLanguage>)((OkObjectResult)actionBoxModelLanguageListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(boxModelLanguageList[0].BoxModelLanguageID == boxModelLanguageListSkipAndTake[0].BoxModelLanguageID);
            }

            // Get BoxModelLanguage With BoxModelLanguageID
            var actionBoxModelLanguageGet = await BoxModelLanguageService.GetBoxModelLanguageWithBoxModelLanguageID(boxModelLanguageList[0].BoxModelLanguageID);
            Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelLanguageGet.Result).Value);
            BoxModelLanguage boxModelLanguageGet = (BoxModelLanguage)((OkObjectResult)actionBoxModelLanguageGet.Result).Value;
            Assert.NotNull(boxModelLanguageGet);
            Assert.Equal(boxModelLanguageGet.BoxModelLanguageID, boxModelLanguageList[0].BoxModelLanguageID);

            // Put BoxModelLanguage
            var actionBoxModelLanguageUpdated = await BoxModelLanguageService.Put(boxModelLanguage);
            Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelLanguageUpdated.Result).Value);
            BoxModelLanguage boxModelLanguageUpdated = (BoxModelLanguage)((OkObjectResult)actionBoxModelLanguageUpdated.Result).Value;
            Assert.NotNull(boxModelLanguageUpdated);

            // Delete BoxModelLanguage
            var actionBoxModelLanguageDeleted = await BoxModelLanguageService.Delete(boxModelLanguage.BoxModelLanguageID);
            Assert.Equal(200, ((ObjectResult)actionBoxModelLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionBoxModelLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionBoxModelLanguageDeleted.Result).Value;
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

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IBoxModelLanguageService, BoxModelLanguageService>();

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

            BoxModelLanguageService = Provider.GetService<IBoxModelLanguageService>();
            Assert.NotNull(BoxModelLanguageService);

            return await Task.FromResult(true);
        }
        private BoxModelLanguage GetFilledRandomBoxModelLanguage(string OmitPropName)
        {
            List<BoxModelLanguage> boxModelLanguageListToDelete = (from c in dbLocal.BoxModelLanguages
                                                               select c).ToList(); 
            
            dbLocal.BoxModelLanguages.RemoveRange(boxModelLanguageListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            BoxModelLanguage boxModelLanguage = new BoxModelLanguage();

            if (OmitPropName != "BoxModelID") boxModelLanguage.BoxModelID = 1;
            if (OmitPropName != "Language") boxModelLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "ScenarioName") boxModelLanguage.ScenarioName = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") boxModelLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") boxModelLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") boxModelLanguage.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "BoxModelLanguageID") boxModelLanguage.BoxModelLanguageID = 10000000;

                try
                {
                    dbIM.BoxModels.Add(new BoxModel() { BoxModelID = 1, InfrastructureTVItemID = 41, Discharge_m3_day = 1021, Depth_m = 1.2, Temperature_C = 10, Dilution = 1000, DecayRate_per_day = 4.6821, FCUntreated_MPN_100ml = 2500000, FCPreDisinfection_MPN_100ml = 357, Concentration_MPN_100ml = 14, T90_hour = 6, DischargeDuration_hour = 24, LastUpdateDate_UTC = new DateTime(2018, 10, 29, 12, 42, 9), LastUpdateContactTVItemID = 2 });
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

            return boxModelLanguage;
        }
        private void CheckBoxModelLanguageFields(List<BoxModelLanguage> boxModelLanguageList)
        {
            Assert.False(string.IsNullOrWhiteSpace(boxModelLanguageList[0].ScenarioName));
        }
        #endregion Functions private
    }
}
