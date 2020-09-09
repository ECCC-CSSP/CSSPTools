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
using LocalServices;
using System.Threading;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class TVTypeUserAuthorizationDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ITVTypeUserAuthorizationDBLocalService TVTypeUserAuthorizationDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private TVTypeUserAuthorization tvTypeUserAuthorization { get; set; }
        #endregion Properties

        #region Constructors
        public TVTypeUserAuthorizationDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocal]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVTypeUserAuthorizationDBLocal_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocal]

        #region Tests Generated [DBLocal] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVTypeUserAuthorizationDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated [DBLocal] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVTypeUserAuthorization_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionTVTypeUserAuthorizationList = await TVTypeUserAuthorizationDBLocalService.GetTVTypeUserAuthorizationList();
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

            var actionTVTypeUserAuthorization = await TVTypeUserAuthorizationDBLocalService.Put(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.TVTypeUserAuthorizationID = 10000000;
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationDBLocalService.Put(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tvTypeUserAuthorization.ContactTVItemID   (Int32)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.ContactTVItemID = 0;
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationDBLocalService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.ContactTVItemID = 1;
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationDBLocalService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvTypeUserAuthorization.TVType   (TVTypeEnum)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.TVType = (TVTypeEnum)1000000;
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationDBLocalService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvTypeUserAuthorization.TVAuth   (TVAuthEnum)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.TVAuth = (TVAuthEnum)1000000;
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationDBLocalService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvTypeUserAuthorization.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.LastUpdateDate_UTC = new DateTime();
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationDBLocalService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);
            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationDBLocalService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tvTypeUserAuthorization.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.LastUpdateContactTVItemID = 0;
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationDBLocalService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);

            tvTypeUserAuthorization = null;
            tvTypeUserAuthorization = GetFilledRandomTVTypeUserAuthorization("");
            tvTypeUserAuthorization.LastUpdateContactTVItemID = 1;
            actionTVTypeUserAuthorization = await TVTypeUserAuthorizationDBLocalService.Post(tvTypeUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVTypeUserAuthorization.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post TVTypeUserAuthorization
            var actionTVTypeUserAuthorizationAdded = await TVTypeUserAuthorizationDBLocalService.Post(tvTypeUserAuthorization);
            Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationAdded.Result).Value);
            TVTypeUserAuthorization tvTypeUserAuthorizationAdded = (TVTypeUserAuthorization)((OkObjectResult)actionTVTypeUserAuthorizationAdded.Result).Value;
            Assert.NotNull(tvTypeUserAuthorizationAdded);

            // List<TVTypeUserAuthorization>
            var actionTVTypeUserAuthorizationList = await TVTypeUserAuthorizationDBLocalService.GetTVTypeUserAuthorizationList();
            Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationList.Result).Value);
            List<TVTypeUserAuthorization> tvTypeUserAuthorizationList = (List<TVTypeUserAuthorization>)((OkObjectResult)actionTVTypeUserAuthorizationList.Result).Value;

            int count = ((List<TVTypeUserAuthorization>)((OkObjectResult)actionTVTypeUserAuthorizationList.Result).Value).Count();
            Assert.True(count > 0);

            // Get TVTypeUserAuthorization With TVTypeUserAuthorizationID
            var actionTVTypeUserAuthorizationGet = await TVTypeUserAuthorizationDBLocalService.GetTVTypeUserAuthorizationWithTVTypeUserAuthorizationID(tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);
            Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationGet.Result).Value);
            TVTypeUserAuthorization tvTypeUserAuthorizationGet = (TVTypeUserAuthorization)((OkObjectResult)actionTVTypeUserAuthorizationGet.Result).Value;
            Assert.NotNull(tvTypeUserAuthorizationGet);
            Assert.Equal(tvTypeUserAuthorizationGet.TVTypeUserAuthorizationID, tvTypeUserAuthorizationList[0].TVTypeUserAuthorizationID);

            // Put TVTypeUserAuthorization
            var actionTVTypeUserAuthorizationUpdated = await TVTypeUserAuthorizationDBLocalService.Put(tvTypeUserAuthorization);
            Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationUpdated.Result).Value);
            TVTypeUserAuthorization tvTypeUserAuthorizationUpdated = (TVTypeUserAuthorization)((OkObjectResult)actionTVTypeUserAuthorizationUpdated.Result).Value;
            Assert.NotNull(tvTypeUserAuthorizationUpdated);

            // Delete TVTypeUserAuthorization
            var actionTVTypeUserAuthorizationDeleted = await TVTypeUserAuthorizationDBLocalService.Delete(tvTypeUserAuthorization.TVTypeUserAuthorizationID);
            Assert.Equal(200, ((ObjectResult)actionTVTypeUserAuthorizationDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVTypeUserAuthorizationDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTVTypeUserAuthorizationDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLoginFileName = Config.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ITVTypeUserAuthorizationDBLocalService, TVTypeUserAuthorizationDBLocalService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            dbLocalIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbLocalIM);

            TVTypeUserAuthorizationDBLocalService = Provider.GetService<ITVTypeUserAuthorizationDBLocalService>();
            Assert.NotNull(TVTypeUserAuthorizationDBLocalService);

            return await Task.FromResult(true);
        }
        private TVTypeUserAuthorization GetFilledRandomTVTypeUserAuthorization(string OmitPropName)
        {
            TVTypeUserAuthorization tvTypeUserAuthorization = new TVTypeUserAuthorization();

            if (OmitPropName != "ContactTVItemID") tvTypeUserAuthorization.ContactTVItemID = 2;
            if (OmitPropName != "TVType") tvTypeUserAuthorization.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "TVAuth") tvTypeUserAuthorization.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvTypeUserAuthorization.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvTypeUserAuthorization.LastUpdateContactTVItemID = 2;

            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }


            return tvTypeUserAuthorization;
        }
        private void CheckTVTypeUserAuthorizationFields(List<TVTypeUserAuthorization> tvTypeUserAuthorizationList)
        {
        }

        #endregion Functions private
    }
}
