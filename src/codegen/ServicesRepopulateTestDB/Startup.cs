using CSSPModels;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServicesRepopulateTestDBServices.Resources;
using ServicesRepopulateTestDBServices.Services;
using System;
using System.IO;
using ValidateAppSettingsServices.Services;

namespace ServicesRepopulateTestDB
{
    public class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration Configuration { get; set; }
        private ServiceProvider provider { get; set; }
        private IServicesRepopulateTestDBService servicesRepopulateTestDBService { get; set; }
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
            serviceCollection.AddSingleton<IServicesRepopulateTestDBService, ServicesRepopulateTestDBService>();
            serviceCollection.AddSingleton<IGenerateCodeBaseService, GenerateCodeBaseService>();
            serviceCollection.AddSingleton<IActionCommandDBService, ActionCommandDBService>();
            serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();

            string retStr = ConfigureGenerateCodeStatusContext(serviceCollection);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = ConfigureCSSPDBContext(serviceCollection);
            if (!string.IsNullOrWhiteSpace(retStr))
            {
                return retStr;
            }

            retStr = ConfigureTestDBContext(serviceCollection);
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
            servicesRepopulateTestDBService = provider.GetService<IServicesRepopulateTestDBService>();
            if (servicesRepopulateTestDBService == null)
            {
                return $"{ AppDomain.CurrentDomain.FriendlyName } enumsGenerated_csService == null";
            }

            if (!servicesRepopulateTestDBService.Run(args).GetAwaiter().GetResult())
            {
                return AppRes.AbnormalCompletion;
            }

            return "";
        }
        #endregion Constructors

        #region Functions private
        private string ConfigureCSSPDBContext(IServiceCollection serviceCollection)
        {
            string CSSPDBConnString = Configuration.GetValue<string>("CSSPDBConnectionString");
            if (CSSPDBConnString == null)
            {
                return $"{ String.Format(AppRes.CouldNotFindParameter_InAppSettingsJSON, "CSSPDBConnectionString") }";
            }

            try
            {
                serviceCollection.AddDbContext<CSSPDBContext>(options =>
                {
                    options.UseSqlServer(CSSPDBConnString);
                });
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }
        private string ConfigureTestDBContext(IServiceCollection serviceCollection)
        {
            string TestDBConnString = Configuration.GetValue<string>("TestDBConnectionString");
            if (TestDBConnString == null)
            {
                return $"{ String.Format(AppRes.CouldNotFindParameter_InAppSettingsJSON, "TestDBConnectionString") }";
            }

            try
            {
                serviceCollection.AddDbContext<TestDBContext>(options =>
                {
                    options.UseSqlServer(TestDBConnString);
                });
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }
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
