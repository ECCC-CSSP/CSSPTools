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
    public partial class MWQMSiteStartEndDateServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMWQMSiteStartEndDateService MWQMSiteStartEndDateService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private MWQMSiteStartEndDate mwqmSiteStartEndDate { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteStartEndDateServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task MWQMSiteStartEndDate_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            mwqmSiteStartEndDate = GetFilledRandomMWQMSiteStartEndDate("");

            if (LoggedInService.IsLocal)
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
            // Post MWQMSiteStartEndDate
            var actionMWQMSiteStartEndDateAdded = await MWQMSiteStartEndDateService.Post(mwqmSiteStartEndDate);
            Assert.Equal(200, ((ObjectResult)actionMWQMSiteStartEndDateAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSiteStartEndDateAdded.Result).Value);
            MWQMSiteStartEndDate mwqmSiteStartEndDateAdded = (MWQMSiteStartEndDate)((OkObjectResult)actionMWQMSiteStartEndDateAdded.Result).Value;
            Assert.NotNull(mwqmSiteStartEndDateAdded);

            // List<MWQMSiteStartEndDate>
            var actionMWQMSiteStartEndDateList = await MWQMSiteStartEndDateService.GetMWQMSiteStartEndDateList();
            Assert.Equal(200, ((ObjectResult)actionMWQMSiteStartEndDateList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSiteStartEndDateList.Result).Value);
            List<MWQMSiteStartEndDate> mwqmSiteStartEndDateList = (List<MWQMSiteStartEndDate>)((OkObjectResult)actionMWQMSiteStartEndDateList.Result).Value;

            int count = ((List<MWQMSiteStartEndDate>)((OkObjectResult)actionMWQMSiteStartEndDateList.Result).Value).Count();
            Assert.True(count > 0);

            // Put MWQMSiteStartEndDate
            var actionMWQMSiteStartEndDateUpdated = await MWQMSiteStartEndDateService.Put(mwqmSiteStartEndDate);
            Assert.Equal(200, ((ObjectResult)actionMWQMSiteStartEndDateUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSiteStartEndDateUpdated.Result).Value);
            MWQMSiteStartEndDate mwqmSiteStartEndDateUpdated = (MWQMSiteStartEndDate)((OkObjectResult)actionMWQMSiteStartEndDateUpdated.Result).Value;
            Assert.NotNull(mwqmSiteStartEndDateUpdated);

            // Delete MWQMSiteStartEndDate
            var actionMWQMSiteStartEndDateDeleted = await MWQMSiteStartEndDateService.Delete(mwqmSiteStartEndDate.MWQMSiteStartEndDateID);
            Assert.Equal(200, ((ObjectResult)actionMWQMSiteStartEndDateDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSiteStartEndDateDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMWQMSiteStartEndDateDeleted.Result).Value;
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
            Services.AddSingleton<IMWQMSiteStartEndDateService, MWQMSiteStartEndDateService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.IsLocal = true;

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            MWQMSiteStartEndDateService = Provider.GetService<IMWQMSiteStartEndDateService>();
            Assert.NotNull(MWQMSiteStartEndDateService);

            return await Task.FromResult(true);
        }
        private MWQMSiteStartEndDate GetFilledRandomMWQMSiteStartEndDate(string OmitPropName)
        {
            List<MWQMSiteStartEndDate> mwqmSiteStartEndDateListToDelete = (from c in dbLocal.MWQMSiteStartEndDates
                                                               select c).ToList(); 
            
            dbLocal.MWQMSiteStartEndDates.RemoveRange(mwqmSiteStartEndDateListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            MWQMSiteStartEndDate mwqmSiteStartEndDate = new MWQMSiteStartEndDate();

            if (OmitPropName != "MWQMSiteTVItemID") mwqmSiteStartEndDate.MWQMSiteTVItemID = 44;
            if (OmitPropName != "StartDate") mwqmSiteStartEndDate.StartDate = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDate") mwqmSiteStartEndDate.EndDate = new DateTime(2005, 3, 7);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSiteStartEndDate.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSiteStartEndDate.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "MWQMSiteStartEndDateID") mwqmSiteStartEndDate.MWQMSiteStartEndDateID = 10000000;

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
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
            }

            return mwqmSiteStartEndDate;
        }
        #endregion Functions private
    }
}
