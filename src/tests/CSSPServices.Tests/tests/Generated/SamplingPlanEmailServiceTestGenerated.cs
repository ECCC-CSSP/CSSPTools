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
    public partial class SamplingPlanEmailServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ISamplingPlanEmailService SamplingPlanEmailService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private InMemoryDBContext dbIM { get; set; }
        private SamplingPlanEmail samplingPlanEmail { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanEmailServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", "true")]
        [InlineData("fr-CA", "true")]
        [InlineData("en-CA", "false")]
        [InlineData("fr-CA", "false")]
        public async Task SamplingPlanEmail_CRUD_Good_Test(string culture, string IsLocalStr)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.IsLocal = bool.Parse(IsLocalStr);

            samplingPlanEmail = GetFilledRandomSamplingPlanEmail("");

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
            // Post SamplingPlanEmail
            var actionSamplingPlanEmailAdded = await SamplingPlanEmailService.Post(samplingPlanEmail);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailAdded.Result).Value);
            SamplingPlanEmail samplingPlanEmailAdded = (SamplingPlanEmail)((OkObjectResult)actionSamplingPlanEmailAdded.Result).Value;
            Assert.NotNull(samplingPlanEmailAdded);

            // List<SamplingPlanEmail>
            var actionSamplingPlanEmailList = await SamplingPlanEmailService.GetSamplingPlanEmailList();
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailList.Result).Value);
            List<SamplingPlanEmail> samplingPlanEmailList = (List<SamplingPlanEmail>)((OkObjectResult)actionSamplingPlanEmailList.Result).Value;

            int count = ((List<SamplingPlanEmail>)((OkObjectResult)actionSamplingPlanEmailList.Result).Value).Count();
            Assert.True(count > 0);

            // Put SamplingPlanEmail
            var actionSamplingPlanEmailUpdated = await SamplingPlanEmailService.Put(samplingPlanEmail);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailUpdated.Result).Value);
            SamplingPlanEmail samplingPlanEmailUpdated = (SamplingPlanEmail)((OkObjectResult)actionSamplingPlanEmailUpdated.Result).Value;
            Assert.NotNull(samplingPlanEmailUpdated);

            // Delete SamplingPlanEmail
            var actionSamplingPlanEmailDeleted = await SamplingPlanEmailService.Delete(samplingPlanEmail.SamplingPlanEmailID);
            Assert.Equal(200, ((ObjectResult)actionSamplingPlanEmailDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionSamplingPlanEmailDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionSamplingPlanEmailDeleted.Result).Value;
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
            Services.AddSingleton<ISamplingPlanEmailService, SamplingPlanEmailService>();

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

            SamplingPlanEmailService = Provider.GetService<ISamplingPlanEmailService>();
            Assert.NotNull(SamplingPlanEmailService);

            return await Task.FromResult(true);
        }
        private SamplingPlanEmail GetFilledRandomSamplingPlanEmail(string OmitPropName)
        {
            List<SamplingPlanEmail> samplingPlanEmailListToDelete = (from c in dbLocal.SamplingPlanEmails
                                                               select c).ToList(); 
            
            dbLocal.SamplingPlanEmails.RemoveRange(samplingPlanEmailListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            SamplingPlanEmail samplingPlanEmail = new SamplingPlanEmail();

            if (OmitPropName != "SamplingPlanID") samplingPlanEmail.SamplingPlanID = 1;
            if (OmitPropName != "Email") samplingPlanEmail.Email = GetRandomEmail();
            if (OmitPropName != "IsContractor") samplingPlanEmail.IsContractor = true;
            if (OmitPropName != "LabSheetHasValueOver500") samplingPlanEmail.LabSheetHasValueOver500 = true;
            if (OmitPropName != "LabSheetReceived") samplingPlanEmail.LabSheetReceived = true;
            if (OmitPropName != "LabSheetAccepted") samplingPlanEmail.LabSheetAccepted = true;
            if (OmitPropName != "LabSheetRejected") samplingPlanEmail.LabSheetRejected = true;
            if (OmitPropName != "LastUpdateDate_UTC") samplingPlanEmail.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") samplingPlanEmail.LastUpdateContactTVItemID = 2;

            if (LoggedInService.IsLocal)
            {
                if (OmitPropName != "SamplingPlanEmailID") samplingPlanEmail.SamplingPlanEmailID = 10000000;

                try
                {
                dbIM.SamplingPlans.Add(new SamplingPlan() { SamplingPlanID = 1, IsActive = false, SamplingPlanName = @"C:\CSSPLabSheets\SamplingPlan_Subsector_Routine_A1_2019_a_aa.txt", ForGroupName = "a_aa", SampleType = (SampleTypeEnum)109, SamplingPlanType = (SamplingPlanTypeEnum)1, LabSheetType = (LabSheetTypeEnum)1, ProvinceTVItemID = 6, CreatorTVItemID = 2, Year = 2019, AccessCode = "Microlab12", DailyDuplicatePrecisionCriteria = 0.6872000098228455, IntertechDuplicatePrecisionCriteria = 0.09300000220537186, IncludeLaboratoryQAQC = false, ApprovalCode = "aaabbb", SamplingPlanFileTVItemID = 49, AnalyzeMethodDefault = (AnalyzeMethodEnum)6, SampleMatrixDefault = (SampleMatrixEnum)7, LaboratoryDefault = (LaboratoryEnum)19, BackupDirectory = @"\\Atlantic.int.ec.gc.ca\shares\Branches\EPB\ShellFish\CSSPTools\CSSPLabSheets\", LastUpdateDate_UTC = new DateTime(2019, 1, 28, 15, 15, 42), LastUpdateContactTVItemID = 2 });
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

            return samplingPlanEmail;
        }
        #endregion Functions private
    }
}
