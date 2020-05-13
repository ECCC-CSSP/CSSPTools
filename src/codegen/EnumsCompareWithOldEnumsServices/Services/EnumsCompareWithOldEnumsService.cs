using EnumsCompareWithOldEnumsServices.Resources;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnumsCompareWithOldEnumsServices.Services
{
    public partial class EnumsCompareWithOldEnumsService : IEnumsCompareWithOldEnumsService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        #endregion Properties

        #region Constructors
        public EnumsCompareWithOldEnumsService(IConfiguration configuration,
            IActionCommandDBService actionCommandDBService,
            IValidateAppSettingsService validateAppSettingsService)
        {
            this.configuration = configuration;
            this.actionCommandDBService = actionCommandDBService;
            this.validateAppSettingsService = validateAppSettingsService;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            await SetCultureWithArgs(args);

            await actionCommandDBService.ConsoleWriteStart();

            if (!await Setup())
            {
                Console.WriteLine(actionCommandDBService.ErrorText.ToString());
                Console.WriteLine("");
                Console.WriteLine(actionCommandDBService.ExecutionStatusText.ToString());
                return false;
            }

            if (!await CompareDLLs())
            {
                Console.WriteLine(actionCommandDBService.ErrorText.ToString());
                Console.WriteLine("");
                Console.WriteLine(actionCommandDBService.ExecutionStatusText.ToString());
                return false;
            }

            await actionCommandDBService.ConsoleWriteEnd();

            return true;
        }
        public async Task SetCulture(CultureInfo culture)
        {
            EnumsCompareWithOldEnumsServicesRes.Culture = culture;
            await actionCommandDBService.SetCulture(culture);
            await validateAppSettingsService.SetCulture(culture);
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
            actionCommandDBService.Command = configuration.GetValue<string>("Command");
            await actionCommandDBService.SetCulture(new CultureInfo(configuration.GetValue<string>("Culture")));
            await validateAppSettingsService.SetCulture(new CultureInfo(configuration.GetValue<string>("Culture")));

            try
            {
                await actionCommandDBService.GetOrCreate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Action", ExpectedValue = "run" },
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "EnumsCompareWithOldEnums" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "NewEnumsDLL", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "OldEnumsDLL", ExpectedValue = "C:\\CSSP Latest Code Old\\CSSPEnumsDLL\\CSSPEnumsDLL\\bin\\Debug\\CSSPEnumsDLL.dll", IsFile = true, CheckExist = true },
            };

            await validateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(actionCommandDBService.ErrorText.ToString()))
            {
                await actionCommandDBService.ConsoleWriteError("");
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}
