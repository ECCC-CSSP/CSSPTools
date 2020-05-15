using ExecuteDotNetCommandServices.Models;
using GenerateCodeBaseServices.Services;
using ActionCommandDBServices.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ExecuteDotNetCommandServices.Services
{
    public interface IExecuteDotNetCommandService
    {
        Task<bool> Run(string[] args);
        Task SetCulture(CultureInfo culture);
    }
}