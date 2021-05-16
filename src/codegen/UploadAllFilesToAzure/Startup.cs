using CSSPScrambleServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace UploadAllFilesToAzure
{
    public class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private IServiceProvider Provider { get; set; }
        private IServiceCollection Services { get; set; }
        private IScrambleService ScrambleService { get; set; }
        public string AzureStore { get; set; }
        public string AzureStoreCSSPFilesPath { get; set; }
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
               .AddJsonFile("appsettings_uploadallfilestoazure.json")
               .AddUserSecrets("6dbd872a-7041-4f22-93b7-74da4fd9eadb")
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

            Services.AddSingleton<IScrambleService, ScrambleService>();

            Provider = Services.BuildServiceProvider();
            if (Provider == null)
            {
                Console.WriteLine("Provider should not be null");
                return false;
            }

            ScrambleService = Provider.GetService<IScrambleService>();

            AzureStore = ScrambleService.Descramble(AzureStore);

            return true;
        }
        #endregion Functions private
    }
}
