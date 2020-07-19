using ConfigServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicesClassNameServiceTestGeneratedServices.Services;
using System;
using System.Threading.Tasks;

namespace ServicesClassNameServiceTestGenerated
{
    public class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IServicesClassNameServiceTestGeneratedService ServicesClassNameServiceTestGeneratedService { get; set; }
        #endregion Properties

        #region Constructors
        public Startup(IConfiguration Configuration) : base(Configuration)
        {
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            if (!await ConfigureBaseServices()) return await Task.FromResult(false);

            if (!await ConfigureCSSPDBContext()) return await Task.FromResult(false);

            if (!await ConfigureTestDBContext()) return await Task.FromResult(false);

            Services.AddSingleton<IServicesClassNameServiceTestGeneratedService, ServicesClassNameServiceTestGeneratedService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            ServicesClassNameServiceTestGeneratedService = Provider.GetService<IServicesClassNameServiceTestGeneratedService>();
            if (ServicesClassNameServiceTestGeneratedService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } IServicesClassNameServiceTestGeneratedService == null");
                return await Task.FromResult(false);
            }

            if (!await ServicesClassNameServiceTestGeneratedService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
