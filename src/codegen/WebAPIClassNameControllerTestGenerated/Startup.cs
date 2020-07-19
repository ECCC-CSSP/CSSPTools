using ConfigServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using WebAPIClassNameControllerTestGeneratedServices.Services;

namespace WebAPIClassNameControllerTestGenerated
{
    public class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IWebAPIClassNameControllerTestGeneratedService WebAPIClassNameControllerTestGeneratedService { get; set; }
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

            Services.AddSingleton<IWebAPIClassNameControllerTestGeneratedService, WebAPIClassNameControllerTestGeneratedService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            WebAPIClassNameControllerTestGeneratedService = Provider.GetService<IWebAPIClassNameControllerTestGeneratedService>();
            if (WebAPIClassNameControllerTestGeneratedService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } IWebAPIClassNameControllerTestGeneratedService == null");
                return await Task.FromResult(false);
            }

            if (!await WebAPIClassNameControllerTestGeneratedService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
