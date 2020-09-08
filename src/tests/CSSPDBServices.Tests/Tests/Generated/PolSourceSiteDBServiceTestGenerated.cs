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
using LoggedInServices;

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class PolSourceSiteDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IPolSourceSiteDBService PolSourceSiteDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private PolSourceSite polSourceSite { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DB]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PolSourceSiteDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            polSourceSite = GetFilledRandomPolSourceSite("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PolSourceSite_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionPolSourceSiteList = await PolSourceSiteDBService.GetPolSourceSiteList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteList.Result).Value);
            List<PolSourceSite> polSourceSiteList = (List<PolSourceSite>)((OkObjectResult)actionPolSourceSiteList.Result).Value;

            count = polSourceSiteList.Count();

            PolSourceSite polSourceSite = GetFilledRandomPolSourceSite("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // polSourceSite.PolSourceSiteID   (Int32)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.PolSourceSiteID = 0;

            var actionPolSourceSite = await PolSourceSiteDBService.Put(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.PolSourceSiteID = 10000000;
            actionPolSourceSite = await PolSourceSiteDBService.Put(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = PolSourceSite)]
            // polSourceSite.PolSourceSiteTVItemID   (Int32)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.PolSourceSiteTVItemID = 0;
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.PolSourceSiteTVItemID = 1;
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(50)]
            // polSourceSite.Temp_Locator_CanDelete   (String)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.Temp_Locator_CanDelete = GetRandomString("", 51);
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);
            //Assert.AreEqual(count, polSourceSiteDBService.GetPolSourceSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000)]
            // polSourceSite.Oldsiteid   (Int32)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.Oldsiteid = -1;
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);
            //Assert.AreEqual(count, polSourceSiteService.GetPolSourceSiteList().Count());
            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.Oldsiteid = 1001;
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);
            //Assert.AreEqual(count, polSourceSiteDBService.GetPolSourceSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000)]
            // polSourceSite.Site   (Int32)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.Site = -1;
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);
            //Assert.AreEqual(count, polSourceSiteService.GetPolSourceSiteList().Count());
            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.Site = 1001;
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);
            //Assert.AreEqual(count, polSourceSiteDBService.GetPolSourceSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 1000)]
            // polSourceSite.SiteID   (Int32)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.SiteID = -1;
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);
            //Assert.AreEqual(count, polSourceSiteService.GetPolSourceSiteList().Count());
            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.SiteID = 1001;
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);
            //Assert.AreEqual(count, polSourceSiteDBService.GetPolSourceSiteList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // polSourceSite.IsPointSource   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // polSourceSite.InactiveReason   (PolSourceInactiveReasonEnum)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.InactiveReason = (PolSourceInactiveReasonEnum)1000000;
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Address)]
            // polSourceSite.CivicAddressTVItemID   (Int32)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.CivicAddressTVItemID = 0;
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.CivicAddressTVItemID = 1;
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // polSourceSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.LastUpdateDate_UTC = new DateTime();
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);
            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // polSourceSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.LastUpdateContactTVItemID = 0;
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);

            polSourceSite = null;
            polSourceSite = GetFilledRandomPolSourceSite("");
            polSourceSite.LastUpdateContactTVItemID = 1;
            actionPolSourceSite = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSite.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post PolSourceSite
            var actionPolSourceSiteAdded = await PolSourceSiteDBService.Post(polSourceSite);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteAdded.Result).Value);
            PolSourceSite polSourceSiteAdded = (PolSourceSite)((OkObjectResult)actionPolSourceSiteAdded.Result).Value;
            Assert.NotNull(polSourceSiteAdded);

            // List<PolSourceSite>
            var actionPolSourceSiteList = await PolSourceSiteDBService.GetPolSourceSiteList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteList.Result).Value);
            List<PolSourceSite> polSourceSiteList = (List<PolSourceSite>)((OkObjectResult)actionPolSourceSiteList.Result).Value;

            int count = ((List<PolSourceSite>)((OkObjectResult)actionPolSourceSiteList.Result).Value).Count();
            Assert.True(count > 0);

            // List<PolSourceSite> with skip and take
            var actionPolSourceSiteListSkipAndTake = await PolSourceSiteDBService.GetPolSourceSiteList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteListSkipAndTake.Result).Value);
            List<PolSourceSite> polSourceSiteListSkipAndTake = (List<PolSourceSite>)((OkObjectResult)actionPolSourceSiteListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<PolSourceSite>)((OkObjectResult)actionPolSourceSiteListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(polSourceSiteList[0].PolSourceSiteID == polSourceSiteListSkipAndTake[0].PolSourceSiteID);

            // Get PolSourceSite With PolSourceSiteID
            var actionPolSourceSiteGet = await PolSourceSiteDBService.GetPolSourceSiteWithPolSourceSiteID(polSourceSiteList[0].PolSourceSiteID);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteGet.Result).Value);
            PolSourceSite polSourceSiteGet = (PolSourceSite)((OkObjectResult)actionPolSourceSiteGet.Result).Value;
            Assert.NotNull(polSourceSiteGet);
            Assert.Equal(polSourceSiteGet.PolSourceSiteID, polSourceSiteList[0].PolSourceSiteID);

            // Put PolSourceSite
            var actionPolSourceSiteUpdated = await PolSourceSiteDBService.Put(polSourceSite);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteUpdated.Result).Value);
            PolSourceSite polSourceSiteUpdated = (PolSourceSite)((OkObjectResult)actionPolSourceSiteUpdated.Result).Value;
            Assert.NotNull(polSourceSiteUpdated);

            // Delete PolSourceSite
            var actionPolSourceSiteDeleted = await PolSourceSiteDBService.Delete(polSourceSite.PolSourceSiteID);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionPolSourceSiteDeleted.Result).Value;
            Assert.True(retBool);

            db.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("70c662c1-a1a8-4b2c-b594-d7834bb5e6db")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IPolSourceSiteDBService, PolSourceSiteDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            PolSourceSiteDBService = Provider.GetService<IPolSourceSiteDBService>();
            Assert.NotNull(PolSourceSiteDBService);

            return await Task.FromResult(true);
        }
        private PolSourceSite GetFilledRandomPolSourceSite(string OmitPropName)
        {
            PolSourceSite polSourceSite = new PolSourceSite();

            if (OmitPropName != "PolSourceSiteTVItemID") polSourceSite.PolSourceSiteTVItemID = 47;
            if (OmitPropName != "Temp_Locator_CanDelete") polSourceSite.Temp_Locator_CanDelete = GetRandomString("", 5);
            if (OmitPropName != "Oldsiteid") polSourceSite.Oldsiteid = GetRandomInt(0, 1000);
            if (OmitPropName != "Site") polSourceSite.Site = GetRandomInt(0, 1000);
            if (OmitPropName != "SiteID") polSourceSite.SiteID = GetRandomInt(0, 1000);
            if (OmitPropName != "IsPointSource") polSourceSite.IsPointSource = true;
            if (OmitPropName != "InactiveReason") polSourceSite.InactiveReason = (PolSourceInactiveReasonEnum)GetRandomEnumType(typeof(PolSourceInactiveReasonEnum));
            if (OmitPropName != "CivicAddressTVItemID") polSourceSite.CivicAddressTVItemID = 46;
            if (OmitPropName != "LastUpdateDate_UTC") polSourceSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceSite.LastUpdateContactTVItemID = 2;



            return polSourceSite;
        }
        private void CheckPolSourceSiteFields(List<PolSourceSite> polSourceSiteList)
        {
            if (!string.IsNullOrWhiteSpace(polSourceSiteList[0].Temp_Locator_CanDelete))
            {
                Assert.False(string.IsNullOrWhiteSpace(polSourceSiteList[0].Temp_Locator_CanDelete));
            }
            if (polSourceSiteList[0].Oldsiteid != null)
            {
                Assert.NotNull(polSourceSiteList[0].Oldsiteid);
            }
            if (polSourceSiteList[0].Site != null)
            {
                Assert.NotNull(polSourceSiteList[0].Site);
            }
            if (polSourceSiteList[0].SiteID != null)
            {
                Assert.NotNull(polSourceSiteList[0].SiteID);
            }
            if (polSourceSiteList[0].InactiveReason != null)
            {
                Assert.NotNull(polSourceSiteList[0].InactiveReason);
            }
            if (polSourceSiteList[0].CivicAddressTVItemID != null)
            {
                Assert.NotNull(polSourceSiteList[0].CivicAddressTVItemID);
            }
        }

        #endregion Functions private
    }
}
