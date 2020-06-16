/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CultureServices.Services;
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
    public partial class ReportSectionServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private IReportSectionService ReportSectionService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public ReportSectionServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ReportSection_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               ReportSection reportSection = GetFilledRandomReportSection(""); 

               // List<ReportSection>
               var actionReportSectionList = await ReportSectionService.GetReportSectionList();
               Assert.Equal(200, ((ObjectResult)actionReportSectionList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionReportSectionList.Result).Value);
               List<ReportSection> reportSectionList = (List<ReportSection>)((OkObjectResult)actionReportSectionList.Result).Value;

               int count = ((List<ReportSection>)((OkObjectResult)actionReportSectionList.Result).Value).Count();
                Assert.True(count > 0);

               // Post ReportSection
               var actionReportSectionAdded = await ReportSectionService.Post(reportSection);
               Assert.Equal(200, ((ObjectResult)actionReportSectionAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionReportSectionAdded.Result).Value);
               ReportSection reportSectionAdded = (ReportSection)((OkObjectResult)actionReportSectionAdded.Result).Value;
               Assert.NotNull(reportSectionAdded);

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
        }
        #endregion Tests Generated CRUD

        #region Functions private
        private async Task<bool> Setup(string culture)
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

            Services.AddSingleton<ICultureService, CultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IReportSectionService, ReportSectionService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            ReportSectionService = Provider.GetService<IReportSectionService>();
            Assert.NotNull(ReportSectionService);

            return await Task.FromResult(true);
        }
        private ReportSection GetFilledRandomReportSection(string OmitPropName)
        {
            ReportSection reportSection = new ReportSection();

            if (OmitPropName != "ReportTypeID") reportSection.ReportTypeID = 1;
            // Need to implement (no items found, would need to add at least one in the TestDB) [ReportSection TVItemID TVItem TVItemID]
            if (OmitPropName != "Language") reportSection.Language = LanguageRequest;
            if (OmitPropName != "Ordinal") reportSection.Ordinal = GetRandomInt(0, 1000);
            if (OmitPropName != "IsStatic") reportSection.IsStatic = true;
            if (OmitPropName != "ParentReportSectionID") reportSection.ParentReportSectionID = 1;
            if (OmitPropName != "Year") reportSection.Year = GetRandomInt(1979, 2050);
            if (OmitPropName != "Locked") reportSection.Locked = true;
            if (OmitPropName != "TemplateReportSectionID") reportSection.TemplateReportSectionID = 1;
            if (OmitPropName != "ReportSectionName") reportSection.ReportSectionName = GetRandomString("", 5);
            if (OmitPropName != "ReportSectionText") reportSection.ReportSectionText = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") reportSection.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") reportSection.LastUpdateContactTVItemID = 2;

            return reportSection;
        }
        #endregion Functions private
    }
}
