using ActionCommandDBServices.Services;
using ConfigServices.Services;
using CultureServices.Services;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Models;
using ValidateAppSettingsServices.Services;

namespace ModelsCompareDBFieldsAndCSSPModelsDLLPropServices.Services
{
    public interface IModelsCompareDBFieldsAndCSSPModelsDLLPropService
    {
        Task<bool> Run(string[] args);
    }
    public partial class ModelsCompareDBFieldsAndCSSPModelsDLLPropService : ConfigService, IModelsCompareDBFieldsAndCSSPModelsDLLPropService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private string CSSPDBConnectionString;
        private List<TableFieldEnumException> TableFieldEnumExceptionList { get; set; }
        private List<TableFieldEmail> TableFieldEmailList { get; set; }
        private List<TableFieldIDException> TableFieldIDExceptionList { get; set; }
        #endregion Properties

        #region Constructors
        public ModelsCompareDBFieldsAndCSSPModelsDLLPropService(IConfiguration configuration,
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "ModelsCompareDBFieldsAndCSSPModelsDLLProp" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\cssp\\cssplocaldatabases\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\_package\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPDBConnectionString", ExpectedValue = "Server=.\\sqlexpress;Database=CSSPDB;Trusted_Connection=True;MultipleActiveResultSets=true" },
            };

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}