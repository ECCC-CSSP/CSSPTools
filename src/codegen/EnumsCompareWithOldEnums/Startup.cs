using ConfigServices.Services;
using EnumsCompareWithOldEnumsServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace EnumsCompareWithOldEnums
{
    public partial class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEnumsCompareWithOldEnumsService EnumsCompareWithOldEnumsService { get; set; }
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

            Services.AddSingleton<IEnumsCompareWithOldEnumsService, EnumsCompareWithOldEnumsService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            EnumsCompareWithOldEnumsService = Provider.GetService<IEnumsCompareWithOldEnumsService>();
            if (EnumsCompareWithOldEnumsService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } angularEnumsGeneratedService  == null");
                return await Task.FromResult(false);
            }

            if (!await EnumsCompareWithOldEnumsService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
