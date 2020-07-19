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

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class MWQMSampleServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMWQMSampleService MWQMSampleService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private MWQMSample mwqmSample { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSampleServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task MWQMSample_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            mwqmSample = GetFilledRandomMWQMSample("");

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
            // Post MWQMSample
            var actionMWQMSampleAdded = await MWQMSampleService.Post(mwqmSample);
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleAdded.Result).Value);
            MWQMSample mwqmSampleAdded = (MWQMSample)((OkObjectResult)actionMWQMSampleAdded.Result).Value;
            Assert.NotNull(mwqmSampleAdded);

            // List<MWQMSample>
            var actionMWQMSampleList = await MWQMSampleService.GetMWQMSampleList();
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleList.Result).Value);
            List<MWQMSample> mwqmSampleList = (List<MWQMSample>)((OkObjectResult)actionMWQMSampleList.Result).Value;

            int count = ((List<MWQMSample>)((OkObjectResult)actionMWQMSampleList.Result).Value).Count();
            Assert.True(count > 0);

            // Put MWQMSample
            var actionMWQMSampleUpdated = await MWQMSampleService.Put(mwqmSample);
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleUpdated.Result).Value);
            MWQMSample mwqmSampleUpdated = (MWQMSample)((OkObjectResult)actionMWQMSampleUpdated.Result).Value;
            Assert.NotNull(mwqmSampleUpdated);

            // Delete MWQMSample
            var actionMWQMSampleDeleted = await MWQMSampleService.Delete(mwqmSample.MWQMSampleID);
            Assert.Equal(200, ((ObjectResult)actionMWQMSampleDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSampleDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMWQMSampleDeleted.Result).Value;
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
            Services.AddSingleton<IMWQMSampleService, MWQMSampleService>();

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

            MWQMSampleService = Provider.GetService<IMWQMSampleService>();
            Assert.NotNull(MWQMSampleService);

            return await Task.FromResult(true);
        }
        private MWQMSample GetFilledRandomMWQMSample(string OmitPropName)
        {
            List<MWQMSample> mwqmSampleListToDelete = (from c in dbLocal.MWQMSamples
                                                               select c).ToList(); 
            
            dbLocal.MWQMSamples.RemoveRange(mwqmSampleListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            MWQMSample mwqmSample = new MWQMSample();

            if (OmitPropName != "MWQMSiteTVItemID") mwqmSample.MWQMSiteTVItemID = 44;
            if (OmitPropName != "MWQMRunTVItemID") mwqmSample.MWQMRunTVItemID = 50;
            if (OmitPropName != "SampleDateTime_Local") mwqmSample.SampleDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "TimeText") mwqmSample.TimeText = GetRandomString("", 5);
            if (OmitPropName != "Depth_m") mwqmSample.Depth_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "FecCol_MPN_100ml") mwqmSample.FecCol_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "Salinity_PPT") mwqmSample.Salinity_PPT = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "WaterTemp_C") mwqmSample.WaterTemp_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "PH") mwqmSample.PH = GetRandomDouble(0.0D, 14.0D);
            if (OmitPropName != "SampleTypesText") mwqmSample.SampleTypesText = GetRandomString("", 5);
            if (OmitPropName != "SampleType_old") mwqmSample.SampleType_old = (SampleTypeEnum)GetRandomEnumType(typeof(SampleTypeEnum));
            if (OmitPropName != "Tube_10") mwqmSample.Tube_10 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube_1_0") mwqmSample.Tube_1_0 = GetRandomInt(0, 5);
            if (OmitPropName != "Tube_0_1") mwqmSample.Tube_0_1 = GetRandomInt(0, 5);
            if (OmitPropName != "ProcessedBy") mwqmSample.ProcessedBy = GetRandomString("", 5);
            if (OmitPropName != "UseForOpenData") mwqmSample.UseForOpenData = true;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSample.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSample.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "MWQMSampleID") mwqmSample.MWQMSampleID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 44, TVLevel = 6, TVPath = "p1p5p6p9p10p12p44", TVType = (TVTypeEnum)16, ParentID = 12, IsActive = true, LastUpdateDate_UTC = new DateTime(2017, 10, 12, 17, 39, 34), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 50, TVLevel = 6, TVPath = "p1p5p6p9p10p12p50", TVType = (TVTypeEnum)31, ParentID = 12, IsActive = true, LastUpdateDate_UTC = new DateTime(2017, 6, 28, 12, 41, 23), LastUpdateContactTVItemID = 2});
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

            return mwqmSample;
        }
        #endregion Functions private
    }
}
