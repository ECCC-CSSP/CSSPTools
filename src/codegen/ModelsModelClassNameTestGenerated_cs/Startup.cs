using ConfigServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelsModelClassNameTestGenerated_csServices.Services;
using System;
using System.Threading.Tasks;

namespace ModelClassNameTestGenerated_cs
{
    public class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IModelsModelClassNameTestGenerated_csService ModelsModelClassNameTestGenerated_csService { get; set; }
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

            Services.AddSingleton<IModelsModelClassNameTestGenerated_csService, ModelsModelClassNameTestGenerated_csService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            ModelsModelClassNameTestGenerated_csService = Provider.GetService<IModelsModelClassNameTestGenerated_csService>();
            if (ModelsModelClassNameTestGenerated_csService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } IModelsCSSPModelsResService  == null");
                return await Task.FromResult(false);
            }

            if (!await ModelsModelClassNameTestGenerated_csService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public 


        #region Functions private
        #endregion Functions private

    }
}
