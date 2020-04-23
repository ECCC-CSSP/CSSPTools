using GenerateCodeBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using GenerateCodeBase.Models;

namespace GenerateCodeBase.Services
{
    public interface IValidateAppSettingsService
    {
        List<AppSettingParameter> AppSettingParameterList { get; set; }
        Task CheckParameterExist();
        Task CheckParameterValue(string param, string shouldHaveValue);
        Task CheckCultureParameterValue(string param);
        Task CheckFileParameterValue(string param, string shouldHaveValue, bool CheckIfExist);
        Task VerifyAppSettings();
    }
}