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
    public partial class MikeBoundaryConditionServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMikeBoundaryConditionService MikeBoundaryConditionService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private MikeBoundaryCondition mikeBoundaryCondition { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task MikeBoundaryCondition_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");

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
            // Post MikeBoundaryCondition
            var actionMikeBoundaryConditionAdded = await MikeBoundaryConditionService.Post(mikeBoundaryCondition);
            Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionAdded.Result).Value);
            MikeBoundaryCondition mikeBoundaryConditionAdded = (MikeBoundaryCondition)((OkObjectResult)actionMikeBoundaryConditionAdded.Result).Value;
            Assert.NotNull(mikeBoundaryConditionAdded);

            // List<MikeBoundaryCondition>
            var actionMikeBoundaryConditionList = await MikeBoundaryConditionService.GetMikeBoundaryConditionList();
            Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionList.Result).Value);
            List<MikeBoundaryCondition> mikeBoundaryConditionList = (List<MikeBoundaryCondition>)((OkObjectResult)actionMikeBoundaryConditionList.Result).Value;

            int count = ((List<MikeBoundaryCondition>)((OkObjectResult)actionMikeBoundaryConditionList.Result).Value).Count();
            Assert.True(count > 0);

            // Put MikeBoundaryCondition
            var actionMikeBoundaryConditionUpdated = await MikeBoundaryConditionService.Put(mikeBoundaryCondition);
            Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionUpdated.Result).Value);
            MikeBoundaryCondition mikeBoundaryConditionUpdated = (MikeBoundaryCondition)((OkObjectResult)actionMikeBoundaryConditionUpdated.Result).Value;
            Assert.NotNull(mikeBoundaryConditionUpdated);

            // Delete MikeBoundaryCondition
            var actionMikeBoundaryConditionDeleted = await MikeBoundaryConditionService.Delete(mikeBoundaryCondition.MikeBoundaryConditionID);
            Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMikeBoundaryConditionDeleted.Result).Value;
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
            Services.AddSingleton<IMikeBoundaryConditionService, MikeBoundaryConditionService>();

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

            MikeBoundaryConditionService = Provider.GetService<IMikeBoundaryConditionService>();
            Assert.NotNull(MikeBoundaryConditionService);

            return await Task.FromResult(true);
        }
        private MikeBoundaryCondition GetFilledRandomMikeBoundaryCondition(string OmitPropName)
        {
            List<MikeBoundaryCondition> mikeBoundaryConditionListToDelete = (from c in dbLocal.MikeBoundaryConditions
                                                               select c).ToList(); 
            
            dbLocal.MikeBoundaryConditions.RemoveRange(mikeBoundaryConditionListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            MikeBoundaryCondition mikeBoundaryCondition = new MikeBoundaryCondition();

            if (OmitPropName != "MikeBoundaryConditionTVItemID") mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 52;
            if (OmitPropName != "MikeBoundaryConditionCode") mikeBoundaryCondition.MikeBoundaryConditionCode = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionName") mikeBoundaryCondition.MikeBoundaryConditionName = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionLength_m") mikeBoundaryCondition.MikeBoundaryConditionLength_m = GetRandomDouble(1.0D, 100000.0D);
            if (OmitPropName != "MikeBoundaryConditionFormat") mikeBoundaryCondition.MikeBoundaryConditionFormat = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionLevelOrVelocity") mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)GetRandomEnumType(typeof(MikeBoundaryConditionLevelOrVelocityEnum));
            if (OmitPropName != "WebTideDataSet") mikeBoundaryCondition.WebTideDataSet = (WebTideDataSetEnum)GetRandomEnumType(typeof(WebTideDataSetEnum));
            if (OmitPropName != "NumberOfWebTideNodes") mikeBoundaryCondition.NumberOfWebTideNodes = GetRandomInt(0, 1000);
            if (OmitPropName != "WebTideDataFromStartToEndDate") mikeBoundaryCondition.WebTideDataFromStartToEndDate = GetRandomString("", 20);
            if (OmitPropName != "TVType") mikeBoundaryCondition.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mikeBoundaryCondition.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeBoundaryCondition.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "MikeBoundaryConditionID") mikeBoundaryCondition.MikeBoundaryConditionID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 52, TVLevel = 5, TVPath = "p1p5p6p39p51p52", TVType = (TVTypeEnum)12, ParentID = 51, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 11, 15, 58, 29), LastUpdateContactTVItemID = 2});
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

            return mikeBoundaryCondition;
        }
        #endregion Functions private
    }
}
