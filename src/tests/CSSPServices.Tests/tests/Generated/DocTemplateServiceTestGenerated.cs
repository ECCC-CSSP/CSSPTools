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
    public partial class DocTemplateServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IDocTemplateService DocTemplateService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private DocTemplate docTemplate { get; set; }
        #endregion Properties

        #region Constructors
        public DocTemplateServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task DocTemplate_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            docTemplate = GetFilledRandomDocTemplate("");

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
        public async Task DocTemplate_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionDocTemplateList = await DocTemplateService.GetDocTemplateList();
            Assert.Equal(200, ((ObjectResult)actionDocTemplateList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDocTemplateList.Result).Value);
            List<DocTemplate> docTemplateList = (List<DocTemplate>)((OkObjectResult)actionDocTemplateList.Result).Value;

            count = docTemplateList.Count();

            DocTemplate docTemplate = GetFilledRandomDocTemplate("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // docTemplate.DocTemplateID   (Int32)
            // -----------------------------------

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            docTemplate.DocTemplateID = 0;

            var actionDocTemplate = await DocTemplateService.Put(docTemplate);
            Assert.IsType<BadRequestObjectResult>(actionDocTemplate.Result);

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            docTemplate.DocTemplateID = 10000000;
            actionDocTemplate = await DocTemplateService.Put(docTemplate);
            Assert.IsType<BadRequestObjectResult>(actionDocTemplate.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // docTemplate.Language   (LanguageEnum)
            // -----------------------------------

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            docTemplate.Language = (LanguageEnum)1000000;
            actionDocTemplate = await DocTemplateService.Post(docTemplate);
            Assert.IsType<BadRequestObjectResult>(actionDocTemplate.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // docTemplate.TVType   (TVTypeEnum)
            // -----------------------------------

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            docTemplate.TVType = (TVTypeEnum)1000000;
            actionDocTemplate = await DocTemplateService.Post(docTemplate);
            Assert.IsType<BadRequestObjectResult>(actionDocTemplate.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = File)]
            // docTemplate.TVFileTVItemID   (Int32)
            // -----------------------------------

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            docTemplate.TVFileTVItemID = 0;
            actionDocTemplate = await DocTemplateService.Post(docTemplate);
            Assert.IsType<BadRequestObjectResult>(actionDocTemplate.Result);

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            docTemplate.TVFileTVItemID = 1;
            actionDocTemplate = await DocTemplateService.Post(docTemplate);
            Assert.IsType<BadRequestObjectResult>(actionDocTemplate.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(150)]
            // docTemplate.FileName   (String)
            // -----------------------------------

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("FileName");
            actionDocTemplate = await DocTemplateService.Post(docTemplate);
            Assert.IsType<BadRequestObjectResult>(actionDocTemplate.Result);

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            docTemplate.FileName = GetRandomString("", 151);
            actionDocTemplate = await DocTemplateService.Post(docTemplate);
            Assert.IsType<BadRequestObjectResult>(actionDocTemplate.Result);
            //Assert.AreEqual(count, docTemplateService.GetDocTemplateList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // docTemplate.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            docTemplate.LastUpdateDate_UTC = new DateTime();
            actionDocTemplate = await DocTemplateService.Post(docTemplate);
            Assert.IsType<BadRequestObjectResult>(actionDocTemplate.Result);
            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            docTemplate.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionDocTemplate = await DocTemplateService.Post(docTemplate);
            Assert.IsType<BadRequestObjectResult>(actionDocTemplate.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // docTemplate.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            docTemplate.LastUpdateContactTVItemID = 0;
            actionDocTemplate = await DocTemplateService.Post(docTemplate);
            Assert.IsType<BadRequestObjectResult>(actionDocTemplate.Result);

            docTemplate = null;
            docTemplate = GetFilledRandomDocTemplate("");
            docTemplate.LastUpdateContactTVItemID = 1;
            actionDocTemplate = await DocTemplateService.Post(docTemplate);
            Assert.IsType<BadRequestObjectResult>(actionDocTemplate.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post DocTemplate
            var actionDocTemplateAdded = await DocTemplateService.Post(docTemplate);
            Assert.Equal(200, ((ObjectResult)actionDocTemplateAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDocTemplateAdded.Result).Value);
            DocTemplate docTemplateAdded = (DocTemplate)((OkObjectResult)actionDocTemplateAdded.Result).Value;
            Assert.NotNull(docTemplateAdded);

            // List<DocTemplate>
            var actionDocTemplateList = await DocTemplateService.GetDocTemplateList();
            Assert.Equal(200, ((ObjectResult)actionDocTemplateList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDocTemplateList.Result).Value);
            List<DocTemplate> docTemplateList = (List<DocTemplate>)((OkObjectResult)actionDocTemplateList.Result).Value;

            int count = ((List<DocTemplate>)((OkObjectResult)actionDocTemplateList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<DocTemplate> with skip and take
                var actionDocTemplateListSkipAndTake = await DocTemplateService.GetDocTemplateList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionDocTemplateListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionDocTemplateListSkipAndTake.Result).Value);
                List<DocTemplate> docTemplateListSkipAndTake = (List<DocTemplate>)((OkObjectResult)actionDocTemplateListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<DocTemplate>)((OkObjectResult)actionDocTemplateListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(docTemplateList[0].DocTemplateID == docTemplateListSkipAndTake[0].DocTemplateID);
            }

            // Get DocTemplate With DocTemplateID
            var actionDocTemplateGet = await DocTemplateService.GetDocTemplateWithDocTemplateID(docTemplateList[0].DocTemplateID);
            Assert.Equal(200, ((ObjectResult)actionDocTemplateGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDocTemplateGet.Result).Value);
            DocTemplate docTemplateGet = (DocTemplate)((OkObjectResult)actionDocTemplateGet.Result).Value;
            Assert.NotNull(docTemplateGet);
            Assert.Equal(docTemplateGet.DocTemplateID, docTemplateList[0].DocTemplateID);

            // Put DocTemplate
            var actionDocTemplateUpdated = await DocTemplateService.Put(docTemplate);
            Assert.Equal(200, ((ObjectResult)actionDocTemplateUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDocTemplateUpdated.Result).Value);
            DocTemplate docTemplateUpdated = (DocTemplate)((OkObjectResult)actionDocTemplateUpdated.Result).Value;
            Assert.NotNull(docTemplateUpdated);

            // Delete DocTemplate
            var actionDocTemplateDeleted = await DocTemplateService.Delete(docTemplate.DocTemplateID);
            Assert.Equal(200, ((ObjectResult)actionDocTemplateDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionDocTemplateDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionDocTemplateDeleted.Result).Value;
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

            Services.AddDbContext<InMemoryDBContext>(options =>
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
            Services.AddSingleton<IDocTemplateService, DocTemplateService>();

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

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            DocTemplateService = Provider.GetService<IDocTemplateService>();
            Assert.NotNull(DocTemplateService);

            return await Task.FromResult(true);
        }
        private DocTemplate GetFilledRandomDocTemplate(string OmitPropName)
        {
            List<DocTemplate> docTemplateListToDelete = (from c in dbLocal.DocTemplates
                                                               select c).ToList(); 
            
            dbLocal.DocTemplates.RemoveRange(docTemplateListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            DocTemplate docTemplate = new DocTemplate();

            if (OmitPropName != "Language") docTemplate.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "TVType") docTemplate.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVFileTVItemID") docTemplate.TVFileTVItemID = 42;
            if (OmitPropName != "FileName") docTemplate.FileName = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") docTemplate.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") docTemplate.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "DocTemplateID") docTemplate.DocTemplateID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 42, TVLevel = 5, TVPath = "p1p5p6p39p41p42", TVType = (TVTypeEnum)8, ParentID = 41, IsActive = true, LastUpdateDate_UTC = new DateTime(2016, 5, 5, 17, 18, 26), LastUpdateContactTVItemID = 2});
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

            return docTemplate;
        }
        private void CheckDocTemplateFields(List<DocTemplate> docTemplateList)
        {
            Assert.False(string.IsNullOrWhiteSpace(docTemplateList[0].FileName));
        }
        #endregion Functions private
    }
}
