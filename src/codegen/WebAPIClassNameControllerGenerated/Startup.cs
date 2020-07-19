using ConfigServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WebAPIClassNameControllerGeneratedServices.Services;

namespace WebAPIClassNameControllerGenerated
{
    public class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IWebAPIClassNameControllerGeneratedService WebAPIClassNameControllerGeneratedService { get; set; }
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

            Services.AddSingleton<IWebAPIClassNameControllerGeneratedService, WebAPIClassNameControllerGeneratedService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            WebAPIClassNameControllerGeneratedService = Provider.GetService<IWebAPIClassNameControllerGeneratedService>();
            if (WebAPIClassNameControllerGeneratedService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } IWebAPIClassNameControllerGeneratedService == null");
                return await Task.FromResult(false);
            }

            if (!await WebAPIClassNameControllerGeneratedService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
