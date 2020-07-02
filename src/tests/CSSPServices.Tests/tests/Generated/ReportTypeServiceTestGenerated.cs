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
    public partial class ReportTypeServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICultureService CultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IReportTypeService ReportTypeService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public ReportTypeServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated CRUD
        [Theory]
        [InlineData("en-CA")]
        [InlineData("fr-CA")]
        public async Task ReportType_CRUD_Good_Test(string culture)
        {
            // -------------------------------
            // -------------------------------
            // CRUD testing
            // -------------------------------
            // -------------------------------

            Assert.True(await Setup(culture));

            using (TransactionScope ts = new TransactionScope())
            {
               ReportType reportType = GetFilledRandomReportType(""); 

               // List<ReportType>
               var actionReportTypeList = await ReportTypeService.GetReportTypeList();
               Assert.Equal(200, ((ObjectResult)actionReportTypeList.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionReportTypeList.Result).Value);
               List<ReportType> reportTypeList = (List<ReportType>)((OkObjectResult)actionReportTypeList.Result).Value;

               int count = ((List<ReportType>)((OkObjectResult)actionReportTypeList.Result).Value).Count();
                Assert.True(count > 0);

               // Post ReportType
               var actionReportTypeAdded = await ReportTypeService.Post(reportType);
               Assert.Equal(200, ((ObjectResult)actionReportTypeAdded.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionReportTypeAdded.Result).Value);
               ReportType reportTypeAdded = (ReportType)((OkObjectResult)actionReportTypeAdded.Result).Value;
               Assert.NotNull(reportTypeAdded);

               // Put ReportType
               var actionReportTypeUpdated = await ReportTypeService.Put(reportType);
               Assert.Equal(200, ((ObjectResult)actionReportTypeUpdated.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionReportTypeUpdated.Result).Value);
               ReportType reportTypeUpdated = (ReportType)((OkObjectResult)actionReportTypeUpdated.Result).Value;
               Assert.NotNull(reportTypeUpdated);

               // Delete ReportType
               var actionReportTypeDeleted = await ReportTypeService.Delete(reportType.ReportTypeID);
               Assert.Equal(200, ((ObjectResult)actionReportTypeDeleted.Result).StatusCode);
               Assert.NotNull(((OkObjectResult)actionReportTypeDeleted.Result).Value);
               bool retBool = (bool)((OkObjectResult)actionReportTypeDeleted.Result).Value;
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
            Services.AddSingleton<IReportTypeService, ReportTypeService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CultureService = Provider.GetService<ICultureService>();
            Assert.NotNull(CultureService);

            CultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            ReportTypeService = Provider.GetService<IReportTypeService>();
            Assert.NotNull(ReportTypeService);

            return await Task.FromResult(true);
        }
        private ReportType GetFilledRandomReportType(string OmitPropName)
        {
            ReportType reportType = new ReportType();

            if (OmitPropName != "TVType") reportType.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "FileType") reportType.FileType = (FileTypeEnum)GetRandomEnumType(typeof(FileTypeEnum));
            if (OmitPropName != "UniqueCode") reportType.UniqueCode = GetRandomString("", 5);
            if (OmitPropName != "Language") reportType.Language = LanguageRequest;
            if (OmitPropName != "Name") reportType.Name = GetRandomString("", 5);
            if (OmitPropName != "Description") reportType.Description = GetRandomString("", 5);
            if (OmitPropName != "StartOfFileName") reportType.StartOfFileName = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") reportType.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") reportType.LastUpdateContactTVItemID = 2;

            return reportType;
        }
        #endregion Functions private
    }
}
