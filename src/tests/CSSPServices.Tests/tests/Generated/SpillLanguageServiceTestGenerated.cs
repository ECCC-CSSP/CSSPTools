/* Auto generated from C:\CSSPTools\src\codegen\ServicesClassNameServiceTestGenerated\bin\Debug\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
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
        private ISpillLanguageService spillLanguageService { get; set; }
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

            await Setup(new CultureInfo(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               SpillLanguage spillLanguage = GetFilledRandomSpillLanguage(""); 

               // List<SpillLanguage>
               var actionSpillLanguageList = await spillLanguageService.GetSpillLanguageList();
               Assert.Equal(200, ((ObjectResult)actionSpillLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillLanguageList.Result).Value);
               List<SpillLanguage> spillLanguageList = (List<SpillLanguage>)(((OkObjectResult)actionSpillLanguageList.Result).Value);

               int count = ((List<SpillLanguage>)((OkObjectResult)actionSpillLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // Add SpillLanguage
               var actionSpillLanguageAdded = await spillLanguageService.Add(spillLanguage);
               Assert.Equal(200, ((ObjectResult)actionSpillLanguageAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillLanguageAdded.Result).Value);
               SpillLanguage spillLanguageAdded = (SpillLanguage)(((OkObjectResult)actionSpillLanguageAdded.Result).Value);
               Assert.NotNull(spillLanguageAdded);

               // Update SpillLanguage
               var actionSpillLanguageUpdated = await spillLanguageService.Update(spillLanguage);
               Assert.Equal(200, ((ObjectResult)actionSpillLanguageUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillLanguageUpdated.Result).Value);
               SpillLanguage spillLanguageUpdated = (SpillLanguage)(((OkObjectResult)actionSpillLanguageUpdated.Result).Value);
               Assert.NotNull(spillLanguageUpdated);

               // Delete SpillLanguage
               var actionSpillLanguageDeleted = await spillLanguageService.Delete(spillLanguage);
               Assert.Equal(200, ((ObjectResult)actionSpillLanguageDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionSpillLanguageDeleted.Result).Value);
               SpillLanguage spillLanguageDeleted = (SpillLanguage)(((OkObjectResult)actionSpillLanguageDeleted.Result).Value);
               Assert.NotNull(spillLanguageDeleted);
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(CultureInfo culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .Build();
        
            Services = new ServiceCollection();
        
            Services.AddSingleton<IConfiguration>(Config);
        
            string TestDBConnString = Config.GetValue<string>("TestDBConnectionString");
            Assert.NotNull(TestDBConnString);
        
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });
        
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ISpillLanguageService, SpillLanguageService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            spillLanguageService = Provider.GetService<ISpillLanguageService>();
            Assert.NotNull(spillLanguageService);
        
            await spillLanguageService.SetCulture(culture);
        
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
