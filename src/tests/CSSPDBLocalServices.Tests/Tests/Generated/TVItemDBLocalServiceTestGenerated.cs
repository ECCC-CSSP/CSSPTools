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
using LocalServices;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class TVItemDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ITVItemDBLocalService TVItemDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private TVItem tvItem { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DBLocal]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            tvItem = GetFilledRandomTVItem("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItem_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionTVItemList = await TVItemDBLocalService.GetTVItemList();
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

            var actionTVItem = await TVItemDBLocalService.Put(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVItemID = 10000000;
            actionTVItem = await TVItemDBLocalService.Put(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100)]
            // tvItem.TVLevel   (Int32)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVLevel = -1;
            actionTVItem = await TVItemDBLocalService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);
            //Assert.AreEqual(count, tvItemService.GetTVItemList().Count());
            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVLevel = 101;
            actionTVItem = await TVItemDBLocalService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);
            //Assert.AreEqual(count, tvItemDBLocalService.GetTVItemList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // tvItem.TVPath   (String)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("TVPath");
            actionTVItem = await TVItemDBLocalService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVPath = GetRandomString("", 251);
            actionTVItem = await TVItemDBLocalService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);
            //Assert.AreEqual(count, tvItemDBLocalService.GetTVItemList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItem.TVType   (TVTypeEnum)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVType = (TVTypeEnum)1000000;
            actionTVItem = await TVItemDBLocalService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,RainExceedance,Classification)]
            // tvItem.ParentID   (Int32)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.ParentID = 0;
            actionTVItem = await TVItemDBLocalService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.ParentID = 38;
            actionTVItem = await TVItemDBLocalService.Post(tvItem);
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
            actionTVItem = await TVItemDBLocalService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);
            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionTVItem = await TVItemDBLocalService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tvItem.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.LastUpdateContactTVItemID = 0;
            actionTVItem = await TVItemDBLocalService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.LastUpdateContactTVItemID = 1;
            actionTVItem = await TVItemDBLocalService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post TVItem
            var actionTVItemAdded = await TVItemDBLocalService.Post(tvItem);
            Assert.Equal(200, ((ObjectResult)actionTVItemAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemAdded.Result).Value);
            TVItem tvItemAdded = (TVItem)((OkObjectResult)actionTVItemAdded.Result).Value;
            Assert.NotNull(tvItemAdded);

            // List<TVItem>
            var actionTVItemList = await TVItemDBLocalService.GetTVItemList();
            Assert.Equal(200, ((ObjectResult)actionTVItemList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemList.Result).Value);
            List<TVItem> tvItemList = (List<TVItem>)((OkObjectResult)actionTVItemList.Result).Value;

            int count = ((List<TVItem>)((OkObjectResult)actionTVItemList.Result).Value).Count();
            Assert.True(count > 0);

            // List<TVItem> with skip and take
            var actionTVItemListSkipAndTake = await TVItemDBLocalService.GetTVItemList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionTVItemListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemListSkipAndTake.Result).Value);
            List<TVItem> tvItemListSkipAndTake = (List<TVItem>)((OkObjectResult)actionTVItemListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<TVItem>)((OkObjectResult)actionTVItemListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(tvItemList[0].TVItemID == tvItemListSkipAndTake[0].TVItemID);

            // Get TVItem With TVItemID
            var actionTVItemGet = await TVItemDBLocalService.GetTVItemWithTVItemID(tvItemList[0].TVItemID);
            Assert.Equal(200, ((ObjectResult)actionTVItemGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemGet.Result).Value);
            TVItem tvItemGet = (TVItem)((OkObjectResult)actionTVItemGet.Result).Value;
            Assert.NotNull(tvItemGet);
            Assert.Equal(tvItemGet.TVItemID, tvItemList[0].TVItemID);

            // Put TVItem
            var actionTVItemUpdated = await TVItemDBLocalService.Put(tvItem);
            Assert.Equal(200, ((ObjectResult)actionTVItemUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemUpdated.Result).Value);
            TVItem tvItemUpdated = (TVItem)((OkObjectResult)actionTVItemUpdated.Result).Value;
            Assert.NotNull(tvItemUpdated);

            // Delete TVItem
            var actionTVItemDeleted = await TVItemDBLocalService.Delete(tvItem.TVItemID);
            Assert.Equal(200, ((ObjectResult)actionTVItemDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTVItemDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLoginFileName = Config.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITVItemDBLocalService, TVItemDBLocalService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            TVItemDBLocalService = Provider.GetService<ITVItemDBLocalService>();
            Assert.NotNull(TVItemDBLocalService);

            return await Task.FromResult(true);
        }
        private TVItem GetFilledRandomTVItem(string OmitPropName)
        {
            TVItem tvItem = new TVItem();

            if (OmitPropName != "TVLevel") tvItem.TVLevel = GetRandomInt(0, 100);
            if (OmitPropName != "TVPath") tvItem.TVPath = GetRandomString("", 5);
            if (OmitPropName != "TVType") tvItem.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ParentID") tvItem.ParentID = 1;
            if (OmitPropName != "IsActive") tvItem.IsActive = true;
            if (OmitPropName != "LastUpdateDate_UTC") tvItem.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItem.LastUpdateContactTVItemID = 2;

            try
            {
                dbLocal.TVItems.Add(new TVItem() { TVItemID = 1, TVLevel = 0, TVPath = "p1", TVType = (TVTypeEnum)1, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocal.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }
            try
            {
                dbLocal.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocal.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
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
