using CSSPEnums;
using GenerateCodeBase.Models;
using GenerateCodeBase.Resources;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GenerateCodeStatusDB.Services;
using System.Globalization;

namespace GenerateCodeBase.Services
{
    public partial class ValidateAppSettingsService : IValidateAppSettingsService
    {
        #region Variables
        private readonly IConfiguration _configuration;
        private readonly IGenerateCodeStatusDBService _generateCodeStatusDBService;
        #endregion Variables

        #region Properties
        public List<AppSettingParameter> AppSettingParameterList { get; set; }
        public CultureInfo Culture { get; set; }
        #endregion Properties

        #region Constructors
        public ValidateAppSettingsService(IConfiguration configuration, IGenerateCodeStatusDBService generateCodeStatusDBService)
        {
            _configuration = configuration;
            _generateCodeStatusDBService = generateCodeStatusDBService;
            AppSettingParameterList = new List<AppSettingParameter>();
        }
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        public async Task VerifyAppSettings()
        {
            _generateCodeStatusDBService.Status.AppendLine($"{ AppRes.VerifyAppSettingsFile }");
            _generateCodeStatusDBService.Status.AppendLine("");

            await CheckParameterExist();

            _generateCodeStatusDBService.Status.AppendLine("");

            foreach (AppSettingParameter appSettingParameter in AppSettingParameterList)
            {
                if (appSettingParameter.IsFile)
                {
                    await CheckFileParameterValue(appSettingParameter.Parameter, appSettingParameter.ExpectedValue, appSettingParameter.CheckExist);
                }
                else if (appSettingParameter.IsCulture)
                {
                    await CheckCultureParameterValue(appSettingParameter.Parameter);
                }
                else
                {
                    await CheckParameterValue(appSettingParameter.Parameter, appSettingParameter.ExpectedValue);
                }
            }

            _generateCodeStatusDBService.Status.AppendLine("");

            return;
        }
        public async Task SetCulture(CultureInfo culture)
        {
            Culture = culture;
            AppRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        private async Task CheckParameterExist()
        {
            foreach (AppSettingParameter appSettingParameter in AppSettingParameterList)
            {
                string retConf = _configuration.GetValue<string>(appSettingParameter.Parameter);

                if (string.IsNullOrWhiteSpace(retConf))
                {
                    _generateCodeStatusDBService.Error.AppendLine($"{ AppRes.Error }\t{ appSettingParameter.Parameter } != { AppRes.CouldNotFindParameter }");
                    return;
                }

                _generateCodeStatusDBService.Status.AppendLine($"{ AppRes.OK }\t{ appSettingParameter.Parameter } == { AppRes.Exist}");
            }
        }
        private async Task CheckParameterValue(string param, string shouldHaveValue)
        {
            string retValue = _configuration.GetValue<string>(param);
            if (retValue != shouldHaveValue)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ AppRes.Error }\t{ param } != { shouldHaveValue }");
                return;
            }

            _generateCodeStatusDBService.Status.AppendLine($"{ AppRes.OK }\t{ param } == { shouldHaveValue }");
        }
        private async Task CheckCultureParameterValue(string param)
        {
            string retValue = _configuration.GetValue<string>(param);
            if (!(retValue == "en-CA" || retValue == "fr-CA"))
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ AppRes.Error }\t{ param } != en-CA || fr-CA");
                return;
            }

            _generateCodeStatusDBService.Status.AppendLine($"{ AppRes.OK }\t{ param } == en-CA || fr-CA");
        }
        private async Task CheckFileParameterValue(string param, string shouldHaveValue, bool CheckIfExist)
        {
            string retValue = _configuration.GetValue<string>(param);

            if (retValue != shouldHaveValue)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ AppRes.Error }\t{ param } != { shouldHaveValue }");
                return;
            }

            _generateCodeStatusDBService.Status.AppendLine($"{ AppRes.OK }\t{ param } == { shouldHaveValue }");


            if (CheckIfExist)
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                FileInfo fiDB = new FileInfo(retValue.Replace("{AppDataPath}", appDataPath));

                if (!fiDB.Exists)
                {
                    _generateCodeStatusDBService.Error.AppendLine($"{ AppRes.Error }\t{ AppRes.DoesNotExist }\t{ fiDB.FullName }");
                    return;
                }

                _generateCodeStatusDBService.Status.AppendLine($"{ AppRes.OK }\t{ AppRes.Exist }\t{ fiDB.FullName }");
            }
        }
        #endregion Functions private

    }
}
