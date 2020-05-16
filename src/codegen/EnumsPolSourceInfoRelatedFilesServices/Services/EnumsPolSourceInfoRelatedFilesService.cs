using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.Extensions.Configuration;
using PolSourceGroupingExcelFileReadServices.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;
using Microsoft.AspNetCore.Mvc;
using ValidateAppSettingsServices.Models;
using CultureServices.Resources;

namespace EnumsPolSourceInfoRelatedFilesServices.Services
{
    public partial class EnumsPolSourceInfoRelatedFilesService : IEnumsPolSourceInfoRelatedFilesService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IActionCommandDBService actionCommandDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private IPolSourceGroupingExcelFileReadService polSourceGroupingExcelFileReadService { get; set; }
        private IGenerateCodeBaseService generateCodeBaseService { get; set; }
        private List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        #endregion Properties

        #region Constructors
        public EnumsPolSourceInfoRelatedFilesService(IConfiguration configuration,
            IActionCommandDBService actionCommandDBService,
            IValidateAppSettingsService validateAppSettingsService,
            IGenerateCodeBaseService generateCodeBaseService,
            IPolSourceGroupingExcelFileReadService polSourceGroupingExcelFileReadService)
        {
            this.configuration = configuration;
            this.actionCommandDBService = actionCommandDBService;
            this.validateAppSettingsService = validateAppSettingsService;
            this.generateCodeBaseService = generateCodeBaseService;
            this.polSourceGroupingExcelFileReadService = polSourceGroupingExcelFileReadService;
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
            await polSourceGroupingExcelFileReadService.SetCulture(culture);
            CultureServicesRes.Culture = culture;
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "EnumsPolSourceInfoRelatedFiles" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "ExcelFileName", ExpectedValue = "C:\\CSSPTools\\src\\assets\\PolSourceGrouping.xlsm", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "FillPolSourceObsInfoChildServiceGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPServices\\Generated\\FillPolSourceObsInfoChildServiceGenerated.cs" },
                new AppSettingParameter() { Parameter = "EnumsPolSourceInfoGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Generated\\EnumsPolSourceInfoGenerated.cs" },
                new AppSettingParameter() { Parameter = "PolSourceObsInfoEnumGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Generated\\PolSourceObsInfoEnumGenerated.cs" },
                new AppSettingParameter() { Parameter = "EnumsPolSourceObsInfoEnumTestGenerated_cs", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPEnums.Tests\\tests\\Generated\\EnumsPolSourceObsInfoEnumTestGenerated.cs" },
                new AppSettingParameter() { Parameter = "PolSourceInfoEnumGeneratedRes_resx", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Resources\\Generated\\PolSourceInfoEnumGeneratedRes.resx" },
                new AppSettingParameter() { Parameter = "PolSourceInfoEnumGeneratedResFR_resx", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\Resources\\Generated\\PolSourceInfoEnumGeneratedRes.fr.resx" },
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