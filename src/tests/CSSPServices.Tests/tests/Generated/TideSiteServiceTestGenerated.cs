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
    public partial class TideSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITideSiteService TideSiteService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private TideSite tideSite { get; set; }
        #endregion Properties

        #region Constructors
        public TideSiteServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task TideSite_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            tideSite = GetFilledRandomTideSite("");

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
            // Post TideSite
            var actionTideSiteAdded = await TideSiteService.Post(tideSite);
            Assert.Equal(200, ((ObjectResult)actionTideSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTideSiteAdded.Result).Value);
            TideSite tideSiteAdded = (TideSite)((OkObjectResult)actionTideSiteAdded.Result).Value;
            Assert.NotNull(tideSiteAdded);

            // List<TideSite>
            var actionTideSiteList = await TideSiteService.GetTideSiteList();
            Assert.Equal(200, ((ObjectResult)actionTideSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTideSiteList.Result).Value);
            List<TideSite> tideSiteList = (List<TideSite>)((OkObjectResult)actionTideSiteList.Result).Value;

            int count = ((List<TideSite>)((OkObjectResult)actionTideSiteList.Result).Value).Count();
            Assert.True(count > 0);

            // Put TideSite
            var actionTideSiteUpdated = await TideSiteService.Put(tideSite);
            Assert.Equal(200, ((ObjectResult)actionTideSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTideSiteUpdated.Result).Value);
            TideSite tideSiteUpdated = (TideSite)((OkObjectResult)actionTideSiteUpdated.Result).Value;
            Assert.NotNull(tideSiteUpdated);

            // Delete TideSite
            var actionTideSiteDeleted = await TideSiteService.Delete(tideSite.TideSiteID);
            Assert.Equal(200, ((ObjectResult)actionTideSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTideSiteDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTideSiteDeleted.Result).Value;
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
            Services.AddSingleton<ITideSiteService, TideSiteService>();

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

            TideSiteService = Provider.GetService<ITideSiteService>();
            Assert.NotNull(TideSiteService);

            return await Task.FromResult(true);
        }
        private TideSite GetFilledRandomTideSite(string OmitPropName)
        {
            List<TideSite> tideSiteListToDelete = (from c in dbLocal.TideSites
                                                               select c).ToList(); 
            
            dbLocal.TideSites.RemoveRange(tideSiteListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            TideSite tideSite = new TideSite();

            if (OmitPropName != "TideSiteTVItemID") tideSite.TideSiteTVItemID = 38;
            if (OmitPropName != "TideSiteName") tideSite.TideSiteName = GetRandomString("", 5);
            if (OmitPropName != "Province") tideSite.Province = GetRandomString("", 2);
            if (OmitPropName != "sid") tideSite.sid = GetRandomInt(0, 10000);
            if (OmitPropName != "Zone") tideSite.Zone = GetRandomInt(0, 10000);
            if (OmitPropName != "LastUpdateDate_UTC") tideSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tideSite.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "TideSiteID") tideSite.TideSiteID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 38, TVLevel = 3, TVPath = "p1p5p6p38", TVType = (TVTypeEnum)22, ParentID = 6, IsActive = true, LastUpdateDate_UTC = new DateTime(2019, 1, 22, 18, 36, 9), LastUpdateContactTVItemID = 2});
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

            return tideSite;
        }
        #endregion Functions private
    }
}
