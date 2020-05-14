using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.Extensions.Configuration;
using ModelsCSSPModelsResServices.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace ModelsCSSPModelsResServices.Services
{
    public partial class ModelsCSSPModelsResService : IModelsCSSPModelsResService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private IGenerateCodeBaseService generateCodeBaseService { get; set; }
        private List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        #endregion Properties

        #region Constructors
        public ModelsCSSPModelsResService(IConfiguration configuration,
            IActionCommandDBService actionCommandDBService,
            IValidateAppSettingsService validateAppSettingsService,
            IGenerateCodeBaseService generateCodeBaseService)
        {
            this.configuration = configuration;
            this.actionCommandDBService = actionCommandDBService;
            this.validateAppSettingsService = validateAppSettingsService;
            this.generateCodeBaseService = generateCodeBaseService;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            await actionCommandDBService.ConsoleWriteStart();

            if (!await Setup())
            {
                await actionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            await SetCultureWithArgs(args);

            if (!await Generate())
            {
                await actionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            await actionCommandDBService.ConsoleWriteEnd();

            return await Task.FromResult(true);
        }
        public async Task SetCulture(CultureInfo culture)
        {
            await actionCommandDBService.SetCulture(culture);
            await validateAppSettingsService.SetCulture(culture);
            await generateCodeBaseService.SetCulture(culture);
            ModelsCSSPModelsResServicesRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        private async Task SetCultureWithArgs(string[] args)
        {
            string culture = AllowableCultures[0];

            if (args.Count() > 0)
            {
                if (AllowableCultures.Contains(args[0]))
                {
                    culture = args[0];
                }
            }

            await SetCulture(new CultureInfo(culture));
        }
        private async Task<bool> Setup()
        {
            actionCommandDBService.Action = configuration.GetValue<string>("Action");
            actionCommandDBService.Command = configuration.GetValue<string>("Command");
            await actionCommandDBService.SetCulture(new CultureInfo(configuration.GetValue<string>("Culture")));
            await validateAppSettingsService.SetCulture(new CultureInfo(configuration.GetValue<string>("Culture")));

            try
            {
                await actionCommandDBService.Delete();
                actionCommandDBService.Action = configuration.GetValue<string>("Action");
                actionCommandDBService.Command = configuration.GetValue<string>("Command");
                await actionCommandDBService.GetOrCreate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return await Task.FromResult(false);
            }

            validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Action", ExpectedValue = "run" },
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "ModelsCSSPModelsRes" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModelsRes", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\Resources\\CSSPModelsRes.resx" },
                new AppSettingParameter() { Parameter = "CSSPModelsResFR", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\Resources\\CSSPModelsRes.fr.resx" },
            };

            await validateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(actionCommandDBService.ErrorText.ToString()))
            {
                await actionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}