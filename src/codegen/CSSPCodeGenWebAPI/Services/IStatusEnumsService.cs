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
    public interface IStatusEnumsService
    {
        Task StatusEnums(string command, CultureInfo culture, IConfiguration configuration, IStatusAndResultsService statusAndResultsService);
    }
}
