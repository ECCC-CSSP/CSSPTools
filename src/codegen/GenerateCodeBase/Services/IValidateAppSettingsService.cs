using GenerateCodeBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using GenerateCodeBase.Models;
using System.Globalization;

namespace GenerateCodeBase.Services
{
    public interface IValidateAppSettingsService
    {
        public CultureInfo Culture { get; set; }
        List<AppSettingParameter> AppSettingParameterList { get; set; }
        //Task CheckParameterExist();
        //Task CheckParameterValue(string param, string shouldHaveValue);
        //Task CheckCultureParameterValue(string param);
        //Task CheckFileParameterValue(string param, string shouldHaveValue, bool CheckIfExist);
        Task VerifyAppSettings();
        Task SetCulture(CultureInfo culture);

    }
}