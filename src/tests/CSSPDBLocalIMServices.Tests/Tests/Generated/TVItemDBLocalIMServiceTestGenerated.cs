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

namespace CSSPDBLocalIMServices.Tests
{
    [Collection("Sequential")]
    public partial class TVItemDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ITVItemDBLocalIMService TVItemDBLocalIMService { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private TVItem tvItem { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DBLocalIM]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemDBLocalIM_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            tvItem = GetFilledRandomTVItem("");

            await DoCRUDDBLocalIMTest();
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

            var actionTVItemList = await TVItemDBLocalIMService.GetTVItemList();
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

            var actionTVItem = await TVItemDBLocalIMService.Put(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVItemID = 10000000;
            actionTVItem = await TVItemDBLocalIMService.Put(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100)]
            // tvItem.TVLevel   (Int32)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVLevel = -1;
            actionTVItem = await TVItemDBLocalIMService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);
            //Assert.AreEqual(count, tvItemService.GetTVItemList().Count());
            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVLevel = 101;
            actionTVItem = await TVItemDBLocalIMService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);
            //Assert.AreEqual(count, tvItemDBLocalIMService.GetTVItemList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // tvItem.TVPath   (String)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("TVPath");
            actionTVItem = await TVItemDBLocalIMService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVPath = GetRandomString("", 251);
            actionTVItem = await TVItemDBLocalIMService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);
            //Assert.AreEqual(count, tvItemDBLocalIMService.GetTVItemList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItem.TVType   (TVTypeEnum)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.TVType = (TVTypeEnum)1000000;
            actionTVItem = await TVItemDBLocalIMService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,HydrometricSite,Infrastructure,MikeBoundaryConditionWebTide,MikeBoundaryConditionMesh,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,MWQMRun,RainExceedance,Classification)]
            // tvItem.ParentID   (Int32)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.ParentID = 0;
            actionTVItem = await TVItemDBLocalIMService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.ParentID = 38;
            actionTVItem = await TVItemDBLocalIMService.Post(tvItem);
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
            actionTVItem = await TVItemDBLocalIMService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);
            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionTVItem = await TVItemDBLocalIMService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tvItem.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.LastUpdateContactTVItemID = 0;
            actionTVItem = await TVItemDBLocalIMService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

            tvItem = null;
            tvItem = GetFilledRandomTVItem("");
            tvItem.LastUpdateContactTVItemID = 1;
            actionTVItem = await TVItemDBLocalIMService.Post(tvItem);
            Assert.IsType<BadRequestObjectResult>(actionTVItem.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalIMTest()
        {
            tvItem.TVItemID = 10000000;

            // Post TVItem
            var actionTVItemAdded = await TVItemDBLocalIMService.Post(tvItem);
            Assert.Equal(200, ((ObjectResult)actionTVItemAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemAdded.Result).Value);
            TVItem tvItemAdded = (TVItem)((OkObjectResult)actionTVItemAdded.Result).Value;
            Assert.NotNull(tvItemAdded);

            // List<TVItem>
            var actionTVItemList = await TVItemDBLocalIMService.GetTVItemList();
            Assert.Equal(200, ((ObjectResult)actionTVItemList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemList.Result).Value);
            List<TVItem> tvItemList = (List<TVItem>)((OkObjectResult)actionTVItemList.Result).Value;

            int count = ((List<TVItem>)((OkObjectResult)actionTVItemList.Result).Value).Count();
            Assert.True(count > 0);

            // Get TVItem With TVItemID
            var actionTVItemGet = await TVItemDBLocalIMService.GetTVItemWithTVItemID(tvItemList[0].TVItemID);
            Assert.Equal(200, ((ObjectResult)actionTVItemGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemGet.Result).Value);
            TVItem tvItemGet = (TVItem)((OkObjectResult)actionTVItemGet.Result).Value;
            Assert.NotNull(tvItemGet);
            Assert.Equal(tvItemGet.TVItemID, tvItemList[0].TVItemID);

            // Put TVItem
            var actionTVItemUpdated = await TVItemDBLocalIMService.Put(tvItem);
            Assert.Equal(200, ((ObjectResult)actionTVItemUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemUpdated.Result).Value);
            TVItem tvItemUpdated = (TVItem)((OkObjectResult)actionTVItemUpdated.Result).Value;
            Assert.NotNull(tvItemUpdated);

            // Delete TVItem
            var actionTVItemDeleted = await TVItemDBLocalIMService.Delete(tvItem.TVItemID);
            Assert.Equal(200, ((ObjectResult)actionTVItemDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTVItemDeleted.Result).Value;
            Assert.True(retBool);

        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalimservicestests.json")
               .AddUserSecrets("64a6d1e4-0d0c-4e59-9c2e-640182417704")
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

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITVItemDBLocalIMService, TVItemDBLocalIMService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocalIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbLocalIM);

            TVItemDBLocalIMService = Provider.GetService<ITVItemDBLocalIMService>();
            Assert.NotNull(TVItemDBLocalIMService);

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
