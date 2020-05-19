using ActionCommandDBServices.Services;
using CultureServices.Resources;
using GenerateCodeBaseServices.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;

namespace BaseCodeGenerateServices.Services
{
    public class BaseCodeGenerateService : IBaseCodeGenerateService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public IConfiguration Config { get; set; }
        public IActionCommandDBService ActionCommandDBService { get; set; }
        public IGenerateCodeBaseService GenerateCodeBaseService { get; set; }
        public IValidateAppSettingsService ValidateAppSettingsService { get; set; }
        public List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        private string ActionParameterText = "Action";
        private string CommandParameterText = "Command";
        #endregion Properties

        #region Constructors
        public BaseCodeGenerateService(IConfiguration configuration)
        {
            Config = configuration;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CheckAppSettingsParameters()
        {
            if (!await ValidateAppSettingsService.VerifyAppSettings())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        public async Task<bool> FillActionAndCommand()
        {
            try
            {
                ActionCommandDBService.Action = Config.GetValue<string>(ActionParameterText);
                if (ActionCommandDBService.Action == null)
                {
                    throw new Exception($"{ string.Format(CultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, ActionParameterText) }");
                }

                ActionCommandDBService.Command = Config.GetValue<string>(CommandParameterText);
                if (ActionCommandDBService.Command == null)
                {
                    throw new Exception($"{ string.Format(CultureServicesRes.CouldNotFindParameter_InAppSettingsJSON, CommandParameterText) }");
                }

                await ActionCommandDBService.SetCulture(new CultureInfo(Config.GetValue<string>("Culture")));
                await ValidateAppSettingsService.SetCulture(new CultureInfo(Config.GetValue<string>("Culture")));

                await ActionCommandDBService.Delete();
                ActionCommandDBService.Action = Config.GetValue<string>(ActionParameterText);
                ActionCommandDBService.Command = Config.GetValue<string>(CommandParameterText);
                var actionResult = await ActionCommandDBService.GetOrCreate();
                if (actionResult.Value == null)
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        public async Task<bool> SetCulture(CultureInfo culture)
        {
            await ActionCommandDBService.SetCulture(culture);
            await ValidateAppSettingsService.SetCulture(culture);
            await GenerateCodeBaseService.SetCulture(culture);
            CultureServicesRes.Culture = culture;

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

            if (!await SetCulture(new CultureInfo(culture))) return await Task.FromResult(false);

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
