using Microsoft.Extensions.Configuration;
using StatusAndResultsDBService.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace EnumsCompareWithOldEnums.Services
{
    public interface IEnumsCompareWithOldEnumsService
    {
        Task Start();
    }
}