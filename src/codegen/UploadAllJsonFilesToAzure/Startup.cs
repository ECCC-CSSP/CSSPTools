using CSSPCreateGzFileServices;
using CSSPCultureServices.Services;
using CSSPDBAzureServices;
using CSSPDBModels;
using CSSPEnums;
using CSSPLocalLoggedInServices;
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
        public ICSSPCreateGzFileService CSSPCreateGzFileService { get; set; }
        public ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
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
            Services.AddSingleton<IContactAzureService, ContactAzureService>();
            Services.AddSingleton<ICSSPCreateGzFileService, CSSPCreateGzFileService>();
            Services.AddSingleton<ITVItemAzureService, TVItemAzureService>();

            Provider = Services.BuildServiceProvider();
            if (Provider == null)
            {
                Console.WriteLine("Provider should not be null");
                return false;
            }

            CSSPLocalLoggedInService = Provider.GetService<ICSSPLocalLoggedInService>();
            if (CSSPLocalLoggedInService == null)
            {
                Console.WriteLine("CSSPLocalLoggedInService should not be null");
                return false;
            }

            CSSPLocalLoggedInService.SetLocalLoggedInContactInfoAsync();
            if (CSSPLocalLoggedInService.LoggedInContactInfo == null)
            {
                Console.WriteLine("CSSPLocalLoggedInService.LoggedInContactInfo should not be null");
                return false;
            }

            CSSPCreateGzFileService = Provider.GetService<ICSSPCreateGzFileService>();
            if (CSSPCreateGzFileService == null)
            {
                Console.WriteLine("CreateGzFileService should not be null");
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
