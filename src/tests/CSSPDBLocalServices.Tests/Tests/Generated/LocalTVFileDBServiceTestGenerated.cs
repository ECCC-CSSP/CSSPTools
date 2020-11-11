/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\GenerateCSSPDBLocalServices_Tests.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPDBLocalModels;
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
using CSSPDBModels;

namespace CSSPDBLocalServices.Tests
{
    [Collection("Sequential")]
    public partial class LocalTVFileDBServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Config { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private ILocalService LocalService { get; set; }
        private ILocalTVFileDBService LocalTVFileDBService { get; set; }
        private CSSPDBLocalContext dbLocal { get; set; }
        private LocalTVFile localTVFile { get; set; }
        #endregion Properties

        #region Constructors
        public LocalTVFileDBServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Tests Generated Constructor [DB]
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalTVFileDB_Constructor_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));
        }
        #endregion Tests Generated Constructor [DB]

        #region Tests Generated [DB] CRUD
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalTVFileDB_CRUD_Good_Test(string culture)
        {
            Assert.True(await Setup(culture));

            localTVFile = GetFilledRandomLocalTVFile("");

            await DoCRUDDBTest();
        }
        #endregion Tests Generated [DB] CRUD

        #region Tests Generated Properties
        [Theory]
        [InlineData("en-CA")]
        //[InlineData("fr-CA")]
        public async Task LocalTVFile_Properties_Test(string culture)
        {
            Assert.True(await Setup(culture));

            int count = 0;
            if (count == 1)
            {
                // just so we don't get a warning during compile [The variable 'count' is assigned but its value is never used]
            }

            var actionLocalTVFileList = await LocalTVFileDBService.GetLocalTVFileList();
            Assert.Equal(200, ((ObjectResult)actionLocalTVFileList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVFileList.Result).Value);
            List<LocalTVFile> localTVFileList = (List<LocalTVFile>)((OkObjectResult)actionLocalTVFileList.Result).Value;

            count = localTVFileList.Count();

            LocalTVFile localTVFile = GetFilledRandomLocalTVFile("");


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localTVFile.LocalDBCommand   (LocalDBCommandEnum)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.LocalDBCommand = (LocalDBCommandEnum)1000000;
            var actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);


            // -----------------------------------
            // [Key]
            // Is NOT Nullable
            // localTVFile.TVFileID   (Int32)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.TVFileID = 0;

            actionLocalTVFile = await LocalTVFileDBService.Put(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.TVFileID = 10000000;
            actionLocalTVFile = await LocalTVFileDBService.Put(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = File)]
            // localTVFile.TVFileTVItemID   (Int32)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.TVFileTVItemID = 0;
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.TVFileTVItemID = 1;
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPEnumType]
            // localTVFile.TemplateTVType   (TVTypeEnum)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.TemplateTVType = (TVTypeEnum)1000000;
             actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);


            // -----------------------------------
            // Is Nullable
            // [CSSPExist(ExistTypeName = "ReportType", ExistPlurial = "s", ExistFieldID = "ReportTypeID", AllowableTVtypeList = )]
            // localTVFile.ReportTypeID   (Int32)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.ReportTypeID = 0;
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);


            // -----------------------------------
            // Is Nullable
            // localTVFile.Parameters   (String)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPRange(1980, 2050)]
            // localTVFile.Year   (Int32)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.Year = 1979;
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);
            //Assert.AreEqual(count, localTVFileService.GetLocalTVFileList().Count());
            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.Year = 2051;
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);
            //Assert.AreEqual(count, localTVFileDBService.GetLocalTVFileList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localTVFile.Language   (LanguageEnum)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.Language = (LanguageEnum)1000000;
             actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localTVFile.FilePurpose   (FilePurposeEnum)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.FilePurpose = (FilePurposeEnum)1000000;
             actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPEnumType]
            // localTVFile.FileType   (FileTypeEnum)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.FileType = (FileTypeEnum)1000000;
             actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPRange(0, 100000000)]
            // localTVFile.FileSize_kb   (Int32)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.FileSize_kb = -1;
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);
            //Assert.AreEqual(count, localTVFileService.GetLocalTVFileList().Count());
            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.FileSize_kb = 100000001;
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);
            //Assert.AreEqual(count, localTVFileDBService.GetLocalTVFileList().Count());

            // -----------------------------------
            // Is Nullable
            // localTVFile.FileInfo   (String)
            // -----------------------------------


            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localTVFile.FileCreatedDate_UTC   (DateTime)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.FileCreatedDate_UTC = new DateTime();
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);
            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.FileCreatedDate_UTC = new DateTime(1979, 1, 1);
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);

            // -----------------------------------
            // Is Nullable
            // localTVFile.FromWater   (Boolean)
            // -----------------------------------


            // -----------------------------------
            // Is Nullable
            // [CSSPMaxLength(250)]
            // localTVFile.ClientFilePath   (String)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.ClientFilePath = GetRandomString("", 251);
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);
            //Assert.AreEqual(count, localTVFileDBService.GetLocalTVFileList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // localTVFile.ServerFileName   (String)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("ServerFileName");
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.ServerFileName = GetRandomString("", 251);
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);
            //Assert.AreEqual(count, localTVFileDBService.GetLocalTVFileList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPMaxLength(250)]
            // localTVFile.ServerFilePath   (String)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("ServerFilePath");
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.ServerFilePath = GetRandomString("", 251);
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);
            //Assert.AreEqual(count, localTVFileDBService.GetLocalTVFileList().Count());

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPAfter(Year = 1980)]
            // localTVFile.LastUpdateDate_UTC   (DateTime)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.LastUpdateDate_UTC = new DateTime();
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);
            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.LastUpdateDate_UTC = new DateTime(1979, 1, 1);
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);

            // -----------------------------------
            // Is NOT Nullable
            // [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVtypeList = Contact)]
            // localTVFile.LastUpdateContactTVItemID   (Int32)
            // -----------------------------------

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.LastUpdateContactTVItemID = 0;
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);

            localTVFile = null;
            localTVFile = GetFilledRandomLocalTVFile("");
            localTVFile.LastUpdateContactTVItemID = 1;
            actionLocalTVFile = await LocalTVFileDBService.Post(localTVFile);
            Assert.IsType<BadRequestObjectResult>(actionLocalTVFile.Result);

        }
        #endregion Tests Generated Properties

        #region Functions private
        private async Task DoCRUDDBTest()
        {
            dbLocal.Database.BeginTransaction();
            // Post LocalTVFile
            var actionLocalTVFileAdded = await LocalTVFileDBService.Post(localTVFile);
            Assert.Equal(200, ((ObjectResult)actionLocalTVFileAdded.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVFileAdded.Result).Value);
            LocalTVFile localTVFileAdded = (LocalTVFile)((OkObjectResult)actionLocalTVFileAdded.Result).Value;
            Assert.NotNull(localTVFileAdded);

            // List<LocalTVFile>
            var actionLocalTVFileList = await LocalTVFileDBService.GetLocalTVFileList();
            Assert.Equal(200, ((ObjectResult)actionLocalTVFileList.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVFileList.Result).Value);
            List<LocalTVFile> localTVFileList = (List<LocalTVFile>)((OkObjectResult)actionLocalTVFileList.Result).Value;

            int count = ((List<LocalTVFile>)((OkObjectResult)actionLocalTVFileList.Result).Value).Count();
            Assert.True(count > 0);

            // List<LocalTVFile> with skip and take
            var actionLocalTVFileListSkipAndTake = await LocalTVFileDBService.GetLocalTVFileList(1, 1);
            Assert.Equal(200, ((ObjectResult)actionLocalTVFileListSkipAndTake.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVFileListSkipAndTake.Result).Value);
            List<LocalTVFile> localTVFileListSkipAndTake = (List<LocalTVFile>)((OkObjectResult)actionLocalTVFileListSkipAndTake.Result).Value;

            int countSkipAndTake = ((List<LocalTVFile>)((OkObjectResult)actionLocalTVFileListSkipAndTake.Result).Value).Count();
            Assert.True(countSkipAndTake == 1);

            Assert.False(localTVFileList[0].TVFileID == localTVFileListSkipAndTake[0].TVFileID);

            // Get LocalTVFile With TVFileID
            var actionLocalTVFileGet = await LocalTVFileDBService.GetLocalTVFileWithTVFileID(localTVFileList[0].TVFileID);
            Assert.Equal(200, ((ObjectResult)actionLocalTVFileGet.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVFileGet.Result).Value);
            LocalTVFile localTVFileGet = (LocalTVFile)((OkObjectResult)actionLocalTVFileGet.Result).Value;
            Assert.NotNull(localTVFileGet);
            Assert.Equal(localTVFileGet.TVFileID, localTVFileList[0].TVFileID);

            // Put LocalTVFile
            var actionLocalTVFileUpdated = await LocalTVFileDBService.Put(localTVFile);
            Assert.Equal(200, ((ObjectResult)actionLocalTVFileUpdated.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVFileUpdated.Result).Value);
            LocalTVFile localTVFileUpdated = (LocalTVFile)((OkObjectResult)actionLocalTVFileUpdated.Result).Value;
            Assert.NotNull(localTVFileUpdated);

            // Delete LocalTVFile
            var actionLocalTVFileDeleted = await LocalTVFileDBService.Delete(localTVFile.TVFileID);
            Assert.Equal(200, ((ObjectResult)actionLocalTVFileDeleted.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionLocalTVFileDeleted.Result).Value);
            bool retBool = (bool)((OkObjectResult)actionLocalTVFileDeleted.Result).Value;
            Assert.True(retBool);

            dbLocal.Database.RollbackTransaction();
        }
        private async Task<bool> Setup(string culture)
        {
            Config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdbservicestests.json")
               .AddUserSecrets("91a273aa-0169-4298-82eb-86ff2429a2f8")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Config);

            string CSSPDBConnString = Config.GetValue<string>("TestDB");
            Assert.NotNull(CSSPDBConnString);

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            /* ---------------------------------------------------------------------------------
             * using CSSPDBLocalContext
             * ---------------------------------------------------------------------------------      
             */
            string CSSPDBLocal = Config.GetValue<string>("CSSPDBLocal");
            Assert.NotNull(CSSPDBLocal);

            FileInfo fiCSSPDBLocal = new FileInfo(CSSPDBLocal);

            Services.AddDbContext<CSSPDBLocalContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBLocal.FullName }");
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ILocalService, LocalService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILocalTVFileDBService, LocalTVFileDBService>();

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            LocalService = Provider.GetService<ILocalService>();
            Assert.NotNull(LocalService);

            string Id = Config.GetValue<string>("Id");
            Assert.True(await LocalService.SetLoggedInContactInfo());

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            LocalTVFileDBService = Provider.GetService<ILocalTVFileDBService>();
            Assert.NotNull(LocalTVFileDBService);

            return await Task.FromResult(true);
        }
        private LocalTVFile GetFilledRandomLocalTVFile(string OmitPropName)
        {
            LocalTVFile localTVFile = new LocalTVFile();

            if (OmitPropName != "LocalDBCommand") localTVFile.LocalDBCommand = (LocalDBCommandEnum)GetRandomEnumType(typeof(LocalDBCommandEnum));
            if (OmitPropName != "TVFileTVItemID") localTVFile.TVFileTVItemID = 42;
            if (OmitPropName != "TemplateTVType") localTVFile.TemplateTVType = (TVTypeEnum)GetRandomEnumType(typeof(TVTypeEnum));
            if (OmitPropName != "ReportTypeID") localTVFile.ReportTypeID = 0;
            if (OmitPropName != "Parameters") localTVFile.Parameters = GetRandomString("", 20);
            if (OmitPropName != "Year") localTVFile.Year = GetRandomInt(1980, 2050);
            if (OmitPropName != "Language") localTVFile.Language = CSSPCultureServicesRes.Culture.TwoLetterISOLanguageName == "fr" ? LanguageEnum.fr : LanguageEnum.en;
            if (OmitPropName != "FilePurpose") localTVFile.FilePurpose = (FilePurposeEnum)GetRandomEnumType(typeof(FilePurposeEnum));
            if (OmitPropName != "FileType") localTVFile.FileType = (FileTypeEnum)GetRandomEnumType(typeof(FileTypeEnum));
            if (OmitPropName != "FileSize_kb") localTVFile.FileSize_kb = GetRandomInt(0, 100000000);
            if (OmitPropName != "FileInfo") localTVFile.FileInfo = GetRandomString("", 20);
            if (OmitPropName != "FileCreatedDate_UTC") localTVFile.FileCreatedDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "FromWater") localTVFile.FromWater = true;
            if (OmitPropName != "ClientFilePath") localTVFile.ClientFilePath = GetRandomString("", 5);
            if (OmitPropName != "ServerFileName") localTVFile.ServerFileName = GetRandomString("", 5);
            if (OmitPropName != "ServerFilePath") localTVFile.ServerFilePath = GetRandomString("", 5);
            if (OmitPropName != "LastUpdateDate_UTC") localTVFile.LastUpdateDate_UTC = new DateTime(2005, 3, 6);
            if (OmitPropName != "LastUpdateContactTVItemID") localTVFile.LastUpdateContactTVItemID = 2;



            return localTVFile;
        }
        private void CheckLocalTVFileFields(List<LocalTVFile> localTVFileList)
        {
            if (localTVFileList[0].TemplateTVType != null)
            {
                Assert.NotNull(localTVFileList[0].TemplateTVType);
            }
            if (localTVFileList[0].ReportTypeID != null)
            {
                Assert.NotNull(localTVFileList[0].ReportTypeID);
            }
            if (!string.IsNullOrWhiteSpace(localTVFileList[0].Parameters))
            {
                Assert.False(string.IsNullOrWhiteSpace(localTVFileList[0].Parameters));
            }
            if (localTVFileList[0].Year != null)
            {
                Assert.NotNull(localTVFileList[0].Year);
            }
            if (!string.IsNullOrWhiteSpace(localTVFileList[0].FileInfo))
            {
                Assert.False(string.IsNullOrWhiteSpace(localTVFileList[0].FileInfo));
            }
            if (localTVFileList[0].FromWater != null)
            {
                Assert.NotNull(localTVFileList[0].FromWater);
            }
            if (!string.IsNullOrWhiteSpace(localTVFileList[0].ClientFilePath))
            {
                Assert.False(string.IsNullOrWhiteSpace(localTVFileList[0].ClientFilePath));
            }
            Assert.False(string.IsNullOrWhiteSpace(localTVFileList[0].ServerFileName));
            Assert.False(string.IsNullOrWhiteSpace(localTVFileList[0].ServerFilePath));
        }

        #endregion Functions private
    }
}
