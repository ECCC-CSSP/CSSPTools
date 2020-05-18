using CSSPEnums;
using CSSPModels;
using GenerateCodeBaseServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidateAppSettingsServices.Services;
using ValidateAppSettingsServices.Models;
using Microsoft.AspNetCore.Mvc;
using CultureServices.Resources;
using ConfigServices.Services;

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
