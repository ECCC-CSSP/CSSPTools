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
    public partial class UseOfSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IUseOfSiteService UseOfSiteService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private UseOfSite useOfSite { get; set; }
        #endregion Properties

        #region Constructors
        public UseOfSiteServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task UseOfSite_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            useOfSite = GetFilledRandomUseOfSite("");

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
            // Post UseOfSite
            var actionUseOfSiteAdded = await UseOfSiteService.Post(useOfSite);
            Assert.Equal(200, ((ObjectResult)actionUseOfSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionUseOfSiteAdded.Result).Value);
            UseOfSite useOfSiteAdded = (UseOfSite)((OkObjectResult)actionUseOfSiteAdded.Result).Value;
            Assert.NotNull(useOfSiteAdded);

            // List<UseOfSite>
            var actionUseOfSiteList = await UseOfSiteService.GetUseOfSiteList();
            Assert.Equal(200, ((ObjectResult)actionUseOfSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionUseOfSiteList.Result).Value);
            List<UseOfSite> useOfSiteList = (List<UseOfSite>)((OkObjectResult)actionUseOfSiteList.Result).Value;

            int count = ((List<UseOfSite>)((OkObjectResult)actionUseOfSiteList.Result).Value).Count();
            Assert.True(count > 0);

            // Put UseOfSite
            var actionUseOfSiteUpdated = await UseOfSiteService.Put(useOfSite);
            Assert.Equal(200, ((ObjectResult)actionUseOfSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionUseOfSiteUpdated.Result).Value);
            UseOfSite useOfSiteUpdated = (UseOfSite)((OkObjectResult)actionUseOfSiteUpdated.Result).Value;
            Assert.NotNull(useOfSiteUpdated);

            // Delete UseOfSite
            var actionUseOfSiteDeleted = await UseOfSiteService.Delete(useOfSite.UseOfSiteID);
            Assert.Equal(200, ((ObjectResult)actionUseOfSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionUseOfSiteDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionUseOfSiteDeleted.Result).Value;
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
            Services.AddSingleton<IUseOfSiteService, UseOfSiteService>();

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

            UseOfSiteService = Provider.GetService<IUseOfSiteService>();
            Assert.NotNull(UseOfSiteService);

            return await Task.FromResult(true);
        }
        private UseOfSite GetFilledRandomUseOfSite(string OmitPropName)
        {
            List<UseOfSite> useOfSiteListToDelete = (from c in dbLocal.UseOfSites
                                                               select c).ToList(); 
            
            dbLocal.UseOfSites.RemoveRange(useOfSiteListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            UseOfSite useOfSite = new UseOfSite();

            if (OmitPropName != "SiteTVItemID") useOfSite.SiteTVItemID = 7;
            if (OmitPropName != "SubsectorTVItemID") useOfSite.SubsectorTVItemID = 11;
            if (OmitPropName != "TVType") useOfSite.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "Ordinal") useOfSite.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "StartYear") useOfSite.StartYear = GetRandomInt(1980, 2050);
            if (OmitPropName != "EndYear") useOfSite.EndYear = GetRandomInt(1980, 2050);
            if (OmitPropName != "UseWeight") useOfSite.UseWeight = true;
            if (OmitPropName != "Weight_perc") useOfSite.Weight_perc = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "UseEquation") useOfSite.UseEquation = true;
            if (OmitPropName != "Param1") useOfSite.Param1 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param2") useOfSite.Param2 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param3") useOfSite.Param3 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param4") useOfSite.Param4 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "LastUpdateDate_UTC") useOfSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") useOfSite.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "UseOfSiteID") useOfSite.UseOfSiteID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 7, TVLevel = 3, TVPath = "p1p5p6p7", TVType = (TVTypeEnum)4, ParentID = 6, IsActive = true, LastUpdateDate_UTC = new DateTime(2015, 6, 18, 14, 40, 7), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 11, TVLevel = 5, TVPath = "p1p5p6p9p10p11", TVType = (TVTypeEnum)20, ParentID = 10, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 18, 53, 40), LastUpdateContactTVItemID = 2});
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

            return useOfSite;
        }
        #endregion Functions private
    }
}
