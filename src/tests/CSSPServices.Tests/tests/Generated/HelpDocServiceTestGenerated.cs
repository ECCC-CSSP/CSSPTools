/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
using LoggedInServices.Services;
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
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IHelpDocService HelpDocService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private HelpDoc helpDoc { get; set; }
        #endregion Properties

        #region Constructors
        public HelpDocServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task HelpDoc_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            helpDoc = GetFilledRandomHelpDoc("");

            if (LoggedInService.IsLocal)
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
               .AddJsonFile("appsettings.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{appDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IHelpDocService, HelpDocService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            //string IsLocalStr = Config.GetValue<string>("IsLocal");
            //Assert.NotNull(IsLocalStr);

            dbIM = Provider.GetService<InMemoryDBContext>();
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
            if (OmitPropName != "Language") helpDoc.Language = LanguageRequest;
            if (OmitPropName != "DocHTMLText") helpDoc.DocHTMLText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") helpDoc.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") helpDoc.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
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
        #endregion Functions private
    }
}
