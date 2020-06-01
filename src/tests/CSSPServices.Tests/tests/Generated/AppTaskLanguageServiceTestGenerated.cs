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
using Xunit;

namespace CSSPServices.Tests
{
    public partial class AppTaskLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IAppTaskLanguageService appTaskLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public AppTaskLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task AppTaskLanguage_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            AppTaskLanguage appTaskLanguage = GetFilledRandomAppTaskLanguage(""); 

            // List<AppTaskLanguage>
            var actionAppTaskLanguageList = await appTaskLanguageService.GetAppTaskLanguageList();
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageList.Result).Value);
            List<AppTaskLanguage> appTaskLanguageList = (List<AppTaskLanguage>)(((OkObjectResult)actionAppTaskLanguageList.Result).Value);

            int count = ((List<AppTaskLanguage>)((OkObjectResult)actionAppTaskLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // Add AppTaskLanguage
            var actionAppTaskLanguageAdded = await appTaskLanguageService.Add(appTaskLanguage);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageAdded.Result).Value);
            AppTaskLanguage appTaskLanguageAdded = (AppTaskLanguage)(((OkObjectResult)actionAppTaskLanguageAdded.Result).Value);
            Assert.NotNull(appTaskLanguageAdded);

            // Update AppTaskLanguage
            var actionAppTaskLanguageUpdated = await appTaskLanguageService.Update(appTaskLanguage);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageUpdated.Result).Value);
            AppTaskLanguage appTaskLanguageUpdated = (AppTaskLanguage)(((OkObjectResult)actionAppTaskLanguageUpdated.Result).Value);
            Assert.NotNull(appTaskLanguageUpdated);

            // Delete AppTaskLanguage
            var actionAppTaskLanguageDeleted = await appTaskLanguageService.Delete(appTaskLanguage);
            Assert.Equal(200, ((ObjectResult)actionAppTaskLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAppTaskLanguageDeleted.Result).Value);
            AppTaskLanguage appTaskLanguageDeleted = (AppTaskLanguage)(((OkObjectResult)actionAppTaskLanguageDeleted.Result).Value);
            Assert.NotNull(appTaskLanguageDeleted);
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
            Services.AddSingleton<IAppTaskLanguageService, AppTaskLanguageService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            appTaskLanguageService = Provider.GetService<IAppTaskLanguageService>();
            Assert.NotNull(appTaskLanguageService);
        
            await appTaskLanguageService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private AppTaskLanguage GetFilledRandomAppTaskLanguage(string OmitPropName)
        {
            AppTaskLanguage appTaskLanguage = new AppTaskLanguage();

            if (OmitPropName != "AppTaskID") appTaskLanguage.AppTaskID = 1;
            if (OmitPropName != "Language") appTaskLanguage.Language = LanguageRequest;
            if (OmitPropName != "StatusText") appTaskLanguage.StatusText = GetRandomString("", 5);
            if (OmitPropName != "ErrorText") appTaskLanguage.ErrorText = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatus") appTaskLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") appTaskLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") appTaskLanguage.LastUpdateContactTVItemID = 2;

            return appTaskLanguage;
        }
        #endregion Functions private
    }
}