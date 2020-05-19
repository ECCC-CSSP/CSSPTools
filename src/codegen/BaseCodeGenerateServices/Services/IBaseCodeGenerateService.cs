using ActionCommandDBServices.Services;
using GenerateCodeBaseServices.Services;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;

namespace BaseCodeGenerateServices.Services
{
    public interface IBaseCodeGenerateService
    {
        IActionCommandDBService ActionCommandDBService { get; set; }
        IGenerateCodeBaseService GenerateCodeBaseService { get; set; }
        IValidateAppSettingsService ValidateAppSettingsService { get; set; }
        List<string> AllowableCultures { get; set; }

        Task<bool> CheckAppSettingsParameters();
        Task<bool> FillActionAndCommand();
        Task<bool> SetCulture(CultureInfo culture);
        Task<bool> SetCultureWithArgs(string[] args);
    }
}
