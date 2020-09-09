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
    public partial class PolSourceSiteEffectTermDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IPolSourceSiteEffectTermDBLocalService PolSourceSiteEffectTermDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private PolSourceSiteEffectTerm polSourceSiteEffectTerm { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceSiteEffectTermDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DBLocal]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PolSourceSiteEffectTermDBLocal_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DBLocal]

        #region Tests Generated [DBLocal] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PolSourceSiteEffectTermDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            polSourceSiteEffectTerm = GetFilledRandomPolSourceSiteEffectTerm("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated [DBLocal] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PolSourceSiteEffectTerm_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionPolSourceSiteEffectTermList = await PolSourceSiteEffectTermDBLocalService.GetPolSourceSiteEffectTermList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTermList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTermList.Result).Value);
            List<PolSourceSiteEffectTerm> polSourceSiteEffectTermList = (List<PolSourceSiteEffectTerm>)((OkObjectResult)actionPolSourceSiteEffectTermList.Result).Value;

            count = polSourceSiteEffectTermList.Count();

            PolSourceSiteEffectTerm polSourceSiteEffectTerm = GetFilledRandomPolSourceSiteEffectTerm("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // polSourceSiteEffectTerm.PolSourceSiteEffectTermID   (Int32)
            // -----------------------------------

            polSourceSiteEffectTerm = null;
            polSourceSiteEffectTerm = GetFilledRandomPolSourceSiteEffectTerm("");
            polSourceSiteEffectTerm.PolSourceSiteEffectTermID = 0;

            var actionPolSourceSiteEffectTerm = await PolSourceSiteEffectTermDBLocalService.Put(polSourceSiteEffectTerm);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffectTerm.Result);

            polSourceSiteEffectTerm = null;
            polSourceSiteEffectTerm = GetFilledRandomPolSourceSiteEffectTerm("");
            polSourceSiteEffectTerm.PolSourceSiteEffectTermID = 10000000;
            actionPolSourceSiteEffectTerm = await PolSourceSiteEffectTermDBLocalService.Put(polSourceSiteEffectTerm);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffectTerm.Result);


            // -----------------------------------
            // Is NOT Nullable
            // polSourceSiteEffectTerm.IsGroup   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "PolSourceSiteEffectTerm", ExistPlurial = "s", ExistFieldID = "PolSourceSiteEffectTermID", AllowableTVtypeList = )]
            // polSourceSiteEffectTerm.UnderGroupID   (Int32)
            // -----------------------------------

            polSourceSiteEffectTerm = null;
            polSourceSiteEffectTerm = GetFilledRandomPolSourceSiteEffectTerm("");
            polSourceSiteEffectTerm.UnderGroupID = 0;
            actionPolSourceSiteEffectTerm = await PolSourceSiteEffectTermDBLocalService.Post(polSourceSiteEffectTerm);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffectTerm.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // polSourceSiteEffectTerm.EffectTermEN   (String)
            // -----------------------------------

            polSourceSiteEffectTerm = null;
            polSourceSiteEffectTerm = GetFilledRandomPolSourceSiteEffectTerm("EffectTermEN");
            actionPolSourceSiteEffectTerm = await PolSourceSiteEffectTermDBLocalService.Post(polSourceSiteEffectTerm);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffectTerm.Result);

            polSourceSiteEffectTerm = null;
            polSourceSiteEffectTerm = GetFilledRandomPolSourceSiteEffectTerm("");
            polSourceSiteEffectTerm.EffectTermEN = GetRandomString("", 101);
            actionPolSourceSiteEffectTerm = await PolSourceSiteEffectTermDBLocalService.Post(polSourceSiteEffectTerm);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffectTerm.Result);
            //Assert.AreEqual(count, polSourceSiteEffectTermDBLocalService.GetPolSourceSiteEffectTermList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // polSourceSiteEffectTerm.EffectTermFR   (String)
            // -----------------------------------

            polSourceSiteEffectTerm = null;
            polSourceSiteEffectTerm = GetFilledRandomPolSourceSiteEffectTerm("EffectTermFR");
            actionPolSourceSiteEffectTerm = await PolSourceSiteEffectTermDBLocalService.Post(polSourceSiteEffectTerm);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffectTerm.Result);

            polSourceSiteEffectTerm = null;
            polSourceSiteEffectTerm = GetFilledRandomPolSourceSiteEffectTerm("");
            polSourceSiteEffectTerm.EffectTermFR = GetRandomString("", 101);
            actionPolSourceSiteEffectTerm = await PolSourceSiteEffectTermDBLocalService.Post(polSourceSiteEffectTerm);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffectTerm.Result);
            //Assert.AreEqual(count, polSourceSiteEffectTermDBLocalService.GetPolSourceSiteEffectTermList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // polSourceSiteEffectTerm.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            polSourceSiteEffectTerm = null;
            polSourceSiteEffectTerm = GetFilledRandomPolSourceSiteEffectTerm("");
            polSourceSiteEffectTerm.LastUpdateDate_UTC = new DateTime();
            actionPolSourceSiteEffectTerm = await PolSourceSiteEffectTermDBLocalService.Post(polSourceSiteEffectTerm);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffectTerm.Result);
            polSourceSiteEffectTerm = null;
            polSourceSiteEffectTerm = GetFilledRandomPolSourceSiteEffectTerm("");
            polSourceSiteEffectTerm.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionPolSourceSiteEffectTerm = await PolSourceSiteEffectTermDBLocalService.Post(polSourceSiteEffectTerm);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffectTerm.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // polSourceSiteEffectTerm.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            polSourceSiteEffectTerm = null;
            polSourceSiteEffectTerm = GetFilledRandomPolSourceSiteEffectTerm("");
            polSourceSiteEffectTerm.LastUpdateContactTVItemID = 0;
            actionPolSourceSiteEffectTerm = await PolSourceSiteEffectTermDBLocalService.Post(polSourceSiteEffectTerm);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffectTerm.Result);

            polSourceSiteEffectTerm = null;
            polSourceSiteEffectTerm = GetFilledRandomPolSourceSiteEffectTerm("");
            polSourceSiteEffectTerm.LastUpdateContactTVItemID = 1;
            actionPolSourceSiteEffectTerm = await PolSourceSiteEffectTermDBLocalService.Post(polSourceSiteEffectTerm);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceSiteEffectTerm.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post PolSourceSiteEffectTerm
            var actionPolSourceSiteEffectTermAdded = await PolSourceSiteEffectTermDBLocalService.Post(polSourceSiteEffectTerm);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTermAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTermAdded.Result).Value);
            PolSourceSiteEffectTerm polSourceSiteEffectTermAdded = (PolSourceSiteEffectTerm)((OkObjectResult)actionPolSourceSiteEffectTermAdded.Result).Value;
            Assert.NotNull(polSourceSiteEffectTermAdded);

            // List<PolSourceSiteEffectTerm>
            var actionPolSourceSiteEffectTermList = await PolSourceSiteEffectTermDBLocalService.GetPolSourceSiteEffectTermList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTermList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTermList.Result).Value);
            List<PolSourceSiteEffectTerm> polSourceSiteEffectTermList = (List<PolSourceSiteEffectTerm>)((OkObjectResult)actionPolSourceSiteEffectTermList.Result).Value;

            int count = ((List<PolSourceSiteEffectTerm>)((OkObjectResult)actionPolSourceSiteEffectTermList.Result).Value).Count();
            Assert.True(count > 0);

            // Get PolSourceSiteEffectTerm With PolSourceSiteEffectTermID
            var actionPolSourceSiteEffectTermGet = await PolSourceSiteEffectTermDBLocalService.GetPolSourceSiteEffectTermWithPolSourceSiteEffectTermID(polSourceSiteEffectTermList[0].PolSourceSiteEffectTermID);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTermGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTermGet.Result).Value);
            PolSourceSiteEffectTerm polSourceSiteEffectTermGet = (PolSourceSiteEffectTerm)((OkObjectResult)actionPolSourceSiteEffectTermGet.Result).Value;
            Assert.NotNull(polSourceSiteEffectTermGet);
            Assert.Equal(polSourceSiteEffectTermGet.PolSourceSiteEffectTermID, polSourceSiteEffectTermList[0].PolSourceSiteEffectTermID);

            // Put PolSourceSiteEffectTerm
            var actionPolSourceSiteEffectTermUpdated = await PolSourceSiteEffectTermDBLocalService.Put(polSourceSiteEffectTerm);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTermUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTermUpdated.Result).Value);
            PolSourceSiteEffectTerm polSourceSiteEffectTermUpdated = (PolSourceSiteEffectTerm)((OkObjectResult)actionPolSourceSiteEffectTermUpdated.Result).Value;
            Assert.NotNull(polSourceSiteEffectTermUpdated);

            // Delete PolSourceSiteEffectTerm
            var actionPolSourceSiteEffectTermDeleted = await PolSourceSiteEffectTermDBLocalService.Delete(polSourceSiteEffectTerm.PolSourceSiteEffectTermID);
            Assert.Equal(200, ((ObjectResult)actionPolSourceSiteEffectTermDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceSiteEffectTermDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionPolSourceSiteEffectTermDeleted.Result).Value;
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
            Services.AddSingleton<IPolSourceSiteEffectTermDBLocalService, PolSourceSiteEffectTermDBLocalService>();

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

            PolSourceSiteEffectTermDBLocalService = Provider.GetService<IPolSourceSiteEffectTermDBLocalService>();
            Assert.NotNull(PolSourceSiteEffectTermDBLocalService);

            return await Task.FromResult(true);
        }
        private PolSourceSiteEffectTerm GetFilledRandomPolSourceSiteEffectTerm(string OmitPropName)
        {
            PolSourceSiteEffectTerm polSourceSiteEffectTerm = new PolSourceSiteEffectTerm();

            if (OmitPropName != "IsGroup") polSourceSiteEffectTerm.IsGroup = true;
            // Need to implement [PolSourceSiteEffectTerm UnderGroupID PolSourceSiteEffectTerm PolSourceSiteEffectTermID]
            if (OmitPropName != "EffectTermEN") polSourceSiteEffectTerm.EffectTermEN = GetRandomString("", 5);
            if (OmitPropName != "EffectTermFR") polSourceSiteEffectTerm.EffectTermFR = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceSiteEffectTerm.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceSiteEffectTerm.LastUpdateContactTVItemID = 2;

            try
            {
                dbLocalIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2 });
                dbLocalIM.SaveChanges();
            }
            catch (Exception)
            {
                // Assert.True(false, ex.Message);
            }


            return polSourceSiteEffectTerm;
        }
        private void CheckPolSourceSiteEffectTermFields(List<PolSourceSiteEffectTerm> polSourceSiteEffectTermList)
        {
            if (polSourceSiteEffectTermList[0].UnderGroupID != null)
            {
                Assert.NotNull(polSourceSiteEffectTermList[0].UnderGroupID);
            }
            Assert.False(string.IsNullOrWhiteSpace(polSourceSiteEffectTermList[0].EffectTermEN));
            Assert.False(string.IsNullOrWhiteSpace(polSourceSiteEffectTermList[0].EffectTermFR));
        }

        #endregion Functions private
    }
}
