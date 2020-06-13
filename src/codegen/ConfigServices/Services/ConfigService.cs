using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using CSSPEnums;
using CSSPModels;
using CultureServices.Resources;
using CultureServices.Services;
using GenerateCodeBaseServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;

namespace ConfigServices.Services
{
    public enum ExitCode
    {
        Success = 0,
        Error = 1,
    }
    public class ConfigService : IConfigService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public IConfiguration Config { get; set; }
        public IServiceProvider Provider { get; set; }
        public IServiceCollection Services { get; set; }
        public ICultureService CultureService { get; set; }
        public IActionCommandDBService ActionCommandDBService { get; set; }
        public IGenerateCodeBaseService GenerateCodeBaseService { get; set; }
        public IValidateAppSettingsService ValidateAppSettingsService { get; set; }
        public List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        public string DBFileName { get; set; } = "DBFileName";
        private string ActionText = "Action";
        private string CommandText = "Command";
        private string CSSPDBConnectionString = "CSSPDBConnectionString";
        private string TestDBConnectionString = "TestDBConnectionString";
        #endregion Properties

        #region Constructors
        public ConfigService()
        {
            
        }
        public ConfigService(IConfiguration configuration)
        {
            Config = configuration;
        }
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions protected
        public async Task<bool> BuildServiceProvider()
        {
            Provider = Services.BuildServiceProvider();
            if (Provider == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ AppDomain.CurrentDomain.FriendlyName } provider == null");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        public async Task<bool> CheckAppSettingsParameters()
        {
            if (!await ValidateAppSettingsService.VerifyAppSettings())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        public async Task<bool> ConfigureBaseServices()
        {
            try
            {
                Services = new ServiceCollection();

                Services.AddSingleton<IConfiguration>(Config);
                Services.AddSingleton<ICultureService, CultureService>();
                Services.AddSingleton<IActionCommandDBService, ActionCommandDBService>();
                Services.AddSingleton<IGenerateCodeBaseService, GenerateCodeBaseService>();
                Services.AddSingleton<IValidateAppSettingsService, ValidateAppSettingsService>();

                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                if (Config.GetValue<string>(DBFileName) == null)
                {
                    throw new Exception($"{ String.Format(CultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, DBFileName) }");
                }

                FileInfo fiDB = new FileInfo(Config.GetValue<string>(DBFileName).Replace("{AppDataPath}", appDataPath));

                if (!fiDB.Exists)
                {
                    throw new Exception($"{ String.Format(CultureServicesRes.CouldNotFindFile_, fiDB.FullName) }");
                }

                Services.AddDbContext<ActionCommandContext>(options =>
                {
                    options.UseSqlite($"DataSource={fiDB.FullName}");
                });

                Provider = Services.BuildServiceProvider();
                if (Provider == null)
                {
                    throw new Exception($"{ AppDomain.CurrentDomain.FriendlyName } provider == null");
                }

                CultureService = Provider.GetService<ICultureService>();
                if (CultureService == null)
                {
                    throw new Exception($"{ AppDomain.CurrentDomain.FriendlyName } CultureService == null");
                }

                CultureService.SetCulture(Config.GetValue<string>("Culture"));

                ActionCommandDBService = Provider.GetService<IActionCommandDBService>();
                if (ActionCommandDBService == null)
                {
                    throw new Exception($"{ AppDomain.CurrentDomain.FriendlyName } ActionCommandDBService == null");
                }

                ActionCommandDBService.Action = Config.GetValue<string>(ActionText);
                if (ActionCommandDBService.Action == null)
                {
                    throw new Exception($"{ string.Format(CultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, ActionText) }");
                }

                ActionCommandDBService.Command = Config.GetValue<string>(CommandText);
                if (ActionCommandDBService.Command == null)
                {
                    throw new Exception($"{ string.Format(CultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, CommandText) }");
                }

                ActionResult<ActionCommand> actionActionCommand = await ActionCommandDBService.Get();
                if (((ObjectResult)actionActionCommand.Result).StatusCode == 400)
                {
                    throw new Exception($"{ string.Format(CultureServicesRes.CouldNotGetAction_Command_InDB_, ActionText, CommandText, fiDB.FullName) }");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        public async Task<bool> ConfigureCSSPDBContext()
        {
            string CSSPDBConnString = Config.GetValue<string>(CSSPDBConnectionString);
            if (CSSPDBConnString == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ String.Format(CultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, CSSPDBConnectionString) }");
                return await Task.FromResult(false);
            }

            try
            {
                Services.AddDbContext<CSSPDBContext>(options =>
                {
                    options.UseSqlServer(CSSPDBConnString);
                });
            }
            catch (Exception ex)
            {
                await ActionCommandDBService.ConsoleWriteError(ex.Message);
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        public async Task<bool> ConfigureTestDBContext()
        {
            string TestDBConnString = Config.GetValue<string>(TestDBConnectionString);
            if (TestDBConnString == null)
            {
                await ActionCommandDBService.ConsoleWriteError($"{ String.Format(CultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, TestDBConnectionString) }");
                return await Task.FromResult(false);
            }

            try
            {
                Services.AddDbContext<TestDBContext>(options =>
                {
                    options.UseSqlServer(TestDBConnString);
                });
            }
            catch (Exception ex)
            {
                await ActionCommandDBService.ConsoleWriteError(ex.Message);
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        public async Task<bool> FillActionAndCommand()
        {
            try
            {
                ActionCommandDBService.Action = Config.GetValue<string>(ActionText);
                if (ActionCommandDBService.Action == null)
                {
                    throw new Exception($"{ string.Format(CultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, ActionText) }");
                }

                ActionCommandDBService.Command = Config.GetValue<string>(CommandText);
                if (ActionCommandDBService.Command == null)
                {
                    throw new Exception($"{ string.Format(CultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, CommandText) }");
                }

                CultureService.SetCulture(Config.GetValue<string>("Culture"));

                var actionResult = await ActionCommandDBService.Get();
                if (((ObjectResult)actionResult.Result).StatusCode == 400)
                {
                    return await Task.FromResult(false);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        public async Task<bool> SetCultureWithArgs(string[] args)
        {
            string culture = AllowableCultures[0];

            if (args.Count() > 0)
            {
                if (AllowableCultures.Contains(args[0]))
                {
                    culture = args[0];
                }
            }

            CultureService.SetCulture(culture);

            return await Task.FromResult(true);
        }
        #endregion Functions protected

    }
}
