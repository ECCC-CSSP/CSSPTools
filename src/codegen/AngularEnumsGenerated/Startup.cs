using AngularEnumsGeneratedServices.Services;
using ConfigServices.Services;
using CSSPEnums;
using CSSPCultureServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace AngularEnumsGenerated
{
    public partial class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IAngularEnumsGeneratedService AngularEnumsGeneratedService { get; set; }
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

            Services.AddSingleton<IEnums, Enums>();
            Services.AddSingleton<IAngularEnumsGeneratedService, AngularEnumsGeneratedService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            CSSPCultureService.SetCulture(Config.GetValue<string>("CSSPCulture"));

            AngularEnumsGeneratedService = Provider.GetService<IAngularEnumsGeneratedService>();
            if (AngularEnumsGeneratedService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } angularEnumsGeneratedService == null");
                return await Task.FromResult(false);
            }

            if (!await AngularEnumsGeneratedService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
