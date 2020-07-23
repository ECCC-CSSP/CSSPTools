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
    public partial class TVItemServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITVItemService TVItemService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private TVItem tvItem { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task TVItem_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            tvItem = GetFilledRandomTVItem("");

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
        public async Task TVItem_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionTVItemList = await TVItemService.GetTVItemList();
            Assert.Equal(200, ((ObjectResult)actionTVItemList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemList.Result).Value);
            List<TVItem> tvItemList = (List<TVItem>)((OkObjectResult)actionTVItemList.Result).Value;

            count = tvItemList.Count();

            TVItem tvItem = GetFilledRandomTVItem("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tvItem.TVItemID   (Int32)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVItemID = 0;

            var actionTVItem = await TVItemService.Put(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVItemID = 10000000;
            actionTVItem = await TVItemService.Put(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100)]
            // tvItem.TVLevel   (Int32)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVLevel = -1;
            actionTVItem = await TVItemService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);
            //Assert.AreEqual(count, tvItemService.GetTVItemList().Count());
            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVLevel = 101;
            actionTVItem = await TVItemService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);
            //Assert.AreEqual(count, tvItemService.GetTVItemList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // tvItem.TVPath   (String)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("TVPath");
            actionTVItem = await TVItemService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVPath = GetRandomString("", 251);
            actionTVItem = await TVItemService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);
            //Assert.AreEqual(count, tvItemService.GetTVItemList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItem.TVType   (TVTypeEnum)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVType = (TVTypeEnum)1000000;
            actionTVItem = await TVItemService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,RainExceedance,Classification)]
            // tvItem.ParentID   (Int32)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.ParentID = 0;
            actionTVItem = await TVItemService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.ParentID = 38;
            actionTVItem = await TVItemService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);


            // -----------------------------------
            // Is NOT Nullable
            // tvItem.IsActive   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvItem.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.LastUpdateDate_UTC = new DateTime();
            actionTVItem = await TVItemService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);
            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionTVItem = await TVItemService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tvItem.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.LastUpdateContactTVItemID = 0;
            actionTVItem = await TVItemService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.LastUpdateContactTVItemID = 1;
            actionTVItem = await TVItemService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post TVItem
            var actionTVItemAdded = await TVItemService.Post(tvItem);
            Assert.Equal(200, ((ObjectResult)actionTVItemAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemAdded.Result).Value);
            TVItem tvItemAdded = (TVItem)((OkObjectResult)actionTVItemAdded.Result).Value;
            Assert.NotNull(tvItemAdded);

            // List<TVItem>
            var actionTVItemList = await TVItemService.GetTVItemList();
            Assert.Equal(200, ((ObjectResult)actionTVItemList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemList.Result).Value);
            List<TVItem> tvItemList = (List<TVItem>)((OkObjectResult)actionTVItemList.Result).Value;

            int count = ((List<TVItem>)((OkObjectResult)actionTVItemList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<TVItem> with skip and take
                var actionTVItemListSkipAndTake = await TVItemService.GetTVItemList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionTVItemListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionTVItemListSkipAndTake.Result).Value);
                List<TVItem> tvItemListSkipAndTake = (List<TVItem>)((OkObjectResult)actionTVItemListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<TVItem>)((OkObjectResult)actionTVItemListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(tvItemList[0].TVItemID == tvItemListSkipAndTake[0].TVItemID);
            }

            // Get TVItem With TVItemID
            var actionTVItemGet = await TVItemService.GetTVItemWithTVItemID(tvItemList[0].TVItemID);
            Assert.Equal(200, ((ObjectResult)actionTVItemGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemGet.Result).Value);
            TVItem tvItemGet = (TVItem)((OkObjectResult)actionTVItemGet.Result).Value;
            Assert.NotNull(tvItemGet);
            Assert.Equal(tvItemGet.TVItemID, tvItemList[0].TVItemID);

            // Put TVItem
            var actionTVItemUpdated = await TVItemService.Put(tvItem);
            Assert.Equal(200, ((ObjectResult)actionTVItemUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemUpdated.Result).Value);
            TVItem tvItemUpdated = (TVItem)((OkObjectResult)actionTVItemUpdated.Result).Value;
            Assert.NotNull(tvItemUpdated);

            // Delete TVItem
            var actionTVItemDeleted = await TVItemService.Delete(tvItem.TVItemID);
            Assert.Equal(200, ((ObjectResult)actionTVItemDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTVItemDeleted.Result).Value;
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
            Services.AddSingleton<ITVItemService, TVItemService>();

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

            TVItemService = Provider.GetService<ITVItemService>();
            Assert.NotNull(TVItemService);

            return await Task.FromResult(true);
        }
        private TVItem GetFilledRandomTVItem(string OmitPropName)
        {
            List<TVItem> tvItemListToDelete = (from c in dbLocal.TVItems
                                                               select c).ToList(); 
            
            dbLocal.TVItems.RemoveRange(tvItemListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            TVItem tvItem = new TVItem();

            if (OmitPropName != "TVLevel") tvItem.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") tvItem.TVPath = GetRandomString("", 5);
            if (OmitPropName != "TVType") tvItem.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ParentID") tvItem.ParentID = 1;
            if (OmitPropName != "IsActive") tvItem.IsActive = true;
            if (OmitPropName != "LastUpdateDate_UTC") tvItem.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItem.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "TVItemID") tvItem.TVItemID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 1, TVLevel = 0, TVPath = "p1", TVType = (TVTypeEnum)1, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
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

            return tvItem;
        }
        private void CheckTVItemFields(List<TVItem> tvItemList)
        {
            Assert.False(string.IsNullOrWhiteSpace(tvItemList[0].TVPath));
            if (tvItemList[0].ParentID != null)
            {
                Assert.NotNull(tvItemList[0].ParentID);
            }
        }
        #endregion Functions private
    }
}
