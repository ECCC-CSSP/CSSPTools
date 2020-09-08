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
    public partial class HelpDocDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IHelpDocDBService HelpDocDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private HelpDoc helpDoc { get; set; }
        #endregion Properties

        #region Constructors
        public HelpDocDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DB]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task HelpDocDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            helpDoc = GetFilledRandomHelpDoc("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task HelpDoc_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionHelpDocList = await HelpDocDBService.GetHelpDocList();
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

            var actionHelpDoc = await HelpDocDBService.Put(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.HelpDocID = 10000000;
            actionHelpDoc = await HelpDocDBService.Put(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // helpDoc.DocKey   (String)
            // -----------------------------------

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("DocKey");
            actionHelpDoc = await HelpDocDBService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.DocKey = GetRandomString("", 101);
            actionHelpDoc = await HelpDocDBService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);
            //Assert.AreEqual(count, helpDocDBService.GetHelpDocList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // helpDoc.Language   (LanguageEnum)
            // -----------------------------------

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.Language = (LanguageEnum)1000000;
            actionHelpDoc = await HelpDocDBService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100000)]
            // helpDoc.DocHTMLText   (String)
            // -----------------------------------

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("DocHTMLText");
            actionHelpDoc = await HelpDocDBService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.DocHTMLText = GetRandomString("", 100001);
            actionHelpDoc = await HelpDocDBService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);
            //Assert.AreEqual(count, helpDocDBService.GetHelpDocList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // helpDoc.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.LastUpdateDate_UTC = new DateTime();
            actionHelpDoc = await HelpDocDBService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);
            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionHelpDoc = await HelpDocDBService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // helpDoc.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.LastUpdateContactTVItemID = 0;
            actionHelpDoc = await HelpDocDBService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);

            helpDoc = null;
            helpDoc = GetFilledRandomHelpDoc("");
            helpDoc.LastUpdateContactTVItemID = 1;
            actionHelpDoc = await HelpDocDBService.Post(helpDoc);
            Assert.IsType<BadRequestObjectResult>(actionHelpDoc.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post HelpDoc
            var actionHelpDocAdded = await HelpDocDBService.Post(helpDoc);
            Assert.Equal(200, ((ObjectResult)actionHelpDocAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHelpDocAdded.Result).Value);
            HelpDoc helpDocAdded = (HelpDoc)((OkObjectResult)actionHelpDocAdded.Result).Value;
            Assert.NotNull(helpDocAdded);

            // List<HelpDoc>
            var actionHelpDocList = await HelpDocDBService.GetHelpDocList();
            Assert.Equal(200, ((ObjectResult)actionHelpDocList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHelpDocList.Result).Value);
            List<HelpDoc> helpDocList = (List<HelpDoc>)((OkObjectResult)actionHelpDocList.Result).Value;

            int count = ((List<HelpDoc>)((OkObjectResult)actionHelpDocList.Result).Value).Count();
            Assert.True(count > 0);

            // List<HelpDoc> with skip and take
            var actionHelpDocListSkipAndTake = await HelpDocDBService.GetHelpDocList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionHelpDocListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHelpDocListSkipAndTake.Result).Value);
            List<HelpDoc> helpDocListSkipAndTake = (List<HelpDoc>)((OkObjectResult)actionHelpDocListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<HelpDoc>)((OkObjectResult)actionHelpDocListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(helpDocList[0].HelpDocID == helpDocListSkipAndTake[0].HelpDocID);

            // Get HelpDoc With HelpDocID
            var actionHelpDocGet = await HelpDocDBService.GetHelpDocWithHelpDocID(helpDocList[0].HelpDocID);
            Assert.Equal(200, ((ObjectResult)actionHelpDocGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHelpDocGet.Result).Value);
            HelpDoc helpDocGet = (HelpDoc)((OkObjectResult)actionHelpDocGet.Result).Value;
            Assert.NotNull(helpDocGet);
            Assert.Equal(helpDocGet.HelpDocID, helpDocList[0].HelpDocID);

            // Put HelpDoc
            var actionHelpDocUpdated = await HelpDocDBService.Put(helpDoc);
            Assert.Equal(200, ((ObjectResult)actionHelpDocUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHelpDocUpdated.Result).Value);
            HelpDoc helpDocUpdated = (HelpDoc)((OkObjectResult)actionHelpDocUpdated.Result).Value;
            Assert.NotNull(helpDocUpdated);

            // Delete HelpDoc
            var actionHelpDocDeleted = await HelpDocDBService.Delete(helpDoc.HelpDocID);
            Assert.Equal(200, ((ObjectResult)actionHelpDocDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionHelpDocDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionHelpDocDeleted.Result).Value;
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
            Services.AddSingleton<IHelpDocDBService, HelpDocDBService>();

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

            HelpDocDBService = Provider.GetService<IHelpDocDBService>();
            Assert.NotNull(HelpDocDBService);

            return await Task.FromResult(true);
        }
        private HelpDoc GetFilledRandomHelpDoc(string OmitPropName)
        {
            HelpDoc helpDoc = new HelpDoc();

            if (OmitPropName != "DocKey") helpDoc.DocKey = GetRandomString("", 5);
            if (OmitPropName != "Language") helpDoc.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "DocHTMLText") helpDoc.DocHTMLText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") helpDoc.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") helpDoc.LastUpdateContactTVItemID = 2;



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
