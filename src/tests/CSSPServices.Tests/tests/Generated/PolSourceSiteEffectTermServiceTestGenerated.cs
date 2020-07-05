/* Auto generated from C:\CSSPTools\src\codegen\tests\_package\netcoreapp5.0\testhost.exe
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
    public partial class PolSourceSiteEffectTermServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IPolSourceSiteEffectTermService PolSourceSiteEffectTermService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private PolSourceSiteEffectTerm polSourceSiteEffectTerm { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task PolSourceSiteEffectTerm_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            polSourceSiteEffectTerm = GetFilledRandomPolSourceSiteEffectTerm("");

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
            // Post PolSourceSiteEffectTerm
            var actionPolSourceSiteEffectTermAdded = await PolSourceSiteEffectTermService.Post(polSourceSiteEffectTerm);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTermAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTermAdded.Result).Value);
            PolSourceSiteEffectTerm polSourceSiteEffectTermAdded = (PolSourceSiteEffectTerm)((OkObjectResult)actionPolSourceSiteEffectTermAdded.Result).Value;
            Assert.NotNull(polSourceSiteEffectTermAdded);

            // List<PolSourceSiteEffectTerm>
            var actionPolSourceSiteEffectTermList = await PolSourceSiteEffectTermService.GetPolSourceSiteEffectTermList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTermList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTermList.Result).Value);
            List<PolSourceSiteEffectTerm> polSourceSiteEffectTermList = (List<PolSourceSiteEffectTerm>)((OkObjectResult)actionPolSourceSiteEffectTermList.Result).Value;

            int count = ((List<PolSourceSiteEffectTerm>)((OkObjectResult)actionPolSourceSiteEffectTermList.Result).Value).Count();
            Assert.True(count > 0);

            // Put PolSourceSiteEffectTerm
            var actionPolSourceSiteEffectTermUpdated = await PolSourceSiteEffectTermService.Put(polSourceSiteEffectTerm);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTermUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTermUpdated.Result).Value);
            PolSourceSiteEffectTerm polSourceSiteEffectTermUpdated = (PolSourceSiteEffectTerm)((OkObjectResult)actionPolSourceSiteEffectTermUpdated.Result).Value;
            Assert.NotNull(polSourceSiteEffectTermUpdated);

            // Delete PolSourceSiteEffectTerm
            var actionPolSourceSiteEffectTermDeleted = await PolSourceSiteEffectTermService.Delete(polSourceSiteEffectTerm.PolSourceSiteEffectTermID);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTermDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTermDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionPolSourceSiteEffectTermDeleted.Result).Value;
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
            Services.AddSingleton<IPolSourceSiteEffectTermService, PolSourceSiteEffectTermService>();

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

            PolSourceSiteEffectTermService = Provider.GetService<IPolSourceSiteEffectTermService>();
            Assert.NotNull(PolSourceSiteEffectTermService);

            return await Task.FromResult(true);
        }
        private PolSourceSiteEffectTerm GetFilledRandomPolSourceSiteEffectTerm(string OmitPropName)
        {
            List<PolSourceSiteEffectTerm> polSourceSiteEffectTermListToDelete = (from c in dbLocal.PolSourceSiteEffectTerms
                                                               select c).ToList(); 
            
            dbLocal.PolSourceSiteEffectTerms.RemoveRange(polSourceSiteEffectTermListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            PolSourceSiteEffectTerm polSourceSiteEffectTerm = new PolSourceSiteEffectTerm();

            if (OmitPropName != "IsGroup") polSourceSiteEffectTerm.IsGroup = true;
            // Need to implement [PolSourceSiteEffectTerm UnderGroupID PolSourceSiteEffectTerm PolSourceSiteEffectTermID]
            if (OmitPropName != "EffectTermEN") polSourceSiteEffectTerm.EffectTermEN = GetRandomString("", 5);
            if (OmitPropName != "EffectTermFR") polSourceSiteEffectTerm.EffectTermFR = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceSiteEffectTerm.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceSiteEffectTerm.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "PolSourceSiteEffectTermID") polSourceSiteEffectTerm.PolSourceSiteEffectTermID = 10000000;

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

            return polSourceSiteEffectTerm;
        }
        #endregion Functions private
    }
}
