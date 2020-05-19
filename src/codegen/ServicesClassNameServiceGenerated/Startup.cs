using CSSPModels;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicesClassNameServiceGeneratedServices.Services;
using System;
using System.IO;
using ValidateAppSettingsServices.Services;
using System.Threading.Tasks;
using CultureServices.Resources;
using ConfigServices.Services;

namespace ServicesClassNameServiceGenerated
{
    public class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IServicesClassNameServiceGeneratedService ServicesClassNameServiceGeneratedService { get; set; }
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

            Services.AddSingleton<IServicesClassNameServiceGeneratedService, ServicesClassNameServiceGeneratedService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            ServicesClassNameServiceGeneratedService = Provider.GetService<IServicesClassNameServiceGeneratedService>();
            if (ServicesClassNameServiceGeneratedService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } IServicesClassNameServiceGeneratedService == null");
                return await Task.FromResult(false);
            }

            if (!await ServicesClassNameServiceGeneratedService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
