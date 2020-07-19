using ConfigServices.Services;
using EnumsTestGenerated_cs.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace EnumsTestGenerated_cs
{
    public class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEnumsTestGenerated_csService EnumsTestGenerated_csService { get; set; }
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

            Services.AddSingleton<IEnumsTestGenerated_csService, EnumsTestGenerated_csService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            EnumsTestGenerated_csService = Provider.GetService<IEnumsTestGenerated_csService>();
            if (EnumsTestGenerated_csService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } IEnumsTestGenerated_csService  == null");
                return await Task.FromResult(false);
            }

            if (!await EnumsTestGenerated_csService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
