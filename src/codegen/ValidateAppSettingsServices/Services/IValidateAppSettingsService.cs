using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using ValidateAppSettingsServices.Models;
using System.Globalization;

namespace ValidateAppSettingsServices.Services
{
    public interface IValidateAppSettingsService
    {
        List<AppSettingParameter> AppSettingParameterList { get; set; }
        Task<bool> VerifyAppSettings();
        void SetCulture(CultureInfo culture);

    }
}