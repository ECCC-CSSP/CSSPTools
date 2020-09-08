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
    public partial class PolSourceObservationIssueDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IPolSourceObservationIssueDBLocalService PolSourceObservationIssueDBLocalService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private PolSourceObservationIssue polSourceObservationIssue { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceObservationIssueDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DBLocal]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PolSourceObservationIssueDBLocal_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");

            await DoCRUDDBLocalTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task PolSourceObservationIssue_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionPolSourceObservationIssueList = await PolSourceObservationIssueDBLocalService.GetPolSourceObservationIssueList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueList.Result).Value);
            List<PolSourceObservationIssue> polSourceObservationIssueList = (List<PolSourceObservationIssue>)((OkObjectResult)actionPolSourceObservationIssueList.Result).Value;

            count = polSourceObservationIssueList.Count();

            PolSourceObservationIssue polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // polSourceObservationIssue.PolSourceObservationIssueID   (Int32)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.PolSourceObservationIssueID = 0;

            var actionPolSourceObservationIssue = await PolSourceObservationIssueDBLocalService.Put(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.PolSourceObservationIssueID = 10000000;
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBLocalService.Put(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "PolSourceObservation", ExistPlurial = "s", ExistFieldID = "PolSourceObservationID", AllowableTVtypeList = )]
            // polSourceObservationIssue.PolSourceObservationID   (Int32)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.PolSourceObservationID = 0;
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBLocalService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // polSourceObservationIssue.ObservationInfo   (String)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("ObservationInfo");
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBLocalService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.ObservationInfo = GetRandomString("", 251);
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBLocalService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);
            //Assert.AreEqual(count, polSourceObservationIssueDBLocalService.GetPolSourceObservationIssueList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // polSourceObservationIssue.Ordinal   (Int32)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.Ordinal = -1;
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBLocalService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);
            //Assert.AreEqual(count, polSourceObservationIssueService.GetPolSourceObservationIssueList().Count());
            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.Ordinal = 1001;
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBLocalService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);
            //Assert.AreEqual(count, polSourceObservationIssueDBLocalService.GetPolSourceObservationIssueList().Count());

            // -----------------------------------
            // Is Nullable
            // polSourceObservationIssue.ExtraComment   (String)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // polSourceObservationIssue.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.LastUpdateDate_UTC = new DateTime();
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBLocalService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);
            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBLocalService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // polSourceObservationIssue.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.LastUpdateContactTVItemID = 0;
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBLocalService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);

            polSourceObservationIssue = null;
            polSourceObservationIssue = GetFilledRandomPolSourceObservationIssue("");
            polSourceObservationIssue.LastUpdateContactTVItemID = 1;
            actionPolSourceObservationIssue = await PolSourceObservationIssueDBLocalService.Post(polSourceObservationIssue);
            Assert.IsType<BadRequestObjectResult>(actionPolSourceObservationIssue.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post PolSourceObservationIssue
            var actionPolSourceObservationIssueAdded = await PolSourceObservationIssueDBLocalService.Post(polSourceObservationIssue);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueAdded.Result).Value);
            PolSourceObservationIssue polSourceObservationIssueAdded = (PolSourceObservationIssue)((OkObjectResult)actionPolSourceObservationIssueAdded.Result).Value;
            Assert.NotNull(polSourceObservationIssueAdded);

            // List<PolSourceObservationIssue>
            var actionPolSourceObservationIssueList = await PolSourceObservationIssueDBLocalService.GetPolSourceObservationIssueList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueList.Result).Value);
            List<PolSourceObservationIssue> polSourceObservationIssueList = (List<PolSourceObservationIssue>)((OkObjectResult)actionPolSourceObservationIssueList.Result).Value;

            int count = ((List<PolSourceObservationIssue>)((OkObjectResult)actionPolSourceObservationIssueList.Result).Value).Count();
            Assert.True(count > 0);

            // List<PolSourceObservationIssue> with skip and take
            var actionPolSourceObservationIssueListSkipAndTake = await PolSourceObservationIssueDBLocalService.GetPolSourceObservationIssueList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueListSkipAndTake.Result).Value);
            List<PolSourceObservationIssue> polSourceObservationIssueListSkipAndTake = (List<PolSourceObservationIssue>)((OkObjectResult)actionPolSourceObservationIssueListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<PolSourceObservationIssue>)((OkObjectResult)actionPolSourceObservationIssueListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(polSourceObservationIssueList[0].PolSourceObservationIssueID == polSourceObservationIssueListSkipAndTake[0].PolSourceObservationIssueID);

            // Get PolSourceObservationIssue With PolSourceObservationIssueID
            var actionPolSourceObservationIssueGet = await PolSourceObservationIssueDBLocalService.GetPolSourceObservationIssueWithPolSourceObservationIssueID(polSourceObservationIssueList[0].PolSourceObservationIssueID);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueGet.Result).Value);
            PolSourceObservationIssue polSourceObservationIssueGet = (PolSourceObservationIssue)((OkObjectResult)actionPolSourceObservationIssueGet.Result).Value;
            Assert.NotNull(polSourceObservationIssueGet);
            Assert.Equal(polSourceObservationIssueGet.PolSourceObservationIssueID, polSourceObservationIssueList[0].PolSourceObservationIssueID);

            // Put PolSourceObservationIssue
            var actionPolSourceObservationIssueUpdated = await PolSourceObservationIssueDBLocalService.Put(polSourceObservationIssue);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueUpdated.Result).Value);
            PolSourceObservationIssue polSourceObservationIssueUpdated = (PolSourceObservationIssue)((OkObjectResult)actionPolSourceObservationIssueUpdated.Result).Value;
            Assert.NotNull(polSourceObservationIssueUpdated);

            // Delete PolSourceObservationIssue
            var actionPolSourceObservationIssueDeleted = await PolSourceObservationIssueDBLocalService.Delete(polSourceObservationIssue.PolSourceObservationIssueID);
            Assert.Equal(200, ((ObjectResult)actionPolSourceObservationIssueDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceObservationIssueDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionPolSourceObservationIssueDeleted.Result).Value;
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
            Services.AddSingleton<IPolSourceObservationIssueDBLocalService, PolSourceObservationIssueDBLocalService>();

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

            PolSourceObservationIssueDBLocalService = Provider.GetService<IPolSourceObservationIssueDBLocalService>();
            Assert.NotNull(PolSourceObservationIssueDBLocalService);

            return await Task.FromResult(true);
        }
        private PolSourceObservationIssue GetFilledRandomPolSourceObservationIssue(string OmitPropName)
        {
            PolSourceObservationIssue polSourceObservationIssue = new PolSourceObservationIssue();

            if (OmitPropName != "PolSourceObservationID") polSourceObservationIssue.PolSourceObservationID = 1;
            if (OmitPropName != "ObservationInfo") polSourceObservationIssue.ObservationInfo = GetRandomString("", 5);
            if (OmitPropName != "Ordinal") polSourceObservationIssue.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "ExtraComment") polSourceObservationIssue.ExtraComment = GetRandomString("", 20);
            if (OmitPropName != "LastUpdateDate_UTC") polSourceObservationIssue.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceObservationIssue.LastUpdateContactTVItemID = 2;

            try
            {
                dbLocal.PolSourceObservations.Add(new PolSourceObservation() { PolSourceObservationID = 1, PolSourceSiteID = 1, ObservationDate_Local = new DateTime(2007, 4, 24, 0, 0, 0), ContactTVItemID = 2, DesktopReviewed = false, Observation_ToBeDeleted = "NP Farm area, 20+ animals observed and manure piled 4m high behind barn approx. 350m from shore. Drainage ditches lead to river with a heavy slope.", LastUpdateDate_UTC = new DateTime(2015, 4, 13, 20, 1, 31), LastUpdateContactTVItemID = 2 });
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


            return polSourceObservationIssue;
        }
        private void CheckPolSourceObservationIssueFields(List<PolSourceObservationIssue> polSourceObservationIssueList)
        {
            Assert.False(string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].ObservationInfo));
            if (!string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].ExtraComment))
            {
                Assert.False(string.IsNullOrWhiteSpace(polSourceObservationIssueList[0].ExtraComment));
            }
        }

        #endregion Functions private
    }
}
