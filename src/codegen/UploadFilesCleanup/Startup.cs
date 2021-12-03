using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLocalLoggedInServices;
using CSSPScrambleServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace UploadAllFilesToAzure
{
    public partial class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private ICSSPScrambleService CSSPScrambleService { get; set; }
        private ICSSPLocalLoggedInService CSSPLocalLoggedInService { get; set; }
        public string AzureStore { get; set; }
        public string AzureStoreCSSPFilesPath { get; set; }
        public CSSPDBContext db { get; set; }
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
               .AddJsonFile("appsettings_uploadfilescleanup.json")
               .AddUserSecrets("30220f9a-7e90-4526-b1ac-4aeba62ffa42")
               .Build();

            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);

            AzureStore = Configuration.GetValue<string>("AzureStore");
            if (string.IsNullOrEmpty(AzureStore))
            {
                Console.WriteLine("Error: Could not find AzureStoreCSSPJSONPath withing UserSecret");
                return false;
            }

            AzureStoreCSSPFilesPath = Configuration.GetValue<string>("AzureStoreCSSPFilesPath");
            if (string.IsNullOrEmpty(AzureStoreCSSPFilesPath))
            {
                Console.WriteLine("Error: Could not find AzureStoreCSSPFilesPath withing UserSecret");
                return false;
            }

            Services.AddSingleton<ICSSPCultureService, CSSPCultureService>();
            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<ICSSPScrambleService, CSSPScrambleService>();
            Services.AddSingleton<ICSSPLocalLoggedInService, CSSPLocalLoggedInService>();

            /* ---------------------------------------------------------------------------------
           * CSSPDBContext
           * ---------------------------------------------------------------------------------      
           */
            string CSSPDB = Configuration.GetValue<string>("CSSPDB");
            if (string.IsNullOrWhiteSpace(CSSPDB))
            {
                Console.WriteLine("Error: Could not read CSSPDB");
                return false;
            }

            Services.AddDbContext<CSSPDBContext>(options =>
            {
                options.UseSqlServer(CSSPDB);
            });

            Provider = Services.BuildServiceProvider();
            if (Provider == null)
            {
                Console.WriteLine("Provider should not be null");
                return false;
            }

            db = Provider.GetService<CSSPDBContext>();
            if (db == null)
            {
                Console.WriteLine("Error: db should not be null");
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

            CSSPScrambleService = Provider.GetService<ICSSPScrambleService>();
            if (CSSPScrambleService == null)
            {
                Console.WriteLine("CSSPScrambleService should not be null");
                return false;
            }

            AzureStore = CSSPScrambleService.Descramble(AzureStore);

            return true;
        }
        #endregion Functions private
    }
}
