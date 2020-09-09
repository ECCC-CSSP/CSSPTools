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
    public partial class UseOfSiteDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IUseOfSiteDBLocalIMService UseOfSiteDBLocalIMService { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private UseOfSite useOfSite { get; set; }
        #endregion Properties

        #region Constructors
        public UseOfSiteDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocalIM]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task UseOfSiteDBLocalIM_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocalIM]

        #region Tests Generated [DBLocalIM] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task UseOfSiteDBLocalIM_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            useOfSite = GetFilledRandomUseOfSite("");

            await DoCRUDDBLocalIMTest();
        }
        #endregion Tests Generated [DBLocalIM] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task UseOfSite_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionUseOfSiteList = await UseOfSiteDBLocalIMService.GetUseOfSiteList();
            Assert.Equal(200, ((ObjectResult)actionUseOfSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionUseOfSiteList.Result).Value);
            List<UseOfSite> useOfSiteList = (List<UseOfSite>)((OkObjectResult)actionUseOfSiteList.Result).Value;

            count = useOfSiteList.Count();

            UseOfSite useOfSite = GetFilledRandomUseOfSite("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // useOfSite.UseOfSiteID   (Int32)
            // -----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.UseOfSiteID = 0;

            var actionUseOfSite = await UseOfSiteDBLocalIMService.Put(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.UseOfSiteID = 10000000;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Put(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = ClimateSite,HydrometricSite,TideSite)]
            // useOfSite.SiteTVItemID   (Int32)
            // -----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.SiteTVItemID = 0;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.SiteTVItemID = 1;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Subsector)]
            // useOfSite.SubsectorTVItemID   (Int32)
            // -----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.SubsectorTVItemID = 0;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.SubsectorTVItemID = 1;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // useOfSite.TVType   (TVTypeEnum)
            // -----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.TVType = (TVTypeEnum)1000000;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // useOfSite.Ordinal   (Int32)
            // -----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.Ordinal = -1;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.Ordinal = 1001;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteDBLocalIMService.GetUseOfSiteList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(1980, 2050)]
            // useOfSite.StartYear   (Int32)
            // -----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.StartYear = 1979;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.StartYear = 2051;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteDBLocalIMService.GetUseOfSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(1980, 2050)]
            // useOfSite.EndYear   (Int32)
            // -----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.EndYear = 1979;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.EndYear = 2051;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteDBLocalIMService.GetUseOfSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // useOfSite.UseWeight   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 100)]
            // useOfSite.Weight_perc   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Weight_perc]

            //CSSPError: Type not implemented [Weight_perc]

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.Weight_perc = -1.0D;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.Weight_perc = 101.0D;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteDBLocalIMService.GetUseOfSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // useOfSite.UseEquation   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 100)]
            // useOfSite.Param1   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Param1]

            //CSSPError: Type not implemented [Param1]

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.Param1 = -1.0D;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.Param1 = 101.0D;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteDBLocalIMService.GetUseOfSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 100)]
            // useOfSite.Param2   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Param2]

            //CSSPError: Type not implemented [Param2]

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.Param2 = -1.0D;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.Param2 = 101.0D;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteDBLocalIMService.GetUseOfSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 100)]
            // useOfSite.Param3   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Param3]

            //CSSPError: Type not implemented [Param3]

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.Param3 = -1.0D;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.Param3 = 101.0D;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteDBLocalIMService.GetUseOfSiteList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPRange(0, 100)]
            // useOfSite.Param4   (Double)
            // -----------------------------------

            //CSSPError: Type not implemented [Param4]

            //CSSPError: Type not implemented [Param4]

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.Param4 = -1.0D;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteService.GetUseOfSiteList().Count());
            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.Param4 = 101.0D;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            //Assert.AreEqual(count, useOfSiteDBLocalIMService.GetUseOfSiteList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // useOfSite.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.LastUpdateDate_UTC = new DateTime();
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);
            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // useOfSite.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.LastUpdateContactTVItemID = 0;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);

            useOfSite = null;
            useOfSite = GetFilledRandomUseOfSite("");
            useOfSite.LastUpdateContactTVItemID = 1;
            actionUseOfSite = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.IsType<BadRequestObjectResult>(actionUseOfSite.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalIMTest()
        {
            useOfSite.UseOfSiteID = 10000000;

            // Post UseOfSite
            var actionUseOfSiteAdded = await UseOfSiteDBLocalIMService.Post(useOfSite);
            Assert.Equal(200, ((ObjectResult)actionUseOfSiteAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionUseOfSiteAdded.Result).Value);
            UseOfSite useOfSiteAdded = (UseOfSite)((OkObjectResult)actionUseOfSiteAdded.Result).Value;
            Assert.NotNull(useOfSiteAdded);

            // List<UseOfSite>
            var actionUseOfSiteList = await UseOfSiteDBLocalIMService.GetUseOfSiteList();
            Assert.Equal(200, ((ObjectResult)actionUseOfSiteList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionUseOfSiteList.Result).Value);
            List<UseOfSite> useOfSiteList = (List<UseOfSite>)((OkObjectResult)actionUseOfSiteList.Result).Value;

            int count = ((List<UseOfSite>)((OkObjectResult)actionUseOfSiteList.Result).Value).Count();
            Assert.True(count > 0);

            // Get UseOfSite With UseOfSiteID
            var actionUseOfSiteGet = await UseOfSiteDBLocalIMService.GetUseOfSiteWithUseOfSiteID(useOfSiteList[0].UseOfSiteID);
            Assert.Equal(200, ((ObjectResult)actionUseOfSiteGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionUseOfSiteGet.Result).Value);
            UseOfSite useOfSiteGet = (UseOfSite)((OkObjectResult)actionUseOfSiteGet.Result).Value;
            Assert.NotNull(useOfSiteGet);
            Assert.Equal(useOfSiteGet.UseOfSiteID, useOfSiteList[0].UseOfSiteID);

            // Put UseOfSite
            var actionUseOfSiteUpdated = await UseOfSiteDBLocalIMService.Put(useOfSite);
            Assert.Equal(200, ((ObjectResult)actionUseOfSiteUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionUseOfSiteUpdated.Result).Value);
            UseOfSite useOfSiteUpdated = (UseOfSite)((OkObjectResult)actionUseOfSiteUpdated.Result).Value;
            Assert.NotNull(useOfSiteUpdated);

            // Delete UseOfSite
            var actionUseOfSiteDeleted = await UseOfSiteDBLocalIMService.Delete(useOfSite.UseOfSiteID);
            Assert.Equal(200, ((ObjectResult)actionUseOfSiteDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionUseOfSiteDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionUseOfSiteDeleted.Result).Value;
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
            Services.AddSingleton<IUseOfSiteDBLocalIMService, UseOfSiteDBLocalIMService>();

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

            UseOfSiteDBLocalIMService = Provider.GetService<IUseOfSiteDBLocalIMService>();
            Assert.NotNull(UseOfSiteDBLocalIMService);

            return await Task.FromResult(true);
        }
        private UseOfSite GetFilledRandomUseOfSite(string OmitPropName)
        {
            UseOfSite useOfSite = new UseOfSite();

            if (OmitPropName != "SiteTVItemID") useOfSite.SiteTVItemID = 7;
            if (OmitPropName != "SubsectorTVItemID") useOfSite.SubsectorTVItemID = 11;
            if (OmitPropName != "TVType") useOfSite.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "Ordinal") useOfSite.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "StartYear") useOfSite.StartYear = GetRandomInt(1980, 2050);
            if (OmitPropName != "EndYear") useOfSite.EndYear = GetRandomInt(1980, 2050);
            if (OmitPropName != "UseWeight") useOfSite.UseWeight = true;
            if (OmitPropName != "Weight_perc") useOfSite.Weight_perc = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "UseEquation") useOfSite.UseEquation = true;
            if (OmitPropName != "Param1") useOfSite.Param1 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param2") useOfSite.Param2 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param3") useOfSite.Param3 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "Param4") useOfSite.Param4 = GetRandomDouble(0.0D, 100.0D);
            if (OmitPropName != "LastUpdateDate_UTC") useOfSite.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") useOfSite.LastUpdateContactTVItemID = 2;

            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 7, TVLevel = 3, TVPath = "p1p5p6p7", TVType = (TVTypeEnum)4, ParentID = 6, IsActive = true, LastUpdateDate_UTC = new DateTime(2015, 6, 18, 14, 40, 7), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }
            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 11, TVLevel = 5, TVPath = "p1p5p6p9p10p11", TVType = (TVTypeEnum)20, ParentID = 10, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 18, 53, 40), LastUpdateContactTVItemID = 2 });
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


            return useOfSite;
        }
        private void CheckUseOfSiteFields(List<UseOfSite> useOfSiteList)
        {
            if (useOfSiteList[0].EndYear != null)
            {
                Assert.NotNull(useOfSiteList[0].EndYear);
            }
            if (useOfSiteList[0].UseWeight != null)
            {
                Assert.NotNull(useOfSiteList[0].UseWeight);
            }
            if (useOfSiteList[0].Weight_perc != null)
            {
                Assert.NotNull(useOfSiteList[0].Weight_perc);
            }
            if (useOfSiteList[0].UseEquation != null)
            {
                Assert.NotNull(useOfSiteList[0].UseEquation);
            }
            if (useOfSiteList[0].Param1 != null)
            {
                Assert.NotNull(useOfSiteList[0].Param1);
            }
            if (useOfSiteList[0].Param2 != null)
            {
                Assert.NotNull(useOfSiteList[0].Param2);
            }
            if (useOfSiteList[0].Param3 != null)
            {
                Assert.NotNull(useOfSiteList[0].Param3);
            }
            if (useOfSiteList[0].Param4 != null)
            {
                Assert.NotNull(useOfSiteList[0].Param4);
            }
        }

        #endregion Functions private
    }
}
