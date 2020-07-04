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
    public partial class MWQMLookupMPNServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IMWQMLookupMPNService MWQMLookupMPNService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private MWQMLookupMPN mwqmLookupMPN { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task MWQMLookupMPN_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");

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
            // Post MWQMLookupMPN
            var actionMWQMLookupMPNAdded = await MWQMLookupMPNService.Post(mwqmLookupMPN);
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNAdded.Result).Value);
            MWQMLookupMPN mwqmLookupMPNAdded = (MWQMLookupMPN)((OkObjectResult)actionMWQMLookupMPNAdded.Result).Value;
            Assert.NotNull(mwqmLookupMPNAdded);

            // List<MWQMLookupMPN>
            var actionMWQMLookupMPNList = await MWQMLookupMPNService.GetMWQMLookupMPNList();
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNList.Result).Value);
            List<MWQMLookupMPN> mwqmLookupMPNList = (List<MWQMLookupMPN>)((OkObjectResult)actionMWQMLookupMPNList.Result).Value;

            int count = ((List<MWQMLookupMPN>)((OkObjectResult)actionMWQMLookupMPNList.Result).Value).Count();
            Assert.True(count > 0);

            // Put MWQMLookupMPN
            var actionMWQMLookupMPNUpdated = await MWQMLookupMPNService.Put(mwqmLookupMPN);
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNUpdated.Result).Value);
            MWQMLookupMPN mwqmLookupMPNUpdated = (MWQMLookupMPN)((OkObjectResult)actionMWQMLookupMPNUpdated.Result).Value;
            Assert.NotNull(mwqmLookupMPNUpdated);

            // Delete MWQMLookupMPN
            var actionMWQMLookupMPNDeleted = await MWQMLookupMPNService.Delete(mwqmLookupMPN.MWQMLookupMPNID);
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMWQMLookupMPNDeleted.Result).Value;
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
            Services.AddSingleton<IMWQMLookupMPNService, MWQMLookupMPNService>();

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

            MWQMLookupMPNService = Provider.GetService<IMWQMLookupMPNService>();
            Assert.NotNull(MWQMLookupMPNService);

            return await Task.FromResult(true);
        }
        private MWQMLookupMPN GetFilledRandomMWQMLookupMPN(string OmitPropName)
        {
            List<MWQMLookupMPN> mwqmLookupMPNListToDelete = (from c in dbLocal.MWQMLookupMPNs
                                                               select c).ToList(); 
            
            dbLocal.MWQMLookupMPNs.RemoveRange(mwqmLookupMPNListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();

            if (OmitPropName != "Tubes10") mwqmLookupMPN.Tubes10 = GetRandomInt(2, 5);
            if (OmitPropName != "Tubes1") mwqmLookupMPN.Tubes1 = GetRandomInt(2, 5);
            if (OmitPropName != "Tubes01") mwqmLookupMPN.Tubes01 = GetRandomInt(2, 5);
            if (OmitPropName != "MPN_100ml") mwqmLookupMPN.MPN_100ml = 14;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmLookupMPN.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmLookupMPN.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "MWQMLookupMPNID") mwqmLookupMPN.MWQMLookupMPNID = 10000000;

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

            return mwqmLookupMPN;
        }
        #endregion Functions private
    }
}
