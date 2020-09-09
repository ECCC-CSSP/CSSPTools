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
    public partial class TVItemStatDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ITVItemStatDBLocalIMService TVItemStatDBLocalIMService { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private TVItemStat tvItemStat { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemStatDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocalIM]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemStatDBLocalIM_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocalIM]

        #region Tests Generated [DBLocalIM] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemStatDBLocalIM_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            tvItemStat = GetFilledRandomTVItemStat("");

            await DoCRUDDBLocalIMTest();
        }
        #endregion Tests Generated [DBLocalIM] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemStat_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionTVItemStatList = await TVItemStatDBLocalIMService.GetTVItemStatList();
            Assert.Equal(200, ((ObjectResult)actionTVItemStatList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemStatList.Result).Value);
            List<TVItemStat> tvItemStatList = (List<TVItemStat>)((OkObjectResult)actionTVItemStatList.Result).Value;

            count = tvItemStatList.Count();

            TVItemStat tvItemStat = GetFilledRandomTVItemStat("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tvItemStat.TVItemStatID   (Int32)
            // -----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.TVItemStatID = 0;

            var actionTVItemStat = await TVItemStatDBLocalIMService.Put(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.TVItemStatID = 10000000;
            actionTVItemStat = await TVItemStatDBLocalIMService.Put(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint)]
            // tvItemStat.TVItemID   (Int32)
            // -----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.TVItemID = 0;
            actionTVItemStat = await TVItemStatDBLocalIMService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.TVItemID = 13;
            actionTVItemStat = await TVItemStatDBLocalIMService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemStat.TVType   (TVTypeEnum)
            // -----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.TVType = (TVTypeEnum)1000000;
            actionTVItemStat = await TVItemStatDBLocalIMService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000000)]
            // tvItemStat.ChildCount   (Int32)
            // -----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.ChildCount = -1;
            actionTVItemStat = await TVItemStatDBLocalIMService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);
            //Assert.AreEqual(count, tvItemStatService.GetTVItemStatList().Count());
            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.ChildCount = 10000001;
            actionTVItemStat = await TVItemStatDBLocalIMService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);
            //Assert.AreEqual(count, tvItemStatDBLocalIMService.GetTVItemStatList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvItemStat.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.LastUpdateDate_UTC = new DateTime();
            actionTVItemStat = await TVItemStatDBLocalIMService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);
            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionTVItemStat = await TVItemStatDBLocalIMService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tvItemStat.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.LastUpdateContactTVItemID = 0;
            actionTVItemStat = await TVItemStatDBLocalIMService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.LastUpdateContactTVItemID = 1;
            actionTVItemStat = await TVItemStatDBLocalIMService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalIMTest()
        {
            tvItemStat.TVItemStatID = 10000000;

            // Post TVItemStat
            var actionTVItemStatAdded = await TVItemStatDBLocalIMService.Post(tvItemStat);
            Assert.Equal(200, ((ObjectResult)actionTVItemStatAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemStatAdded.Result).Value);
            TVItemStat tvItemStatAdded = (TVItemStat)((OkObjectResult)actionTVItemStatAdded.Result).Value;
            Assert.NotNull(tvItemStatAdded);

            // List<TVItemStat>
            var actionTVItemStatList = await TVItemStatDBLocalIMService.GetTVItemStatList();
            Assert.Equal(200, ((ObjectResult)actionTVItemStatList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemStatList.Result).Value);
            List<TVItemStat> tvItemStatList = (List<TVItemStat>)((OkObjectResult)actionTVItemStatList.Result).Value;

            int count = ((List<TVItemStat>)((OkObjectResult)actionTVItemStatList.Result).Value).Count();
            Assert.True(count > 0);

            // Get TVItemStat With TVItemStatID
            var actionTVItemStatGet = await TVItemStatDBLocalIMService.GetTVItemStatWithTVItemStatID(tvItemStatList[0].TVItemStatID);
            Assert.Equal(200, ((ObjectResult)actionTVItemStatGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemStatGet.Result).Value);
            TVItemStat tvItemStatGet = (TVItemStat)((OkObjectResult)actionTVItemStatGet.Result).Value;
            Assert.NotNull(tvItemStatGet);
            Assert.Equal(tvItemStatGet.TVItemStatID, tvItemStatList[0].TVItemStatID);

            // Put TVItemStat
            var actionTVItemStatUpdated = await TVItemStatDBLocalIMService.Put(tvItemStat);
            Assert.Equal(200, ((ObjectResult)actionTVItemStatUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemStatUpdated.Result).Value);
            TVItemStat tvItemStatUpdated = (TVItemStat)((OkObjectResult)actionTVItemStatUpdated.Result).Value;
            Assert.NotNull(tvItemStatUpdated);

            // Delete TVItemStat
            var actionTVItemStatDeleted = await TVItemStatDBLocalIMService.Delete(tvItemStat.TVItemStatID);
            Assert.Equal(200, ((ObjectResult)actionTVItemStatDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemStatDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTVItemStatDeleted.Result).Value;
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
            Services.AddSingleton<ITVItemStatDBLocalIMService, TVItemStatDBLocalIMService>();

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

            TVItemStatDBLocalIMService = Provider.GetService<ITVItemStatDBLocalIMService>();
            Assert.NotNull(TVItemStatDBLocalIMService);

            return await Task.FromResult(true);
        }
        private TVItemStat GetFilledRandomTVItemStat(string OmitPropName)
        {
            TVItemStat tvItemStat = new TVItemStat();

            if (OmitPropName != "TVItemID") tvItemStat.TVItemID = 1;
            if (OmitPropName != "TVType") tvItemStat.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ChildCount") tvItemStat.ChildCount = GetRandomInt(0, 10000000);
            if (OmitPropName != "LastUpdateDate_UTC") tvItemStat.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemStat.LastUpdateContactTVItemID = 2;

            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 1, TVLevel = 0, TVPath = "p1", TVType = (TVTypeEnum)1, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }
            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }


            return tvItemStat;
        }
        private void CheckTVItemStatFields(List<TVItemStat> tvItemStatList)
        {
        }

        #endregion Functions private
    }
}
