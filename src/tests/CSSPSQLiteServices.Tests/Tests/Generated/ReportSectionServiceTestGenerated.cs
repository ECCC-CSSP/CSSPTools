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

namespace CSSPServices.Tests
{
    [Collection("Sequential")]
    public partial class ReportSectionServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IReportSectionService ReportSectionService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private CSSPDBInMemoryContext dbIM { get; set; }
        private ReportSection reportSection { get; set; }
        #endregion Properties

        #region Constructors
        public ReportSectionServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task ReportSection_CRUD_Good_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            reportSection = GetFilledRandomReportSection("");

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
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

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA", DBLocationEnum.Local)]
        [InlineData("fr-CA", DBLocationEnum.Local)]
        [InlineData("en-CA", DBLocationEnum.Server)]
        [InlineData("fr-CA", DBLocationEnum.Server)]
        public async Task ReportSection_Properties_Test(string culture, DBLocationEnum DBLocation)
        {
            // -------------------------------
            // -------------------------------
            // Properties testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            LoggedInService.DBLocation = DBLocation;

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionReportSectionList = await ReportSectionService.GetReportSectionList();
            Assert.Equal(200, ((ObjectResult)actionReportSectionList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportSectionList.Result).Value);
            List<ReportSection> reportSectionList = (List<ReportSection>)((OkObjectResult)actionReportSectionList.Result).Value;

            count = reportSectionList.Count();

            ReportSection reportSection = GetFilledRandomReportSection("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // reportSection.ReportSectionID   (Int32)
            // -----------------------------------

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.ReportSectionID = 0;

            var actionReportSection = await ReportSectionService.Put(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.ReportSectionID = 10000000;
            actionReportSection = await ReportSectionService.Put(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "ReportType", ExistPlurial = "s", ExistFieldID = "ReportTypeID", AllowableTVtypeList = )]
            // reportSection.ReportTypeID   (Int32)
            // -----------------------------------

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.ReportTypeID = 0;
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = )]
            // reportSection.TVItemID   (Int32)
            // -----------------------------------

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.TVItemID = 0;
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.TVItemID = 1;
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // reportSection.Language   (LanguageEnum)
            // -----------------------------------

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.Language = (LanguageEnum)1000000;
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 1000)]
            // reportSection.Ordinal   (Int32)
            // -----------------------------------

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.Ordinal = -1;
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);
            //Assert.AreEqual(count, reportSectionService.GetReportSectionList().Count());
            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.Ordinal = 1001;
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);
            //Assert.AreEqual(count, reportSectionService.GetReportSectionList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // reportSection.IsStatic   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "ReportSection", ExistPlurial = "s", ExistFieldID = "ReportSectionID", AllowableTVtypeList = )]
            // reportSection.ParentReportSectionID   (Int32)
            // -----------------------------------

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.ParentReportSectionID = 0;
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPRange(1979, 2050)]
            // reportSection.Year   (Int32)
            // -----------------------------------

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.Year = 1978;
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);
            //Assert.AreEqual(count, reportSectionService.GetReportSectionList().Count());
            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.Year = 2051;
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);
            //Assert.AreEqual(count, reportSectionService.GetReportSectionList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // reportSection.Locked   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "ReportSection", ExistPlurial = "s", ExistFieldID = "ReportSectionID", AllowableTVtypeList = )]
            // reportSection.TemplateReportSectionID   (Int32)
            // -----------------------------------

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.TemplateReportSectionID = 0;
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(100)]
            // reportSection.ReportSectionName   (String)
            // -----------------------------------

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.ReportSectionName = GetRandomString("", 101);
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);
            //Assert.AreEqual(count, reportSectionService.GetReportSectionList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(10000)]
            // reportSection.ReportSectionText   (String)
            // -----------------------------------

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.ReportSectionText = GetRandomString("", 10001);
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);
            //Assert.AreEqual(count, reportSectionService.GetReportSectionList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // reportSection.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.LastUpdateDate_UTC = new DateTime();
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);
            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // reportSection.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.LastUpdateContactTVItemID = 0;
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);

            reportSection = null;
            reportSection = GetFilledRandomReportSection("");
            reportSection.LastUpdateContactTVItemID = 1;
            actionReportSection = await ReportSectionService.Post(reportSection);
            Assert.IsType<BadRequestObjectResult>(actionReportSection.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDTest()
        {
            // Post ReportSection
            var actionReportSectionAdded = await ReportSectionService.Post(reportSection);
            Assert.Equal(200, ((ObjectResult)actionReportSectionAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportSectionAdded.Result).Value);
            ReportSection reportSectionAdded = (ReportSection)((OkObjectResult)actionReportSectionAdded.Result).Value;
            Assert.NotNull(reportSectionAdded);

            // List<ReportSection>
            var actionReportSectionList = await ReportSectionService.GetReportSectionList();
            Assert.Equal(200, ((ObjectResult)actionReportSectionList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportSectionList.Result).Value);
            List<ReportSection> reportSectionList = (List<ReportSection>)((OkObjectResult)actionReportSectionList.Result).Value;

            int count = ((List<ReportSection>)((OkObjectResult)actionReportSectionList.Result).Value).Count();
            Assert.True(count > 0);

            if (LoggedInService.DBLocation == DBLocationEnum.Server)
            {
                // List<ReportSection> with skip and take
                var actionReportSectionListSkipAndTake = await ReportSectionService.GetReportSectionList(1, 1);
                Assert.Equal(200, ((ObjectResult)actionReportSectionListSkipAndTake.Result).StatusCode);
                Assert.NotNull(((OkObjectResult)actionReportSectionListSkipAndTake.Result).Value);
                List<ReportSection> reportSectionListSkipAndTake = (List<ReportSection>)((OkObjectResult)actionReportSectionListSkipAndTake.Result).Value;

                int countSkipAndTake = ((List<ReportSection>)((OkObjectResult)actionReportSectionListSkipAndTake.Result).Value).Count();
                Assert.True(countSkipAndTake == 1);

                Assert.False(reportSectionList[0].ReportSectionID == reportSectionListSkipAndTake[0].ReportSectionID);
            }

            // Get ReportSection With ReportSectionID
            var actionReportSectionGet = await ReportSectionService.GetReportSectionWithReportSectionID(reportSectionList[0].ReportSectionID);
            Assert.Equal(200, ((ObjectResult)actionReportSectionGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportSectionGet.Result).Value);
            ReportSection reportSectionGet = (ReportSection)((OkObjectResult)actionReportSectionGet.Result).Value;
            Assert.NotNull(reportSectionGet);
            Assert.Equal(reportSectionGet.ReportSectionID, reportSectionList[0].ReportSectionID);

            // Put ReportSection
            var actionReportSectionUpdated = await ReportSectionService.Put(reportSection);
            Assert.Equal(200, ((ObjectResult)actionReportSectionUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportSectionUpdated.Result).Value);
            ReportSection reportSectionUpdated = (ReportSection)((OkObjectResult)actionReportSectionUpdated.Result).Value;
            Assert.NotNull(reportSectionUpdated);

            // Delete ReportSection
            var actionReportSectionDeleted = await ReportSectionService.Delete(reportSection.ReportSectionID);
            Assert.Equal(200, ((ObjectResult)actionReportSectionDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportSectionDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionReportSectionDeleted.Result).Value;
            Assert.True(retBool);
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspservicestests.json")
               .AddUserSecrets("6f27cbbe-6ffb-4154-b49b-d739597c4f60")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            string TestDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(TestDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(TestDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(TestDBConnString);
            });

            FileInfo fiAppDataPath = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiAppDataPath.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IReportSectionService, ReportSectionService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            LoggedInService.DBLocation = DBLocationEnum.Local;

            dbIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbIM);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            ReportSectionService = Provider.GetService<IReportSectionService>();
            Assert.NotNull(ReportSectionService);

            return await Task.FromResult(true);
        }
        private ReportSection GetFilledRandomReportSection(string OmitPropName)
        {
            List<ReportSection> reportSectionListToDelete = (from c in dbLocal.ReportSections
                                                               select c).ToList(); 
            
            dbLocal.ReportSections.RemoveRange(reportSectionListToDelete);
            try
            {
                dbLocal.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, ex.Message);
            }
            
            dbIM.Database.EnsureDeleted();

            ReportSection reportSection = new ReportSection();

            if (OmitPropName != "ReportTypeID") reportSection.ReportTypeID = 1;
            // Need to implement (no items found, would need to add at least one in the TestDB) [ReportSection TVItemID TVItem TVItemID]
            if (OmitPropName != "Language") reportSection.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "Ordinal") reportSection.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "IsStatic") reportSection.IsStatic = true;
            // Need to implement [ReportSection ParentReportSectionID ReportSection ReportSectionID]
            if (OmitPropName != "Year") reportSection.Year = GetRandomInt(1979, 2050);
            if (OmitPropName != "Locked") reportSection.Locked = true;
            // Need to implement [ReportSection TemplateReportSectionID ReportSection ReportSectionID]
            if (OmitPropName != "ReportSectionName") reportSection.ReportSectionName = GetRandomString("", 5);
            if (OmitPropName != "ReportSectionText") reportSection.ReportSectionText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") reportSection.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") reportSection.LastUpdateContactTVItemID = 2;

            if (LoggedInService.DBLocation == DBLocationEnum.Local)
            {
                if (OmitPropName != "ReportSectionID") reportSection.ReportSectionID = 10000000;

                try
                {
                    dbIM.ReportTypes.Add(new ReportType() { ReportTypeID = 1, TVType = (TVTypeEnum)20, FileType = (FileTypeEnum)11, UniqueCode = "FCSummaryStatENDOCX", Language = (LanguageEnum)1, Name = "FC summary statistics", Description = "Summary statistics of FC densities", StartOfFileName = "{subsector}_{year}_Summary_Stat_FC_{datecreated}_en", LastUpdateDate_UTC = new DateTime(2017, 11, 15, 14, 27, 14), LastUpdateContactTVItemID = 2 });
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

            return reportSection;
        }
        private void CheckReportSectionFields(List<ReportSection> reportSectionList)
        {
            if (reportSectionList[0].TVItemID != null)
            {
                Assert.NotNull(reportSectionList[0].TVItemID);
            }
            if (reportSectionList[0].Language != null)
            {
                Assert.NotNull(reportSectionList[0].Language);
            }
            if (reportSectionList[0].ParentReportSectionID != null)
            {
                Assert.NotNull(reportSectionList[0].ParentReportSectionID);
            }
            if (reportSectionList[0].Year != null)
            {
                Assert.NotNull(reportSectionList[0].Year);
            }
            if (reportSectionList[0].TemplateReportSectionID != null)
            {
                Assert.NotNull(reportSectionList[0].TemplateReportSectionID);
            }
            if (!string.IsNullOrWhiteSpace(reportSectionList[0].ReportSectionName))
            {
                Assert.False(string.IsNullOrWhiteSpace(reportSectionList[0].ReportSectionName));
            }
            if (!string.IsNullOrWhiteSpace(reportSectionList[0].ReportSectionText))
            {
                Assert.False(string.IsNullOrWhiteSpace(reportSectionList[0].ReportSectionText));
            }
        }
        #endregion Functions private
    }
}
