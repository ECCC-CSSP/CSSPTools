using CSSPEnums;
using CSSPGenerateCodeBase.Models;
using CSSPGenerateCodeBase.Resources;
using Microsoft.Extensions.Configuration;
using StatusAndResultsDBService.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSSPGenerateCodeBase.Services
{
    public partial class ValidateAppSettingsService : IValidateAppSettingsService
    {
        #region Variables
        private readonly IConfigurationRoot _configuration;
        private readonly IStatusAndResultsService _statusAndResultsService;
        #endregion Variables

        #region Properties
        public List<AppSettingParameter> AppSettingParameterList { get; set; }
        #endregion Properties

        #region Constructors
        public ValidateAppSettingsService(IConfigurationRoot configuration, IStatusAndResultsService statusAndResultsService)
        {
            _configuration = configuration;
            _statusAndResultsService = statusAndResultsService;
            AppSettingParameterList = new List<AppSettingParameter>();
        }
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        public async Task CheckParameterExist()
        {
            foreach (AppSettingParameter appSettingParameter in AppSettingParameterList)
            {
                string retConf = _configuration.GetValue<string>(appSettingParameter.Parameter);

                if (!string.IsNullOrWhiteSpace(retConf))
                {
                    _statusAndResultsService.Status.AppendLine($"{ AppRes.OK }\t{ appSettingParameter.Parameter } == { AppRes.Exist}");
                }
                else
                {
                    _statusAndResultsService.Error.AppendLine($"{ AppRes.Error }\t{ appSettingParameter.Parameter } != { AppRes.CouldNotFindParameter }");
                }
            }
        }
        public async Task CheckParameterValue(string param, string shouldHaveValue)
        {
            string retValue = _configuration.GetValue<string>(param);
            if (retValue != shouldHaveValue)
            {
                _statusAndResultsService.Error.AppendLine($"{ AppRes.Error }\t{ param } != { shouldHaveValue }");
            }
            else
            {
                _statusAndResultsService.Status.AppendLine($"{ AppRes.OK }\t{ param } == { shouldHaveValue }");
            }
        }
        public async Task CheckCultureParameterValue(string param)
        {
            string retValue = _configuration.GetValue<string>(param);
            if (!(retValue == "en-CA" || retValue == "fr-CA"))
            {
                _statusAndResultsService.Error.AppendLine($"{ AppRes.Error }\t{ param } != en-CA || fr-CA");
            }
            else
            {
                _statusAndResultsService.Status.AppendLine($"{ AppRes.OK }\t{ param } == en-CA || fr-CA");
            }
        }
        public async Task CheckFileParameterValue(string param, string shouldHaveValue, bool CheckIfExist)
        {
            string retValue = _configuration.GetValue<string>(param);

            if (retValue != shouldHaveValue)
            {
                _statusAndResultsService.Error.AppendLine($"{ AppRes.Error }\t{ param } != { shouldHaveValue }");
            }
            else
            {
                _statusAndResultsService.Status.AppendLine($"{ AppRes.OK }\t{ param } == { shouldHaveValue }");
            }

            if (CheckIfExist)
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                FileInfo fiDB = new FileInfo(retValue.Replace("{AppDataPath}", appDataPath));

                if (!fiDB.Exists)
                {
                    _statusAndResultsService.Error.AppendLine($"{ AppRes.Error }\t{ AppRes.DoesNotExist }\t{ fiDB.FullName }");
                }
                else
                {
                    _statusAndResultsService.Status.AppendLine($"{ AppRes.OK }\t{ AppRes.Exist }\t{ fiDB.FullName }");
                }
            }
        }
        public async Task VerifyAppSettings()
        {
            _statusAndResultsService.Status.AppendLine($"{ AppRes.VerifyAppSettingsFile }");
            _statusAndResultsService.Status.AppendLine("");

            await CheckParameterExist();

            _statusAndResultsService.Status.AppendLine("");

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

            _statusAndResultsService.Status.AppendLine("");

            return;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
