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
using LoggedInServices;

namespace CSSPDBServices.Tests
{
    [Collection("Sequential")]
    public partial class ReportTypeDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private IReportTypeDBService ReportTypeDBService { get; set; }
        private CSSPDBContext db { get; set; }
        private ReportType reportType { get; set; }
        #endregion Properties

        #region Constructors
        public ReportTypeDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DB]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReportTypeDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            reportType = GetFilledRandomReportType("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReportType_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionReportTypeList = await ReportTypeDBService.GetReportTypeList();
            Assert.Equal(200, ((ObjectResult)actionReportTypeList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportTypeList.Result).Value);
            List<ReportType> reportTypeList = (List<ReportType>)((OkObjectResult)actionReportTypeList.Result).Value;

            count = reportTypeList.Count();

            ReportType reportType = GetFilledRandomReportType("");


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // reportType.ReportTypeID   (Int32)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.ReportTypeID = 0;

            var actionReportType = await ReportTypeDBService.Put(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.ReportTypeID = 10000000;
            actionReportType = await ReportTypeDBService.Put(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // reportType.TVType   (TVTypeEnum)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.TVType = (TVTypeEnum)1000000;
            actionReportType = await ReportTypeDBService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // reportType.FileType   (FileTypeEnum)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.FileType = (FileTypeEnum)1000000;
            actionReportType = await ReportTypeDBService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // reportType.UniqueCode   (String)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("UniqueCode");
            actionReportType = await ReportTypeDBService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.UniqueCode = GetRandomString("", 101);
            actionReportType = await ReportTypeDBService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);
            //Assert.AreEqual(count, reportTypeDBService.GetReportTypeList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // reportType.Language   (LanguageEnum)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.Language = (LanguageEnum)1000000;
            actionReportType = await ReportTypeDBService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(100)]
            // reportType.Name   (String)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.Name = GetRandomString("", 101);
            actionReportType = await ReportTypeDBService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);
            //Assert.AreEqual(count, reportTypeDBService.GetReportTypeList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(1000)]
            // reportType.Description   (String)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.Description = GetRandomString("", 1001);
            actionReportType = await ReportTypeDBService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);
            //Assert.AreEqual(count, reportTypeDBService.GetReportTypeList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(100)]
            // reportType.StartOfFileName   (String)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.StartOfFileName = GetRandomString("", 101);
            actionReportType = await ReportTypeDBService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);
            //Assert.AreEqual(count, reportTypeDBService.GetReportTypeList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // reportType.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.LastUpdateDate_UTC = new DateTime();
            actionReportType = await ReportTypeDBService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);
            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionReportType = await ReportTypeDBService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // reportType.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.LastUpdateContactTVItemID = 0;
            actionReportType = await ReportTypeDBService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.LastUpdateContactTVItemID = 1;
            actionReportType = await ReportTypeDBService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            db.Database.BeginTransaction();
            // Post ReportType
            var actionReportTypeAdded = await ReportTypeDBService.Post(reportType);
            Assert.Equal(200, ((ObjectResult)actionReportTypeAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportTypeAdded.Result).Value);
            ReportType reportTypeAdded = (ReportType)((OkObjectResult)actionReportTypeAdded.Result).Value;
            Assert.NotNull(reportTypeAdded);

            // List<ReportType>
            var actionReportTypeList = await ReportTypeDBService.GetReportTypeList();
            Assert.Equal(200, ((ObjectResult)actionReportTypeList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportTypeList.Result).Value);
            List<ReportType> reportTypeList = (List<ReportType>)((OkObjectResult)actionReportTypeList.Result).Value;

            int count = ((List<ReportType>)((OkObjectResult)actionReportTypeList.Result).Value).Count();
            Assert.True(count > 0);

            // List<ReportType> with skip and take
            var actionReportTypeListSkipAndTake = await ReportTypeDBService.GetReportTypeList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionReportTypeListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportTypeListSkipAndTake.Result).Value);
            List<ReportType> reportTypeListSkipAndTake = (List<ReportType>)((OkObjectResult)actionReportTypeListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<ReportType>)((OkObjectResult)actionReportTypeListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(reportTypeList[0].ReportTypeID == reportTypeListSkipAndTake[0].ReportTypeID);

            // Get ReportType With ReportTypeID
            var actionReportTypeGet = await ReportTypeDBService.GetReportTypeWithReportTypeID(reportTypeList[0].ReportTypeID);
            Assert.Equal(200, ((ObjectResult)actionReportTypeGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportTypeGet.Result).Value);
            ReportType reportTypeGet = (ReportType)((OkObjectResult)actionReportTypeGet.Result).Value;
            Assert.NotNull(reportTypeGet);
            Assert.Equal(reportTypeGet.ReportTypeID, reportTypeList[0].ReportTypeID);

            // Put ReportType
            var actionReportTypeUpdated = await ReportTypeDBService.Put(reportType);
            Assert.Equal(200, ((ObjectResult)actionReportTypeUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportTypeUpdated.Result).Value);
            ReportType reportTypeUpdated = (ReportType)((OkObjectResult)actionReportTypeUpdated.Result).Value;
            Assert.NotNull(reportTypeUpdated);

            // Delete ReportType
            var actionReportTypeDeleted = await ReportTypeDBService.Delete(reportType.ReportTypeID);
            Assert.Equal(200, ((ObjectResult)actionReportTypeDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportTypeDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionReportTypeDeleted.Result).Value;
            Assert.True(retBool);

            db.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("70c662c1-a1a8-4b2c-b594-d7834bb5e6db")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase(CSSPDBConnString);
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IReportTypeDBService, ReportTypeDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LoggedInService = Provider.GetService<ILoggedInService>();
            Assert.NotNull(LoggedInService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LoggedInService.SetLoggedInContactInfo(Id));

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            ReportTypeDBService = Provider.GetService<IReportTypeDBService>();
            Assert.NotNull(ReportTypeDBService);

            return await Task.FromResult(true);
        }
        private ReportType GetFilledRandomReportType(string OmitPropName)
        {
            ReportType reportType = new ReportType();

            if (OmitPropName != "TVType") reportType.TVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "FileType") reportType.FileType = (FileTypeEnum)GetRandomEnumType(typeof(FileTypeEnum));
            if (OmitPropName != "UniqueCode") reportType.UniqueCode = GetRandomString("", 5);
            if (OmitPropName != "Language") reportType.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "Name") reportType.Name = GetRandomString("", 5);
            if (OmitPropName != "Description") reportType.Description = GetRandomString("", 5);
            if (OmitPropName != "StartOfFileName") reportType.StartOfFileName = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") reportType.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") reportType.LastUpdateContactTVItemID = 2;



            return reportType;
        }
        private void CheckReportTypeFields(List<ReportType> reportTypeList)
        {
            Assert.False(string.IsNullOrWhiteSpace(reportTypeList[0].UniqueCode));
            if (reportTypeList[0].Language != null)
            {
                Assert.NotNull(reportTypeList[0].Language);
            }
            if (!string.IsNullOrWhiteSpace(reportTypeList[0].Name))
            {
                Assert.False(string.IsNullOrWhiteSpace(reportTypeList[0].Name));
            }
            if (!string.IsNullOrWhiteSpace(reportTypeList[0].Description))
            {
                Assert.False(string.IsNullOrWhiteSpace(reportTypeList[0].Description));
            }
            if (!string.IsNullOrWhiteSpace(reportTypeList[0].StartOfFileName))
            {
                Assert.False(string.IsNullOrWhiteSpace(reportTypeList[0].StartOfFileName));
            }
        }

        #endregion Functions private
    }
}
