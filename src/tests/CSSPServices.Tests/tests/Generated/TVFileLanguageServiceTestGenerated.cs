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
    public partial class TVFileLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ITVFileLanguageService tvFileLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public TVFileLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task TVFileLanguage_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               TVFileLanguage tvFileLanguage = GetFilledRandomTVFileLanguage(""); 

               // List<TVFileLanguage>
               var actionTVFileLanguageList = await tvFileLanguageService.GetTVFileLanguageList();
               Assert.Equal(200, ((ObjectResult)actionTVFileLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVFileLanguageList.Result).Value);
               List<TVFileLanguage> tvFileLanguageList = (List<TVFileLanguage>)((OkObjectResult)actionTVFileLanguageList.Result).Value;

               int count = ((List<TVFileLanguage>)((OkObjectResult)actionTVFileLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // Add TVFileLanguage
               var actionTVFileLanguageAdded = await tvFileLanguageService.Add(tvFileLanguage);
               Assert.Equal(200, ((ObjectResult)actionTVFileLanguageAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVFileLanguageAdded.Result).Value);
               TVFileLanguage tvFileLanguageAdded = (TVFileLanguage)((OkObjectResult)actionTVFileLanguageAdded.Result).Value;
               Assert.NotNull(tvFileLanguageAdded);

               // Update TVFileLanguage
               var actionTVFileLanguageUpdated = await tvFileLanguageService.Update(tvFileLanguage);
               Assert.Equal(200, ((ObjectResult)actionTVFileLanguageUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVFileLanguageUpdated.Result).Value);
               TVFileLanguage tvFileLanguageUpdated = (TVFileLanguage)((OkObjectResult)actionTVFileLanguageUpdated.Result).Value;
               Assert.NotNull(tvFileLanguageUpdated);

               // Delete TVFileLanguage
               var actionTVFileLanguageDeleted = await tvFileLanguageService.Delete(tvFileLanguage.TVFileLanguageID);
               Assert.Equal(200, ((ObjectResult)actionTVFileLanguageDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionTVFileLanguageDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionTVFileLanguageDeleted.Result).Value;
               Assert.True(retBool);
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
            Services.AddSingleton<ITVFileLanguageService, TVFileLanguageService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            tvFileLanguageService = Provider.GetService<ITVFileLanguageService>();
            Assert.NotNull(tvFileLanguageService);
        
            await tvFileLanguageService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private TVFileLanguage GetFilledRandomTVFileLanguage(string OmitPropName)
        {
            TVFileLanguage tvFileLanguage = new TVFileLanguage();

            if (OmitPropName != "TVFileID") tvFileLanguage.TVFileID = 1;
            if (OmitPropName != "Language") tvFileLanguage.Language = LanguageRequest;
            if (OmitPropName != "FileDescription") tvFileLanguage.FileDescription = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") tvFileLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") tvFileLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") tvFileLanguage.LastUpdateContactTVItemID = 2;

            return tvFileLanguage;
        }
        #endregion Functions private
    }
}
