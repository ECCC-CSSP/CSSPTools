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
    public partial class TideSiteServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITideSiteService TideSiteService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private TideSite tideSite { get; set; }
        #endregion Properties

        #region Constructors
        public TideSiteServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task TideSite_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            tideSite = GetFilledRandomTideSite("");

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
        public async Task TideSite_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionTideSiteList = await TideSiteService.GetTideSiteList();
            Assert.Equal(200, ((ObjectResult)actionTideSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTideSiteList.Result).Value);
            List<TideSite> tideSiteList = (List<TideSite>)((OkObjectResult)actionTideSiteList.Result).Value;

            count = tideSiteList.Count();

            TideSite tideSite = GetFilledRandomTideSite("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tideSite.TideSiteID   (Int32)
            // -----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.TideSiteID = 0;

            var actionTideSite = await TideSiteService.Put(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.TideSiteID = 10000000;
            actionTideSite = await TideSiteService.Put(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = TideSite)]
            // tideSite.TideSiteTVItemID   (Int32)
            // -----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.TideSiteTVItemID = 0;
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.TideSiteTVItemID = 1;
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // tideSite.TideSiteName   (String)
            // -----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("TideSiteName");
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.TideSiteName = GetRandomString("", 101);
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);
            //Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(2)]
            // [CSSPMinLength(2)]
            // tideSite.Province   (String)
            // -----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("Province");
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.Province = GetRandomString("", 1);
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);
            //Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());
            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.Province = GetRandomString("", 3);
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);
            //Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000)]
            // tideSite.sid   (Int32)
            // -----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.sid = -1;
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);
            //Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());
            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.sid = 10001;
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);
            //Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000)]
            // tideSite.Zone   (Int32)
            // -----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.Zone = -1;
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);
            //Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());
            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.Zone = 10001;
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);
            //Assert.AreEqual(count, tideSiteService.GetTideSiteList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tideSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.LastUpdateDate_UTC = new DateTime();
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);
            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tideSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.LastUpdateContactTVItemID = 0;
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);

            tideSite = null;
            tideSite = GetFilledRandomTideSite("");
            tideSite.LastUpdateContactTVItemID = 1;
            actionTideSite = await TideSiteService.Post(tideSite);
            Assert.IsType<BadRequestObjectResult>(actionTideSite.Result);

        }
        #endregion Tests Generated Properties

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

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<TideSite> with skip and take
                var actionTideSiteListSkipAndTake = await TideSiteService.GetTideSiteList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionTideSiteListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionTideSiteListSkipAndTake.Result).Value);
                List<TideSite> tideSiteListSkipAndTake = (List<TideSite>)((OkObjectResult)actionTideSiteListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<TideSite>)((OkObjectResult)actionTideSiteListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(tideSiteList[0].TideSiteID == tideSiteListSkipAndTake[0].TideSiteID);
            }

            // Get TideSite With TideSiteID
            var actionTideSiteGet = await TideSiteService.GetTideSiteWithTideSiteID(tideSiteList[0].TideSiteID);
            Assert.Equal(200, ((ObjectResult)actionTideSiteGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTideSiteGet.Result).Value);
            TideSite tideSiteGet = (TideSite)((OkObjectResult)actionTideSiteGet.Result).Value;
            Assert.NotNull(tideSiteGet);
            Assert.Equal(tideSiteGet.TideSiteID, tideSiteList[0].TideSiteID);

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
               .AddJsonFile("appsettings_csspservicestests.json")
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

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITideSiteService, TideSiteService>();

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

            dbIM = Provider.GetService<CSSPDBInMemoryContext>();
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

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
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
        private void CheckTideSiteFields(List<TideSite> tideSiteList)
        {
            Assert.False(string.IsNullOrWhiteSpace(tideSiteList[0].TideSiteName));
            Assert.False(string.IsNullOrWhiteSpace(tideSiteList[0].Province));
        }
        #endregion Functions private
    }
}