using ConfigServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelsCSSPModelsResServices.Services;
using System;
using System.Threading.Tasks;

namespace ModelsCSSPModelsRes
{
    public class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IModelsCSSPModelsResService ModelsCSSPModelsResService { get; set; }
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

            Services.AddSingleton<IModelsCSSPModelsResService, ModelsCSSPModelsResService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            ModelsCSSPModelsResService = Provider.GetService<IModelsCSSPModelsResService>();
            if (ModelsCSSPModelsResService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } IModelsCSSPModelsResService  == null");
                return await Task.FromResult(false);
            }

            if (!await ModelsCSSPModelsResService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
