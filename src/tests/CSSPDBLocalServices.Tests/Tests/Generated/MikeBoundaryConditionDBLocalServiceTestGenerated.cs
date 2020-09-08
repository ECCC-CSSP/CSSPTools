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

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class MikeBoundaryConditionDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IMikeBoundaryConditionDBLocalService MikeBoundaryConditionDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private MikeBoundaryCondition mikeBoundaryCondition { get; set; }
        #endregion Properties

        #region Constructors
        public MikeBoundaryConditionDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DBLocal]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MikeBoundaryConditionDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task MikeBoundaryCondition_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionMikeBoundaryConditionList = await MikeBoundaryConditionDBLocalService.GetMikeBoundaryConditionList();
            Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionList.Result).Value);
            List<MikeBoundaryCondition> mikeBoundaryConditionList = (List<MikeBoundaryCondition>)((OkObjectResult)actionMikeBoundaryConditionList.Result).Value;

            count = mikeBoundaryConditionList.Count();

            MikeBoundaryCondition mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // mikeBoundaryCondition.MikeBoundaryConditionID   (Int32)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionID = 0;

            var actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Put(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionID = 10000000;
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Put(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = MikeBoundaryConditionMesh,MikeBoundaryConditionWebTide)]
            // mikeBoundaryCondition.MikeBoundaryConditionTVItemID   (Int32)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 0;
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 1;
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // mikeBoundaryCondition.MikeBoundaryConditionCode   (String)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("MikeBoundaryConditionCode");
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionCode = GetRandomString("", 101);
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);
            //Assert.AreEqual(count, mikeBoundaryConditionDBLocalService.GetMikeBoundaryConditionList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // mikeBoundaryCondition.MikeBoundaryConditionName   (String)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("MikeBoundaryConditionName");
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionName = GetRandomString("", 101);
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);
            //Assert.AreEqual(count, mikeBoundaryConditionDBLocalService.GetMikeBoundaryConditionList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1, 100000)]
            // mikeBoundaryCondition.MikeBoundaryConditionLength_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [MikeBoundaryConditionLength_m]

            //CSSPError: Type not implemented [MikeBoundaryConditionLength_m]

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 0.0D;
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);
            //Assert.AreEqual(count, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());
            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionLength_m = 100001.0D;
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);
            //Assert.AreEqual(count, mikeBoundaryConditionDBLocalService.GetMikeBoundaryConditionList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // mikeBoundaryCondition.MikeBoundaryConditionFormat   (String)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("MikeBoundaryConditionFormat");
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionFormat = GetRandomString("", 101);
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);
            //Assert.AreEqual(count, mikeBoundaryConditionDBLocalService.GetMikeBoundaryConditionList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity   (MikeBoundaryConditionLevelOrVelocityEnum)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)1000000;
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mikeBoundaryCondition.WebTideDataSet   (WebTideDataSetEnum)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.WebTideDataSet = (WebTideDataSetEnum)1000000;
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // mikeBoundaryCondition.NumberOfWebTideNodes   (Int32)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.NumberOfWebTideNodes = -1;
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);
            //Assert.AreEqual(count, mikeBoundaryConditionService.GetMikeBoundaryConditionList().Count());
            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.NumberOfWebTideNodes = 1001;
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);
            //Assert.AreEqual(count, mikeBoundaryConditionDBLocalService.GetMikeBoundaryConditionList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // mikeBoundaryCondition.WebTideDataFromStartToEndDate   (String)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("WebTideDataFromStartToEndDate");
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // mikeBoundaryCondition.TVType   (TVTypeEnum)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.TVType = (TVTypeEnum)1000000;
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // mikeBoundaryCondition.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.LastUpdateDate_UTC = new DateTime();
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);
            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // mikeBoundaryCondition.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.LastUpdateContactTVItemID = 0;
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);

            mikeBoundaryCondition = null;
            mikeBoundaryCondition = GetFilledRandomMikeBoundaryCondition("");
            mikeBoundaryCondition.LastUpdateContactTVItemID = 1;
            actionMikeBoundaryCondition = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.IsType<BadRequestObjectResult>(actionMikeBoundaryCondition.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post MikeBoundaryCondition
            var actionMikeBoundaryConditionAdded = await MikeBoundaryConditionDBLocalService.Post(mikeBoundaryCondition);
            Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionAdded.Result).Value);
            MikeBoundaryCondition mikeBoundaryConditionAdded = (MikeBoundaryCondition)((OkObjectResult)actionMikeBoundaryConditionAdded.Result).Value;
            Assert.NotNull(mikeBoundaryConditionAdded);

            // List<MikeBoundaryCondition>
            var actionMikeBoundaryConditionList = await MikeBoundaryConditionDBLocalService.GetMikeBoundaryConditionList();
            Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionList.Result).Value);
            List<MikeBoundaryCondition> mikeBoundaryConditionList = (List<MikeBoundaryCondition>)((OkObjectResult)actionMikeBoundaryConditionList.Result).Value;

            int count = ((List<MikeBoundaryCondition>)((OkObjectResult)actionMikeBoundaryConditionList.Result).Value).Count();
            Assert.True(count > 0);

            // List<MikeBoundaryCondition> with skip and take
            var actionMikeBoundaryConditionListSkipAndTake = await MikeBoundaryConditionDBLocalService.GetMikeBoundaryConditionList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionListSkipAndTake.Result).Value);
            List<MikeBoundaryCondition> mikeBoundaryConditionListSkipAndTake = (List<MikeBoundaryCondition>)((OkObjectResult)actionMikeBoundaryConditionListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<MikeBoundaryCondition>)((OkObjectResult)actionMikeBoundaryConditionListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(mikeBoundaryConditionList[0].MikeBoundaryConditionID == mikeBoundaryConditionListSkipAndTake[0].MikeBoundaryConditionID);

            // Get MikeBoundaryCondition With MikeBoundaryConditionID
            var actionMikeBoundaryConditionGet = await MikeBoundaryConditionDBLocalService.GetMikeBoundaryConditionWithMikeBoundaryConditionID(mikeBoundaryConditionList[0].MikeBoundaryConditionID);
            Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionGet.Result).Value);
            MikeBoundaryCondition mikeBoundaryConditionGet = (MikeBoundaryCondition)((OkObjectResult)actionMikeBoundaryConditionGet.Result).Value;
            Assert.NotNull(mikeBoundaryConditionGet);
            Assert.Equal(mikeBoundaryConditionGet.MikeBoundaryConditionID, mikeBoundaryConditionList[0].MikeBoundaryConditionID);

            // Put MikeBoundaryCondition
            var actionMikeBoundaryConditionUpdated = await MikeBoundaryConditionDBLocalService.Put(mikeBoundaryCondition);
            Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionUpdated.Result).Value);
            MikeBoundaryCondition mikeBoundaryConditionUpdated = (MikeBoundaryCondition)((OkObjectResult)actionMikeBoundaryConditionUpdated.Result).Value;
            Assert.NotNull(mikeBoundaryConditionUpdated);

            // Delete MikeBoundaryCondition
            var actionMikeBoundaryConditionDeleted = await MikeBoundaryConditionDBLocalService.Delete(mikeBoundaryCondition.MikeBoundaryConditionID);
            Assert.Equal(200, ((ObjectResult)actionMikeBoundaryConditionDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionMikeBoundaryConditionDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionMikeBoundaryConditionDeleted.Result).Value;
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

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IMikeBoundaryConditionDBLocalService, MikeBoundaryConditionDBLocalService>();

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

            MikeBoundaryConditionDBLocalService = Provider.GetService<IMikeBoundaryConditionDBLocalService>();
            Assert.NotNull(MikeBoundaryConditionDBLocalService);

            return await Task.FromResult(true);
        }
        private MikeBoundaryCondition GetFilledRandomMikeBoundaryCondition(string OmitPropName)
        {
            MikeBoundaryCondition mikeBoundaryCondition = new MikeBoundaryCondition();

            if (OmitPropName != "MikeBoundaryConditionTVItemID") mikeBoundaryCondition.MikeBoundaryConditionTVItemID = 52;
            if (OmitPropName != "MikeBoundaryConditionCode") mikeBoundaryCondition.MikeBoundaryConditionCode = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionName") mikeBoundaryCondition.MikeBoundaryConditionName = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionLength_m") mikeBoundaryCondition.MikeBoundaryConditionLength_m = GetRandomDouble(1.0D, 100000.0D);
            if (OmitPropName != "MikeBoundaryConditionFormat") mikeBoundaryCondition.MikeBoundaryConditionFormat = GetRandomString("", 5);
            if (OmitPropName != "MikeBoundaryConditionLevelOrVelocity") mikeBoundaryCondition.MikeBoundaryConditionLevelOrVelocity = (MikeBoundaryConditionLevelOrVelocityEnum)GetRandomEnumType(typeof(MikeBoundaryConditionLevelOrVelocityEnum));
            if (OmitPropName != "WebTideDataSet") mikeBoundaryCondition.WebTideDataSet = (WebTideDataSetEnum)GetRandomEnumType(typeof(WebTideDataSetEnum));
            if (OmitPropName != "NumberOfWebTideNodes") mikeBoundaryCondition.NumberOfWebTideNodes = GetRandomInt(0, 1000);
            if (OmitPropName != "WebTideDataFromStartToEndDate") mikeBoundaryCondition.WebTideDataFromStartToEndDate = GetRandomString("", 20);
            if (OmitPropName != "TVType") mikeBoundaryCondition.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mikeBoundaryCondition.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mikeBoundaryCondition.LastUpdateContactTVItemID = 2;

            try
            {
                dbLocal.TVItems.Add(new TVItem() { TVItemID = 52, TVLevel = 5, TVPath = "p1p5p6p39p51p52", TVType = (TVTypeEnum)12, ParentID = 51, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 11, 15, 58, 29), LastUpdateContactTVItemID = 2 });
                dbLocal.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }
            try
            {
                dbLocal.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocal.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }


            return mikeBoundaryCondition;
        }
        private void CheckMikeBoundaryConditionFields(List<MikeBoundaryCondition> mikeBoundaryConditionList)
        {
            Assert.False(string.IsNullOrWhiteSpace(mikeBoundaryConditionList[0].MikeBoundaryConditionCode));
            Assert.False(string.IsNullOrWhiteSpace(mikeBoundaryConditionList[0].MikeBoundaryConditionName));
            Assert.False(string.IsNullOrWhiteSpace(mikeBoundaryConditionList[0].MikeBoundaryConditionFormat));
            Assert.False(string.IsNullOrWhiteSpace(mikeBoundaryConditionList[0].WebTideDataFromStartToEndDate));
        }

        #endregion Functions private
    }
}
