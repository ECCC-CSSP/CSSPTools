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
    public partial class PolSourceGroupingLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IPolSourceGroupingLanguageService PolSourceGroupingLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private PolSourceGroupingLanguage polSourceGroupingLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task PolSourceGroupingLanguage_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");

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
        public async Task PolSourceGroupingLanguage_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionPolSourceGroupingLanguageList = await PolSourceGroupingLanguageService.GetPolSourceGroupingLanguageList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageList.Result).Value);
            List<PolSourceGroupingLanguage> polSourceGroupingLanguageList = (List<PolSourceGroupingLanguage>)((OkObjectResult)actionPolSourceGroupingLanguageList.Result).Value;

            count = polSourceGroupingLanguageList.Count();

            PolSourceGroupingLanguage polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // polSourceGroupingLanguage.PolSourceGroupingLanguageID   (Int32)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.PolSourceGroupingLanguageID = 0;

            var actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Put(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.PolSourceGroupingLanguageID = 10000000;
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Put(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "PolSourceGrouping", ExistPlurial = "s", ExistFieldID = "PolSourceGroupingID", AllowableTVtypeList = )]
            // polSourceGroupingLanguage.PolSourceGroupingID   (Int32)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.PolSourceGroupingID = 0;
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // polSourceGroupingLanguage.Language   (LanguageEnum)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.Language = (LanguageEnum)1000000;
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(500)]
            // polSourceGroupingLanguage.SourceName   (String)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("SourceName");
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.SourceName = GetRandomString("", 501);
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);
            //Assert.AreEqual(count, polSourceGroupingLanguageService.GetPolSourceGroupingLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // polSourceGroupingLanguage.SourceNameOrder   (Int32)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.SourceNameOrder = -1;
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);
            //Assert.AreEqual(count, polSourceGroupingLanguageService.GetPolSourceGroupingLanguageList().Count());
            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.SourceNameOrder = 1001;
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);
            //Assert.AreEqual(count, polSourceGroupingLanguageService.GetPolSourceGroupingLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // polSourceGroupingLanguage.TranslationStatusSourceName   (TranslationStatusEnum)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.TranslationStatusSourceName = (TranslationStatusEnum)1000000;
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(50)]
            // polSourceGroupingLanguage.Init   (String)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("Init");
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.Init = GetRandomString("", 51);
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);
            //Assert.AreEqual(count, polSourceGroupingLanguageService.GetPolSourceGroupingLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // polSourceGroupingLanguage.TranslationStatusInit   (TranslationStatusEnum)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.TranslationStatusInit = (TranslationStatusEnum)1000000;
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(500)]
            // polSourceGroupingLanguage.Description   (String)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("Description");
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.Description = GetRandomString("", 501);
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);
            //Assert.AreEqual(count, polSourceGroupingLanguageService.GetPolSourceGroupingLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // polSourceGroupingLanguage.TranslationStatusDescription   (TranslationStatusEnum)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.TranslationStatusDescription = (TranslationStatusEnum)1000000;
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(500)]
            // polSourceGroupingLanguage.Report   (String)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("Report");
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.Report = GetRandomString("", 501);
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);
            //Assert.AreEqual(count, polSourceGroupingLanguageService.GetPolSourceGroupingLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // polSourceGroupingLanguage.TranslationStatusReport   (TranslationStatusEnum)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.TranslationStatusReport = (TranslationStatusEnum)1000000;
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(500)]
            // polSourceGroupingLanguage.Text   (String)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("Text");
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.Text = GetRandomString("", 501);
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);
            //Assert.AreEqual(count, polSourceGroupingLanguageService.GetPolSourceGroupingLanguageList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // polSourceGroupingLanguage.TranslationStatusText   (TranslationStatusEnum)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.TranslationStatusText = (TranslationStatusEnum)1000000;
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // polSourceGroupingLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.LastUpdateDate_UTC = new DateTime();
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);
            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // polSourceGroupingLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.LastUpdateContactTVItemID = 0;
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);

            polSourceGroupingLanguage = null;
            polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage("");
            polSourceGroupingLanguage.LastUpdateContactTVItemID = 1;
            actionPolSourceGroupingLanguage = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceGroupingLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post PolSourceGroupingLanguage
            var actionPolSourceGroupingLanguageAdded = await PolSourceGroupingLanguageService.Post(polSourceGroupingLanguage);
            Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageAdded.Result).Value);
            PolSourceGroupingLanguage polSourceGroupingLanguageAdded = (PolSourceGroupingLanguage)((OkObjectResult)actionPolSourceGroupingLanguageAdded.Result).Value;
            Assert.NotNull(polSourceGroupingLanguageAdded);

            // List<PolSourceGroupingLanguage>
            var actionPolSourceGroupingLanguageList = await PolSourceGroupingLanguageService.GetPolSourceGroupingLanguageList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageList.Result).Value);
            List<PolSourceGroupingLanguage> polSourceGroupingLanguageList = (List<PolSourceGroupingLanguage>)((OkObjectResult)actionPolSourceGroupingLanguageList.Result).Value;

            int count = ((List<PolSourceGroupingLanguage>)((OkObjectResult)actionPolSourceGroupingLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<PolSourceGroupingLanguage> with skip and take
                var actionPolSourceGroupingLanguageListSkipAndTake = await PolSourceGroupingLanguageService.GetPolSourceGroupingLanguageList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageListSkipAndTake.Result).Value);
                List<PolSourceGroupingLanguage> polSourceGroupingLanguageListSkipAndTake = (List<PolSourceGroupingLanguage>)((OkObjectResult)actionPolSourceGroupingLanguageListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<PolSourceGroupingLanguage>)((OkObjectResult)actionPolSourceGroupingLanguageListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(polSourceGroupingLanguageList[0].PolSourceGroupingLanguageID == polSourceGroupingLanguageListSkipAndTake[0].PolSourceGroupingLanguageID);
            }

            // Get PolSourceGroupingLanguage With PolSourceGroupingLanguageID
            var actionPolSourceGroupingLanguageGet = await PolSourceGroupingLanguageService.GetPolSourceGroupingLanguageWithPolSourceGroupingLanguageID(polSourceGroupingLanguageList[0].PolSourceGroupingLanguageID);
            Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageGet.Result).Value);
            PolSourceGroupingLanguage polSourceGroupingLanguageGet = (PolSourceGroupingLanguage)((OkObjectResult)actionPolSourceGroupingLanguageGet.Result).Value;
            Assert.NotNull(polSourceGroupingLanguageGet);
            Assert.Equal(polSourceGroupingLanguageGet.PolSourceGroupingLanguageID, polSourceGroupingLanguageList[0].PolSourceGroupingLanguageID);

            // Put PolSourceGroupingLanguage
            var actionPolSourceGroupingLanguageUpdated = await PolSourceGroupingLanguageService.Put(polSourceGroupingLanguage);
            Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageUpdated.Result).Value);
            PolSourceGroupingLanguage polSourceGroupingLanguageUpdated = (PolSourceGroupingLanguage)((OkObjectResult)actionPolSourceGroupingLanguageUpdated.Result).Value;
            Assert.NotNull(polSourceGroupingLanguageUpdated);

            // Delete PolSourceGroupingLanguage
            var actionPolSourceGroupingLanguageDeleted = await PolSourceGroupingLanguageService.Delete(polSourceGroupingLanguage.PolSourceGroupingLanguageID);
            Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionPolSourceGroupingLanguageDeleted.Result).Value;
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
            Services.AddSingleton<IPolSourceGroupingLanguageService, PolSourceGroupingLanguageService>();

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

            PolSourceGroupingLanguageService = Provider.GetService<IPolSourceGroupingLanguageService>();
            Assert.NotNull(PolSourceGroupingLanguageService);

            return await Task.FromResult(true);
        }
        private PolSourceGroupingLanguage GetFilledRandomPolSourceGroupingLanguage(string OmitPropName)
        {
            List<PolSourceGroupingLanguage> polSourceGroupingLanguageListToDelete = (from c in dbLocal.PolSourceGroupingLanguages
                                                               select c).ToList(); 
            
            dbLocal.PolSourceGroupingLanguages.RemoveRange(polSourceGroupingLanguageListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            PolSourceGroupingLanguage polSourceGroupingLanguage = new PolSourceGroupingLanguage();

            if (OmitPropName != "PolSourceGroupingID") polSourceGroupingLanguage.PolSourceGroupingID = 1;
            if (OmitPropName != "Language") polSourceGroupingLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "SourceName") polSourceGroupingLanguage.SourceName = GetRandomString("", 5);
            if (OmitPropName != "SourceNameOrder") polSourceGroupingLanguage.SourceNameOrder = GetRandomInt(0, 1000);
            if (OmitPropName != "TranslationStatusSourceName") polSourceGroupingLanguage.TranslationStatusSourceName = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "Init") polSourceGroupingLanguage.Init = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusInit") polSourceGroupingLanguage.TranslationStatusInit = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "Description") polSourceGroupingLanguage.Description = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusDescription") polSourceGroupingLanguage.TranslationStatusDescription = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "Report") polSourceGroupingLanguage.Report = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusReport") polSourceGroupingLanguage.TranslationStatusReport = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "Text") polSourceGroupingLanguage.Text = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusText") polSourceGroupingLanguage.TranslationStatusText = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") polSourceGroupingLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceGroupingLanguage.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "PolSourceGroupingLanguageID") polSourceGroupingLanguage.PolSourceGroupingLanguageID = 10000000;

                try
                {
                    dbIM.PolSourceGroupings.Add(new PolSourceGrouping() { PolSourceGroupingID = 1, CSSPID = 10003, GroupName = "FirstGroupName", Child = "FirstChild", Hide = "FirstHide", LastUpdateDate_UTC = new DateTime(2020, 8, 27, 14, 56, 23), LastUpdateContactTVItemID = 2 });
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

            return polSourceGroupingLanguage;
        }
        private void CheckPolSourceGroupingLanguageFields(List<PolSourceGroupingLanguage> polSourceGroupingLanguageList)
        {
            Assert.False(string.IsNullOrWhiteSpace(polSourceGroupingLanguageList[0].SourceName));
            Assert.False(string.IsNullOrWhiteSpace(polSourceGroupingLanguageList[0].Init));
            Assert.False(string.IsNullOrWhiteSpace(polSourceGroupingLanguageList[0].Description));
            Assert.False(string.IsNullOrWhiteSpace(polSourceGroupingLanguageList[0].Report));
            Assert.False(string.IsNullOrWhiteSpace(polSourceGroupingLanguageList[0].Text));
        }
        #endregion Functions private
    }
}
