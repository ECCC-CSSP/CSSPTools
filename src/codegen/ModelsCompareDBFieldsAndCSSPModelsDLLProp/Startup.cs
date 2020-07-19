using ConfigServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Services;
using System;
using System.Threading.Tasks;

namespace ModelsCompareDBFieldsAndCSSPModelsDLLProp
{
    public class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IModelsCompareDBFieldsAndCSSPModelsDLLPropService ModelsCompareDBFieldsAndCSSPModelsDLLPropService { get; set; }
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

            Services.AddSingleton<IModelsCompareDBFieldsAndCSSPModelsDLLPropService, ModelsCompareDBFieldsAndCSSPModelsDLLPropService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            ModelsCompareDBFieldsAndCSSPModelsDLLPropService = Provider.GetService<IModelsCompareDBFieldsAndCSSPModelsDLLPropService>();
            if (ModelsCompareDBFieldsAndCSSPModelsDLLPropService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } IModelsCompareDBFieldsAndCSSPModelsDLLPropService  == null");
                return await Task.FromResult(false);
            }

            if (!await ModelsCompareDBFieldsAndCSSPModelsDLLPropService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
