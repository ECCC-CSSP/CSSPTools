﻿using ActionCommandDBServices.Services;
using BaseCodeGenerateServices.Services;
using CultureServices.Resources;
using GenerateCodeBaseServices.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Models;
using ValidateAppSettingsServices.Services;

namespace WebAPIClassNameControllerTestGeneratedServices.Services
{
    public partial class WebAPIClassNameControllerTestGeneratedService : BaseCodeGenerateService, IWebAPIClassNameControllerTestGeneratedService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public WebAPIClassNameControllerTestGeneratedService(IConfiguration configuration,
            IActionCommandDBService actionCommandDBService,
            IValidateAppSettingsService validateAppSettingsService,
            IGenerateCodeBaseService generateCodeBaseService) : base(configuration)
        {
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
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "WebAPIClassNameControllerTestGenerated" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\ActionCommandDB.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPEnums", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPEnums\\bin\\Debug\\netcoreapp3.1\\CSSPEnums.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModels", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\bin\\Debug\\netcoreapp3.1\\CSSPModels.dll", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "TypeNameFile", ExpectedValue = "C:\\CSSPCode\\CSSPWebAPI\\CSSPWebAPI.Tests\\Controllers\\Generated\\{TypeName}ControllerTestGenerated.cs" },
            };

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}