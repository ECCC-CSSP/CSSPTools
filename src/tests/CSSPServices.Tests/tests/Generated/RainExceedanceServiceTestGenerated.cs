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
    public partial class RainExceedanceServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IRainExceedanceService RainExceedanceService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private RainExceedance rainExceedance { get; set; }
        #endregion Properties

        #region Constructors
        public RainExceedanceServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task RainExceedance_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            rainExceedance = GetFilledRandomRainExceedance("");

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
            // Post RainExceedance
            var actionRainExceedanceAdded = await RainExceedanceService.Post(rainExceedance);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceAdded.Result).Value);
            RainExceedance rainExceedanceAdded = (RainExceedance)((OkObjectResult)actionRainExceedanceAdded.Result).Value;
            Assert.NotNull(rainExceedanceAdded);

            // List<RainExceedance>
            var actionRainExceedanceList = await RainExceedanceService.GetRainExceedanceList();
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceList.Result).Value);
            List<RainExceedance> rainExceedanceList = (List<RainExceedance>)((OkObjectResult)actionRainExceedanceList.Result).Value;

            int count = ((List<RainExceedance>)((OkObjectResult)actionRainExceedanceList.Result).Value).Count();
            Assert.True(count > 0);

            // Put RainExceedance
            var actionRainExceedanceUpdated = await RainExceedanceService.Put(rainExceedance);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceUpdated.Result).Value);
            RainExceedance rainExceedanceUpdated = (RainExceedance)((OkObjectResult)actionRainExceedanceUpdated.Result).Value;
            Assert.NotNull(rainExceedanceUpdated);

            // Delete RainExceedance
            var actionRainExceedanceDeleted = await RainExceedanceService.Delete(rainExceedance.RainExceedanceID);
            Assert.Equal(200, ((ObjectResult)actionRainExceedanceDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRainExceedanceDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionRainExceedanceDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
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

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{appDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IRainExceedanceService, RainExceedanceService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            //string IsLocalStr = Config.GetValue<string>("IsLocal");
            //Assert.NotNull(IsLocalStr);

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            RainExceedanceService = Provider.GetService<IRainExceedanceService>();
            Assert.NotNull(RainExceedanceService);

            return await Task.FromResult(true);
        }
        private RainExceedance GetFilledRandomRainExceedance(string OmitPropName)
        {
            List<RainExceedance> rainExceedanceListToDelete = (from c in dbLocal.RainExceedances
                                                               select c).ToList(); 
            
            dbLocal.RainExceedances.RemoveRange(rainExceedanceListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            RainExceedance rainExceedance = new RainExceedance();

            if (OmitPropName != "RainExceedanceTVItemID") rainExceedance.RainExceedanceTVItemID = 56;
            if (OmitPropName != "StartMonth") rainExceedance.StartMonth = GetRandomInt(1, 12);
            if (OmitPropName != "StartDay") rainExceedance.StartDay = GetRandomInt(1, 31);
            if (OmitPropName != "EndMonth") rainExceedance.EndMonth = GetRandomInt(1, 12);
            if (OmitPropName != "EndDay") rainExceedance.EndDay = GetRandomInt(1, 31);
            if (OmitPropName != "RainMaximum_mm") rainExceedance.RainMaximum_mm = GetRandomDouble(0.0D, 300.0D);
            if (OmitPropName != "StakeholdersEmailDistributionListID") rainExceedance.StakeholdersEmailDistributionListID = 1;
            if (OmitPropName != "OnlyStaffEmailDistributionListID") rainExceedance.OnlyStaffEmailDistributionListID = 1;
            if (OmitPropName != "IsActive") rainExceedance.IsActive = true;
            if (OmitPropName != "LastUpdateDate_UTC") rainExceedance.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") rainExceedance.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "RainExceedanceID") rainExceedance.RainExceedanceID = 10000000;

                try
                {
                dbIM.TVItems.Add(new TVItem() { TVItemID = 56, TVLevel = 2, TVPath = "p1p5p56", TVType = (TVTypeEnum)75, ParentID = 5, IsActive = true, LastUpdateDate_UTC = new DateTime(2019, 8, 16, 14, 13, 49), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                dbIM.EmailDistributionLists.Add(new EmailDistributionList() { EmailDistributionListID = 1, ParentTVItemID = 5, Ordinal = 1, LastUpdateDate_UTC = new DateTime(2017, 6, 14, 18, 7, 57), LastUpdateContactTVItemID = 2 });
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

            return rainExceedance;
        }
        #endregion Functions private
    }
}
