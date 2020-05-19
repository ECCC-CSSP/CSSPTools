using ConfigServices.Services;
using EnumsPolSourceInfoRelatedFilesServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace EnumsPolSourceInfoRelatedFiles
{
    public class Startup : ConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEnumsPolSourceInfoRelatedFilesService EnumsPolSourceInfoRelatedFilesService { get; set; }
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

            Services.AddSingleton<IEnumsPolSourceInfoRelatedFilesService, EnumsPolSourceInfoRelatedFilesService>();

            if (!await BuildServiceProvider())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            EnumsPolSourceInfoRelatedFilesService = Provider.GetService<IEnumsPolSourceInfoRelatedFilesService>();
            if (EnumsPolSourceInfoRelatedFilesService == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } EnumsGenerated_csService  == null");
                return await Task.FromResult(false);
            }

            if (!await EnumsPolSourceInfoRelatedFilesService.Run(args)) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
