/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
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
    public partial class TVFileLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITVFileLanguageService TVFileLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private TVFileLanguage tvFileLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task TVFileLanguage_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            tvFileLanguage = GetFilledRandomTVFileLanguage("");

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
            // Post TVFileLanguage
            var actionTVFileLanguageAdded = await TVFileLanguageService.Post(tvFileLanguage);
            Assert.Equal(200, ((ObjectResult)actionTVFileLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVFileLanguageAdded.Result).Value);
            TVFileLanguage tvFileLanguageAdded = (TVFileLanguage)((OkObjectResult)actionTVFileLanguageAdded.Result).Value;
            Assert.NotNull(tvFileLanguageAdded);

            // List<TVFileLanguage>
            var actionTVFileLanguageList = await TVFileLanguageService.GetTVFileLanguageList();
            Assert.Equal(200, ((ObjectResult)actionTVFileLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVFileLanguageList.Result).Value);
            List<TVFileLanguage> tvFileLanguageList = (List<TVFileLanguage>)((OkObjectResult)actionTVFileLanguageList.Result).Value;

            int count = ((List<TVFileLanguage>)((OkObjectResult)actionTVFileLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // Put TVFileLanguage
            var actionTVFileLanguageUpdated = await TVFileLanguageService.Put(tvFileLanguage);
            Assert.Equal(200, ((ObjectResult)actionTVFileLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVFileLanguageUpdated.Result).Value);
            TVFileLanguage tvFileLanguageUpdated = (TVFileLanguage)((OkObjectResult)actionTVFileLanguageUpdated.Result).Value;
            Assert.NotNull(tvFileLanguageUpdated);

            // Delete TVFileLanguage
            var actionTVFileLanguageDeleted = await TVFileLanguageService.Delete(tvFileLanguage.TVFileLanguageID);
            Assert.Equal(200, ((ObjectResult)actionTVFileLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVFileLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTVFileLanguageDeleted.Result).Value;
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
            Services.AddSingleton<ITVFileLanguageService, TVFileLanguageService>();

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

            TVFileLanguageService = Provider.GetService<ITVFileLanguageService>();
            Assert.NotNull(TVFileLanguageService);

            return await Task.FromResult(true);
        }
        private TVFileLanguage GetFilledRandomTVFileLanguage(string OmitPropName)
        {
            List<TVFileLanguage> tvFileLanguageListToDelete = (from c in dbLocal.TVFileLanguages
                                                               select c).ToList(); 
            
            dbLocal.TVFileLanguages.RemoveRange(tvFileLanguageListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            TVFileLanguage tvFileLanguage = new TVFileLanguage();

            if (OmitPropName != "TVFileID") tvFileLanguage.TVFileID = 1;
            if (OmitPropName != "Language") tvFileLanguage.Language = LanguageRequest;
            if (OmitPropName != "FileDescription") tvFileLanguage.FileDescription = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") tvFileLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvFileLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvFileLanguage.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "TVFileLanguageID") tvFileLanguage.TVFileLanguageID = 10000000;

                try
                {
                dbIM.TVFiles.Add(new TVFile() { TVFileID = 1, TVFileTVItemID = 42, TemplateTVType = null, ReportTypeID = null, Parameters = null, Year = null, Language = (LanguageEnum)3, FilePurpose = (FilePurposeEnum)7, FileType = (FileTypeEnum)13, FileSize_kb = 3806224, FileInfo = "Uploaded file", FileCreatedDate_UTC = new DateTime(2016, 5, 5, 14, 18, 26), FromWater = null, ClientFilePath = @"DSCF6003.JPG", ServerFileName = @"TP - Bouctouche Lagoon.JPG", ServerFilePath = @"E:\inetpub\wwwroot\csspwebtools\App_Data\28689\", LastUpdateDate_UTC = new DateTime(2016, 5, 5, 17, 18, 26), LastUpdateContactTVItemID = 2 });
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

            return tvFileLanguage;
        }
        #endregion Functions private
    }
}
