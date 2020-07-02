/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
using LoggedInServices.Services;
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

namespace CSSPServices.Tests
{
    public partial class SpillLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ISpillLanguageService SpillLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public SpillLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task SpillLanguage_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               SpillLanguage spillLanguage = GetFilledRandomSpillLanguage(""); 

               // List<SpillLanguage>
               var actionSpillLanguageList = await SpillLanguageService.GetSpillLanguageList();
               Assert.Equal(200, ((ObjectResult)actionSpillLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillLanguageList.Result).Value);
               List<SpillLanguage> spillLanguageList = (List<SpillLanguage>)((OkObjectResult)actionSpillLanguageList.Result).Value;

               int count = ((List<SpillLanguage>)((OkObjectResult)actionSpillLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // Post SpillLanguage
               var actionSpillLanguageAdded = await SpillLanguageService.Post(spillLanguage);
               Assert.Equal(200, ((ObjectResult)actionSpillLanguageAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillLanguageAdded.Result).Value);
               SpillLanguage spillLanguageAdded = (SpillLanguage)((OkObjectResult)actionSpillLanguageAdded.Result).Value;
               Assert.NotNull(spillLanguageAdded);

               // Put SpillLanguage
               var actionSpillLanguageUpdated = await SpillLanguageService.Put(spillLanguage);
               Assert.Equal(200, ((ObjectResult)actionSpillLanguageUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillLanguageUpdated.Result).Value);
               SpillLanguage spillLanguageUpdated = (SpillLanguage)((OkObjectResult)actionSpillLanguageUpdated.Result).Value;
               Assert.NotNull(spillLanguageUpdated);

               // Delete SpillLanguage
               var actionSpillLanguageDeleted = await SpillLanguageService.Delete(spillLanguage.SpillLanguageID);
               Assert.Equal(200, ((ObjectResult)actionSpillLanguageDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillLanguageDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionSpillLanguageDeleted.Result).Value;
               Assert.True(retBool);
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<InMemoryDBContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ISpillLanguageService, SpillLanguageService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            SpillLanguageService = Provider.GetService<ISpillLanguageService>();
            Assert.NotNull(SpillLanguageService);

            return await Task.FromResult(true);
        }
        private SpillLanguage GetFilledRandomSpillLanguage(string OmitPropName)
        {
            SpillLanguage spillLanguage = new SpillLanguage();

            if (OmitPropName != "SpillID") spillLanguage.SpillID = 1;
            if (OmitPropName != "Language") spillLanguage.Language = LanguageRequest;
            if (OmitPropName != "SpillComment") spillLanguage.SpillComment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") spillLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") spillLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") spillLanguage.LastUpdateContactTVItemID = 2;

            return spillLanguage;
        }
        #endregion Functions private
    }
}
