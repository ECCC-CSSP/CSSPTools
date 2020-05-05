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
        void VerifyAppSettings();
        void SetCulture(CultureInfo culture);

    }
}