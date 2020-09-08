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

namespace CSSPDBLocalIMServices.Tests
{
    [Collection("Sequential")]
    public partial class MWQMSiteDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IMWQMSiteDBLocalIMService MWQMSiteDBLocalIMService { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private MWQMSite mwqmSite { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSiteDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DBLocalIM]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMSiteDBLocalIM_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            mwqmSite = GetFilledRandomMWQMSite("");

            await DoCRUDDBLocalIMTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMSite_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionMWQMSiteList = await MWQMSiteDBLocalIMService.GetMWQMSiteList();
            Assert.Equal(200, ((ObjectResult)actionMWQMSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSiteList.Result).Value);
            List<MWQMSite> mwqmSiteList = (List<MWQMSite>)((OkObjectResult)actionMWQMSiteList.Result).Value;

            count = mwqmSiteList.Count();

            MWQMSite mwqmSite = GetFilledRandomMWQMSite("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mwqmSite.MWQMSiteID   (Int32)
            // -----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.MWQMSiteID = 0;

            var actionMWQMSite = await MWQMSiteDBLocalIMService.Put(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.MWQMSiteID = 10000000;
            actionMWQMSite = await MWQMSiteDBLocalIMService.Put(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MWQMSite)]
            // mwqmSite.MWQMSiteTVItemID   (Int32)
            // -----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.MWQMSiteTVItemID = 0;
            actionMWQMSite = await MWQMSiteDBLocalIMService.Post(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.MWQMSiteTVItemID = 1;
            actionMWQMSite = await MWQMSiteDBLocalIMService.Post(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(8)]
            // mwqmSite.MWQMSiteNumber   (String)
            // -----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("MWQMSiteNumber");
            actionMWQMSite = await MWQMSiteDBLocalIMService.Post(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.MWQMSiteNumber = GetRandomString("", 9);
            actionMWQMSite = await MWQMSiteDBLocalIMService.Post(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);
            //Assert.AreEqual(count, mwqmSiteDBLocalIMService.GetMWQMSiteList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(200)]
            // mwqmSite.MWQMSiteDescription   (String)
            // -----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("MWQMSiteDescription");
            actionMWQMSite = await MWQMSiteDBLocalIMService.Post(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.MWQMSiteDescription = GetRandomString("", 201);
            actionMWQMSite = await MWQMSiteDBLocalIMService.Post(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);
            //Assert.AreEqual(count, mwqmSiteDBLocalIMService.GetMWQMSiteList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mwqmSite.MWQMSiteLatestClassification   (MWQMSiteLatestClassificationEnum)
            // -----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.MWQMSiteLatestClassification = (MWQMSiteLatestClassificationEnum)1000000;
            actionMWQMSite = await MWQMSiteDBLocalIMService.Post(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // mwqmSite.Ordinal   (Int32)
            // -----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.Ordinal = -1;
            actionMWQMSite = await MWQMSiteDBLocalIMService.Post(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);
            //Assert.AreEqual(count, mwqmSiteService.GetMWQMSiteList().Count());
            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.Ordinal = 1001;
            actionMWQMSite = await MWQMSiteDBLocalIMService.Post(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);
            //Assert.AreEqual(count, mwqmSiteDBLocalIMService.GetMWQMSiteList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.LastUpdateDate_UTC = new DateTime();
            actionMWQMSite = await MWQMSiteDBLocalIMService.Post(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);
            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMWQMSite = await MWQMSiteDBLocalIMService.Post(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mwqmSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.LastUpdateContactTVItemID = 0;
            actionMWQMSite = await MWQMSiteDBLocalIMService.Post(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);

            mwqmSite = null;
            mwqmSite = GetFilledRandomMWQMSite("");
            mwqmSite.LastUpdateContactTVItemID = 1;
            actionMWQMSite = await MWQMSiteDBLocalIMService.Post(mwqmSite);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSite.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalIMTest()
        {
            mwqmSite.MWQMSiteID = 10000000;

            // Post MWQMSite
            var actionMWQMSiteAdded = await MWQMSiteDBLocalIMService.Post(mwqmSite);
            Assert.Equal(200, ((ObjectResult)actionMWQMSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSiteAdded.Result).Value);
            MWQMSite mwqmSiteAdded = (MWQMSite)((OkObjectResult)actionMWQMSiteAdded.Result).Value;
            Assert.NotNull(mwqmSiteAdded);

            // List<MWQMSite>
            var actionMWQMSiteList = await MWQMSiteDBLocalIMService.GetMWQMSiteList();
            Assert.Equal(200, ((ObjectResult)actionMWQMSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSiteList.Result).Value);
            List<MWQMSite> mwqmSiteList = (List<MWQMSite>)((OkObjectResult)actionMWQMSiteList.Result).Value;

            int count = ((List<MWQMSite>)((OkObjectResult)actionMWQMSiteList.Result).Value).Count();
            Assert.True(count > 0);

            // Get MWQMSite With MWQMSiteID
            var actionMWQMSiteGet = await MWQMSiteDBLocalIMService.GetMWQMSiteWithMWQMSiteID(mwqmSiteList[0].MWQMSiteID);
            Assert.Equal(200, ((ObjectResult)actionMWQMSiteGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSiteGet.Result).Value);
            MWQMSite mwqmSiteGet = (MWQMSite)((OkObjectResult)actionMWQMSiteGet.Result).Value;
            Assert.NotNull(mwqmSiteGet);
            Assert.Equal(mwqmSiteGet.MWQMSiteID, mwqmSiteList[0].MWQMSiteID);

            // Put MWQMSite
            var actionMWQMSiteUpdated = await MWQMSiteDBLocalIMService.Put(mwqmSite);
            Assert.Equal(200, ((ObjectResult)actionMWQMSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSiteUpdated.Result).Value);
            MWQMSite mwqmSiteUpdated = (MWQMSite)((OkObjectResult)actionMWQMSiteUpdated.Result).Value;
            Assert.NotNull(mwqmSiteUpdated);

            // Delete MWQMSite
            var actionMWQMSiteDeleted = await MWQMSiteDBLocalIMService.Delete(mwqmSite.MWQMSiteID);
            Assert.Equal(200, ((ObjectResult)actionMWQMSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSiteDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMWQMSiteDeleted.Result).Value;
            Assert.True(retBool);

        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalimservicestests.json")
               .AddUserSecrets("64a6d1e4-0d0c-4e59-9c2e-640182417704")
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

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IMWQMSiteDBLocalIMService, MWQMSiteDBLocalIMService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocalIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbLocalIM);

            MWQMSiteDBLocalIMService = Provider.GetService<IMWQMSiteDBLocalIMService>();
            Assert.NotNull(MWQMSiteDBLocalIMService);

            return await Task.FromResult(true);
        }
        private MWQMSite GetFilledRandomMWQMSite(string OmitPropName)
        {
            MWQMSite mwqmSite = new MWQMSite();

            if (OmitPropName != "MWQMSiteTVItemID") mwqmSite.MWQMSiteTVItemID = 44;
            if (OmitPropName != "MWQMSiteNumber") mwqmSite.MWQMSiteNumber = GetRandomString("", 5);
            if (OmitPropName != "MWQMSiteDescription") mwqmSite.MWQMSiteDescription = GetRandomString("", 5);
            if (OmitPropName != "MWQMSiteLatestClassification") mwqmSite.MWQMSiteLatestClassification = (MWQMSiteLatestClassificationEnum)GetRandomEnumType(typeof(MWQMSiteLatestClassificationEnum));
            if (OmitPropName != "Ordinal") mwqmSite.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSite.LastUpdateContactTVItemID = 2;



            return mwqmSite;
        }
        private void CheckMWQMSiteFields(List<MWQMSite> mwqmSiteList)
        {
            Assert.False(string.IsNullOrWhiteSpace(mwqmSiteList[0].MWQMSiteNumber));
            Assert.False(string.IsNullOrWhiteSpace(mwqmSiteList[0].MWQMSiteDescription));
        }

        #endregion Functions private
    }
}
