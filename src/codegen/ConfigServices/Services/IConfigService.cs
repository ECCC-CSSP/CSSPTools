using ActionCommandDBServices.Services;
using CultureServices.Services;
using GenerateCodeBaseServices.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;

namespace ConfigServices.Services
{
    public interface IConfigService
    {
        IConfiguration Config { get; set; }
        IServiceProvider Provider { get; set; }
        IServiceCollection Services { get; set; }
        ICultureService CultureService { get; set; }
        IActionCommandDBService ActionCommandDBService { get; set; }
        IGenerateCodeBaseService GenerateCodeBaseService { get; set; }
        IValidateAppSettingsService ValidateAppSettingsService { get; set; }
        List<string> AllowableCultures { get; set; }
        string DBFileName { get; set; }


        Task<bool> BuildServiceProvider();
        Task<bool> CheckAppSettingsParameters();
        Task<bool> ConfigureBaseServices();
        Task<bool> ConfigureCSSPDBContext();
        Task<bool> ConfigureTestDBContext();
        Task<bool> FillActionAndCommand();
        Task<bool> SetCultureWithArgs(string[] args);
    }
}
