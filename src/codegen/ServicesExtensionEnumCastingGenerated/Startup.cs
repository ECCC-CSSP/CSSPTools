using ConfigServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicesClassNameServiceGeneratedServices.Services;
using System;
using System.Threading.Tasks;

namespace ServicesExtensionEnumCastingGenerated
{
    public class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IServicesExtensionEnumCastingGeneratedService ServicesExtensionEnumCastingGeneratedService { get; set; }
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

            Services.AddSingleton<IServicesExtensionEnumCastingGeneratedService, ServicesExtensionEnumCastingGeneratedService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            ServicesExtensionEnumCastingGeneratedService = Provider.GetService<IServicesExtensionEnumCastingGeneratedService>();
            if (ServicesExtensionEnumCastingGeneratedService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } IServicesExtensionEnumCastingGeneratedService == null");
                return await Task.FromResult(false);
            }

            if (!await ServicesExtensionEnumCastingGeneratedService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
