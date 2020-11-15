/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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
using CSSPDBModels;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class LocalSpillDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalSpillDBService LocalSpillDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalSpill localSpill { get; set; }
        #endregion Properties

        #region Constructors
        public LocalSpillDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalSpillDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalSpillDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localSpill = GetFilledRandomLocalSpill("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalSpill_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalSpillList = await LocalSpillDBService.GetLocalSpillList();
            Assert.Equal(200, ((ObjectResult)actionLocalSpillList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalSpillList.Result).Value);
            List<LocalSpill> localSpillList = (List<LocalSpill>)((OkObjectResult)actionLocalSpillList.Result).Value;

            count = localSpillList.Count();

            LocalSpill localSpill = GetFilledRandomLocalSpill("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localSpill.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalSpill = await LocalSpillDBService.Post(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localSpill.SpillID   (Int32)
            // -----------------------------------

            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.SpillID = 0;

            actionLocalSpill = await LocalSpillDBService.Put(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);

            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.SpillID = 10000000;
            actionLocalSpill = await LocalSpillDBService.Put(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Municipality)]
            // localSpill.MunicipalityTVItemID   (Int32)
            // -----------------------------------

            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.MunicipalityTVItemID = 0;
            actionLocalSpill = await LocalSpillDBService.Post(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);

            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.MunicipalityTVItemID = 1;
            actionLocalSpill = await LocalSpillDBService.Post(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Infrastructure)]
            // localSpill.InfrastructureTVItemID   (Int32)
            // -----------------------------------

            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.InfrastructureTVItemID = 0;
            actionLocalSpill = await LocalSpillDBService.Post(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);

            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.InfrastructureTVItemID = 1;
            actionLocalSpill = await LocalSpillDBService.Post(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localSpill.StartDateTime_Local   (DateTime)
            // -----------------------------------

            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.StartDateTime_Local = new DateTime();
            actionLocalSpill = await LocalSpillDBService.Post(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);
            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.StartDateTime_Local = new DateTime(1979, 1, 1);
            actionLocalSpill = await LocalSpillDBService.Post(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);

            // -----------------------------------
            // Is Nullable
            // [CSSPAfter(Year = 1980)]
            // [CSSPBigger(OtherField = StartDateTime_Local)]
            // localSpill.EndDateTime_Local   (DateTime)
            // -----------------------------------

            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.EndDateTime_Local = new DateTime(1979, 1, 1);
            actionLocalSpill = await LocalSpillDBService.Post(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000000)]
            // localSpill.AverageFlow_m3_day   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [AverageFlow_m3_day]

            //CSSPError: Type not implemented [AverageFlow_m3_day]

            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.AverageFlow_m3_day = -1.0D;
            actionLocalSpill = await LocalSpillDBService.Post(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);
            //Assert.AreEqual(count, localSpillService.GetLocalSpillList().Count());
            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.AverageFlow_m3_day = 1000001.0D;
            actionLocalSpill = await LocalSpillDBService.Post(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);
            //Assert.AreEqual(count, localSpillDBService.GetLocalSpillList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localSpill.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.LastUpdateDate_UTC = new DateTime();
            actionLocalSpill = await LocalSpillDBService.Post(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);
            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalSpill = await LocalSpillDBService.Post(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localSpill.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.LastUpdateContactTVItemID = 0;
            actionLocalSpill = await LocalSpillDBService.Post(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);

            localSpill = null;
            localSpill = GetFilledRandomLocalSpill("");
            localSpill.LastUpdateContactTVItemID = 1;
            actionLocalSpill = await LocalSpillDBService.Post(localSpill);
            Assert.IsType<BadRequestObjectResult>(actionLocalSpill.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalSpill
            var actionLocalSpillAdded = await LocalSpillDBService.Post(localSpill);
            Assert.Equal(200, ((ObjectResult)actionLocalSpillAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalSpillAdded.Result).Value);
            LocalSpill localSpillAdded = (LocalSpill)((OkObjectResult)actionLocalSpillAdded.Result).Value;
            Assert.NotNull(localSpillAdded);

            // List<LocalSpill>
            var actionLocalSpillList = await LocalSpillDBService.GetLocalSpillList();
            Assert.Equal(200, ((ObjectResult)actionLocalSpillList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalSpillList.Result).Value);
            List<LocalSpill> localSpillList = (List<LocalSpill>)((OkObjectResult)actionLocalSpillList.Result).Value;

            int count = ((List<LocalSpill>)((OkObjectResult)actionLocalSpillList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalSpill> with skip and take
            var actionLocalSpillListSkipAndTake = await LocalSpillDBService.GetLocalSpillList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalSpillListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalSpillListSkipAndTake.Result).Value);
            List<LocalSpill> localSpillListSkipAndTake = (List<LocalSpill>)((OkObjectResult)actionLocalSpillListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalSpill>)((OkObjectResult)actionLocalSpillListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localSpillList[0].SpillID == localSpillListSkipAndTake[0].SpillID);

            // Get LocalSpill With SpillID
            var actionLocalSpillGet = await LocalSpillDBService.GetLocalSpillWithSpillID(localSpillList[0].SpillID);
            Assert.Equal(200, ((ObjectResult)actionLocalSpillGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalSpillGet.Result).Value);
            LocalSpill localSpillGet = (LocalSpill)((OkObjectResult)actionLocalSpillGet.Result).Value;
            Assert.NotNull(localSpillGet);
            Assert.Equal(localSpillGet.SpillID, localSpillList[0].SpillID);

            // Put LocalSpill
            var actionLocalSpillUpdated = await LocalSpillDBService.Put(localSpill);
            Assert.Equal(200, ((ObjectResult)actionLocalSpillUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalSpillUpdated.Result).Value);
            LocalSpill localSpillUpdated = (LocalSpill)((OkObjectResult)actionLocalSpillUpdated.Result).Value;
            Assert.NotNull(localSpillUpdated);

            // Delete LocalSpill
            var actionLocalSpillDeleted = await LocalSpillDBService.Delete(localSpill.SpillID);
            Assert.Equal(200, ((ObjectResult)actionLocalSpillDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalSpillDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalSpillDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            /* ---------------------------------------------------------------------------------
             * using CSSPDBLocalContext
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocal = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILocalSpillDBService, LocalSpillDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            LocalSpillDBService = Provider.GetService<ILocalSpillDBService>();
            Assert.NotNull(LocalSpillDBService);

            return await Task.FromResult(true);
        }
        private LocalSpill GetFilledRandomLocalSpill(string OmitPropName)
        {
            LocalSpill localSpill = new LocalSpill();

            if (OmitPropName != "LocalDBCommand") localSpill.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "MunicipalityTVItemID") localSpill.MunicipalityTVItemID = 39;
            if (OmitPropName != "InfrastructureTVItemID") localSpill.InfrastructureTVItemID = 41;
            if (OmitPropName != "StartDateTime_Local") localSpill.StartDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "EndDateTime_Local") localSpill.EndDateTime_Local = new DateTime(2005, 3, 6);
            if (OmitPropName != "AverageFlow_m3_day") localSpill.AverageFlow_m3_day = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") localSpill.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localSpill.LastUpdateContactTVItemID = 2;



            return localSpill;
        }
        private void CheckLocalSpillFields(List<LocalSpill> localSpillList)
        {
            if (localSpillList[0].InfrastructureTVItemID != null)
            {
                Assert.NotNull(localSpillList[0].InfrastructureTVItemID);
            }
            if (localSpillList[0].EndDateTime_Local != null)
            {
                Assert.NotNull(localSpillList[0].EndDateTime_Local);
            }
        }

        #endregion Functions private
    }
}