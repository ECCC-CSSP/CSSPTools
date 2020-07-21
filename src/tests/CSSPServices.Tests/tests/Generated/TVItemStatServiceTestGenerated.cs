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

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class TVItemStatServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITVItemStatService TVItemStatService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private TVItemStat tvItemStat { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemStatServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task TVItemStat_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            tvItemStat = GetFilledRandomTVItemStat("");

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
        public async Task TVItemStat_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionTVItemStatList = await TVItemStatService.GetTVItemStatList();
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

            var actionTVItemStat = await TVItemStatService.Put(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.TVItemStatID = 10000000;
            actionTVItemStat = await TVItemStatService.Put(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint)]
            // tvItemStat.TVItemID   (Int32)
            // -----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.TVItemID = 0;
            actionTVItemStat = await TVItemStatService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.TVItemID = 13;
            actionTVItemStat = await TVItemStatService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemStat.TVType   (TVTypeEnum)
            // -----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.TVType = (TVTypeEnum)1000000;
            actionTVItemStat = await TVItemStatService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 10000000)]
            // tvItemStat.ChildCount   (Int32)
            // -----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.ChildCount = -1;
            actionTVItemStat = await TVItemStatService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);
            //Assert.AreEqual(count, tvItemStatService.GetTVItemStatList().Count());
            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.ChildCount = 10000001;
            actionTVItemStat = await TVItemStatService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);
            //Assert.AreEqual(count, tvItemStatService.GetTVItemStatList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvItemStat.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.LastUpdateDate_UTC = new DateTime();
            actionTVItemStat = await TVItemStatService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);
            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionTVItemStat = await TVItemStatService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tvItemStat.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.LastUpdateContactTVItemID = 0;
            actionTVItemStat = await TVItemStatService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);

            tvItemStat = null;
            tvItemStat = GetFilledRandomTVItemStat("");
            tvItemStat.LastUpdateContactTVItemID = 1;
            actionTVItemStat = await TVItemStatService.Post(tvItemStat);
            Assert.IsType<BadRequestObjectResult>(actionTVItemStat.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post TVItemStat
            var actionTVItemStatAdded = await TVItemStatService.Post(tvItemStat);
            Assert.Equal(200, ((ObjectResult)actionTVItemStatAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemStatAdded.Result).Value);
            TVItemStat tvItemStatAdded = (TVItemStat)((OkObjectResult)actionTVItemStatAdded.Result).Value;
            Assert.NotNull(tvItemStatAdded);

            // List<TVItemStat>
            var actionTVItemStatList = await TVItemStatService.GetTVItemStatList();
            Assert.Equal(200, ((ObjectResult)actionTVItemStatList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemStatList.Result).Value);
            List<TVItemStat> tvItemStatList = (List<TVItemStat>)((OkObjectResult)actionTVItemStatList.Result).Value;

            int count = ((List<TVItemStat>)((OkObjectResult)actionTVItemStatList.Result).Value).Count();
            Assert.True(count > 0);

            // Put TVItemStat
            var actionTVItemStatUpdated = await TVItemStatService.Put(tvItemStat);
            Assert.Equal(200, ((ObjectResult)actionTVItemStatUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemStatUpdated.Result).Value);
            TVItemStat tvItemStatUpdated = (TVItemStat)((OkObjectResult)actionTVItemStatUpdated.Result).Value;
            Assert.NotNull(tvItemStatUpdated);

            // Delete TVItemStat
            var actionTVItemStatDeleted = await TVItemStatService.Delete(tvItemStat.TVItemStatID);
            Assert.Equal(200, ((ObjectResult)actionTVItemStatDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemStatDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTVItemStatDeleted.Result).Value;
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
            Services.AddSingleton<ITVItemStatService, TVItemStatService>();

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

            TVItemStatService = Provider.GetService<ITVItemStatService>();
            Assert.NotNull(TVItemStatService);

            return await Task.FromResult(true);
        }
        private TVItemStat GetFilledRandomTVItemStat(string OmitPropName)
        {
            List<TVItemStat> tvItemStatListToDelete = (from c in dbLocal.TVItemStats
                                                               select c).ToList(); 
            
            dbLocal.TVItemStats.RemoveRange(tvItemStatListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            TVItemStat tvItemStat = new TVItemStat();

            if (OmitPropName != "TVItemID") tvItemStat.TVItemID = 1;
            if (OmitPropName != "TVType") tvItemStat.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ChildCount") tvItemStat.ChildCount = GetRandomInt(0, 10000000);
            if (OmitPropName != "LastUpdateDate_UTC") tvItemStat.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemStat.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "TVItemStatID") tvItemStat.TVItemStatID = 10000000;

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

            return tvItemStat;
        }
        private void CheckTVItemStatFields(List<TVItemStat> tvItemStatList)
        {
        }
        #endregion Functions private
    }
}
