/* 
 *  Manually Edited
 *  
 */

using CreateGzFileServices;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPFileServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReadGzFileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;
using CSSPLogServices;
using System.Linq;
using CSSPScrambleServices;
using CSSPWebModels;

namespace CSSPDBLocalServices.Tests
{
    public partial class CSSPDBLocalServiceTest
    {
        #region Properties
        protected IConfiguration Configuration { get; set; }
        protected ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
        protected CSSPDBLocalContext dbLocal { get; set; }
        protected IReadGzFileService ReadGzFileService { get; set; }
        protected IAppTaskLocalService AppTaskLocalService { get; set; }
        protected IMapInfoLocalService MapInfoLocalService { get; set; }
        protected ITVItemLocalService TVItemLocalService { get; set; }

        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ICSSPScrambleService CSSPScrambleService { get; set; }
        private ICSSPLogService CSSPLogService { get; set; }
        private ICSSPFileService FileService { get; set; }
        private IManageFileService ManageFileService { get; set; }
        private ICreateGzFileService CreateGzFileService { get; set; }
        private CSSPDBContext db { get; set; }
        private CSSPDBManageContext dbManage { get; set; }
        private FileInfo fiCSSPDBLocal { get; set; }
        private FileInfo fiCSSPDBLocalTest { get; set; }
        private FileInfo fiCSSPDBManage { get; set; }
        private FileInfo fiCSSPDBManageTest { get; set; }
        #endregion Properties

        #region Constructors
        public CSSPDBLocalServiceTest()
        {

        }
        #endregion Constructors

        public async Task<bool> CSSPDBLocalServiceSetup(string culture)
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspdblocalservicestests.json")
               .AddUserSecrets("86d17aa8-ffaa-4834-b06c-95bdec59d59b")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            Assert.NotNull(Configuration["APISecret"]);
            Assert.NotNull(Configuration["AzureCSSPDB"]);
            Assert.NotNull(Configuration["AzureStore"]);
            Assert.NotNull(Configuration["CSSPAzureUrl"]);
            Assert.NotNull(Configuration["CSSPLocalUrl"]);
            Assert.NotNull(Configuration["CSSPDB"]);
            Assert.NotNull(Configuration["CSSPDBLocal"]);
            Assert.NotNull(Configuration["CSSPDBManage"]);
            Assert.NotNull(Configuration["azure_csspjson_backup_uncompress"]);
            Assert.NotNull(Configuration["azure_csspjson_backup"]);
            Assert.NotNull(Configuration["CSSPDesktopPath"]);
            Assert.NotNull(Configuration["CSSPDatabasesPath"]);
            Assert.NotNull(Configuration["CSSPWebAPIsLocalPath"]);
            Assert.NotNull(Configuration["CSSPJSONPath"]);
            Assert.NotNull(Configuration["CSSPJSONPathLocal"]);
            Assert.NotNull(Configuration["CSSPFilesPath"]);
            Assert.NotNull(Configuration["CSSPOtherFilesPath"]);

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
            Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
            Services.AddSingleton<ICSSPLogService, CSSPLogService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IManageFileService, ManageFileService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPFileService, CSSPFileService>();
            Services.AddSingleton<ICreateGzFileService, CreateGzFileService>();
            Services.AddSingleton<IReadGzFileService, ReadGzFileService>();


            Services.AddSingleton<IAppTaskLocalService, AppTaskLocalService>();
            Services.AddSingleton<IMapInfoLocalService, MapInfoLocalService>();
            Services.AddSingleton<ITVItemLocalService, TVItemLocalService>();

            Assert.True(await DirectoryAndDBSetup());

            Provider = Services.BuildServiceProvider();
            Assert.NotNull(Provider);

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            Assert.NotNull(CSSPCultureService);

            CSSPCultureService.SetCulture(culture);

            CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
            Assert.NotNull(CSSPLocalLoggedInService);

            Assert.True(await CSSPLocalLoggedInService.SetLoggedInContactInfo());

            CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
            Assert.NotNull(CSSPScrambleService);

            CSSPLogService = Provider.GetService<ICSSPLogService>();
            Assert.NotNull(CSSPLogService);

            enums = Provider.GetService<IEnums>();
            Assert.NotNull(enums);

            FileService = Provider.GetService<ICSSPFileService>();
            Assert.NotNull(FileService);

            ManageFileService = Provider.GetService<IManageFileService>();
            Assert.NotNull(ManageFileService);

            CreateGzFileService = Provider.GetService<ICreateGzFileService>();
            Assert.NotNull(CreateGzFileService);

            ReadGzFileService = Provider.GetService<IReadGzFileService>();
            Assert.NotNull(ReadGzFileService);

            AppTaskLocalService = Provider.GetService<IAppTaskLocalService>();
            Assert.NotNull(AppTaskLocalService);

            MapInfoLocalService = Provider.GetService<IMapInfoLocalService>();
            Assert.NotNull(MapInfoLocalService);

            TVItemLocalService = Provider.GetService<ITVItemLocalService>();
            Assert.NotNull(TVItemLocalService);

            db = Provider.GetService<CSSPDBContext>();
            Assert.NotNull(db);

            dbLocal = Provider.GetService<CSSPDBLocalContext>();
            Assert.NotNull(dbLocal);

            dbManage = Provider.GetService<CSSPDBManageContext>();
            Assert.NotNull(dbManage);

            Assert.True(await ClearSomeTablesOfCSSPDBManage());

            Assert.NotNull(Configuration);
            Assert.NotNull(CSSPCultureService);
            Assert.NotNull(CSSPLocalLoggedInService);
            Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo);
            Assert.NotNull(CSSPLocalLoggedInService.LoggedInContactInfo.LoggedInContact);
            Assert.NotNull(CSSPScrambleService);
            Assert.NotNull(CSSPLogService);
            Assert.NotNull(enums);
            Assert.NotNull(FileService);
            Assert.NotNull(ManageFileService);
            Assert.NotNull(CreateGzFileService);
            Assert.NotNull(ReadGzFileService);
            Assert.NotNull(AppTaskLocalService);
            Assert.NotNull(MapInfoLocalService);
            Assert.NotNull(TVItemLocalService);
            Assert.NotNull(db);
            Assert.NotNull(dbLocal);
            Assert.NotNull(dbManage);

            return await Task.FromResult(true);
        }
    }
}
