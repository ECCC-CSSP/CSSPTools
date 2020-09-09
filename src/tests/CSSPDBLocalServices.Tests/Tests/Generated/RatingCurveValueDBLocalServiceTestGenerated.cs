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
    public partial class RatingCurveValueDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IRatingCurveValueDBLocalService RatingCurveValueDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private RatingCurveValue ratingCurveValue { get; set; }
        #endregion Properties

        #region Constructors
        public RatingCurveValueDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocal]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RatingCurveValueDBLocal_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocal]

        #region Tests Generated [DBLocal] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RatingCurveValueDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            ratingCurveValue = GetFilledRandomRatingCurveValue("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated [DBLocal] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task RatingCurveValue_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionRatingCurveValueList = await RatingCurveValueDBLocalService.GetRatingCurveValueList();
            Assert.Equal(200, ((ObjectResult)actionRatingCurveValueList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveValueList.Result).Value);
            List<RatingCurveValue> ratingCurveValueList = (List<RatingCurveValue>)((OkObjectResult)actionRatingCurveValueList.Result).Value;

            count = ratingCurveValueList.Count();

            RatingCurveValue ratingCurveValue = GetFilledRandomRatingCurveValue("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // ratingCurveValue.RatingCurveValueID   (Int32)
            // -----------------------------------

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.RatingCurveValueID = 0;

            var actionRatingCurveValue = await RatingCurveValueDBLocalService.Put(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.RatingCurveValueID = 10000000;
            actionRatingCurveValue = await RatingCurveValueDBLocalService.Put(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "RatingCurve", ExistPlurial = "s", ExistFieldID = "RatingCurveID", AllowableTVtypeList = )]
            // ratingCurveValue.RatingCurveID   (Int32)
            // -----------------------------------

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.RatingCurveID = 0;
            actionRatingCurveValue = await RatingCurveValueDBLocalService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // ratingCurveValue.StageValue_m   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [StageValue_m]

            //CSSPError: Type not implemented [StageValue_m]

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.StageValue_m = -1.0D;
            actionRatingCurveValue = await RatingCurveValueDBLocalService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);
            //Assert.AreEqual(count, ratingCurveValueService.GetRatingCurveValueList().Count());
            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.StageValue_m = 1001.0D;
            actionRatingCurveValue = await RatingCurveValueDBLocalService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);
            //Assert.AreEqual(count, ratingCurveValueDBLocalService.GetRatingCurveValueList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000000)]
            // ratingCurveValue.DischargeValue_m3_s   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [DischargeValue_m3_s]

            //CSSPError: Type not implemented [DischargeValue_m3_s]

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.DischargeValue_m3_s = -1.0D;
            actionRatingCurveValue = await RatingCurveValueDBLocalService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);
            //Assert.AreEqual(count, ratingCurveValueService.GetRatingCurveValueList().Count());
            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.DischargeValue_m3_s = 1000001.0D;
            actionRatingCurveValue = await RatingCurveValueDBLocalService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);
            //Assert.AreEqual(count, ratingCurveValueDBLocalService.GetRatingCurveValueList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // ratingCurveValue.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.LastUpdateDate_UTC = new DateTime();
            actionRatingCurveValue = await RatingCurveValueDBLocalService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);
            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionRatingCurveValue = await RatingCurveValueDBLocalService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // ratingCurveValue.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.LastUpdateContactTVItemID = 0;
            actionRatingCurveValue = await RatingCurveValueDBLocalService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);

            ratingCurveValue = null;
            ratingCurveValue = GetFilledRandomRatingCurveValue("");
            ratingCurveValue.LastUpdateContactTVItemID = 1;
            actionRatingCurveValue = await RatingCurveValueDBLocalService.Post(ratingCurveValue);
            Assert.IsType<BadRequestObjectResult>(actionRatingCurveValue.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post RatingCurveValue
            var actionRatingCurveValueAdded = await RatingCurveValueDBLocalService.Post(ratingCurveValue);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveValueAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveValueAdded.Result).Value);
            RatingCurveValue ratingCurveValueAdded = (RatingCurveValue)((OkObjectResult)actionRatingCurveValueAdded.Result).Value;
            Assert.NotNull(ratingCurveValueAdded);

            // List<RatingCurveValue>
            var actionRatingCurveValueList = await RatingCurveValueDBLocalService.GetRatingCurveValueList();
            Assert.Equal(200, ((ObjectResult)actionRatingCurveValueList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveValueList.Result).Value);
            List<RatingCurveValue> ratingCurveValueList = (List<RatingCurveValue>)((OkObjectResult)actionRatingCurveValueList.Result).Value;

            int count = ((List<RatingCurveValue>)((OkObjectResult)actionRatingCurveValueList.Result).Value).Count();
            Assert.True(count > 0);

            // Get RatingCurveValue With RatingCurveValueID
            var actionRatingCurveValueGet = await RatingCurveValueDBLocalService.GetRatingCurveValueWithRatingCurveValueID(ratingCurveValueList[0].RatingCurveValueID);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveValueGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveValueGet.Result).Value);
            RatingCurveValue ratingCurveValueGet = (RatingCurveValue)((OkObjectResult)actionRatingCurveValueGet.Result).Value;
            Assert.NotNull(ratingCurveValueGet);
            Assert.Equal(ratingCurveValueGet.RatingCurveValueID, ratingCurveValueList[0].RatingCurveValueID);

            // Put RatingCurveValue
            var actionRatingCurveValueUpdated = await RatingCurveValueDBLocalService.Put(ratingCurveValue);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveValueUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveValueUpdated.Result).Value);
            RatingCurveValue ratingCurveValueUpdated = (RatingCurveValue)((OkObjectResult)actionRatingCurveValueUpdated.Result).Value;
            Assert.NotNull(ratingCurveValueUpdated);

            // Delete RatingCurveValue
            var actionRatingCurveValueDeleted = await RatingCurveValueDBLocalService.Delete(ratingCurveValue.RatingCurveValueID);
            Assert.Equal(200, ((ObjectResult)actionRatingCurveValueDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionRatingCurveValueDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionRatingCurveValueDeleted.Result).Value;
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
            Services.AddSingleton<IRatingCurveValueDBLocalService, RatingCurveValueDBLocalService>();

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

            RatingCurveValueDBLocalService = Provider.GetService<IRatingCurveValueDBLocalService>();
            Assert.NotNull(RatingCurveValueDBLocalService);

            return await Task.FromResult(true);
        }
        private RatingCurveValue GetFilledRandomRatingCurveValue(string OmitPropName)
        {
            RatingCurveValue ratingCurveValue = new RatingCurveValue();

            if (OmitPropName != "RatingCurveID") ratingCurveValue.RatingCurveID = 1;
            if (OmitPropName != "StageValue_m") ratingCurveValue.StageValue_m = GetRandomDouble(0.0D, 1000.0D);
            if (OmitPropName != "DischargeValue_m3_s") ratingCurveValue.DischargeValue_m3_s = GetRandomDouble(0.0D, 1000000.0D);
            if (OmitPropName != "LastUpdateDate_UTC") ratingCurveValue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") ratingCurveValue.LastUpdateContactTVItemID = 2;

            try
            {
                dbLocalIM.RatingCurves.Add(new RatingCurve() { RatingCurveID = 1, HydrometricSiteID = 1, RatingCurveNumber = "17", LastUpdateDate_UTC = new DateTime(2014, 12, 3, 20, 45, 2), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }
            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }


            return ratingCurveValue;
        }
        private void CheckRatingCurveValueFields(List<RatingCurveValue> ratingCurveValueList)
        {
        }

        #endregion Functions private
    }
}
