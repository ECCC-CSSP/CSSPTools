using CSSPCodeGenWebAPI.Models;
using Microsoft.Extensions.Configuration;
using StatusAndResultsDBService.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSPCodeGenWebAPI.Services
{
    public interface IGenerateModelsService
    {
        Task GenerateModels(string command, CultureInfo culture, IConfiguration configuration, IStatusAndResultsService statusAndResultsService);
    }
}
