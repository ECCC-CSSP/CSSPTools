/* 
 *  Manually Edited
 *  
 */

using CSSPCreateGzFileServices;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPFileServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CSSPReadGzFileServices;
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
        protected ICSSPReadGzFileService CSSPReadGzFileService { get; set; }
        protected IAddressLocalService AddressLocalService { get; set; }
        protected IAppTaskLocalService AppTaskLocalService { get; set; }
        protected IClassificationLocalService ClassificationLocalService { get; set; }
        protected ICountryLocalService CountryLocalService { get; set; }
        protected IEmailLocalService EmailLocalService { get; set; }
        protected IHelpDocLocalService HelpDocLocalService { get; set; }
        protected IHelperLocalService HelperLocalService { get; set; }
        protected IMapInfoLocalService MapInfoLocalService { get; set; }
        protected IMWQMLookupMPNLocalService MWQMLookupMPNLocalService { get; set; }
        protected IProvinceLocalService ProvinceLocalService { get; set; }
        protected IRootLocalService RootLocalService { get; set; }
        protected ITelLocalService TelLocalService { get; set; }
        protected ITVItemLocalService TVItemLocalService { get; set; }
        protected CSSPDBManageContext dbManage { get; set; }
        protected ICSSPLogService CSSPLogService { get; set; }

        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ICSSPScrambleService CSSPScrambleService { get; set; }
        private ICSSPFileService FileService { get; set; }
        private IManageFileService ManageFileService { get; set; }
        private ICSSPCreateGzFileService CSSPCreateGzFileService { get; set; }
        private CSSPDBContext db { get; set; }
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
            Services.AddSingleton<ICSSPCreateGzFileService, CSSPCreateGzFileService>();
            Services.AddSingleton<ICSSPReadGzFileService, CSSPReadGzFileService>();


            Services.AddSingleton<IAddressLocalService, AddressLocalService>();
            Services.AddSingleton<IAppTaskLocalService, AppTaskLocalService>();
            Services.AddSingleton<ICountryLocalService, CountryLocalService>();
            Services.AddSingleton<IClassificationLocalService, ClassificationLocalService>();
            Services.AddSingleton<IEmailLocalService, EmailLocalService>();
            Services.AddSingleton<IHelpDocLocalService, HelpDocLocalService>();
            Services.AddSingleton<IHelperLocalService, HelperLocalService>();
            Services.AddSingleton<IMapInfoLocalService, MapInfoLocalService>();
            Services.AddSingleton<IMWQMLookupMPNLocalService, MWQMLookupMPNLocalService>();
            Services.AddSingleton<IProvinceLocalService, ProvinceLocalService>();
            Services.AddSingleton<IRootLocalService, RootLocalService>();
            Services.AddSingleton<ITelLocalService, TelLocalService>();
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

            CSSPCreateGzFileService = Provider.GetService<ICSSPCreateGzFileService>();
            Assert.NotNull(CSSPCreateGzFileService);

            CSSPReadGzFileService = Provider.GetService<ICSSPReadGzFileService>();
            Assert.NotNull(CSSPReadGzFileService);

            AddressLocalService = Provider.GetService<IAddressLocalService>();
            Assert.NotNull(AddressLocalService);

            AppTaskLocalService = Provider.GetService<IAppTaskLocalService>();
            Assert.NotNull(AppTaskLocalService);

            ClassificationLocalService = Provider.GetService<IClassificationLocalService>();
            Assert.NotNull(ClassificationLocalService);

            CountryLocalService = Provider.GetService<ICountryLocalService>();
            Assert.NotNull(CountryLocalService);

            EmailLocalService = Provider.GetService<IEmailLocalService>();
            Assert.NotNull(EmailLocalService);

            HelpDocLocalService = Provider.GetService<IHelpDocLocalService>();
            Assert.NotNull(HelpDocLocalService);

            HelperLocalService = Provider.GetService<IHelperLocalService>();
            Assert.NotNull(HelperLocalService);

            MapInfoLocalService = Provider.GetService<IMapInfoLocalService>();
            Assert.NotNull(MapInfoLocalService);

            MWQMLookupMPNLocalService = Provider.GetService<IMWQMLookupMPNLocalService>();
            Assert.NotNull(MWQMLookupMPNLocalService);

            ProvinceLocalService = Provider.GetService<IProvinceLocalService>();
            Assert.NotNull(ProvinceLocalService);

            RootLocalService = Provider.GetService<IRootLocalService>();
            Assert.NotNull(RootLocalService);

            TelLocalService = Provider.GetService<ITelLocalService>();
            Assert.NotNull(TelLocalService);

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
            Assert.NotNull(CSSPCreateGzFileService);
            Assert.NotNull(CSSPReadGzFileService);
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
