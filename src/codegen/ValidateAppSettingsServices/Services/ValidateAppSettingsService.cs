using CSSPEnums;
using ValidateAppSettingsServices.Models;
using ValidateAppSettingsServices.Resources;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using ActionCommandDBServices.Services;

namespace ValidateAppSettingsServices.Services
{
    public partial class ValidateAppSettingsService : IValidateAppSettingsService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; }
        public List<AppSettingParameter> AppSettingParameterList { get; set; }
        private IActionCommandDBService actionCommandDBService { get; }
        #endregion Properties

        #region Constructors
        public ValidateAppSettingsService(IConfiguration configuration, IActionCommandDBService actionCommandDBService)
        {
            this.configuration = configuration;
            this.actionCommandDBService = actionCommandDBService;
            AppSettingParameterList = new List<AppSettingParameter>();
        }
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        public async Task<bool> VerifyAppSettings()
        {
            bool retBool = true;

            if (!await CheckParameterExist())
            {
                retBool = false;
            }

            foreach (AppSettingParameter appSettingParameter in AppSettingParameterList)
            {
                if (appSettingParameter.IsFile)
                {
                    if (!await CheckFileParameterValue(appSettingParameter.Parameter, appSettingParameter.ExpectedValue, appSettingParameter.CheckExist))
                    {
                        retBool = false;
                    }
                }
                else if (appSettingParameter.IsCulture)
                {
                    if (!await CheckCultureParameterValue(appSettingParameter.Parameter))
                    {
                        retBool = false;
                    }
                }
                else
                {
                    if (!await CheckParameterValue(appSettingParameter.Parameter, appSettingParameter.ExpectedValue))
                    {
                        retBool = false;
                    }
                }
            }
            return retBool;
        }
        public void SetCulture(CultureInfo culture)
        {
            actionCommandDBService.SetCulture(culture);
            AppRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> CheckParameterExist()
        {
            bool retBool = true;

            foreach (AppSettingParameter appSettingParameter in AppSettingParameterList)
            {
                string retConf = configuration.GetValue<string>(appSettingParameter.Parameter);

                if (string.IsNullOrWhiteSpace(retConf))
                {
                    retBool = false;
                    actionCommandDBService.ErrorText.AppendLine($"{ AppRes.Error }\t{ appSettingParameter.Parameter } != { AppRes.CouldNotFindParameter }");
                }
            }

            return retBool;
        }
        private async Task<bool> CheckParameterValue(string param, string shouldHaveValue)
        {
            bool retBool = true;

            string retValue = configuration.GetValue<string>(param);
            if (retValue != shouldHaveValue)
            {
                retBool = false;
                actionCommandDBService.ErrorText.AppendLine($"{ AppRes.Error }\t{ param } != { shouldHaveValue }");
            }

            return retBool;
        }
        private async Task<bool> CheckCultureParameterValue(string param)
        {
            bool retBool = true;

            string retValue = configuration.GetValue<string>(param);
            if (!(retValue == "en-CA" || retValue == "fr-CA"))
            {
                retBool = false;
                actionCommandDBService.ErrorText.AppendLine($"{ AppRes.Error }\t{ param } != en-CA || fr-CA");
            }

            return retBool;
        }
        private async Task<bool> CheckFileParameterValue(string param, string shouldHaveValue, bool CheckIfExist)
        {
            bool retBool = true;
            string retValue = configuration.GetValue<string>(param);

            if (retValue != shouldHaveValue)
            {
                retBool = false;
                actionCommandDBService.ErrorText.AppendLine($"{ AppRes.Error }\t{ param } != { shouldHaveValue }");
            }


            if (CheckIfExist)
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                FileInfo fiDB = new FileInfo(retValue.Replace("{AppDataPath}", appDataPath));

                if (!fiDB.Exists)
                {
                    retBool = false;
                    actionCommandDBService.ErrorText.AppendLine($"{ AppRes.Error }\t{ AppRes.DoesNotExist }\t{ fiDB.FullName }");
                }
            }

            return retBool;
        }
        #endregion Functions private

    }
}
