/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
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
    public partial class PolSourceObservationIssueServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IPolSourceObservationIssueService PolSourceObservationIssueService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private PolSourceObservationIssue polSourceObservationIssue { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task PolSourceObservationIssue_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");

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
            // Post PolSourceObservationIssue
            var actionPolSourceObservationIssueAdded = await PolSourceObservationIssueService.Post(polSourceObservationIssue);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueAdded.Result).Value);
            PolSourceObservationIssue polSourceObservationIssueAdded = (PolSourceObservationIssue)((OkObjectResult)actionPolSourceObservationIssueAdded.Result).Value;
            Assert.NotNull(polSourceObservationIssueAdded);

            // List<PolSourceObservationIssue>
            var actionPolSourceObservationIssueList = await PolSourceObservationIssueService.GetPolSourceObservationIssueList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueList.Result).Value);
            List<PolSourceObservationIssue> polSourceObservationIssueList = (List<PolSourceObservationIssue>)((OkObjectResult)actionPolSourceObservationIssueList.Result).Value;

            int count = ((List<PolSourceObservationIssue>)((OkObjectResult)actionPolSourceObservationIssueList.Result).Value).Count();
            Assert.True(count > 0);

            // Put PolSourceObservationIssue
            var actionPolSourceObservationIssueUpdated = await PolSourceObservationIssueService.Put(polSourceObservationIssue);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueUpdated.Result).Value);
            PolSourceObservationIssue polSourceObservationIssueUpdated = (PolSourceObservationIssue)((OkObjectResult)actionPolSourceObservationIssueUpdated.Result).Value;
            Assert.NotNull(polSourceObservationIssueUpdated);

            // Delete PolSourceObservationIssue
            var actionPolSourceObservationIssueDeleted = await PolSourceObservationIssueService.Delete(polSourceObservationIssue.PolSourceObservationIssueID);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionPolSourceObservationIssueDeleted.Result).Value;
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
            Services.AddSingleton<IPolSourceObservationIssueService, PolSourceObservationIssueService>();

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

            PolSourceObservationIssueService = Provider.GetService<IPolSourceObservationIssueService>();
            Assert.NotNull(PolSourceObservationIssueService);

            return await Task.FromResult(true);
        }
        private PolSourceObservationIssue GetFilledRandomPolSourceObservationIssue(string OmitPropName)
        {
            List<PolSourceObservationIssue> polSourceObservationIssueListToDelete = (from c in dbLocal.PolSourceObservationIssues
                                                               select c).ToList(); 
            
            dbLocal.PolSourceObservationIssues.RemoveRange(polSourceObservationIssueListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            PolSourceObservationIssue polSourceObservationIssue = new PolSourceObservationIssue();

            if (OmitPropName != "PolSourceObservationID") polSourceObservationIssue.PolSourceObservationID = 1;
            if (OmitPropName != "ObservationInfo") polSourceObservationIssue.ObservationInfo = GetRandomString("", 5);
            if (OmitPropName != "Ordinal") polSourceObservationIssue.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "ExtraComment") polSourceObservationIssue.ExtraComment = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservationIssue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceObservationIssue.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "PolSourceObservationIssueID") polSourceObservationIssue.PolSourceObservationIssueID = 10000000;

                try
                {
                    dbIM.PolSourceObservations.Add(new PolSourceObservation() { PolSourceObservationID = 1, PolSourceSiteID = 1, ObservationDate_Local = new DateTime(2007, 4, 24, 0, 0, 0), ContactTVItemID = 2, DesktopReviewed = false, Observation_ToBeDeleted = "NP Farm area, 20+ animals observed and manure piled 4m high behind barn approx. 350m from shore. Drainage ditches lead to river with a heavy slope.", LastUpdateDate_UTC = new DateTime(2015, 4, 13, 20, 1, 31), LastUpdateContactTVItemID = 2 });
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

            return polSourceObservationIssue;
        }
        #endregion Functions private
    }
}
