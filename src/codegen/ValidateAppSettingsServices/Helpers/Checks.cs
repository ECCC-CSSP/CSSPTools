﻿using ValidateAppSettingsServices.Models;
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
using CultureServices.Resources;

namespace ValidateAppSettingsServices.Services
{
    public partial class ValidateAppSettingsService : IValidateAppSettingsService
    {
        private async Task<bool> CheckParameterExist()
        {
            bool retBool = true;

            foreach (AppSettingParameter appSettingParameter in AppSettingParameterList)
            {
                string retConf = configuration.GetValue<string>(appSettingParameter.Parameter);

                if (string.IsNullOrWhiteSpace(retConf))
                {
                    retBool = false;
                    actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Error }\t{ appSettingParameter.Parameter }\t{ CultureServicesRes.CouldNotFindParameter }");
                }
            }

            return await Task.FromResult(retBool);
        }
        private async Task<bool> CheckParameterValue(string param, string shouldHaveValue)
        {
            bool retBool = true;

            string retValue = configuration.GetValue<string>(param);
            if (retValue != shouldHaveValue)
            {
                retBool = false;
                actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Error }\t{ param } != { shouldHaveValue }");
            }

            return await Task.FromResult(retBool);
        }
        private async Task<bool> CheckCultureParameterValue(string param)
        {
            bool retBool = true;

            string retValue = configuration.GetValue<string>(param);
            if (!(retValue == "en-CA" || retValue == "fr-CA"))
            {
                retBool = false;
                actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Error }\t{ param } != en-CA || fr-CA");
            }

            return await Task.FromResult(retBool);
        }
        private async Task<bool> CheckFileParameterValue(string param, string shouldHaveValue, bool CheckIfExist)
        {
            bool retBool = true;
            string retValue = configuration.GetValue<string>(param);

            if (retValue != shouldHaveValue)
            {
                retBool = false;
                actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Error }\t{ param } != { shouldHaveValue }");
            }


            if (CheckIfExist)
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                FileInfo fiDB = new FileInfo(retValue.Replace("{AppDataPath}", appDataPath));

                if (!fiDB.Exists)
                {
                    retBool = false;
                    actionCommandDBService.ErrorText.AppendLine($"{ CultureServicesRes.Error }\t{ CultureServicesRes.DoesNotExist }\t{ fiDB.FullName }");
                }
            }

            return await Task.FromResult(retBool);
        }
    }
}
