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
    public partial class MikeScenarioResultServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMikeScenarioResultService MikeScenarioResultService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private MikeScenarioResult mikeScenarioResult { get; set; }
        #endregion Properties

        #region Constructors
        public MikeScenarioResultServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task MikeScenarioResult_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            mikeScenarioResult = GetFilledRandomMikeScenarioResult("");

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
            // Post MikeScenarioResult
            var actionMikeScenarioResultAdded = await MikeScenarioResultService.Post(mikeScenarioResult);
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultAdded.Result).Value);
            MikeScenarioResult mikeScenarioResultAdded = (MikeScenarioResult)((OkObjectResult)actionMikeScenarioResultAdded.Result).Value;
            Assert.NotNull(mikeScenarioResultAdded);

            // List<MikeScenarioResult>
            var actionMikeScenarioResultList = await MikeScenarioResultService.GetMikeScenarioResultList();
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultList.Result).Value);
            List<MikeScenarioResult> mikeScenarioResultList = (List<MikeScenarioResult>)((OkObjectResult)actionMikeScenarioResultList.Result).Value;

            int count = ((List<MikeScenarioResult>)((OkObjectResult)actionMikeScenarioResultList.Result).Value).Count();
            Assert.True(count > 0);

            // Put MikeScenarioResult
            var actionMikeScenarioResultUpdated = await MikeScenarioResultService.Put(mikeScenarioResult);
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultUpdated.Result).Value);
            MikeScenarioResult mikeScenarioResultUpdated = (MikeScenarioResult)((OkObjectResult)actionMikeScenarioResultUpdated.Result).Value;
            Assert.NotNull(mikeScenarioResultUpdated);

            // Delete MikeScenarioResult
            var actionMikeScenarioResultDeleted = await MikeScenarioResultService.Delete(mikeScenarioResult.MikeScenarioResultID);
            Assert.Equal(200, ((ObjectResult)actionMikeScenarioResultDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeScenarioResultDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMikeScenarioResultDeleted.Result).Value;
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

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{AppDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IMikeScenarioResultService, MikeScenarioResultService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.IsLocal = true;

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            MikeScenarioResultService = Provider.GetService<IMikeScenarioResultService>();
            Assert.NotNull(MikeScenarioResultService);

            return await Task.FromResult(true);
        }
        private MikeScenarioResult GetFilledRandomMikeScenarioResult(string OmitPropName)
        {
            List<MikeScenarioResult> mikeScenarioResultListToDelete = (from c in dbLocal.MikeScenarioResults
                                                               select c).ToList(); 
            
            dbLocal.MikeScenarioResults.RemoveRange(mikeScenarioResultListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            MikeScenarioResult mikeScenarioResult = new MikeScenarioResult();

            if (OmitPropName != "MikeScenarioTVItemID") mikeScenarioResult.MikeScenarioTVItemID = 51;
            if (OmitPropName != "MikeResultsJSON") mikeScenarioResult.MikeResultsJSON = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") mikeScenarioResult.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeScenarioResult.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "MikeScenarioResultID") mikeScenarioResult.MikeScenarioResultID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 51, TVLevel = 4, TVPath = "p1p5p6p39p51", TVType = (TVTypeEnum)13, ParentID = 39, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 21, 28, 56), LastUpdateContactTVItemID = 2});
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

            return mikeScenarioResult;
        }
        #endregion Functions private
    }
}
