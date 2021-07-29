using CreateGzFileServices;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDBServices;
using CSSPEnums;
using CSSPHelperServices;
using CSSPUpdateServices;
using LoggedInServices;
using ManageServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdate
{
    public partial class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties


        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICreateGzFileService CreateGzFileService { get; set; }
        private string AzureStore { get; set; }
        private string AzureStoreCSSPFilesPath { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
        private CSSPDBContext db { get; set; }
        
        
        public ICSSPUpdateService CSSPUpdateService { get; set; }

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
               //.AddUserSecrets("f1d5ece7-8bc6-44ff-8611-8899787c64a9")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            AzureStore = Configuration.GetValue<string>("AzureStore");
            if (string.IsNullOrEmpty(AzureStore))
            {
                Console.WriteLine("Error: Could not find AzureStoreCSSPJSONPath withing UserSecret");
                return await Task.FromResult(false);
            }

            AzureStoreCSSPFilesPath = Configuration.GetValue<string>("AzureStoreCSSPFilesPath");
            if (string.IsNullOrEmpty(AzureStoreCSSPFilesPath))
            {
                Console.WriteLine("Error: Could not find AzureStoreCSSPFilesPath withing UserSecret");
                return await Task.FromResult(false);
            }

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            if (string.IsNullOrEmpty(AzureStoreCSSPJSONPath))
            {
                Console.WriteLine("Error: Could not find AzureStoreCSSPJsonPath withing UserSecret");
                return await Task.FromResult(false);
            }

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoggedInService, LoggedInService>();
            Services.AddSingleton<ILoginModelService, LoginModelService>();
            Services.AddSingleton<IRegisterModelService, RegisterModelService>();
            Services.AddSingleton<IContactDBService, ContactDBService>();
            Services.AddSingleton<ICreateGzFileService, CreateGzFileService>();
            Services.AddSingleton<ITVItemDBService, TVItemDBService>();
            Services.AddSingleton<ICSSPUpdateService, CSSPUpdateService>();

            /* ---------------------------------------------------------------------------------
           * CSSPDBContext
           * ---------------------------------------------------------------------------------      
           */
            string CSSPDB = Configuration.GetValue<string>("CSSPDB");
            if (string.IsNullOrWhiteSpace(CSSPDB))
            {
                Console.WriteLine("Error: Could not read CSSPDB");
                return await Task.FromResult(false);
            }

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDB);
            });

            /* ---------------------------------------------------------------------------------
             * CSSPDBManageContext
             * ---------------------------------------------------------------------------------      
             */

            string CSSPDBManage = Configuration.GetValue<string>("CSSPDBManage");
            if (string.IsNullOrWhiteSpace(CSSPDBManage))
            {
                Console.WriteLine("Error: Could not read CSSPDBManage");
                return await Task.FromResult(false);
            }

            FileInfo fiCSSPDBManage = new FileInfo(CSSPDBManage);
            if(!fiCSSPDBManage.Exists)
            {
                Console.WriteLine($"Error: file does not exist: { fiCSSPDBManage.FullName }");
                return await Task.FromResult(false);
            }

            Services.AddDbContext<CSSPDBManageContext>(options =>
            {
                options.UseSqlite($"Data Source={ fiCSSPDBManage.FullName }");
            });

            Provider = Services.BuildServiceProvider();
            if (Provider == null)
            {
                Console.WriteLine("Provider should not be null");
                return await Task.FromResult(false);
            }

            db = Provider.GetService<CSSPDBContext>();
            if (db == null)
            {
                Console.WriteLine("Error: db should not be null");
                return await Task.FromResult(false);
            }

            LoggedInService = Provider.GetService<ILoggedInService>();
            if (LoggedInService == null)
            {
                Console.WriteLine("LoggedInService should not be null");
                return await Task.FromResult(false);
            }

            await LoggedInService.SetLoggedInLocalContactInfo();
            if (LoggedInService.LoggedInContactInfo == null)
            {
                Console.WriteLine("LoggedInService.LoggedInContactInfo should not be null");
                return await Task.FromResult(false);
            }

            CreateGzFileService = Provider.GetService<ICreateGzFileService>();
            if (CreateGzFileService == null)
            {
                Console.WriteLine("CreateGzFileService should not be null");
                return await Task.FromResult(false);
            }

            AzureStore = LoggedInService.Descramble(AzureStore);

            CSSPUpdateService = Provider.GetService<ICSSPUpdateService>();
            if (CSSPUpdateService == null)
            {
                Console.WriteLine("CreateGzFileService should not be null");
                return await Task.FromResult(false);
            }


            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
