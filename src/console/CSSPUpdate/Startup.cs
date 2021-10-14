using CreateGzFileServices;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLogServices;
using CSSPUpdateServices;
using CSSPLocalLoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CSSPUpdate
{
    public partial class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        public ICSSPUpdateService CSSPUpdateService { get; set; }

        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPCultureService CSSPCultureService { get; set; }
        private IEnums enums { get; set; }
        private ICSSPLogService CSSPLogService { get; set; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
        private ICreateGzFileService CreateGzFileService { get; set; }
        private CSSPDBContext db { get; set; }
        #endregion Properties

        #region Constructors
        public Startup()
        {
        }
        #endregion Constructors

        #region Functions private
        public async Task<bool> Setup()
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_csspupdate.json")
               .AddUserSecrets("f1d5ece7-8bc6-44ff-8611-8899787c64a9")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            if (string.IsNullOrEmpty(Configuration["azure_csspjson_backup"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["azure_csspjson_backup_uncompress"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "azure_csspjson_backup_uncompress", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStore"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStore", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPFilesPath", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["AzureStoreCSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "AzureStoreCSSPJSONPath", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPAzureUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPAzureUrl", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPFilesPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPFilesPath", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPJSONPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPath", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPJSONPathLocal"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPJSONPathLocal", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["CSSPLocalUrl"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "CSSPLocalUrl", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["LocalAppDataPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "LocalAppDataPath", "CreateGzFileService") }");
            if (string.IsNullOrEmpty(Configuration["NationalBackupAppDataPath"])) throw new Exception($"{ string.Format(CSSPCultureServicesRes.CouldNotFindParameter_InConfigFilesOfService_, "NationalBackupAppDataPath", "CreateGzFileService") }");

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPLogService, CSSPLogService>();
            Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();
            Services.AddSingleton<ICreateGzFileService, CreateGzFileService>();
            Services.AddSingleton<ICSSPUpdateService, CSSPUpdateService>();

            /* ---------------------------------------------------------------------------------
           * CSSPDBContext
           * ---------------------------------------------------------------------------------      
           */
            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(Configuration["CSSPDB"]);
            });

            /* ---------------------------------------------------------------------------------
             * CSSPDBManageContext
             * ---------------------------------------------------------------------------------      
             */

            FileInfo fiCSSPDBManage = new FileInfo(Configuration["CSSPDBManage"]);
            if (!fiCSSPDBManage.Exists)
            {
                Console.WriteLine($"{ string.Format(CSSPCultureServicesRes.FileNotFound_, fiCSSPDBManage.FullName) }");
                return await Task.FromResult(false);
            }

            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
            });

            Provider = Services.BuildServiceProvider();
            if (Provider == null)
            {
                Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "Provider") }");
                return await Task.FromResult(false);
            }

            db = Provider.GetService<CSSPDBContext>();
            if (db == null)
            {
                Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "db") }");
                return await Task.FromResult(false);
            }

            CSSPCultureService = Provider.GetService<ICSSPCultureService>();
            if (CSSPCultureService == null)
            {
                Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPCultureService") }");
                return await Task.FromResult(false);
            }

            enums = Provider.GetService<IEnums>();
            if (enums == null)
            {
                Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "enums") }");
                return await Task.FromResult(false);
            }

            CSSPLogService = Provider.GetService<ICSSPLogService>();
            if (CSSPLogService == null)
            {
                Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLogService ") }");
                return await Task.FromResult(false);
            }

            CSSPLogService.CSSPAppName = "CSSPUpdate";
            CSSPLogService.CSSPCommandName = "Unknown";

            CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
            if (CSSPLocalLoggedInService == null)
            {
                Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService") }");
                return await Task.FromResult(false);
            }

            await CSSPLocalLoggedInService.SetLoggedInContactInfo();
            if (CSSPLocalLoggedInService.LoggedInContactInfo == null)
            {
                Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPLocalLoggedInService.LoggedInContactInfo") }");
                return await Task.FromResult(false);
            }

            CreateGzFileService = Provider.GetService<ICreateGzFileService>();
            if (CreateGzFileService == null)
            {
                Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CreateGzFileService") }");
                return await Task.FromResult(false);
            }

            CSSPUpdateService = Provider.GetService<ICSSPUpdateService>();
            if (CSSPUpdateService == null)
            {
                Console.WriteLine($"{ string.Format(CSSPCultureServicesRes._ShouldNotBeNullOrEmpty, "CSSPUpdateService") }");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
