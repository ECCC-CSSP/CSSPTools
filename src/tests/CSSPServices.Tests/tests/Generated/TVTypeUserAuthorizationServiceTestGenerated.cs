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
using CSSPCultureServices.Resources;

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class TVTypeUserAuthorizationServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ITVTypeUserAuthorizationService TVTypeUserAuthorizationService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private TVTypeUserAuthorization tvTypeUserAuthorization { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task TVTypeUserAuthorization_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");

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
        public async Task TVTypeUserAuthorization_Properties_Test(string culture, DBLocationEnum DBLocation)
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

            var actionTVTypeUserAuthorizationList = await TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationList();
            Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationList.Result).Value);
            List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = (List<TVTypeUserAuthorization>)((OkObjectResult)actionTVTypeUserAuthorizationList.Result).Value;

            count = tvTypeUserAuthorizationList.Count();

            TVTypeUserAuthorization tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tvTypeUserAuthorization.TVTypeUserAuthorizationID   (Int32)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.TVTypeUserAuthorizationID = 0;

            var actionTVTypeUserAuthorization = await TVTypeUserAuthorizationService.Put(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.TVTypeUserAuthorizationID = 10000000;
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationService.Put(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tvTypeUserAuthorization.ContactTVItemID   (Int32)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.ContactTVItemID = 0;
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.ContactTVItemID = 1;
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvTypeUserAuthorization.TVType   (TVTypeEnum)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.TVType = (TVTypeEnum)1000000;
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvTypeUserAuthorization.TVAuth   (TVAuthEnum)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.TVAuth = (TVAuthEnum)1000000;
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvTypeUserAuthorization.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.LastUpdateDate_UTC = new DateTime();
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);
            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tvTypeUserAuthorization.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.LastUpdateContactTVItemID = 0;
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.LastUpdateContactTVItemID = 1;
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post TVTypeUserAuthorization
            var actionTVTypeUserAuthorizationAdded = await TVTypeUserAuthorizationService.Post(tvTypeUserAuthorization);
            Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationAdded.Result).Value);
            TVTypeUserAuthorization tvTypeUserAuthorizationAdded = (TVTypeUserAuthorization)((OkObjectResult)actionTVTypeUserAuthorizationAdded.Result).Value;
            Assert.NotNull(tvTypeUserAuthorizationAdded);

            // List<TVTypeUserAuthorization>
            var actionTVTypeUserAuthorizationList = await TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationList();
            Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationList.Result).Value);
            List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = (List<TVTypeUserAuthorization>)((OkObjectResult)actionTVTypeUserAuthorizationList.Result).Value;

            int count = ((List<TVTypeUserAuthorization>)((OkObjectResult)actionTVTypeUserAuthorizationList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<TVTypeUserAuthorization> with skip and take
                var actionTVTypeUserAuthorizationListSkipAndTake = await TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationListSkipAndTake.Result).Value);
                List<TVTypeUserAuthorization> tvTypeUserAuthorizationListSkipAndTake = (List<TVTypeUserAuthorization>)((OkObjectResult)actionTVTypeUserAuthorizationListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<TVTypeUserAuthorization>)((OkObjectResult)actionTVTypeUserAuthorizationListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID == tvTypeUserAuthorizationListSkipAndTake[0].TVTypeUserAuthorizationID);
            }

            // Get TVTypeUserAuthorization With TVTypeUserAuthorizationID
            var actionTVTypeUserAuthorizationGet = await TVTypeUserAuthorizationService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
            Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationGet.Result).Value);
            TVTypeUserAuthorization tvTypeUserAuthorizationGet = (TVTypeUserAuthorization)((OkObjectResult)actionTVTypeUserAuthorizationGet.Result).Value;
            Assert.NotNull(tvTypeUserAuthorizationGet);
            Assert.Equal(tvTypeUserAuthorizationGet.TVTypeUserAuthorizationID, tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);

            // Put TVTypeUserAuthorization
            var actionTVTypeUserAuthorizationUpdated = await TVTypeUserAuthorizationService.Put(tvTypeUserAuthorization);
            Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationUpdated.Result).Value);
            TVTypeUserAuthorization tvTypeUserAuthorizationUpdated = (TVTypeUserAuthorization)((OkObjectResult)actionTVTypeUserAuthorizationUpdated.Result).Value;
            Assert.NotNull(tvTypeUserAuthorizationUpdated);

            // Delete TVTypeUserAuthorization
            var actionTVTypeUserAuthorizationDeleted = await TVTypeUserAuthorizationService.Delete(tvTypeUserAuthorization.TVTypeUserAuthorizationID);
            Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTVTypeUserAuthorizationDeleted.Result).Value;
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
            Services.AddSingleton<ITVTypeUserAuthorizationService, TVTypeUserAuthorizationService>();

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

            TVTypeUserAuthorizationService = Provider.GetService<ITVTypeUserAuthorizationService>();
            Assert.NotNull(TVTypeUserAuthorizationService);

            return await Task.FromResult(true);
        }
        private TVTypeUserAuthorization GetFilledRandomTVTypeUserAuthorization(string OmitPropName)
        {
            List<TVTypeUserAuthorization> tvTypeUserAuthorizationListToDelete = (from c in dbLocal.TVTypeUserAuthorizations
                                                               select c).ToList(); 
            
            dbLocal.TVTypeUserAuthorizations.RemoveRange(tvTypeUserAuthorizationListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            TVTypeUserAuthorization tvTypeUserAuthorization = new TVTypeUserAuthorization();

            if (OmitPropName != "ContactTVItemID") tvTypeUserAuthorization.ContactTVItemID = 2;
            if (OmitPropName != "TVType") tvTypeUserAuthorization.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVAuth") tvTypeUserAuthorization.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvTypeUserAuthorization.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvTypeUserAuthorization.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "TVTypeUserAuthorizationID") tvTypeUserAuthorization.TVTypeUserAuthorizationID = 10000000;

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

            return tvTypeUserAuthorization;
        }
        private void CheckTVTypeUserAuthorizationFields(List<TVTypeUserAuthorization> tvTypeUserAuthorizationList)
        {
        }
        #endregion Functions private
    }
}
