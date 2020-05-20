using ConfigServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicesRepopulateTestDBServices.Services;
using System;
using System.Threading.Tasks;

namespace ServicesRepopulateTestDB
{
    public class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IServicesRepopulateTestDBService ServicesRepopulateTestDBService { get; set; }
        #endregion Properties

        #region Constructors
        public Startup(IConfiguration configuration) : base(configuration)
        {
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            if (!await ConfigureBaseServices()) return await Task.FromResult(false);

            if (!await ConfigureCSSPDBContext()) return await Task.FromResult(false);

            if (!await ConfigureTestDBContext()) return await Task.FromResult(false);

            Services.AddSingleton<IServicesRepopulateTestDBService, ServicesRepopulateTestDBService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            ServicesRepopulateTestDBService = Provider.GetService<IServicesRepopulateTestDBService>();
            if (ServicesRepopulateTestDBService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } IServicesRepopulateTestDBService == null");
                return await Task.FromResult(false);
            }

            if (!await ServicesRepopulateTestDBService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
