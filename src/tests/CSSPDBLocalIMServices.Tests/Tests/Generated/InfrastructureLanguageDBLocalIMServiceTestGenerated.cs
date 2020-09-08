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
    public partial class InfrastructureLanguageDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IInfrastructureLanguageDBLocalIMService InfrastructureLanguageDBLocalIMService { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private InfrastructureLanguage infrastructureLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DBLocalIM]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task InfrastructureLanguageDBLocalIM_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");

            await DoCRUDDBLocalIMTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task InfrastructureLanguage_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionInfrastructureLanguageList = await InfrastructureLanguageDBLocalIMService.GetInfrastructureLanguageList();
            Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionInfrastructureLanguageList.Result).Value);
            List<InfrastructureLanguage> infrastructureLanguageList = (List<InfrastructureLanguage>)((OkObjectResult)actionInfrastructureLanguageList.Result).Value;

            count = infrastructureLanguageList.Count();

            InfrastructureLanguage infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // infrastructureLanguage.InfrastructureLanguageID   (Int32)
            // -----------------------------------

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            infrastructureLanguage.InfrastructureLanguageID = 0;

            var actionInfrastructureLanguage = await InfrastructureLanguageDBLocalIMService.Put(infrastructureLanguage);
            Assert.IsType<BadRequestObjectResult>(actionInfrastructureLanguage.Result);

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            infrastructureLanguage.InfrastructureLanguageID = 10000000;
            actionInfrastructureLanguage = await InfrastructureLanguageDBLocalIMService.Put(infrastructureLanguage);
            Assert.IsType<BadRequestObjectResult>(actionInfrastructureLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "Infrastructure", ExistPlurial = "s", ExistFieldID = "InfrastructureID", AllowableTVtypeList = )]
            // infrastructureLanguage.InfrastructureID   (Int32)
            // -----------------------------------

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            infrastructureLanguage.InfrastructureID = 0;
            actionInfrastructureLanguage = await InfrastructureLanguageDBLocalIMService.Post(infrastructureLanguage);
            Assert.IsType<BadRequestObjectResult>(actionInfrastructureLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // infrastructureLanguage.Language   (LanguageEnum)
            // -----------------------------------

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            infrastructureLanguage.Language = (LanguageEnum)1000000;
            actionInfrastructureLanguage = await InfrastructureLanguageDBLocalIMService.Post(infrastructureLanguage);
            Assert.IsType<BadRequestObjectResult>(actionInfrastructureLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // infrastructureLanguage.Comment   (String)
            // -----------------------------------

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("Comment");
            actionInfrastructureLanguage = await InfrastructureLanguageDBLocalIMService.Post(infrastructureLanguage);
            Assert.IsType<BadRequestObjectResult>(actionInfrastructureLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // infrastructureLanguage.TranslationStatus   (TranslationStatusEnum)
            // -----------------------------------

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            infrastructureLanguage.TranslationStatus = (TranslationStatusEnum)1000000;
            actionInfrastructureLanguage = await InfrastructureLanguageDBLocalIMService.Post(infrastructureLanguage);
            Assert.IsType<BadRequestObjectResult>(actionInfrastructureLanguage.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // infrastructureLanguage.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            infrastructureLanguage.LastUpdateDate_UTC = new DateTime();
            actionInfrastructureLanguage = await InfrastructureLanguageDBLocalIMService.Post(infrastructureLanguage);
            Assert.IsType<BadRequestObjectResult>(actionInfrastructureLanguage.Result);
            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            infrastructureLanguage.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionInfrastructureLanguage = await InfrastructureLanguageDBLocalIMService.Post(infrastructureLanguage);
            Assert.IsType<BadRequestObjectResult>(actionInfrastructureLanguage.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // infrastructureLanguage.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            infrastructureLanguage.LastUpdateContactTVItemID = 0;
            actionInfrastructureLanguage = await InfrastructureLanguageDBLocalIMService.Post(infrastructureLanguage);
            Assert.IsType<BadRequestObjectResult>(actionInfrastructureLanguage.Result);

            infrastructureLanguage = null;
            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");
            infrastructureLanguage.LastUpdateContactTVItemID = 1;
            actionInfrastructureLanguage = await InfrastructureLanguageDBLocalIMService.Post(infrastructureLanguage);
            Assert.IsType<BadRequestObjectResult>(actionInfrastructureLanguage.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalIMTest()
        {
            infrastructureLanguage.InfrastructureLanguageID = 10000000;

            // Post InfrastructureLanguage
            var actionInfrastructureLanguageAdded = await InfrastructureLanguageDBLocalIMService.Post(infrastructureLanguage);
            Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionInfrastructureLanguageAdded.Result).Value);
            InfrastructureLanguage infrastructureLanguageAdded = (InfrastructureLanguage)((OkObjectResult)actionInfrastructureLanguageAdded.Result).Value;
            Assert.NotNull(infrastructureLanguageAdded);

            // List<InfrastructureLanguage>
            var actionInfrastructureLanguageList = await InfrastructureLanguageDBLocalIMService.GetInfrastructureLanguageList();
            Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionInfrastructureLanguageList.Result).Value);
            List<InfrastructureLanguage> infrastructureLanguageList = (List<InfrastructureLanguage>)((OkObjectResult)actionInfrastructureLanguageList.Result).Value;

            int count = ((List<InfrastructureLanguage>)((OkObjectResult)actionInfrastructureLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // Get InfrastructureLanguage With InfrastructureLanguageID
            var actionInfrastructureLanguageGet = await InfrastructureLanguageDBLocalIMService.GetInfrastructureLanguageWithInfrastructureLanguageID(infrastructureLanguageList[0].InfrastructureLanguageID);
            Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguageGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionInfrastructureLanguageGet.Result).Value);
            InfrastructureLanguage infrastructureLanguageGet = (InfrastructureLanguage)((OkObjectResult)actionInfrastructureLanguageGet.Result).Value;
            Assert.NotNull(infrastructureLanguageGet);
            Assert.Equal(infrastructureLanguageGet.InfrastructureLanguageID, infrastructureLanguageList[0].InfrastructureLanguageID);

            // Put InfrastructureLanguage
            var actionInfrastructureLanguageUpdated = await InfrastructureLanguageDBLocalIMService.Put(infrastructureLanguage);
            Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionInfrastructureLanguageUpdated.Result).Value);
            InfrastructureLanguage infrastructureLanguageUpdated = (InfrastructureLanguage)((OkObjectResult)actionInfrastructureLanguageUpdated.Result).Value;
            Assert.NotNull(infrastructureLanguageUpdated);

            // Delete InfrastructureLanguage
            var actionInfrastructureLanguageDeleted = await InfrastructureLanguageDBLocalIMService.Delete(infrastructureLanguage.InfrastructureLanguageID);
            Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionInfrastructureLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionInfrastructureLanguageDeleted.Result).Value;
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
            Services.AddSingleton<IInfrastructureLanguageDBLocalIMService, InfrastructureLanguageDBLocalIMService>();

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

            InfrastructureLanguageDBLocalIMService = Provider.GetService<IInfrastructureLanguageDBLocalIMService>();
            Assert.NotNull(InfrastructureLanguageDBLocalIMService);

            return await Task.FromResult(true);
        }
        private InfrastructureLanguage GetFilledRandomInfrastructureLanguage(string OmitPropName)
        {
            InfrastructureLanguage infrastructureLanguage = new InfrastructureLanguage();

            if (OmitPropName != "InfrastructureID") infrastructureLanguage.InfrastructureID = 1;
            if (OmitPropName != "Language") infrastructureLanguage.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "Comment") infrastructureLanguage.Comment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") infrastructureLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") infrastructureLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") infrastructureLanguage.LastUpdateContactTVItemID = 2;



            return infrastructureLanguage;
        }
        private void CheckInfrastructureLanguageFields(List<InfrastructureLanguage> infrastructureLanguageList)
        {
            Assert.False(string.IsNullOrWhiteSpace(infrastructureLanguageList[0].Comment));
        }

        #endregion Functions private
    }
}
