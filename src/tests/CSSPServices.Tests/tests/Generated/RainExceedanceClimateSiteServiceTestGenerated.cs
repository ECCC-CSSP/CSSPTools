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
    public partial class RainExceedanceClimateSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
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
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task RainExceedanceClimateSite_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");

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
        public async Task RainExceedanceClimateSite_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionRainExceedanceClimateSiteList = await RainExceedanceClimateSiteService.GetRainExceedanceClimateSiteList();
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value);
            List<RainExceedanceClimateSite> rainExceedanceClimateSiteList = (List<RainExceedanceClimateSite>)((OkObjectResult)actionRainExceedanceClimateSiteList.Result).Value;

            count = rainExceedanceClimateSiteList.Count();

            RainExceedanceClimateSite rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // rainExceedanceClimateSite.RainExceedanceClimateSiteID   (Int32)
            // -----------------------------------

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.RainExceedanceClimateSiteID = 0;

            var actionRainExceedanceClimateSite = await RainExceedanceClimateSiteService.Put(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.RainExceedanceClimateSiteID = 10000000;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteService.Put(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = RainExceedance)]
            // rainExceedanceClimateSite.RainExceedanceTVItemID   (Int32)
            // -----------------------------------

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.RainExceedanceTVItemID = 0;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.RainExceedanceTVItemID = 1;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = ClimateSite)]
            // rainExceedanceClimateSite.ClimateSiteTVItemID   (Int32)
            // -----------------------------------

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.ClimateSiteTVItemID = 0;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.ClimateSiteTVItemID = 1;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // rainExceedanceClimateSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.LastUpdateDate_UTC = new DateTime();
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);
            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // rainExceedanceClimateSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.LastUpdateContactTVItemID = 0;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);

            rainExceedanceClimateSite = null;
            rainExceedanceClimateSite = GetFilledRandomRainExceedanceClimateSite("");
            rainExceedanceClimateSite.LastUpdateContactTVItemID = 1;
            actionRainExceedanceClimateSite = await RainExceedanceClimateSiteService.Post(rainExceedanceClimateSite);
            Assert.IsType<BadRequestObjectResult>(actionRainExceedanceClimateSite.Result);

        }
        #endregion Tests Generated Properties

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

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<RainExceedanceClimateSite> with skip and take
                var actionRainExceedanceClimateSiteListSkipAndTake = await RainExceedanceClimateSiteService.GetRainExceedanceClimateSiteList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteListSkipAndTake.Result).Value);
                List<RainExceedanceClimateSite> rainExceedanceClimateSiteListSkipAndTake = (List<RainExceedanceClimateSite>)((OkObjectResult)actionRainExceedanceClimateSiteListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<RainExceedanceClimateSite>)((OkObjectResult)actionRainExceedanceClimateSiteListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(rainExceedanceClimateSiteList[0].RainExceedanceClimateSiteID == rainExceedanceClimateSiteListSkipAndTake[0].RainExceedanceClimateSiteID);
            }

            // Get RainExceedanceClimateSite With RainExceedanceClimateSiteID
            var actionRainExceedanceClimateSiteGet = await RainExceedanceClimateSiteService.GetRainExceedanceClimateSiteWithRainExceedanceClimateSiteID(rainExceedanceClimateSiteList[0].RainExceedanceClimateSiteID);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceClimateSiteGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceClimateSiteGet.Result).Value);
            RainExceedanceClimateSite rainExceedanceClimateSiteGet = (RainExceedanceClimateSite)((OkObjectResult)actionRainExceedanceClimateSiteGet.Result).Value;
            Assert.NotNull(rainExceedanceClimateSiteGet);
            Assert.Equal(rainExceedanceClimateSiteGet.RainExceedanceClimateSiteID, rainExceedanceClimateSiteList[0].RainExceedanceClimateSiteID);

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
            Services.AddSingleton<IRainExceedanceClimateSiteService, RainExceedanceClimateSiteService>();

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

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
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
        private void CheckRainExceedanceClimateSiteFields(List<RainExceedanceClimateSite> rainExceedanceClimateSiteList)
        {
        }
        #endregion Functions private
    }
}
