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
    public partial class PolSourceGroupingLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IPolSourceGroupingLanguageService polSourceGroupingLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public PolSourceGroupingLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task PolSourceGroupingLanguage_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            PolSourceGroupingLanguage polSourceGroupingLanguage = GetFilledRandomPolSourceGroupingLanguage(""); 

            // List<PolSourceGroupingLanguage>
            var actionPolSourceGroupingLanguageList = await polSourceGroupingLanguageService.GetPolSourceGroupingLanguageList();
            Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageList.Result).Value);
            List<PolSourceGroupingLanguage> polSourceGroupingLanguageList = (List<PolSourceGroupingLanguage>)(((OkObjectResult)actionPolSourceGroupingLanguageList.Result).Value);

            int count = ((List<PolSourceGroupingLanguage>)((OkObjectResult)actionPolSourceGroupingLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // Add PolSourceGroupingLanguage
            var actionPolSourceGroupingLanguageAdded = await polSourceGroupingLanguageService.Add(polSourceGroupingLanguage);
            Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageAdded.Result).Value);
            PolSourceGroupingLanguage polSourceGroupingLanguageAdded = (PolSourceGroupingLanguage)(((OkObjectResult)actionPolSourceGroupingLanguageAdded.Result).Value);
            Assert.NotNull(polSourceGroupingLanguageAdded);

            // Update PolSourceGroupingLanguage
            var actionPolSourceGroupingLanguageUpdated = await polSourceGroupingLanguageService.Update(polSourceGroupingLanguage);
            Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageUpdated.Result).Value);
            PolSourceGroupingLanguage polSourceGroupingLanguageUpdated = (PolSourceGroupingLanguage)(((OkObjectResult)actionPolSourceGroupingLanguageUpdated.Result).Value);
            Assert.NotNull(polSourceGroupingLanguageUpdated);

            // Delete PolSourceGroupingLanguage
            var actionPolSourceGroupingLanguageDeleted = await polSourceGroupingLanguageService.Delete(polSourceGroupingLanguage);
            Assert.Equal(200, ((ObjectResult)actionPolSourceGroupingLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionPolSourceGroupingLanguageDeleted.Result).Value);
            PolSourceGroupingLanguage polSourceGroupingLanguageDeleted = (PolSourceGroupingLanguage)(((OkObjectResult)actionPolSourceGroupingLanguageDeleted.Result).Value);
            Assert.NotNull(polSourceGroupingLanguageDeleted);
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
            Services.AddSingleton<IPolSourceGroupingLanguageService, PolSourceGroupingLanguageService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            polSourceGroupingLanguageService = Provider.GetService<IPolSourceGroupingLanguageService>();
            Assert.NotNull(polSourceGroupingLanguageService);
        
            await polSourceGroupingLanguageService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private PolSourceGroupingLanguage GetFilledRandomPolSourceGroupingLanguage(string OmitPropName)
        {
            PolSourceGroupingLanguage polSourceGroupingLanguage = new PolSourceGroupingLanguage();

            if (OmitPropName != "PolSourceGroupingID") polSourceGroupingLanguage.PolSourceGroupingID = 1;
            if (OmitPropName != "Language") polSourceGroupingLanguage.Language = LanguageRequest;
            if (OmitPropName != "SourceName") polSourceGroupingLanguage.SourceName = GetRandomString("", 5);
            if (OmitPropName != "SourceNameOrder") polSourceGroupingLanguage.SourceNameOrder = GetRandomInt(0, 1000);
            if (OmitPropName != "TranslationStatusSourceName") polSourceGroupingLanguage.TranslationStatusSourceName = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "Init") polSourceGroupingLanguage.Init = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusInit") polSourceGroupingLanguage.TranslationStatusInit = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "Description") polSourceGroupingLanguage.Description = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusDescription") polSourceGroupingLanguage.TranslationStatusDescription = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "Report") polSourceGroupingLanguage.Report = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusReport") polSourceGroupingLanguage.TranslationStatusReport = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "Text") polSourceGroupingLanguage.Text = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusText") polSourceGroupingLanguage.TranslationStatusText = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") polSourceGroupingLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") polSourceGroupingLanguage.LastUpdateContactTVItemID = 2;

            return polSourceGroupingLanguage;
        }
        #endregion Functions private
    }
}