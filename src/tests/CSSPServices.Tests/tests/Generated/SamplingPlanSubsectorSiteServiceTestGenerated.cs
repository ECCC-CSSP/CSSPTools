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
    public partial class SamplingPlanSubsectorSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ISamplingPlanSubsectorSiteService SamplingPlanSubsectorSiteService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private SamplingPlanSubsectorSite samplingPlanSubsectorSite { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanSubsectorSiteServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task SamplingPlanSubsectorSite_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            samplingPlanSubsectorSite = GetFilledRandomSamplingPlanSubsectorSite("");

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

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post SamplingPlanSubsectorSite
            var actionSamplingPlanSubsectorSiteAdded = await SamplingPlanSubsectorSiteService.Post(samplingPlanSubsectorSite);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteAdded.Result).Value);
            SamplingPlanSubsectorSite samplingPlanSubsectorSiteAdded = (SamplingPlanSubsectorSite)((OkObjectResult)actionSamplingPlanSubsectorSiteAdded.Result).Value;
            Assert.NotNull(samplingPlanSubsectorSiteAdded);

            // List<SamplingPlanSubsectorSite>
            var actionSamplingPlanSubsectorSiteList = await SamplingPlanSubsectorSiteService.GetSamplingPlanSubsectorSiteList();
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteList.Result).Value);
            List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteList = (List<SamplingPlanSubsectorSite>)((OkObjectResult)actionSamplingPlanSubsectorSiteList.Result).Value;

            int count = ((List<SamplingPlanSubsectorSite>)((OkObjectResult)actionSamplingPlanSubsectorSiteList.Result).Value).Count();
            Assert.True(count > 0);

            // Put SamplingPlanSubsectorSite
            var actionSamplingPlanSubsectorSiteUpdated = await SamplingPlanSubsectorSiteService.Put(samplingPlanSubsectorSite);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteUpdated.Result).Value);
            SamplingPlanSubsectorSite samplingPlanSubsectorSiteUpdated = (SamplingPlanSubsectorSite)((OkObjectResult)actionSamplingPlanSubsectorSiteUpdated.Result).Value;
            Assert.NotNull(samplingPlanSubsectorSiteUpdated);

            // Delete SamplingPlanSubsectorSite
            var actionSamplingPlanSubsectorSiteDeleted = await SamplingPlanSubsectorSiteService.Delete(samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanSubsectorSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanSubsectorSiteDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionSamplingPlanSubsectorSiteDeleted.Result).Value;
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

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ISamplingPlanSubsectorSiteService, SamplingPlanSubsectorSiteService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.DBLocation = DBLocationEnum.Local;

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            SamplingPlanSubsectorSiteService = Provider.GetService<ISamplingPlanSubsectorSiteService>();
            Assert.NotNull(SamplingPlanSubsectorSiteService);

            return await Task.FromResult(true);
        }
        private SamplingPlanSubsectorSite GetFilledRandomSamplingPlanSubsectorSite(string OmitPropName)
        {
            List<SamplingPlanSubsectorSite> samplingPlanSubsectorSiteListToDelete = (from c in dbLocal.SamplingPlanSubsectorSites
                                                               select c).ToList(); 
            
            dbLocal.SamplingPlanSubsectorSites.RemoveRange(samplingPlanSubsectorSiteListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            SamplingPlanSubsectorSite samplingPlanSubsectorSite = new SamplingPlanSubsectorSite();

            if (OmitPropName != "SamplingPlanSubsectorID") samplingPlanSubsectorSite.SamplingPlanSubsectorID = 1;
            if (OmitPropName != "MWQMSiteTVItemID") samplingPlanSubsectorSite.MWQMSiteTVItemID = 44;
            if (OmitPropName != "IsDuplicate") samplingPlanSubsectorSite.IsDuplicate = true;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanSubsectorSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanSubsectorSite.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "SamplingPlanSubsectorSiteID") samplingPlanSubsectorSite.SamplingPlanSubsectorSiteID = 10000000;

                try
                {
                    dbIM.SamplingPlanSubsectors.Add(new SamplingPlanSubsector() { SamplingPlanSubsectorID = 1, SamplingPlanID = 1, SubsectorTVItemID = 12, LastUpdateDate_UTC = new DateTime(2019, 1, 15, 14, 24, 39), LastUpdateContactTVItemID = 2 });
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 44, TVLevel = 6, TVPath = "p1p5p6p9p10p12p44", TVType = (TVTypeEnum)16, ParentID = 12, IsActive = true, LastUpdateDate_UTC = new DateTime(2017, 10, 12, 17, 39, 34), LastUpdateContactTVItemID = 2});
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

            return samplingPlanSubsectorSite;
        }
        #endregion Functions private
    }
}
