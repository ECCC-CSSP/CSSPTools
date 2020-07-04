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
    [Collection("Sequential")]
    public partial class InfrastructureLanguageServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IInfrastructureLanguageService InfrastructureLanguageService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private InfrastructureLanguage infrastructureLanguage { get; set; }
        #endregion Properties

        #region Constructors
        public InfrastructureLanguageServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task InfrastructureLanguage_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            infrastructureLanguage = GetFilledRandomInfrastructureLanguage("");

            if (LoggedInService.IsLocal)
            {
                await DoCRUDTest();
            }
            else
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    await DoCRUDTest();
                }
            }
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post InfrastructureLanguage
            var actionInfrastructureLanguageAdded = await InfrastructureLanguageService.Post(infrastructureLanguage);
            Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguageAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionInfrastructureLanguageAdded.Result).Value);
            InfrastructureLanguage infrastructureLanguageAdded = (InfrastructureLanguage)((OkObjectResult)actionInfrastructureLanguageAdded.Result).Value;
            Assert.NotNull(infrastructureLanguageAdded);

            // List<InfrastructureLanguage>
            var actionInfrastructureLanguageList = await InfrastructureLanguageService.GetInfrastructureLanguageList();
            Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguageList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionInfrastructureLanguageList.Result).Value);
            List<InfrastructureLanguage> infrastructureLanguageList = (List<InfrastructureLanguage>)((OkObjectResult)actionInfrastructureLanguageList.Result).Value;

            int count = ((List<InfrastructureLanguage>)((OkObjectResult)actionInfrastructureLanguageList.Result).Value).Count();
            Assert.True(count > 0);

            // Put InfrastructureLanguage
            var actionInfrastructureLanguageUpdated = await InfrastructureLanguageService.Put(infrastructureLanguage);
            Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguageUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionInfrastructureLanguageUpdated.Result).Value);
            InfrastructureLanguage infrastructureLanguageUpdated = (InfrastructureLanguage)((OkObjectResult)actionInfrastructureLanguageUpdated.Result).Value;
            Assert.NotNull(infrastructureLanguageUpdated);

            // Delete InfrastructureLanguage
            var actionInfrastructureLanguageDeleted = await InfrastructureLanguageService.Delete(infrastructureLanguage.InfrastructureLanguageID);
            Assert.Equal(200, ((ObjectResult)actionInfrastructureLanguageDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionInfrastructureLanguageDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionInfrastructureLanguageDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

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

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName.Replace("{appDataPath}", appDataPath));

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IInfrastructureLanguageService, InfrastructureLanguageService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            //string IsLocalStr = Config.GetValue<string>("IsLocal");
            //Assert.NotNull(IsLocalStr);

            dbIM = Provider.GetService<InMemoryDBContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            InfrastructureLanguageService = Provider.GetService<IInfrastructureLanguageService>();
            Assert.NotNull(InfrastructureLanguageService);

            return await Task.FromResult(true);
        }
        private InfrastructureLanguage GetFilledRandomInfrastructureLanguage(string OmitPropName)
        {
            List<InfrastructureLanguage> infrastructureLanguageListToDelete = (from c in dbLocal.InfrastructureLanguages
                                                               select c).ToList(); 
            
            dbLocal.InfrastructureLanguages.RemoveRange(infrastructureLanguageListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            InfrastructureLanguage infrastructureLanguage = new InfrastructureLanguage();

            if (OmitPropName != "InfrastructureID") infrastructureLanguage.InfrastructureID = 1;
            if (OmitPropName != "Language") infrastructureLanguage.Language = LanguageRequest;
            if (OmitPropName != "Comment") infrastructureLanguage.Comment = GetRandomString("", 20);
            if (OmitPropName != "TranslationStatus") infrastructureLanguage.TranslationStatus = (TranslationStatusEnum)GetRandomEnumType(typeof(TranslationStatusEnum));
            if (OmitPropName != "LastUpdateDate_UTC") infrastructureLanguage.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") infrastructureLanguage.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "InfrastructureLanguageID") infrastructureLanguage.InfrastructureLanguageID = 10000000;

                try
                {
                dbIM.Infrastructures.Add(new Infrastructure() { InfrastructureID = 1, InfrastructureTVItemID = 41, PrismID = null, TPID = 64, LSID = null, SiteID = 1593, Site = 14, InfrastructureCategory = "null", InfrastructureType = (InfrastructureTypeEnum)1, FacilityType = (FacilityTypeEnum)1, HasBackupPower = null, IsMechanicallyAerated = true, NumberOfCells = null, NumberOfAeratedCells = 2, AerationType = (AerationTypeEnum)1, PreliminaryTreatmentType = null, PrimaryTreatmentType = null, SecondaryTreatmentType = null, TertiaryTreatmentType = null, TreatmentType = (TreatmentTypeEnum)9, DisinfectionType = (DisinfectionTypeEnum)2, CollectionSystemType = null, AlarmSystemType = null, DesignFlow_m3_day = 2280, AverageFlow_m3_day = 1021, PeakFlow_m3_day = 2347, PopServed = 2383, CanOverflow = false, ValveType = null, PercFlowOfTotal = 100, TimeOffset_hour = -4, TempCatchAllRemoveLater = "               Year of assessment:	[]---              Design flow in m3/d:	2280---             Average flow in m3/d:	1021---                Peak flow in m3/d:	2347---           Estimated flow in m3/d:	[]---             Date of construction:	[]---           Date of recent upgrade:	[]---Number of visit to plant per week:	[]---                 Has alarm system:	[]---              Combined percentage:	[]---------Please add the contact info in the system------ Operator name:	Denny Richard---  Operator tel:	(506)  743-7318, Cell (506) 744-0837---Operator email:	---Infrastructure type:	WWTP------Disinfection Type Text---Chlorination and Dechlorination------Infrastructure Type Text---WWTP------Treatment Type Text---2 Cell Aerated Lagoon---", AverageDepth_m = 1, NumberOfPorts = 1, PortDiameter_m = 0.4, PortSpacing_m = 1000, PortElevation_m = 0.5, VerticalAngle_deg = null, HorizontalAngle_deg = 90, DecayRate_per_day = 4.6821, NearFieldVelocity_m_s = null, FarFieldVelocity_m_s = 0.18, ReceivingWaterSalinity_PSU = 28, ReceivingWaterTemperature_C = null, ReceivingWater_MPN_per_100ml = 2500000, DistanceFromShore_m = null, SeeOtherMunicipalityTVItemID = null, CivicAddressTVItemID = null, LastUpdateDate_UTC = new DateTime(2018, 7, 5, 19, 20, 50), LastUpdateContactTVItemID = 2 });
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
                try
                {
                dbIM.TVItems.Add(new TVItem() { TVItemID = 2, TVLevel = 1, TVPath = "p1p2", TVType = (TVTypeEnum)5, ParentID = 1, IsActive = true, LastUpdateDate_UTC = new DateTime(2014, 12, 2, 16, 58, 16), LastUpdateContactTVItemID = 2});
                    dbIM.SaveChanges();
                }
                catch (Exception)
                {
                   // nothing for now
                }
            }

            return infrastructureLanguage;
        }
        #endregion Functions private
    }
}
