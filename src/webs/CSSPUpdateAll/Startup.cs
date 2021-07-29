using CreateGzFileServices;
using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPDBServices;
using CSSPEnums;
using CSSPHelperServices;
using LoggedInServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdateAll
{
    public partial class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        public StringBuilder sbError { get; set; }
        public StringBuilder sbLog { get; set; }


        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ILoggedInService LoggedInService { get; set; }
        private ICreateGzFileService CreateGzFileService { get; set; }
        private string AzureStore { get; set; }
        private string AzureStoreCSSPFilesPath { get; set; }
        private string AzureStoreCSSPJSONPath { get; set; }
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
               .AddJsonFile("appsettings_csspupdateall.json")
               .AddUserSecrets("f1d5ece7-8bc6-44ff-8611-8899787c64a9")
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

            string LoginEmail = Configuration.GetValue<string>("LoginEmail");
            if (LoginEmail == null)
            {
                Console.WriteLine("LoginEmail should not be null");
                return await Task.FromResult(false);
            }

            await LoggedInService.SetLoggedInContactInfo(LoginEmail);
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

            //sb = new StringBuilder();


            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
