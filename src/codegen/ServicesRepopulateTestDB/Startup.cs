﻿using CSSPModels;
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
using System.Threading.Tasks;

namespace ServicesRepopulateTestDB
{
    public class Startup
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private ServiceProvider provider { get; set; }
        private IServiceCollection serviceCollection { get; set; }
        private IServicesRepopulateTestDBService servicesRepopulateTestDBService { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        private string DBFileName { get; set; } = "DBFileName";
        #endregion Properties

        #region Constructors
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion Constructors

        #region Functions public
        public async Task Run(string[] args)
        {
            if (!await ConfigureServices()) return;

            await servicesRepopulateTestDBService.Run(args);
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> ConfigureServices()
        {
            serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<IConfiguration>(configuration);

            if (!await ConfigureIActionCommandDBService()) return await Task.FromResult(false);

            if (!await ConfigureCSSPDBContext(serviceCollection)) return await Task.FromResult(false);

            if (!await ConfigureTestDBContext(serviceCollection)) return await Task.FromResult(false);

            if (!await ConfigureIAllOtherServices()) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        private async Task<bool> ConfigureIActionCommandDBService()
        {
            try
            {
                serviceCollection.AddSingleton<IActionCommandDBService, ActionCommandDBService>();

                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                if (configuration.GetValue<string>(DBFileName) == null)
                {
                    Console.WriteLine($"{ String.Format(ServicesRepopulateTestDBServicesRes.CouldNotFindParameter_InAppSettingsJSON, DBFileName) }");
                    return await Task.FromResult(false);
                }

                FileInfo fiDB = new FileInfo(configuration.GetValue<string>(DBFileName).Replace("{AppDataPath}", appDataPath));

                if (!fiDB.Exists)
                {
                    Console.WriteLine($"{ String.Format(ServicesRepopulateTestDBServicesRes.CouldNotFindFile_, fiDB.FullName) }");
                    return await Task.FromResult(false);
                }

                serviceCollection.AddDbContext<ActionCommandContext>(options =>
                {
                    options.UseSqlite($"DataSource={fiDB.FullName}");
                });

                provider = serviceCollection.BuildServiceProvider();
                if (provider == null)
                {
                    Console.WriteLine($"{ AppDomain.CurrentDomain.FriendlyName } provider == null");
                    return await Task.FromResult(false);
                }

                actionCommandDBService = provider.GetService<IActionCommandDBService>();
                if (actionCommandDBService == null)
                {
                    Console.WriteLine($"{ AppDomain.CurrentDomain.FriendlyName } actionCommandDBService   == null");
                    return await Task.FromResult(false);
                }

                actionCommandDBService.Action = configuration.GetValue<string>("Action");
                actionCommandDBService.Command = configuration.GetValue<string>("Command");

                await actionCommandDBService.Create();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        private async Task<bool> ConfigureCSSPDBContext(IServiceCollection serviceCollection)
        {
            string CSSPDBConnString = configuration.GetValue<string>("CSSPDBConnectionString");
            if (CSSPDBConnString == null)
            {
                await actionCommandDBService.ConsoleWriteError($"{ String.Format(ServicesRepopulateTestDBServicesRes.CouldNotFindParameter_InAppSettingsJSON, "CSSPDBConnectionString") }");
                return await Task.FromResult(false);
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
                await actionCommandDBService.ConsoleWriteError(ex.Message);
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        private async Task<bool> ConfigureTestDBContext(IServiceCollection serviceCollection)
        {
            string TestDBConnString = configuration.GetValue<string>("TestDBConnectionString");
            if (TestDBConnString == null)
            {
                await actionCommandDBService.ConsoleWriteError($"{ String.Format(ServicesRepopulateTestDBServicesRes.CouldNotFindParameter_InAppSettingsJSON, "TestDBConnectionString") }");
                return await Task.FromResult(false);
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
                await actionCommandDBService.ConsoleWriteError(ex.Message);
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        private async Task<bool> ConfigureIAllOtherServices()
        {
            try
            {
                serviceCollection.AddSingleton<IGenerateCodeBaseService, GenerateCodeBaseService>();
                serviceCollection.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();
                serviceCollection.AddSingleton<IServicesRepopulateTestDBService, ServicesRepopulateTestDBService>();

                provider = serviceCollection.BuildServiceProvider();
                if (provider == null)
                {
                    await actionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } provider == null");
                    return await Task.FromResult(false);
                }

                servicesRepopulateTestDBService = provider.GetService<IServicesRepopulateTestDBService>();
                if (servicesRepopulateTestDBService == null)
                {
                    await actionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } angularEnumsGeneratedService  == null");
                    return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                await actionCommandDBService.ConsoleWriteError(ex.Message);
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}
