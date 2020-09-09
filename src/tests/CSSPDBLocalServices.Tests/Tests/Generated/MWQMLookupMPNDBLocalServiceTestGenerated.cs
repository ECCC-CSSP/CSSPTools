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
    public partial class MWQMLookupMPNDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IMWQMLookupMPNDBLocalService MWQMLookupMPNDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private MWQMLookupMPN mwqmLookupMPN { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMLookupMPNDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocal]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMLookupMPNDBLocal_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocal]

        #region Tests Generated [DBLocal] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMLookupMPNDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated [DBLocal] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MWQMLookupMPN_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionMWQMLookupMPNList = await MWQMLookupMPNDBLocalService.GetMWQMLookupMPNList();
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNList.Result).Value);
            List<MWQMLookupMPN> mwqmLookupMPNList = (List<MWQMLookupMPN>)((OkObjectResult)actionMWQMLookupMPNList.Result).Value;

            count = mwqmLookupMPNList.Count();

            MWQMLookupMPN mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mwqmLookupMPN.MWQMLookupMPNID   (Int32)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.MWQMLookupMPNID = 0;

            var actionMWQMLookupMPN = await MWQMLookupMPNDBLocalService.Put(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.MWQMLookupMPNID = 10000000;
            actionMWQMLookupMPN = await MWQMLookupMPNDBLocalService.Put(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 5)]
            // mwqmLookupMPN.Tubes10   (Int32)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.Tubes10 = -1;
            actionMWQMLookupMPN = await MWQMLookupMPNDBLocalService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());
            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.Tubes10 = 6;
            actionMWQMLookupMPN = await MWQMLookupMPNDBLocalService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNDBLocalService.GetMWQMLookupMPNList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 5)]
            // mwqmLookupMPN.Tubes1   (Int32)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.Tubes1 = -1;
            actionMWQMLookupMPN = await MWQMLookupMPNDBLocalService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());
            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.Tubes1 = 6;
            actionMWQMLookupMPN = await MWQMLookupMPNDBLocalService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNDBLocalService.GetMWQMLookupMPNList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 5)]
            // mwqmLookupMPN.Tubes01   (Int32)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.Tubes01 = -1;
            actionMWQMLookupMPN = await MWQMLookupMPNDBLocalService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());
            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.Tubes01 = 6;
            actionMWQMLookupMPN = await MWQMLookupMPNDBLocalService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNDBLocalService.GetMWQMLookupMPNList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, 10000)]
            // mwqmLookupMPN.MPN_100ml   (Int32)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.MPN_100ml = 0;
            actionMWQMLookupMPN = await MWQMLookupMPNDBLocalService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNService.GetMWQMLookupMPNList().Count());
            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.MPN_100ml = 10001;
            actionMWQMLookupMPN = await MWQMLookupMPNDBLocalService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            //Assert.AreEqual(count, mwqmLookupMPNDBLocalService.GetMWQMLookupMPNList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mwqmLookupMPN.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.LastUpdateDate_UTC = new DateTime();
            actionMWQMLookupMPN = await MWQMLookupMPNDBLocalService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);
            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMWQMLookupMPN = await MWQMLookupMPNDBLocalService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mwqmLookupMPN.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.LastUpdateContactTVItemID = 0;
            actionMWQMLookupMPN = await MWQMLookupMPNDBLocalService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);

            mwqmLookupMPN = null;
            mwqmLookupMPN = GetFilledRandomMWQMLookupMPN("");
            mwqmLookupMPN.LastUpdateContactTVItemID = 1;
            actionMWQMLookupMPN = await MWQMLookupMPNDBLocalService.Post(mwqmLookupMPN);
            Assert.IsType<BadRequestObjectResult>(actionMWQMLookupMPN.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post MWQMLookupMPN
            var actionMWQMLookupMPNAdded = await MWQMLookupMPNDBLocalService.Post(mwqmLookupMPN);
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNAdded.Result).Value);
            MWQMLookupMPN mwqmLookupMPNAdded = (MWQMLookupMPN)((OkObjectResult)actionMWQMLookupMPNAdded.Result).Value;
            Assert.NotNull(mwqmLookupMPNAdded);

            // List<MWQMLookupMPN>
            var actionMWQMLookupMPNList = await MWQMLookupMPNDBLocalService.GetMWQMLookupMPNList();
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNList.Result).Value);
            List<MWQMLookupMPN> mwqmLookupMPNList = (List<MWQMLookupMPN>)((OkObjectResult)actionMWQMLookupMPNList.Result).Value;

            int count = ((List<MWQMLookupMPN>)((OkObjectResult)actionMWQMLookupMPNList.Result).Value).Count();
            Assert.True(count > 0);

            // Get MWQMLookupMPN With MWQMLookupMPNID
            var actionMWQMLookupMPNGet = await MWQMLookupMPNDBLocalService.GetMWQMLookupMPNWithMWQMLookupMPNID(mwqmLookupMPNList[0].MWQMLookupMPNID);
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNGet.Result).Value);
            MWQMLookupMPN mwqmLookupMPNGet = (MWQMLookupMPN)((OkObjectResult)actionMWQMLookupMPNGet.Result).Value;
            Assert.NotNull(mwqmLookupMPNGet);
            Assert.Equal(mwqmLookupMPNGet.MWQMLookupMPNID, mwqmLookupMPNList[0].MWQMLookupMPNID);

            // Put MWQMLookupMPN
            var actionMWQMLookupMPNUpdated = await MWQMLookupMPNDBLocalService.Put(mwqmLookupMPN);
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNUpdated.Result).Value);
            MWQMLookupMPN mwqmLookupMPNUpdated = (MWQMLookupMPN)((OkObjectResult)actionMWQMLookupMPNUpdated.Result).Value;
            Assert.NotNull(mwqmLookupMPNUpdated);

            // Delete MWQMLookupMPN
            var actionMWQMLookupMPNDeleted = await MWQMLookupMPNDBLocalService.Delete(mwqmLookupMPN.MWQMLookupMPNID);
            Assert.Equal(200, ((ObjectResult)actionMWQMLookupMPNDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMWQMLookupMPNDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMWQMLookupMPNDeleted.Result).Value;
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
            Services.AddSingleton<IMWQMLookupMPNDBLocalService, MWQMLookupMPNDBLocalService>();

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

            MWQMLookupMPNDBLocalService = Provider.GetService<IMWQMLookupMPNDBLocalService>();
            Assert.NotNull(MWQMLookupMPNDBLocalService);

            return await Task.FromResult(true);
        }
        private MWQMLookupMPN GetFilledRandomMWQMLookupMPN(string OmitPropName)
        {
            MWQMLookupMPN mwqmLookupMPN = new MWQMLookupMPN();

            if (OmitPropName != "Tubes10") mwqmLookupMPN.Tubes10 = GetRandomInt(2, 5);
            if (OmitPropName != "Tubes1") mwqmLookupMPN.Tubes1 = GetRandomInt(2, 5);
            if (OmitPropName != "Tubes01") mwqmLookupMPN.Tubes01 = GetRandomInt(2, 5);
            if (OmitPropName != "MPN_100ml") mwqmLookupMPN.MPN_100ml = 14;
            if (OmitPropName != "LastUpdateDate_UTC") mwqmLookupMPN.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmLookupMPN.LastUpdateContactTVItemID = 2;

            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }


            return mwqmLookupMPN;
        }
        private void CheckMWQMLookupMPNFields(List<MWQMLookupMPN> mwqmLookupMPNList)
        {
        }

        #endregion Functions private
    }
}
