using ConfigServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelsModelClassNameTestServices.Services;
using System;
using System.Threading.Tasks;

namespace ModelsModelClassNameTest
{
    public class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IModelsModelClassNameTestService ModelsModelClassNameTestService { get; set; }
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

            Services.AddSingleton<IModelsModelClassNameTestService, ModelsModelClassNameTestService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            ModelsModelClassNameTestService = Provider.GetService<IModelsModelClassNameTestService>();
            if (ModelsModelClassNameTestService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } IModelsModelClassNameTestService == null");
                return await Task.FromResult(false);
            }

            if (!await ModelsModelClassNameTestService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
