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
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace UploadAllJsonFilesToAzure
{
    public class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        public ICreateGzFileService CreateGzFileService { get; set; }
        public ILoggedInService LoggedInService { get; set; }
        public string AzureStore { get; set; }
        public string AzureStoreCSSPJSONPath { get; set; }
        #endregion Properties

        #region Constructors
        public Startup()
        {
        }
        #endregion Constructors

        #region Functions private
        public bool Setup()
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
               .AddJsonFile("appsettings_uploadalljsonfilestoazure.json")
               .AddUserSecrets("248bc440-ee6f-4886-9090-52f18d87241d")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            AzureStore = Configuration.GetValue<string>("AzureStore");
            if (string.IsNullOrEmpty(AzureStore))
            {
                Console.WriteLine("Error: Could not find AzureStoreCSSPJSONPath withing UserSecret");
                return false;
            }

            AzureStoreCSSPJSONPath = Configuration.GetValue<string>("AzureStoreCSSPJSONPath");
            if (string.IsNullOrEmpty(AzureStoreCSSPJSONPath))
            {
                Console.WriteLine("Error: Could not find AzureStoreCSSPJsonPath withing UserSecret");
                return false;
            }

            string CSSPDBConnString = Configuration.GetValue<string>("CSSPDB");
            if (string.IsNullOrWhiteSpace(CSSPDBConnString))
            {
                Console.WriteLine("Error: Could not find CSSPDB withing appsettings_uploadalljsonfilestoazure.json");
                return false;
            }

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDBConnString);
            });

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ILoginModelService, LoginModelService>();
            Services.AddSingleton<IContactDBService, ContactDBService>();
            Services.AddSingleton<ICreateGzFileService, CreateGzFileService>();
            Services.AddSingleton<ITVItemDBService, TVItemDBService>();

            Provider = Services.BuildServiceProvider();
            if (Provider == null)
            {
                Console.WriteLine("Provider should not be null");
                return false;
            }

            LoggedInService = Provider.GetService<ILoggedInService>();
            if (LoggedInService == null)
            {
                Console.WriteLine("LoggedInService should not be null");
                return false;
            }

            LoggedInService.SetLoggedInLocalContactInfo();
            if (LoggedInService.LoggedInContactInfo == null)
            {
                Console.WriteLine("LoggedInService.LoggedInContactInfo should not be null");
                return false;
            }

            CreateGzFileService = Provider.GetService<ICreateGzFileService>();
            if (CreateGzFileService == null)
            {
                Console.WriteLine("CreateGzFileService should not be null");
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
