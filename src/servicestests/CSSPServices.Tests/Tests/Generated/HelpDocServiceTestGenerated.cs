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
    public partial class HelpDocServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IHelpDocService HelpDocService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private HelpDoc helpDoc { get; set; }
        #endregion Properties

        #region Constructors
        public HelpDocServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task HelpDoc_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            helpDoc = GetFilledRandomHelpDoc("");

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
        public async Task HelpDoc_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionHelpDocList = await HelpDocService.GetHelpDocList();
            Assert.Equal(200, ((ObjectResult)actionHelpDocList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHelpDocList.Result).Value);
            List<HelpDoc> helpDocList = (List<HelpDoc>)((OkObjectResult)actionHelpDocList.Result).Value;

            count = helpDocList.Count();

            HelpDoc helpDoc = GetFilledRandomHelpDoc("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // helpDoc.HelpDocID   (Int32)
            // -----------------------------------

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.HelpDocID = 0;

            var actionHelpDoc = await HelpDocService.Put(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.HelpDocID = 10000000;
            actionHelpDoc = await HelpDocService.Put(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // helpDoc.DocKey   (String)
            // -----------------------------------

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("DocKey");
            actionHelpDoc = await HelpDocService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.DocKey = GetRandomString("", 101);
            actionHelpDoc = await HelpDocService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);
            //Assert.AreEqual(count, helpDocService.GetHelpDocList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // helpDoc.Language   (LanguageEnum)
            // -----------------------------------

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.Language = (LanguageEnum)1000000;
            actionHelpDoc = await HelpDocService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100000)]
            // helpDoc.DocHTMLText   (String)
            // -----------------------------------

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("DocHTMLText");
            actionHelpDoc = await HelpDocService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.DocHTMLText = GetRandomString("", 100001);
            actionHelpDoc = await HelpDocService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);
            //Assert.AreEqual(count, helpDocService.GetHelpDocList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // helpDoc.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.LastUpdateDate_UTC = new DateTime();
            actionHelpDoc = await HelpDocService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);
            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionHelpDoc = await HelpDocService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // helpDoc.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.LastUpdateContactTVItemID = 0;
            actionHelpDoc = await HelpDocService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.LastUpdateContactTVItemID = 1;
            actionHelpDoc = await HelpDocService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post HelpDoc
            var actionHelpDocAdded = await HelpDocService.Post(helpDoc);
            Assert.Equal(200, ((ObjectResult)actionHelpDocAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHelpDocAdded.Result).Value);
            HelpDoc helpDocAdded = (HelpDoc)((OkObjectResult)actionHelpDocAdded.Result).Value;
            Assert.NotNull(helpDocAdded);

            // List<HelpDoc>
            var actionHelpDocList = await HelpDocService.GetHelpDocList();
            Assert.Equal(200, ((ObjectResult)actionHelpDocList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHelpDocList.Result).Value);
            List<HelpDoc> helpDocList = (List<HelpDoc>)((OkObjectResult)actionHelpDocList.Result).Value;

            int count = ((List<HelpDoc>)((OkObjectResult)actionHelpDocList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<HelpDoc> with skip and take
                var actionHelpDocListSkipAndTake = await HelpDocService.GetHelpDocList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionHelpDocListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionHelpDocListSkipAndTake.Result).Value);
                List<HelpDoc> helpDocListSkipAndTake = (List<HelpDoc>)((OkObjectResult)actionHelpDocListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<HelpDoc>)((OkObjectResult)actionHelpDocListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(helpDocList[0].HelpDocID == helpDocListSkipAndTake[0].HelpDocID);
            }

            // Get HelpDoc With HelpDocID
            var actionHelpDocGet = await HelpDocService.GetHelpDocWithHelpDocID(helpDocList[0].HelpDocID);
            Assert.Equal(200, ((ObjectResult)actionHelpDocGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHelpDocGet.Result).Value);
            HelpDoc helpDocGet = (HelpDoc)((OkObjectResult)actionHelpDocGet.Result).Value;
            Assert.NotNull(helpDocGet);
            Assert.Equal(helpDocGet.HelpDocID, helpDocList[0].HelpDocID);

            // Put HelpDoc
            var actionHelpDocUpdated = await HelpDocService.Put(helpDoc);
            Assert.Equal(200, ((ObjectResult)actionHelpDocUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHelpDocUpdated.Result).Value);
            HelpDoc helpDocUpdated = (HelpDoc)((OkObjectResult)actionHelpDocUpdated.Result).Value;
            Assert.NotNull(helpDocUpdated);

            // Delete HelpDoc
            var actionHelpDocDeleted = await HelpDocService.Delete(helpDoc.HelpDocID);
            Assert.Equal(200, ((ObjectResult)actionHelpDocDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHelpDocDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionHelpDocDeleted.Result).Value;
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
            Services.AddSingleton<IHelpDocService, HelpDocService>();

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

            HelpDocService = Provider.GetService<IHelpDocService>();
            Assert.NotNull(HelpDocService);

            return await Task.FromResult(true);
        }
        private HelpDoc GetFilledRandomHelpDoc(string OmitPropName)
        {
            List<HelpDoc> helpDocListToDelete = (from c in dbLocal.HelpDocs
                                                               select c).ToList(); 
            
            dbLocal.HelpDocs.RemoveRange(helpDocListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            HelpDoc helpDoc = new HelpDoc();

            if (OmitPropName != "DocKey") helpDoc.DocKey = GetRandomString("", 5);
            if (OmitPropName != "Language") helpDoc.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "DocHTMLText") helpDoc.DocHTMLText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") helpDoc.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") helpDoc.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "HelpDocID") helpDoc.HelpDocID = 10000000;

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

            return helpDoc;
        }
        private void CheckHelpDocFields(List<HelpDoc> helpDocList)
        {
            Assert.False(string.IsNullOrWhiteSpace(helpDocList[0].DocKey));
            Assert.False(string.IsNullOrWhiteSpace(helpDocList[0].DocHTMLText));
        }
        #endregion Functions private
    }
}