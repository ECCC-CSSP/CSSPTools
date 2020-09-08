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
    public partial class TVItemUserAuthorizationDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ITVItemUserAuthorizationDBLocalIMService TVItemUserAuthorizationDBLocalIMService { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private TVItemUserAuthorization tvItemUserAuthorization { get; set; }
        #endregion Properties

        #region Constructors
        public TVItemUserAuthorizationDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DBLocalIM]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemUserAuthorizationDBLocalIM_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");

            await DoCRUDDBLocalIMTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task TVItemUserAuthorization_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionTVItemUserAuthorizationList = await TVItemUserAuthorizationDBLocalIMService.GetTVItemUserAuthorizationList();
            Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorizationList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorizationList.Result).Value);
            List<TVItemUserAuthorization> tvItemUserAuthorizationList = (List<TVItemUserAuthorization>)((OkObjectResult)actionTVItemUserAuthorizationList.Result).Value;

            count = tvItemUserAuthorizationList.Count();

            TVItemUserAuthorization tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // tvItemUserAuthorization.TVItemUserAuthorizationID   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemUserAuthorizationID = 0;

            var actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Put(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemUserAuthorizationID = 10000000;
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Put(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tvItemUserAuthorization.ContactTVItemID   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.ContactTVItemID = 0;
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.ContactTVItemID = 1;
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint)]
            // tvItemUserAuthorization.TVItemID1   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemID1 = 0;
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemID1 = 13;
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint)]
            // tvItemUserAuthorization.TVItemID2   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemID2 = 0;
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemID2 = 13;
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint)]
            // tvItemUserAuthorization.TVItemID3   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemID3 = 0;
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemID3 = 13;
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Root,Address,Area,ClimateSite,Contact,Country,Email,File,HydrometricSite,Infrastructure,MikeScenario,MikeSource,Municipality,MWQMSite,PolSourceSite,Province,Sector,Subsector,Tel,TideSite,WasteWaterTreatmentPlant,LiftStation,Spill,BoxModel,VisualPlumesScenario,OtherInfrastructure,MWQMRun,MeshNode,WebTideNode,SamplingPlan,SeeOtherMunicipality,LineOverflow,MapInfo,MapInfoPoint)]
            // tvItemUserAuthorization.TVItemID4   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemID4 = 0;
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVItemID4 = 13;
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // tvItemUserAuthorization.TVAuth   (TVAuthEnum)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.TVAuth = (TVAuthEnum)1000000;
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // tvItemUserAuthorization.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.LastUpdateDate_UTC = new DateTime();
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);
            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // tvItemUserAuthorization.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.LastUpdateContactTVItemID = 0;
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);

            tvItemUserAuthorization = null;
            tvItemUserAuthorization = GetFilledRandomTVItemUserAuthorization("");
            tvItemUserAuthorization.LastUpdateContactTVItemID = 1;
            actionTVItemUserAuthorization = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.IsType<BadRequestObjectResult>(actionTVItemUserAuthorization.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalIMTest()
        {
            tvItemUserAuthorization.TVItemUserAuthorizationID = 10000000;

            // Post TVItemUserAuthorization
            var actionTVItemUserAuthorizationAdded = await TVItemUserAuthorizationDBLocalIMService.Post(tvItemUserAuthorization);
            Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorizationAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorizationAdded.Result).Value);
            TVItemUserAuthorization tvItemUserAuthorizationAdded = (TVItemUserAuthorization)((OkObjectResult)actionTVItemUserAuthorizationAdded.Result).Value;
            Assert.NotNull(tvItemUserAuthorizationAdded);

            // List<TVItemUserAuthorization>
            var actionTVItemUserAuthorizationList = await TVItemUserAuthorizationDBLocalIMService.GetTVItemUserAuthorizationList();
            Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorizationList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorizationList.Result).Value);
            List<TVItemUserAuthorization> tvItemUserAuthorizationList = (List<TVItemUserAuthorization>)((OkObjectResult)actionTVItemUserAuthorizationList.Result).Value;

            int count = ((List<TVItemUserAuthorization>)((OkObjectResult)actionTVItemUserAuthorizationList.Result).Value).Count();
            Assert.True(count > 0);

            // Get TVItemUserAuthorization With TVItemUserAuthorizationID
            var actionTVItemUserAuthorizationGet = await TVItemUserAuthorizationDBLocalIMService.GetTVItemUserAuthorizationWithTVItemUserAuthorizationID(tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);
            Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorizationGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorizationGet.Result).Value);
            TVItemUserAuthorization tvItemUserAuthorizationGet = (TVItemUserAuthorization)((OkObjectResult)actionTVItemUserAuthorizationGet.Result).Value;
            Assert.NotNull(tvItemUserAuthorizationGet);
            Assert.Equal(tvItemUserAuthorizationGet.TVItemUserAuthorizationID, tvItemUserAuthorizationList[0].TVItemUserAuthorizationID);

            // Put TVItemUserAuthorization
            var actionTVItemUserAuthorizationUpdated = await TVItemUserAuthorizationDBLocalIMService.Put(tvItemUserAuthorization);
            Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorizationUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorizationUpdated.Result).Value);
            TVItemUserAuthorization tvItemUserAuthorizationUpdated = (TVItemUserAuthorization)((OkObjectResult)actionTVItemUserAuthorizationUpdated.Result).Value;
            Assert.NotNull(tvItemUserAuthorizationUpdated);

            // Delete TVItemUserAuthorization
            var actionTVItemUserAuthorizationDeleted = await TVItemUserAuthorizationDBLocalIMService.Delete(tvItemUserAuthorization.TVItemUserAuthorizationID);
            Assert.Equal(200, ((ObjectResult)actionTVItemUserAuthorizationDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionTVItemUserAuthorizationDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionTVItemUserAuthorizationDeleted.Result).Value;
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
            Services.AddSingleton<ITVItemUserAuthorizationDBLocalIMService, TVItemUserAuthorizationDBLocalIMService>();

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

            TVItemUserAuthorizationDBLocalIMService = Provider.GetService<ITVItemUserAuthorizationDBLocalIMService>();
            Assert.NotNull(TVItemUserAuthorizationDBLocalIMService);

            return await Task.FromResult(true);
        }
        private TVItemUserAuthorization GetFilledRandomTVItemUserAuthorization(string OmitPropName)
        {
            TVItemUserAuthorization tvItemUserAuthorization = new TVItemUserAuthorization();

            if (OmitPropName != "ContactTVItemID") tvItemUserAuthorization.ContactTVItemID = 2;
            if (OmitPropName != "TVItemID1") tvItemUserAuthorization.TVItemID1 = 1;
            if (OmitPropName != "TVItemID2") tvItemUserAuthorization.TVItemID2 = 1;
            if (OmitPropName != "TVItemID3") tvItemUserAuthorization.TVItemID3 = 1;
            if (OmitPropName != "TVItemID4") tvItemUserAuthorization.TVItemID4 = 1;
            if (OmitPropName != "TVAuth") tvItemUserAuthorization.TVAuth = (TVAuthEnum)GetRandomEnumType(typeof(TVAuthEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvItemUserAuthorization.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvItemUserAuthorization.LastUpdateContactTVItemID = 2;



            return tvItemUserAuthorization;
        }
        private void CheckTVItemUserAuthorizationFields(List<TVItemUserAuthorization> tvItemUserAuthorizationList)
        {
            if (tvItemUserAuthorizationList[0].TVItemID2 != null)
            {
                Assert.NotNull(tvItemUserAuthorizationList[0].TVItemID2);
            }
            if (tvItemUserAuthorizationList[0].TVItemID3 != null)
            {
                Assert.NotNull(tvItemUserAuthorizationList[0].TVItemID3);
            }
            if (tvItemUserAuthorizationList[0].TVItemID4 != null)
            {
                Assert.NotNull(tvItemUserAuthorizationList[0].TVItemID4);
            }
        }

        #endregion Functions private
    }
}
