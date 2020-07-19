using AngularModelsGeneratedServices.Services;
using ConfigServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace AngularModelsGenerated
{
    public partial class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IAngularModelsGeneratedService AngularModelsGeneratedService { get; set; }
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

            Services.AddSingleton<IAngularModelsGeneratedService, AngularModelsGeneratedService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            AngularModelsGeneratedService = Provider.GetService<IAngularModelsGeneratedService>();
            if (AngularModelsGeneratedService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } angularEnumsGeneratedService  == null");
                return await Task.FromResult(false);
            }

            if (!await AngularModelsGeneratedService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
