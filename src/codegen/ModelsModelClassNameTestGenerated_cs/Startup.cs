using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using ModelsModelClassNameTestGenerated_csServices.Services;
using ModelsModelClassNameTestGenerated_csServices.Resources;
using ValidateAppSettingsServices.Services;

namespace ModelClassNameTestGenerated_cs
{
    public class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private ServiceProvider provider { get; set; }
        private IModelsModelClassNameTestGenerated_csService modelsModelClassNameTestGenerated_csService { get; set; }
        private string DBFileName { get; set; } = "DBFileName";
        #endregion Properties

        #region Constructors
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public string ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IConfiguration>(Configuration);
            serviceCollection.AddSingleton<IModelsModelClassNameTestGenerated_csService, ModelsModelClassNameTestGenerated_csService>();
            serviceCollection.AddSingleton<IGenerateCodeBaseService, GenerateCodeBaseService>();
            serviceCollection.AddSingleton<IActionCommandDBService, ActionCommandDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();

            string retStr = ConfigureGenerateCodeStatusContext(serviceCollection);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            provider = serviceCollection.BuildServiceProvider();
            if (provider == null)
            {
                return $"{ AppDomain.CurrentDomain.FriendlyName } provider == null";
            }

            return "";
        }
        public string Run(string[] args)
        {
            modelsModelClassNameTestGenerated_csService = provider.GetService<IModelsModelClassNameTestGenerated_csService>();
            if (modelsModelClassNameTestGenerated_csService == null)
            {
                return $"{ AppDomain.CurrentDomain.FriendlyName } enumsGenerated_csService == null";
            }

            if (!modelsModelClassNameTestGenerated_csService.Run(args).GetAwaiter().GetResult())
            {
                return AppRes.AbnormalCompletion;
            }

            return "";
        }
        #endregion Constructors

        #region Functions private
        private string ConfigureGenerateCodeStatusContext(IServiceCollection serviceCollection)
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (Configuration.GetValue<string>(DBFileName) == null)
            {
                return $"{ String.Format(AppRes.CouldNotFindParameter_InAppSettingsJSON, DBFileName) }";
            }

            FileInfo fiDB = new FileInfo(Configuration.GetValue<string>(DBFileName).Replace("{AppDataPath}", appDataPath));

            if (!fiDB.Exists)
            {
                return $"{ String.Format(AppRes.CouldNotFindFile_, fiDB.FullName) }";
            }

            try
            {
                serviceCollection.AddDbContext<ActionCommandContext>(options =>
                {
                    options.UseSqlite($"DataSource={fiDB.FullName}");
                });
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }
        #endregion Functions private

    }
}
