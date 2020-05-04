using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EnumsCompareWithOldEnumsServices.Services
{
    public interface IEnumsCompareWithOldEnumsService
    {
        //IServiceCollection serviceCollection { get; set; }
        IConfiguration configuration { get; set; }
        IGenerateCodeStatusDBService generateCodeStatusDBService { get; set; }
        IValidateAppSettingsService validateAppSettingsService { get; set; }

        List<string> Args0Allowables { get; set; }
        string DBFileName { get; set; }
        //IServiceProvider provider { get; set; }
        FileInfo fiDB { get; set; }



        Task<bool> Run(string[] args);
        Task<bool> Setup();
        Task<bool> CompareDLLs();

        Task ConsoleWriteEnd();
        Task ConsoleWriteError(string errMessage);
        Task ConsoleWriteStart();
        Task<bool> DoValidateAppSettings();
        Task<bool> FillGenerateCodeStatusDB();
        Task<bool> SettingProvider();
        Task<bool> SetupConfigure();
        Task<bool> SetupGenerateCodeStatusDBService();
        Task<bool> SetupValidateAppSettingsService();
    }
}