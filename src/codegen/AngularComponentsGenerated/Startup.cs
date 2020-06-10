using AngularComponentsGeneratedServices.Services;
using ConfigServices.Services;
using CultureServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace AngularComponentsGenerated
{
    public partial class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IAngularComponentsGeneratedService AngularComponentsGeneratedService { get; set; }
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

            Services.AddSingleton<IAngularComponentsGeneratedService, AngularComponentsGeneratedService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            AngularComponentsGeneratedService = Provider.GetService<IAngularComponentsGeneratedService>();
            if (AngularComponentsGeneratedService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } angularEnumsGeneratedService  == null");
                return await Task.FromResult(false);
            }

            if (!await AngularComponentsGeneratedService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
