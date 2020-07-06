using ActionCommandDBServices.Services;
using ConfigServices.Services;
using CultureServices.Services;
using GenerateCodeBaseServices.Services;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Models;
using ValidateAppSettingsServices.Services;

namespace AngularComponentsGeneratedServices.Services
{
    public partial class AngularComponentsGeneratedService : ConfigService, IAngularComponentsGeneratedService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AngularComponentsGeneratedService(IConfiguration configuration,
            ICultureService cultureService,
            IActionCommandDBService actionCommandDBService,
            IValidateAppSettingsService validateAppSettingsService,
            IGenerateCodeBaseService generateCodeBaseService) : base(configuration)
        {
            CultureService = cultureService;
            ActionCommandDBService = actionCommandDBService;
            ValidateAppSettingsService = validateAppSettingsService;
            GenerateCodeBaseService = generateCodeBaseService;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            if (!await FillActionAndCommand()) return await Task.FromResult(false);

            await ActionCommandDBService.ConsoleWriteStart();

            if (!await FillAppSettingsParameters()) return await Task.FromResult(false);

            if (!await CheckAppSettingsParameters()) return await Task.FromResult(false);

            if (!await SetCultureWithArgs(args)) return await Task.FromResult(false);

            if (!await Generate())
            {
                await ActionCommandDBService.ConsoleWriteError("");
                return await Task.FromResult(false);
            }

            await ActionCommandDBService.ConsoleWriteEnd();

            return await Task.FromResult(true);
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> FillAppSettingsParameters()
        {
            ValidateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Action", ExpectedValue = "run" },
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "AngularComponentsGenerated" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\_package\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\_package\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "OutputDir", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\" },
                new AppSettingParameter() { Parameter = "RoutingModuleFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\{TypeNameLower}-routing.module.ts" },
                new AppSettingParameter() { Parameter = "ComponentCSSFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\{TypeNameLower}.component.css" },
                new AppSettingParameter() { Parameter = "ComponentEditCSSFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\{TypeNameLower}-edit.component.css" },
                new AppSettingParameter() { Parameter = "ComponentHTMLFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\{TypeNameLower}.component.html" },
                new AppSettingParameter() { Parameter = "ComponentEditHTMLFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\{TypeNameLower}-edit.component.html" },
                new AppSettingParameter() { Parameter = "ComponentSpecFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\{TypeNameLower}.component.spec.ts" },
                new AppSettingParameter() { Parameter = "ComponentFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\{TypeNameLower}.component.ts" },
                new AppSettingParameter() { Parameter = "ComponentEditFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\{TypeNameLower}-edit.component.ts" },
                new AppSettingParameter() { Parameter = "LocalesFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\{TypeNameLower}.locales.ts" },
                new AppSettingParameter() { Parameter = "ModelsFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\{TypeNameLower}.models.ts" },
                new AppSettingParameter() { Parameter = "ModuleFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\{TypeNameLower}.module.ts" },
                new AppSettingParameter() { Parameter = "ServiceSpecFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\{TypeNameLower}.service.spec.ts" },
                new AppSettingParameter() { Parameter = "ServiceFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\{TypeNameLower}.service.ts" },
                new AppSettingParameter() { Parameter = "IndexFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\generated\\{TypeNameLower}\\index.ts" },
                new AppSettingParameter() { Parameter = "HomeRoutingModuleFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\home\\home-routing.module.ts" },
                new AppSettingParameter() { Parameter = "HomeComponentHTMLFileName", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\test-components\\home\\home.component.html" },
            };

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}