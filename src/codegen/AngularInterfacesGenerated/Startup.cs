using AngularInterfacesGeneratedServices.Resources;
using AngularInterfacesGeneratedServices.Services;
using CSSPModels;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using ValidateAppSettingsServices.Services;

namespace AngularInterfacesGenerated
{
    public class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private ServiceProvider provider { get; set; }
        private IAngularInterfacesGeneratedService angularInterfacesGeneratedService { get; set; }
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
            serviceCollection.AddSingleton<IAngularInterfacesGeneratedService, AngularInterfacesGeneratedService>();
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
            angularInterfacesGeneratedService = provider.GetService<IAngularInterfacesGeneratedService>();
            if (angularInterfacesGeneratedService == null)
            {
                return $"{ AppDomain.CurrentDomain.FriendlyName } enumsGenerated_csService == null";
            }

            if (!angularInterfacesGeneratedService.Run(args).GetAwaiter().GetResult())
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
