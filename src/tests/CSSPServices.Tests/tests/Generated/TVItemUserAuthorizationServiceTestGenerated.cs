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
    public partial class TVItemUserAuthorizationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITVItemUserAuthorizationService TVItemUserAuthorizationService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private TVItemUserAuthorization tvItemUserAuthorization { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task TVItemUserAuthorization_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");

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
            // Post TVItemUserAuthorization
            var actionTVItemUserAuthorizationAdded = await TVItemUserAuthorizationService.Post(tvItemUserAuthorization);
            Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorizationAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorizationAdded.Result).Value);
            TVItemUserAuthorization tvItemUserAuthorizationAdded = (TVItemUserAuthorization)((OkObjectResult)actionTVItemUserAuthorizationAdded.Result).Value;
            Assert.NotNull(tvItemUserAuthorizationAdded);

            // List<TVItemUserAuthorization>
            var actionTVItemUserAuthorizationList = await TVItemUserAuthorizationService.GetTVItemUserAuthorizationList();
            Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorizationList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorizationList.Result).Value);
            List<TVItemUserAuthorization> tvItemUserAuthorizationList = (List<TVItemUserAuthorization>)((OkObjectResult)actionTVItemUserAuthorizationList.Result).Value;

            int count = ((List<TVItemUserAuthorization>)((OkObjectResult)actionTVItemUserAuthorizationList.Result).Value).Count();
            Assert.True(count > 0);

            // Put TVItemUserAuthorization
            var actionTVItemUserAuthorizationUpdated = await TVItemUserAuthorizationService.Put(tvItemUserAuthorization);
            Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorizationUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorizationUpdated.Result).Value);
            TVItemUserAuthorization tvItemUserAuthorizationUpdated = (TVItemUserAuthorization)((OkObjectResult)actionTVItemUserAuthorizationUpdated.Result).Value;
            Assert.NotNull(tvItemUserAuthorizationUpdated);

            // Delete TVItemUserAuthorization
            var actionTVItemUserAuthorizationDeleted = await TVItemUserAuthorizationService.Delete(tvItemUserAuthorization.TVItemUserAuthorizationID);
            Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorizationDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorizationDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTVItemUserAuthorizationDeleted.Result).Value;
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
            Services.AddSingleton<ITVItemUserAuthorizationService, TVItemUserAuthorizationService>();

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

            TVItemUserAuthorizationService = Provider.GetService<ITVItemUserAuthorizationService>();
            Assert.NotNull(TVItemUserAuthorizationService);

            return await Task.FromResult(true);
        }
        private TVItemUserAuthorization GetFilledRandomTVItemUserAuthorization(string OmitPropName)
        {
            List<TVItemUserAuthorization> tvItemUserAuthorizationListToDelete = (from c in dbLocal.TVItemUserAuthorizations
                                                               select c).ToList(); 
            
            dbLocal.TVItemUserAuthorizations.RemoveRange(tvItemUserAuthorizationListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            TVItemUserAuthorization tvItemUserAuthorization = new TVItemUserAuthorization();

            if (OmitPropName != "ContactTVItemID") tvItemUserAuthorization.ContactTVItemID = 2;
            if (OmitPropName != "TVItemID1") tvItemUserAuthorization.TVItemID1 = 1;
            if (OmitPropName != "TVItemID2") tvItemUserAuthorization.TVItemID2 = 1;
            if (OmitPropName != "TVItemID3") tvItemUserAuthorization.TVItemID3 = 1;
            if (OmitPropName != "TVItemID4") tvItemUserAuthorization.TVItemID4 = 1;
            if (OmitPropName != "TVAuth") tvItemUserAuthorization.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemUserAuthorization.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemUserAuthorization.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "TVItemUserAuthorizationID") tvItemUserAuthorization.TVItemUserAuthorizationID = 10000000;

                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                    dbIM.TVItems.Add(new TVItem() { TVItemID = 1, TVLevel = 0, TVPath = "p1", TVType = (TVTypeEnum)1, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
            }

            return tvItemUserAuthorization;
        }
        #endregion Functions private
    }
}
