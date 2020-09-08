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
using LocalServices;

namespace CSSPDBLocalIMServices.Tests
{
    [Collection("Sequential")]
    public partial class ReportTypeDBLocalIMServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private IReportTypeDBLocalIMService ReportTypeDBLocalIMService { get; set; }
        private CSSPDBInMemoryContext dbLocalIM { get; set; }
        private ReportType reportType { get; set; }
        #endregion Properties

        #region Constructors
        public ReportTypeDBLocalIMServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated [DBLocalIM]CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task ReportTypeDBLocalIM_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            reportType = GetFilledRandomReportType("");

            await DoCRUDDBLocalIMTest();
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

            var actionReportTypeList = await ReportTypeDBLocalIMService.GetReportTypeList();
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

            var actionReportType = await ReportTypeDBLocalIMService.Put(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.ReportTypeID = 10000000;
            actionReportType = await ReportTypeDBLocalIMService.Put(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // reportType.TVType   (TVTypeEnum)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.TVType = (TVTypeEnum)1000000;
            actionReportType = await ReportTypeDBLocalIMService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // reportType.FileType   (FileTypeEnum)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.FileType = (FileTypeEnum)1000000;
            actionReportType = await ReportTypeDBLocalIMService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(100)]
            // reportType.UniqueCode   (String)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("UniqueCode");
            actionReportType = await ReportTypeDBLocalIMService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.UniqueCode = GetRandomString("", 101);
            actionReportType = await ReportTypeDBLocalIMService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);
            //Assert.AreEqual(count, reportTypeDBLocalIMService.GetReportTypeList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // reportType.Language   (LanguageEnum)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.Language = (LanguageEnum)1000000;
            actionReportType = await ReportTypeDBLocalIMService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(100)]
            // reportType.Name   (String)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.Name = GetRandomString("", 101);
            actionReportType = await ReportTypeDBLocalIMService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);
            //Assert.AreEqual(count, reportTypeDBLocalIMService.GetReportTypeList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(1000)]
            // reportType.Description   (String)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.Description = GetRandomString("", 1001);
            actionReportType = await ReportTypeDBLocalIMService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);
            //Assert.AreEqual(count, reportTypeDBLocalIMService.GetReportTypeList().Count());

            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(100)]
            // reportType.StartOfFileName   (String)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.StartOfFileName = GetRandomString("", 101);
            actionReportType = await ReportTypeDBLocalIMService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);
            //Assert.AreEqual(count, reportTypeDBLocalIMService.GetReportTypeList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // reportType.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.LastUpdateDate_UTC = new DateTime();
            actionReportType = await ReportTypeDBLocalIMService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);
            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionReportType = await ReportTypeDBLocalIMService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // reportType.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.LastUpdateContactTVItemID = 0;
            actionReportType = await ReportTypeDBLocalIMService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);

            reportType = null;
            reportType = GetFilledRandomReportType("");
            reportType.LastUpdateContactTVItemID = 1;
            actionReportType = await ReportTypeDBLocalIMService.Post(reportType);
            Assert.IsType<BadRequestObjectResult>(actionReportType.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBLocalIMTest()
        {
            reportType.ReportTypeID = 10000000;

            // Post ReportType
            var actionReportTypeAdded = await ReportTypeDBLocalIMService.Post(reportType);
            Assert.Equal(200, ((ObjectResult)actionReportTypeAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportTypeAdded.Result).Value);
            ReportType reportTypeAdded = (ReportType)((OkObjectResult)actionReportTypeAdded.Result).Value;
            Assert.NotNull(reportTypeAdded);

            // List<ReportType>
            var actionReportTypeList = await ReportTypeDBLocalIMService.GetReportTypeList();
            Assert.Equal(200, ((ObjectResult)actionReportTypeList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportTypeList.Result).Value);
            List<ReportType> reportTypeList = (List<ReportType>)((OkObjectResult)actionReportTypeList.Result).Value;

            int count = ((List<ReportType>)((OkObjectResult)actionReportTypeList.Result).Value).Count();
            Assert.True(count > 0);

            // Get ReportType With ReportTypeID
            var actionReportTypeGet = await ReportTypeDBLocalIMService.GetReportTypeWithReportTypeID(reportTypeList[0].ReportTypeID);
            Assert.Equal(200, ((ObjectResult)actionReportTypeGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportTypeGet.Result).Value);
            ReportType reportTypeGet = (ReportType)((OkObjectResult)actionReportTypeGet.Result).Value;
            Assert.NotNull(reportTypeGet);
            Assert.Equal(reportTypeGet.ReportTypeID, reportTypeList[0].ReportTypeID);

            // Put ReportType
            var actionReportTypeUpdated = await ReportTypeDBLocalIMService.Put(reportType);
            Assert.Equal(200, ((ObjectResult)actionReportTypeUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportTypeUpdated.Result).Value);
            ReportType reportTypeUpdated = (ReportType)((OkObjectResult)actionReportTypeUpdated.Result).Value;
            Assert.NotNull(reportTypeUpdated);

            // Delete ReportType
            var actionReportTypeDeleted = await ReportTypeDBLocalIMService.Delete(reportType.ReportTypeID);
            Assert.Equal(200, ((ObjectResult)actionReportTypeDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionReportTypeDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionReportTypeDeleted.Result).Value;
            Assert.True(retBool);

        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalimservicestests.json")
               .AddUserSecrets("64a6d1e4-0d0c-4e59-9c2e-640182417704")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBLoginFileName = Config.GetValue<string>("CSSPDBLogin");
            Assert.NotNull(CSSPDBLoginFileName);

            FileInfo fiCSSPDBLogin = new FileInfo(CSSPDBLoginFileName);

            Services.AddDbContext<CSSPDBLoginContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            Services.AddDbContext<CSSPDBLoginInMemoryContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLogin.FullName }");
            });

            string CSSPDBLocalFileName = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocalFileName);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocalFileName);

            Services.AddDbContext<CSSPDBInMemoryContext>(options =>
            {
                options.UseInMemoryDatabase($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IReportTypeDBLocalIMService, ReportTypeDBLocalIMService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocalIM = Provider.GetService<CSSPDBInMemoryContext>();
            Assert.NotNull(dbLocalIM);

            ReportTypeDBLocalIMService = Provider.GetService<IReportTypeDBLocalIMService>();
            Assert.NotNull(ReportTypeDBLocalIMService);

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
