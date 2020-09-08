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
    public partial class MWQMSubsectorDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IMWQMSubsectorDBLocalIMService MWQMSubsectorDBLocalIMService { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private MWQMSubsector mwqmSubsector { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DBLocalIM]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMSubsectorDBLocalIM_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            mwqmSubsector = GetFilledRandomMWQMSubsector("");

            await DoCRUDDBLocalIMTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMSubsector_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionMWQMSubsectorList = await MWQMSubsectorDBLocalIMService.GetMWQMSubsectorList();
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorList.Result).Value);
            List<MWQMSubsector> mwqmSubsectorList = (List<MWQMSubsector>)((OkObjectResult)actionMWQMSubsectorList.Result).Value;

            count = mwqmSubsectorList.Count();

            MWQMSubsector mwqmSubsector = GetFilledRandomMWQMSubsector("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mwqmSubsector.MWQMSubsectorID   (Int32)
            // -----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.MWQMSubsectorID = 0;

            var actionMWQMSubsector = await MWQMSubsectorDBLocalIMService.Put(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.MWQMSubsectorID = 10000000;
            actionMWQMSubsector = await MWQMSubsectorDBLocalIMService.Put(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
            // mwqmSubsector.MWQMSubsectorTVItemID   (Int32)
            // -----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.MWQMSubsectorTVItemID = 0;
            actionMWQMSubsector = await MWQMSubsectorDBLocalIMService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.MWQMSubsectorTVItemID = 1;
            actionMWQMSubsector = await MWQMSubsectorDBLocalIMService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(20)]
            // mwqmSubsector.SubsectorHistoricKey   (String)
            // -----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("SubsectorHistoricKey");
            actionMWQMSubsector = await MWQMSubsectorDBLocalIMService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.SubsectorHistoricKey = GetRandomString("", 21);
            actionMWQMSubsector = await MWQMSubsectorDBLocalIMService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);
            //Assert.AreEqual(count, mwqmSubsectorDBLocalIMService.GetMWQMSubsectorList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(20)]
            // mwqmSubsector.TideLocationSIDText   (String)
            // -----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.TideLocationSIDText = GetRandomString("", 21);
            actionMWQMSubsector = await MWQMSubsectorDBLocalIMService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);
            //Assert.AreEqual(count, mwqmSubsectorDBLocalIMService.GetMWQMSubsectorList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmSubsector.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.LastUpdateDate_UTC = new DateTime();
            actionMWQMSubsector = await MWQMSubsectorDBLocalIMService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);
            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMWQMSubsector = await MWQMSubsectorDBLocalIMService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mwqmSubsector.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.LastUpdateContactTVItemID = 0;
            actionMWQMSubsector = await MWQMSubsectorDBLocalIMService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);

            mwqmSubsector = null;
            mwqmSubsector = GetFilledRandomMWQMSubsector("");
            mwqmSubsector.LastUpdateContactTVItemID = 1;
            actionMWQMSubsector = await MWQMSubsectorDBLocalIMService.Post(mwqmSubsector);
            Assert.IsType<BadRequestObjectResult>(actionMWQMSubsector.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalIMTest()
        {
            mwqmSubsector.MWQMSubsectorID = 10000000;

            // Post MWQMSubsector
            var actionMWQMSubsectorAdded = await MWQMSubsectorDBLocalIMService.Post(mwqmSubsector);
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorAdded.Result).Value);
            MWQMSubsector mwqmSubsectorAdded = (MWQMSubsector)((OkObjectResult)actionMWQMSubsectorAdded.Result).Value;
            Assert.NotNull(mwqmSubsectorAdded);

            // List<MWQMSubsector>
            var actionMWQMSubsectorList = await MWQMSubsectorDBLocalIMService.GetMWQMSubsectorList();
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorList.Result).Value);
            List<MWQMSubsector> mwqmSubsectorList = (List<MWQMSubsector>)((OkObjectResult)actionMWQMSubsectorList.Result).Value;

            int count = ((List<MWQMSubsector>)((OkObjectResult)actionMWQMSubsectorList.Result).Value).Count();
            Assert.True(count > 0);

            // Get MWQMSubsector With MWQMSubsectorID
            var actionMWQMSubsectorGet = await MWQMSubsectorDBLocalIMService.GetMWQMSubsectorWithMWQMSubsectorID(mwqmSubsectorList[0].MWQMSubsectorID);
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorGet.Result).Value);
            MWQMSubsector mwqmSubsectorGet = (MWQMSubsector)((OkObjectResult)actionMWQMSubsectorGet.Result).Value;
            Assert.NotNull(mwqmSubsectorGet);
            Assert.Equal(mwqmSubsectorGet.MWQMSubsectorID, mwqmSubsectorList[0].MWQMSubsectorID);

            // Put MWQMSubsector
            var actionMWQMSubsectorUpdated = await MWQMSubsectorDBLocalIMService.Put(mwqmSubsector);
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorUpdated.Result).Value);
            MWQMSubsector mwqmSubsectorUpdated = (MWQMSubsector)((OkObjectResult)actionMWQMSubsectorUpdated.Result).Value;
            Assert.NotNull(mwqmSubsectorUpdated);

            // Delete MWQMSubsector
            var actionMWQMSubsectorDeleted = await MWQMSubsectorDBLocalIMService.Delete(mwqmSubsector.MWQMSubsectorID);
            Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMSubsectorDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMWQMSubsectorDeleted.Result).Value;
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
            Services.AddSingleton<IMWQMSubsectorDBLocalIMService, MWQMSubsectorDBLocalIMService>();

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

            MWQMSubsectorDBLocalIMService = Provider.GetService<IMWQMSubsectorDBLocalIMService>();
            Assert.NotNull(MWQMSubsectorDBLocalIMService);

            return await Task.FromResult(true);
        }
        private MWQMSubsector GetFilledRandomMWQMSubsector(string OmitPropName)
        {
            MWQMSubsector mwqmSubsector = new MWQMSubsector();

            if (OmitPropName != "MWQMSubsectorTVItemID") mwqmSubsector.MWQMSubsectorTVItemID = 11;
            if (OmitPropName != "SubsectorHistoricKey") mwqmSubsector.SubsectorHistoricKey = GetRandomString("", 5);
            if (OmitPropName != "TideLocationSIDText") mwqmSubsector.TideLocationSIDText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSubsector.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSubsector.LastUpdateContactTVItemID = 2;



            return mwqmSubsector;
        }
        private void CheckMWQMSubsectorFields(List<MWQMSubsector> mwqmSubsectorList)
        {
            Assert.False(string.IsNullOrWhiteSpace(mwqmSubsectorList[0].SubsectorHistoricKey));
            if (!string.IsNullOrWhiteSpace(mwqmSubsectorList[0].TideLocationSIDText))
            {
                Assert.False(string.IsNullOrWhiteSpace(mwqmSubsectorList[0].TideLocationSIDText));
            }
        }

        #endregion Functions private
    }
}
