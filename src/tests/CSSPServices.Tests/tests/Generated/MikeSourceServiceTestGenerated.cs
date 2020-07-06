/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp3.1\testhost.exe
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
    public partial class MikeSourceServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMikeSourceService MikeSourceService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private MikeSource mikeSource { get; set; }
        #endregion Properties

        #region Constructors
        public MikeSourceServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task MikeSource_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            mikeSource = GetFilledRandomMikeSource("");

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
            // Post MikeSource
            var actionMikeSourceAdded = await MikeSourceService.Post(mikeSource);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceAdded.Result).Value);
            MikeSource mikeSourceAdded = (MikeSource)((OkObjectResult)actionMikeSourceAdded.Result).Value;
            Assert.NotNull(mikeSourceAdded);

            // List<MikeSource>
            var actionMikeSourceList = await MikeSourceService.GetMikeSourceList();
            Assert.Equal(200, ((ObjectResult)actionMikeSourceList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceList.Result).Value);
            List<MikeSource> mikeSourceList = (List<MikeSource>)((OkObjectResult)actionMikeSourceList.Result).Value;

            int count = ((List<MikeSource>)((OkObjectResult)actionMikeSourceList.Result).Value).Count();
            Assert.True(count > 0);

            // Put MikeSource
            var actionMikeSourceUpdated = await MikeSourceService.Put(mikeSource);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceUpdated.Result).Value);
            MikeSource mikeSourceUpdated = (MikeSource)((OkObjectResult)actionMikeSourceUpdated.Result).Value;
            Assert.NotNull(mikeSourceUpdated);

            // Delete MikeSource
            var actionMikeSourceDeleted = await MikeSourceService.Delete(mikeSource.MikeSourceID);
            Assert.Equal(200, ((ObjectResult)actionMikeSourceDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeSourceDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMikeSourceDeleted.Result).Value;
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
            Services.AddSingleton<IMikeSourceService, MikeSourceService>();

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

            MikeSourceService = Provider.GetService<IMikeSourceService>();
            Assert.NotNull(MikeSourceService);

            return await Task.FromResult(true);
        }
        private MikeSource GetFilledRandomMikeSource(string OmitPropName)
        {
            List<MikeSource> mikeSourceListToDelete = (from c in dbLocal.MikeSources
                                                               select c).ToList(); 
            
            dbLocal.MikeSources.RemoveRange(mikeSourceListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            MikeSource mikeSource = new MikeSource();

            if (OmitPropName != "MikeSourceTVItemID") mikeSource.MikeSourceTVItemID = 53;
            if (OmitPropName != "IsContinuous") mikeSource.IsContinuous = true;
            if (OmitPropName != "Include") mikeSource.Include = true;
            if (OmitPropName != "IsRiver") mikeSource.IsRiver = true;
            if (OmitPropName != "UseHydrometric") mikeSource.UseHydrometric = true;
            if (OmitPropName != "HydrometricTVItemID") mikeSource.HydrometricTVItemID = 8;
            if (OmitPropName != "DrainageArea_km2") mikeSource.DrainageArea_km2 = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "Factor") mikeSource.Factor = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "SourceNumberString") mikeSource.SourceNumberString = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") mikeSource.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeSource.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "MikeSourceID") mikeSource.MikeSourceID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 53, TVLevel = 5, TVPath = "p1p5p6p39p51p53", TVType = (TVTypeEnum)14, ParentID = 51, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 21, 28, 56), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 8, TVLevel = 3, TVPath = "p1p5p6p8", TVType = (TVTypeEnum)9, ParentID = 6, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 3, 20, 45, 2), LastUpdateContactTVItemID = 2});
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

            return mikeSource;
        }
        #endregion Functions private
    }
}
