using ActionCommandDBServices.Services;
using ConfigServices.Services;
using CSSPCultureServices.Services;
using GenerateCodeBaseServices.Services;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Models;
using ValidateAppSettingsServices.Services;

namespace ModelsModelClassNameTestServices.Services
{
    public interface IModelsModelClassNameTestService
    {
        Task<bool> Run(string[] args);
    }
    public partial class ModelsModelClassNameTestService : ConfigService, IModelsModelClassNameTestService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public ModelsModelClassNameTestService(IConfiguration Configuration,
            ICSSPCultureService CSSPCultureService,
            IActionCommandDBService ActionCommandDBService,
            IValidateAppSettingsService ValidateAppSettingsService,
            IGenerateCodeBaseService GenerateCodeBaseService) : base(Configuration)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.ActionCommandDBService = ActionCommandDBService;
            this.ValidateAppSettingsService = ValidateAppSettingsService;
            this.GenerateCodeBaseService = GenerateCodeBaseService;
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "ModelsModelClassNameTest" },
                new AppSettingParameter() { Parameter = "CSSPCulture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "C:\\CSSPDesktop\\cssplocaldatabases\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\_package\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "TypeNameTest", ExpectedValue = "C:\\CSSPTools\\src\\tests\\CSSPModels.Tests\\tests\\{TypeName}Test.cs" },
            };

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}