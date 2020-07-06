using ActionCommandDBServices.Services;
using GenerateCodeBaseServices.Services;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Models;
using ValidateAppSettingsServices.Services;
using CultureServices;
using CultureServices.Services;
using CSSPEnums;
using ConfigServices.Services;

namespace AngularEnumsGeneratedServices.Services
{
    public partial class AngularEnumsGeneratedService : ConfigService, IAngularEnumsGeneratedService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IEnums Enums { get; set; }
        #endregion Properties

        #region Constructors
        public AngularEnumsGeneratedService(IConfiguration configuration,
            ICultureService cultureService,
            IActionCommandDBService actionCommandDBService,
            IValidateAppSettingsService validateAppSettingsService,
            IGenerateCodeBaseService generateCodeBaseService,
            IEnums enums) : base(configuration)
        {
            CultureService = cultureService;
            ActionCommandDBService = actionCommandDBService;
            ValidateAppSettingsService = validateAppSettingsService;
            GenerateCodeBaseService = generateCodeBaseService;
            Enums = enums;
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "AngularEnumsGenerated" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\_package\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "OutputDir", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\enums\\generated\\" },
                new AppSettingParameter() { Parameter = "EnumNameFile", ExpectedValue = "C:\\CSSPTools\\src\\webs\\CSSPWebToolsAng\\client-apps\\src\\app\\enums\\generated\\{EnumName}.ts" },
            };

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}