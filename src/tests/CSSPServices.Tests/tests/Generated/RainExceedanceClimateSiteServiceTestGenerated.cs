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
    public partial class RainExceedanceClimateSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IRainExceedanceClimateSiteService RainExceedanceClimateSiteService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private RainExceedanceClimateSite rainExceedanceClimateSite { get; set; }
        #endregion Properties

        #region Constructors
        public RainExceedanceClimateSiteServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task RainExceedanceClimateSite_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");

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
            // Post RainExceedanceClimateSite
            var actionRainExceedanceClimateSiteAdded = await RainExceedanceClimateSiteService.Post(rainExceedanceClimateSite);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteAdded.Result).Value);
            RainExceedanceClimateSite rainExceedanceClimateSiteAdded = (RainExceedanceClimateSite)((OkObjectResult)actionRainExceedanceClimateSiteAdded.Result).Value;
            Assert.NotNull(rainExceedanceClimateSiteAdded);

            // List<RainExceedanceClimateSite>
            var actionRainExceedanceClimateSiteList = await RainExceedanceClimateSiteService.GetRainExceedanceClimateSiteList();
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value);
            List<RainExceedanceClimateSite> rainExceedanceClimateSiteList = (List<RainExceedanceClimateSite>)((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value;

            int count = ((List<RainExceedanceClimateSite>)((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value).Count();
            Assert.True(count > 0);

            // Put RainExceedanceClimateSite
            var actionRainExceedanceClimateSiteUpdated = await RainExceedanceClimateSiteService.Put(rainExceedanceClimateSite);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteUpdated.Result).Value);
            RainExceedanceClimateSite rainExceedanceClimateSiteUpdated = (RainExceedanceClimateSite)((OkObjectResult)actionRainExceedanceClimateSiteUpdated.Result).Value;
            Assert.NotNull(rainExceedanceClimateSiteUpdated);

            // Delete RainExceedanceClimateSite
            var actionRainExceedanceClimateSiteDeleted = await RainExceedanceClimateSiteService.Delete(rainExceedanceClimateSite.RainExceedanceClimateSiteID);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionRainExceedanceClimateSiteDeleted.Result).Value;
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
            Services.AddSingleton<IRainExceedanceClimateSiteService, RainExceedanceClimateSiteService>();

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

            RainExceedanceClimateSiteService = Provider.GetService<IRainExceedanceClimateSiteService>();
            Assert.NotNull(RainExceedanceClimateSiteService);

            return await Task.FromResult(true);
        }
        private RainExceedanceClimateSite GetFilledRandomRainExceedanceClimateSite(string OmitPropName)
        {
            List<RainExceedanceClimateSite> rainExceedanceClimateSiteListToDelete = (from c in dbLocal.RainExceedanceClimateSites
                                                               select c).ToList(); 
            
            dbLocal.RainExceedanceClimateSites.RemoveRange(rainExceedanceClimateSiteListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            RainExceedanceClimateSite rainExceedanceClimateSite = new RainExceedanceClimateSite();

            if (OmitPropName != "RainExceedanceTVItemID") rainExceedanceClimateSite.RainExceedanceTVItemID = 56;
            if (OmitPropName != "ClimateSiteTVItemID") rainExceedanceClimateSite.ClimateSiteTVItemID = 7;
            if (OmitPropName != "LastUpdateDate_UTC") rainExceedanceClimateSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") rainExceedanceClimateSite.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "RainExceedanceClimateSiteID") rainExceedanceClimateSite.RainExceedanceClimateSiteID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 56, TVLevel = 2, TVPath = "p1p5p56", TVType = (TVTypeEnum)75, ParentID = 5, IsActive = true, LastUpdateDate_UTC = new DateTime(2019, 8, 16, 14, 13, 49), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
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
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
            }

            return rainExceedanceClimateSite;
        }
        #endregion Functions private
    }
}
