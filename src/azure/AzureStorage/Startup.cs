using AzureStorageServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace AzureStorage
{

    public partial class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        public IConfiguration Configuration { get; set; }
        public IServiceProvider Provider { get; set; }
        public IServiceCollection Services { get; set; }
        public IAzureStorageService AzureStorageService { get; set; }
        #endregion Properties

        #region Constructors
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            Services = new ServiceCollection();

            Services.AddSingleton<IConfiguration>(Configuration);
            Services.AddSingleton<IAzureStorageService, AzureStorageService>();

            Provider = Services.BuildServiceProvider();
            if (Provider == null)
            {
                throw new Exception($"{ AppDomain.CurrentDomain.FriendlyName } provider == null");
            }

            AzureStorageService = Provider.GetService<IAzureStorageService>();
            if (AzureStorageService == null)
            {
                Console.WriteLine($"{ AppDomain.CurrentDomain.FriendlyName } AzureStorageService == null");
                return await Task.FromResult(false);
            }

            if (!await AzureStorageService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
