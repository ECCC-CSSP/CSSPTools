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
    public partial class MWQMSubsectorLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IMWQMSubsectorLanguageService mwqmSubsectorLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMSubsectorLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task MWQMSubsectorLanguage_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            await Setup(new CultureInfo(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               MWQMSubsectorLanguage mwqmSubsectorLanguage = GetFilledRandomMWQMSubsectorLanguage(""); 

               // List<MWQMSubsectorLanguage>
               var actionMWQMSubsectorLanguageList = await mwqmSubsectorLanguageService.GetMWQMSubsectorLanguageList();
               Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorLanguageList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSubsectorLanguageList.Result).Value);
               List<MWQMSubsectorLanguage> mwqmSubsectorLanguageList = (List<MWQMSubsectorLanguage>)((OkObjectResult)actionMWQMSubsectorLanguageList.Result).Value;

               int count = ((List<MWQMSubsectorLanguage>)((OkObjectResult)actionMWQMSubsectorLanguageList.Result).Value).Count();
                Assert.True(count > 0);

               // Add MWQMSubsectorLanguage
               var actionMWQMSubsectorLanguageAdded = await mwqmSubsectorLanguageService.Add(mwqmSubsectorLanguage);
               Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorLanguageAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSubsectorLanguageAdded.Result).Value);
               MWQMSubsectorLanguage mwqmSubsectorLanguageAdded = (MWQMSubsectorLanguage)((OkObjectResult)actionMWQMSubsectorLanguageAdded.Result).Value;
               Assert.NotNull(mwqmSubsectorLanguageAdded);

               // Update MWQMSubsectorLanguage
               var actionMWQMSubsectorLanguageUpdated = await mwqmSubsectorLanguageService.Update(mwqmSubsectorLanguage);
               Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorLanguageUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSubsectorLanguageUpdated.Result).Value);
               MWQMSubsectorLanguage mwqmSubsectorLanguageUpdated = (MWQMSubsectorLanguage)((OkObjectResult)actionMWQMSubsectorLanguageUpdated.Result).Value;
               Assert.NotNull(mwqmSubsectorLanguageUpdated);

               // Delete MWQMSubsectorLanguage
               var actionMWQMSubsectorLanguageDeleted = await mwqmSubsectorLanguageService.Delete(mwqmSubsectorLanguage.MWQMSubsectorLanguageID);
               Assert.Equal(200, ((ObjectResult)actionMWQMSubsectorLanguageDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionMWQMSubsectorLanguageDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionMWQMSubsectorLanguageDeleted.Result).Value;
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
            Services.AddSingleton<IMWQMSubsectorLanguageService, MWQMSubsectorLanguageService>();
        
            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);
        
            mwqmSubsectorLanguageService = Provider.GetService<IMWQMSubsectorLanguageService>();
            Assert.NotNull(mwqmSubsectorLanguageService);
        
            await mwqmSubsectorLanguageService.SetCulture(culture);
        
            return await Task.FromResult(true);
        }
        private MWQMSubsectorLanguage GetFilledRandomMWQMSubsectorLanguage(string OmitPropName)
        {
            MWQMSubsectorLanguage mwqmSubsectorLanguage = new MWQMSubsectorLanguage();

            if (OmitPropName != "MWQMSubsectorID") mwqmSubsectorLanguage.MWQMSubsectorID = 1;
            if (OmitPropName != "Language") mwqmSubsectorLanguage.Language = LanguageRequest;
            if (OmitPropName != "SubsectorDesc") mwqmSubsectorLanguage.SubsectorDesc = GetRandomString("", 5);
            if (OmitPropName != "TranslationStatusSubsectorDesc") mwqmSubsectorLanguage.TranslationStatusSubsectorDesc = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LogBook") mwqmSubsectorLanguage.LogBook = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatusLogBook") mwqmSubsectorLanguage.TranslationStatusLogBook = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") mwqmSubsectorLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") mwqmSubsectorLanguage.LastUpdateContactTVItemID = 2;

            return mwqmSubsectorLanguage;
        }
        #endregion Functions private
    }
}
