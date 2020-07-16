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
    public partial class MikeSourceStartEndServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMikeSourceStartEndService MikeSourceStartEndService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private MikeSourceStartEnd mikeSourceStartEnd { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceStartEndServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task MikeSourceStartEnd_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            mikeSourceStartEnd = GetFilledRandomMikeSourceStartEnd("");

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
            // Post MikeSourceStartEnd
            var actionMikeSourceStartEndAdded = await MikeSourceStartEndService.Post(mikeSourceStartEnd);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndAdded.Result).Value);
            MikeSourceStartEnd mikeSourceStartEndAdded = (MikeSourceStartEnd)((OkObjectResult)actionMikeSourceStartEndAdded.Result).Value;
            Assert.NotNull(mikeSourceStartEndAdded);

            // List<MikeSourceStartEnd>
            var actionMikeSourceStartEndList = await MikeSourceStartEndService.GetMikeSourceStartEndList();
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndList.Result).Value);
            List<MikeSourceStartEnd> mikeSourceStartEndList = (List<MikeSourceStartEnd>)((OkObjectResult)actionMikeSourceStartEndList.Result).Value;

            int count = ((List<MikeSourceStartEnd>)((OkObjectResult)actionMikeSourceStartEndList.Result).Value).Count();
            Assert.True(count > 0);

            // Put MikeSourceStartEnd
            var actionMikeSourceStartEndUpdated = await MikeSourceStartEndService.Put(mikeSourceStartEnd);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndUpdated.Result).Value);
            MikeSourceStartEnd mikeSourceStartEndUpdated = (MikeSourceStartEnd)((OkObjectResult)actionMikeSourceStartEndUpdated.Result).Value;
            Assert.NotNull(mikeSourceStartEndUpdated);

            // Delete MikeSourceStartEnd
            var actionMikeSourceStartEndDeleted = await MikeSourceStartEndService.Delete(mikeSourceStartEnd.MikeSourceStartEndID);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceStartEndDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceStartEndDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMikeSourceStartEndDeleted.Result).Value;
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
            Services.AddSingleton<IMikeSourceStartEndService, MikeSourceStartEndService>();

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

            MikeSourceStartEndService = Provider.GetService<IMikeSourceStartEndService>();
            Assert.NotNull(MikeSourceStartEndService);

            return await Task.FromResult(true);
        }
        private MikeSourceStartEnd GetFilledRandomMikeSourceStartEnd(string OmitPropName)
        {
            List<MikeSourceStartEnd> mikeSourceStartEndListToDelete = (from c in dbLocal.MikeSourceStartEnds
                                                               select c).ToList(); 
            
            dbLocal.MikeSourceStartEnds.RemoveRange(mikeSourceStartEndListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            MikeSourceStartEnd mikeSourceStartEnd = new MikeSourceStartEnd();

            if (OmitPropName != "MikeSourceID") mikeSourceStartEnd.MikeSourceID = 1;
            if (OmitPropName != "StartDateAndTime_Local") mikeSourceStartEnd.StartDateAndTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateAndTime_Local") mikeSourceStartEnd.EndDateAndTime_Local = new DateTime(2005, 3, 7);
            if (OmitPropName != "SourceFlowStart_m3_day") mikeSourceStartEnd.SourceFlowStart_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourceFlowEnd_m3_day") mikeSourceStartEnd.SourceFlowEnd_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourcePollutionStart_MPN_100ml") mikeSourceStartEnd.SourcePollutionStart_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourcePollutionEnd_MPN_100ml") mikeSourceStartEnd.SourcePollutionEnd_MPN_100ml = GetRandomInt(0, 10000000);
            if (OmitPropName != "SourceTemperatureStart_C") mikeSourceStartEnd.SourceTemperatureStart_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SourceTemperatureEnd_C") mikeSourceStartEnd.SourceTemperatureEnd_C = GetRandomDouble(-10.0D, 40.0D);
            if (OmitPropName != "SourceSalinityStart_PSU") mikeSourceStartEnd.SourceSalinityStart_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "SourceSalinityEnd_PSU") mikeSourceStartEnd.SourceSalinityEnd_PSU = GetRandomDouble(0.0D, 40.0D);
            if (OmitPropName != "LastUpdateDate_UTC") mikeSourceStartEnd.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeSourceStartEnd.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "MikeSourceStartEndID") mikeSourceStartEnd.MikeSourceStartEndID = 10000000;

                try
                {
                    dbIM.MikeSources.Add(new MikeSource() { MikeSourceID = 1, MikeSourceTVItemID = 53, IsContinuous = true, Include = false, IsRiver = false, UseHydrometric = false, HydrometricTVItemID = null, DrainageArea_km2 = null, Factor = null, SourceNumberString = "SOURCE_1", LastUpdateDate_UTC = new DateTime(2014, 12, 2, 21, 28, 56), LastUpdateContactTVItemID = 2 });
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

            return mikeSourceStartEnd;
        }
        #endregion Functions private
    }
}
