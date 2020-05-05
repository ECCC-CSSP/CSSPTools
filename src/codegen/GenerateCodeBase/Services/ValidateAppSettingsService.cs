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
        public void VerifyAppSettings()
        {
            CheckParameterExist();

            foreach (AppSettingParameter appSettingParameter in AppSettingParameterList)
            {
                if (appSettingParameter.IsFile)
                {
                    CheckFileParameterValue(appSettingParameter.Parameter, appSettingParameter.ExpectedValue, appSettingParameter.CheckExist);
                }
                else if (appSettingParameter.IsCulture)
                {
                    CheckCultureParameterValue(appSettingParameter.Parameter);
                }
                else
                {
                    CheckParameterValue(appSettingParameter.Parameter, appSettingParameter.ExpectedValue);
                }
            }

            return;
        }
        public void SetCulture(CultureInfo culture)
        {
            Culture = culture;
            AppRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        private void CheckParameterExist()
        {
            foreach (AppSettingParameter appSettingParameter in AppSettingParameterList)
            {
                string retConf = _configuration.GetValue<string>(appSettingParameter.Parameter);

                if (string.IsNullOrWhiteSpace(retConf))
                {
                    _generateCodeStatusDBService.Error.AppendLine($"{ AppRes.Error }\t{ appSettingParameter.Parameter } != { AppRes.CouldNotFindParameter }");
                    return;
                }
            }
        }
        private void CheckParameterValue(string param, string shouldHaveValue)
        {
            string retValue = _configuration.GetValue<string>(param);
            if (retValue != shouldHaveValue)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ AppRes.Error }\t{ param } != { shouldHaveValue }");
                return;
            }
        }
        private void CheckCultureParameterValue(string param)
        {
            string retValue = _configuration.GetValue<string>(param);
            if (!(retValue == "en-CA" || retValue == "fr-CA"))
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ AppRes.Error }\t{ param } != en-CA || fr-CA");
                return;
            }
        }
        private void CheckFileParameterValue(string param, string shouldHaveValue, bool CheckIfExist)
        {
            string retValue = _configuration.GetValue<string>(param);

            if (retValue != shouldHaveValue)
            {
                _generateCodeStatusDBService.Error.AppendLine($"{ AppRes.Error }\t{ param } != { shouldHaveValue }");
                return;
            }


            if (CheckIfExist)
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                FileInfo fiDB = new FileInfo(retValue.Replace("{AppDataPath}", appDataPath));

                if (!fiDB.Exists)
                {
                    _generateCodeStatusDBService.Error.AppendLine($"{ AppRes.Error }\t{ AppRes.DoesNotExist }\t{ fiDB.FullName }");
                    return;
                }
            }
        }
        #endregion Functions private

    }
}
