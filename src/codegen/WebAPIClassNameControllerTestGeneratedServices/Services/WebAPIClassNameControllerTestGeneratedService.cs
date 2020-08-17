using ActionCommandDBServices.Services;
using ConfigServices.Services;
using CSSPCultureServices.Services;
using GenerateCodeBaseServices.Services;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Models;
using ValidateAppSettingsServices.Services;

namespace WebAPIClassNameControllerTestGeneratedServices.Services
{
    public interface IWebAPIClassNameControllerTestGeneratedService
    {
        Task<bool> Run(string[] args);
    }
    public partial class WebAPIClassNameControllerTestGeneratedService : ConfigService, IWebAPIClassNameControllerTestGeneratedService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public WebAPIClassNameControllerTestGeneratedService(IConfiguration Configuration,
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "WebAPIClassNameControllerTestGenerated" },
                new AppSettingParameter() { Parameter = "CSSPCulture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "C:\\CSSPTools\\src\\assets\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\_package\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\_package\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "TypeNameFile", ExpectedValue = "C:\\CSSPTools\\src\\webs\\tests\\CSSPWebAPIs.Tests\\Controllers\\Generated\\{TypeName}ControllerTestGenerated.cs" },
            };

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}